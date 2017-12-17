/*
    Copyright (C) 2017  github.com/cxgrillo/UpdateMagicNTAG

    This file is part of UpdateMagicNTAG.

    UpdateMagicNTAG is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    UpdateMagicNTAG is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with UpdateMagicNTAG   If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace UpdateMagicNTAG
{

    public partial class UpdateMagicNTAG : Form
    {

        private byte[] bCardUIDBytes = new byte[7];

        private string[] sVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');

        private const string csNoCardFound = "No Card found";
        private const string csOK = "OK";
        private const string csNotAMagicNTAG = "Not a Magic NTAG card!";
        private const string csSuccess = "Success";
        private const string csFail = "Fail";
        private const string csFailed = "Failed!";
        private const string cs0Response = "CGrillo:";

        private SerialPort spSerialPort;

        public UpdateMagicNTAG()
        {
            InitializeComponent();

            if (sVersion.Length >= 1)
            {
                this.Text += String.Format(" - v{0}", sVersion[0]);
            }
            if (sVersion.Length >= 2 && sVersion[1] != "0")
            {
                this.Text += String.Format(".{0}", sVersion[1]);
            }

            Size sz = new Size(this.Width, this.Height);
            this.MaximumSize = sz;
            this.MinimumSize = sz;

            buttonConnect.Enabled = true;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonInitialiseCard.Visible = false;
            buttonGetCard.Visible = true;

            labelConnect.Text = "Searching...";
            this.Invalidate();
            this.Refresh();
            ClearLabels();
            DisableButtons();
            labelGetCard.Text = "";

            if (buttonConnect.Text == "Disconnect")
            {
                spSerialPort.Close();
                spSerialPort.Dispose();
                buttonConnect.Text = "Connect";
                labelConnect.Text = "disconnected";
                buttonGetCard.Enabled = false;
            }
            else
            {
                string sSerialPort = GetSerialPortNo();

                if (sSerialPort.Length > 0)
                {
                    spSerialPort = new SerialPort(sSerialPort);

                    SetUpAndOpenSerialPort(spSerialPort);

                    string str = WriteToArduinoAndRead("0");

                    if (str.Contains(cs0Response))
                    {
                        labelConnect.Text = str.Replace(cs0Response, "Arduino : ");
                        buttonConnect.Text = "Disconnect";
                        buttonGetCard.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong with Serial Port opening");
                    }
                }
                else
                {
                    labelConnect.Text = "No Arduino found!";
                }
            }
            
        }

        private void SetUpAndOpenSerialPort(SerialPort spSerialPort)
        {
            spSerialPort.NewLine = "\r\n";
            spSerialPort.ReadTimeout = 5000;
            spSerialPort.BaudRate = 9600;
            spSerialPort.Open();
        }

        private string WriteToArduinoAndRead(string sToSend)
        {
            if (sToSend == "") sToSend = "0";
            string sRet = "";
            spSerialPort.WriteLine(sToSend);
            try
            {
                sRet = spSerialPort.ReadLine().Trim();
            }
            catch (Exception)
            {
                return "Err";
            }

            if (sRet.StartsWith("ERROR"))
            {
                string sErrNo = sRet.Substring(6);

                if (sErrNo == "99")
                    return csNoCardFound;
                else
                    return sRet;
            }
            else
            {
                return sRet;
            }
        }

        private string GetSerialPortNo()
        {
            string[] portNames = SerialPort.GetPortNames();

            // try ports 3 times..
            for (int iLoop = 0; iLoop <= 2; iLoop++)
            {
                foreach (string portName in portNames)
                {
                    try
                    {
                        using (SerialPort serialPort = new SerialPort(portName))
                        {
                            SetUpAndOpenSerialPort(serialPort);

                            serialPort.WriteLine("0");
                            string str = serialPort.ReadLine().Trim();

                            if (str.Contains(cs0Response))
                            {
                                return portName;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                Thread.Sleep(1000);
            }

            return "";
        }

        private void buttonGetCard_Click(object sender, EventArgs e)
        {
            ClearData();
            ClearLabels();
            DisableButtons();

            labelGetCard.Text = "";

            string sUID = GetUID(" ");

            if (sUID.Trim().Length == 0)
            {
                labelGetCard.Text = csNoCardFound;
                ClearData();
                return;
            }

            textBoxUIDToWrite.Text = sUID;

            if (!IsThisAMagicNTAGCard())
            {
                labelGetCard.Text = csNotAMagicNTAG;
                return;
            }

            GetAndSetLength();
            GetAndSetTemp();
            GetPage9Data();
            GetPage20Data();

            EnableButtons();
            labelGetCard.Text = "Details read ok.";

        }

        private void ClearData()
        {
            labelPasswordPack.Text = textBoxUIDToWrite.Text = textBoxPage9Byte0.Text = textBoxPage9Byte1.Text = textBoxPage9Byte2.Text = textBoxPage9Byte3.Text = "";
            this.Refresh();
        }

        private void ClearLabels()
        {
            labelLengthRemaining.Text = labelOutput.Text = labelWriteUID.Text = "";
            labelOutput.ForeColor = Color.Red;
            this.Refresh();
        }

        private bool WriteUID()
        {
            // We may have spaces and/or tab chars!..
            // Count the no of valid chars first

            StringBuilder sbNewCardUID = new StringBuilder();
            int iLen = textBoxUIDToWrite.TextLength;

            for (int iChar = 0; iChar < iLen; iChar++)
            {
                if (ValidHexChar(textBoxUIDToWrite.Text.Substring(iChar, 1)))
                    sbNewCardUID.Append(textBoxUIDToWrite.Text.Substring(iChar, 1).ToUpper());
            }
            
            if (sbNewCardUID.Length != 14)
            {
                labelWriteUID.Text = "Invalid Length";
                labelWriteUID.ForeColor = Color.Red;
                return false;
            }

            MessageBox.Show("Remove and replace card");
            WriteToArduinoAndRead("9");

            // Page 0
            //byte bUID0 = byte.Parse(sbNewCardUID.ToString().Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            //byte bUID1 = byte.Parse(sbNewCardUID.ToString().Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            //byte bUID2 = byte.Parse(sbNewCardUID.ToString().Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            //byte bUID3 = 0; // Checksum required?

            //StringBuilder sbPage0 = new StringBuilder();
            //sbPage0.AppendFormat("3,0,{0},{1},{2},{3}", bUID0, bUID1, bUID2, bUID3);

            //// Page 1
            //byte bUID4 = byte.Parse(sbNewCardUID.ToString().Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            //byte bUID5 = byte.Parse(sbNewCardUID.ToString().Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //byte bUID6 = byte.Parse(sbNewCardUID.ToString().Substring(10, 2), System.Globalization.NumberStyles.HexNumber);
            //byte bUID7 = byte.Parse(sbNewCardUID.ToString().Substring(12, 2), System.Globalization.NumberStyles.HexNumber);

            //StringBuilder sbPage1 = new StringBuilder();
            //sbPage1.AppendFormat("3,1,{0},{1},{2},{3}", bUID4, bUID5, bUID6, bUID7);


            //bCardUIDBytes[0] = bUID0;
            //bCardUIDBytes[1] = bUID1;
            //bCardUIDBytes[2] = bUID2;
            //bCardUIDBytes[3] = bUID4;
            //bCardUIDBytes[4] = bUID5;
            //bCardUIDBytes[5] = bUID6;
            //bCardUIDBytes[6] = bUID7;

            StringBuilder sbPage0 = new StringBuilder();
            sbPage0.AppendFormat("3,0,{0},{1},{2},{3}", bCardUIDBytes[0], bCardUIDBytes[1], bCardUIDBytes[2], 0);

            StringBuilder sbPage1 = new StringBuilder();
            sbPage1.AppendFormat("3,1,{0},{1},{2},{3}", bCardUIDBytes[3], bCardUIDBytes[4], bCardUIDBytes[5], bCardUIDBytes[6]);

            // Page 2 checksum required?
            StringBuilder sbPage2 = new StringBuilder();
            int iUID8 = 0; // Checksum required?
            sbPage2.AppendFormat("3,2,{0},72,00,00", iUID8);

            string sRetPage0 = WriteToArduinoAndRead(sbPage0.ToString());
            string sRetPage1 = WriteToArduinoAndRead(sbPage1.ToString());
            string sRetPage2 = WriteToArduinoAndRead(sbPage2.ToString());

            //MessageBox.Show("Remove and replace card");

            WriteToArduinoAndRead("9");

            if (sRetPage0 == "OK" && sRetPage1 == "OK")
            {
                //labelWriteUID.Text = csSuccess;
                //labelWriteUID.ForeColor = Color.Green;
            }
            else
            {
                labelWriteUID.Text = csFailed;
                labelWriteUID.ForeColor = Color.Red;
            }

            return true;
        }

        private void GetCardUIDBytes()
        {
            StringBuilder sbNewCardUID = new StringBuilder();
            int iLen = textBoxUIDToWrite.TextLength;

            for (int iChar = 0; iChar < iLen; iChar++)
            {
                if (ValidHexChar(textBoxUIDToWrite.Text.Substring(iChar, 1)))
                    sbNewCardUID.Append(textBoxUIDToWrite.Text.Substring(iChar, 1).ToUpper());
            }


            // Page 0
            byte bUID0 = byte.Parse(sbNewCardUID.ToString().Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte bUID1 = byte.Parse(sbNewCardUID.ToString().Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte bUID2 = byte.Parse(sbNewCardUID.ToString().Substring(4, 2), System.Globalization.NumberStyles.HexNumber);


            // Page 1
            byte bUID4 = byte.Parse(sbNewCardUID.ToString().Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            byte bUID5 = byte.Parse(sbNewCardUID.ToString().Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            byte bUID6 = byte.Parse(sbNewCardUID.ToString().Substring(10, 2), System.Globalization.NumberStyles.HexNumber);
            byte bUID7 = byte.Parse(sbNewCardUID.ToString().Substring(12, 2), System.Globalization.NumberStyles.HexNumber);


            bCardUIDBytes[0] = bUID0;
            bCardUIDBytes[1] = bUID1;
            bCardUIDBytes[2] = bUID2;
            bCardUIDBytes[3] = bUID4;
            bCardUIDBytes[4] = bUID5;
            bCardUIDBytes[5] = bUID6;
            bCardUIDBytes[6] = bUID7;

        }

        private bool WritePassword()
        {
            // We may have spaces and/or tab chars!..
            // Count the no of valid chars first

            byte[] bPasswordBytes = NfcHack.NfcKey.GetKey(bCardUIDBytes);

            String bPackBytes = string.Format("3,240,{0},{1},{2},{3}", bPasswordBytes[0], bPasswordBytes[1], bPasswordBytes[2], bPasswordBytes[3]);
            string sRetPassword = WriteToArduinoAndRead(bPackBytes.ToString());


            labelPasswordPack.Text = String.Format("{0:X} {1:X} {2:X} {3:X}", bPasswordBytes[0], bPasswordBytes[1], bPasswordBytes[2], bPasswordBytes[3]);

            return (sRetPassword == "OK");
        }

        private bool WritePACK()
        {

            // We may have spaces and/or tab chars!..
            // Count the no of valid chars first

            byte[] bPackBytes = NfcHack.NfcKey.GetPack(bCardUIDBytes);

            string sPACK = String.Format("3,241,{0},{1},0,0", bPackBytes[0], bPackBytes[1]);

            string sRetPACK = WriteToArduinoAndRead(sPACK.ToString());

            labelPasswordPack.Text += String.Format(" - {0:X} {1:X}", bPackBytes[0], bPackBytes[1]);

            return (sRetPACK == "OK");
        }

        private bool ValidHexChar(string sPassed)
        {
            if (sPassed.Length != 1)
                return false;
            else
            {
                byte[] toBytes = Encoding.ASCII.GetBytes(sPassed.ToUpper());

                if (toBytes[0] >= 65 && toBytes[0] <= 70)
                    return true;
                else if (toBytes[0] >= 48 && toBytes[0] <= 57)
                    return true;
                else
                    return false;

            }
        }

        private void EnableButtons()
        {
            buttonSetData.Enabled = true;
        }

        private void DisableButtons()
        {
            buttonSetData.Enabled = false;
        }

        private string GetUID(string sDelimiter)
        {
            string sReturned = WriteToArduinoAndRead("1");
            string sRet = "";

            // NTAG213 ?
            if (sReturned.EndsWith(",OK"))
            {
                string sUID = String.Format("{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}",
                    sReturned.Substring(0, 2), sReturned.Substring(2, 2), sReturned.Substring(4, 2), sReturned.Substring(6, 2),
                    sReturned.Substring(8, 2), sReturned.Substring(10, 2), sReturned.Substring(12, 2), sDelimiter);
                sRet = sUID;
            }
            return sRet;
        }

        private int GetLength()
        {
            string sReturned = WriteToArduinoAndRead("2,10");
            if (sReturned == "40,0D,03,00")
                return 200;
            else
                return 300;
        }

        private void GetAndSetLength()
        {
            if (GetLength() == 200)
                radioButton200m.Checked = true;
            else
                radioButton300m.Checked = true;
        }

        private int GetTemp()
        {
            string sReturned = WriteToArduinoAndRead("2,8");
            if (sReturned.EndsWith(",32,00")
             || sReturned.EndsWith(",45,00")
             || sReturned.EndsWith(",4C,00")
             || sReturned.EndsWith(",4F,00")
             || sReturned.EndsWith(",5A,00"))
                return 190;
            else if(sReturned.EndsWith(",4B,00"))
                return 200;
            else
                return 210;
        }

        private void GetAndSetTemp()
        {
            int iTemp = GetTemp();

            if (iTemp == 190)
                radioButton190deg.Checked = true;
            else if (iTemp == 200)
                radioButton200deg.Checked = true;
            else
                radioButton210deg.Checked = true;
        }

        private void GetPage9Data()
        {
            try
            {
                string sReturned = WriteToArduinoAndRead("2,9");
                if (sReturned.Length == 11)
                {
                    textBoxPage9Byte0.Text = sReturned.Substring(0, 2);

                    if (sReturned.Substring(3, 2).Equals("00"))
                        textBoxPage9Byte1.Text = "35";
                    else
                        textBoxPage9Byte1.Text = sReturned.Substring(3, 2);

                    if (sReturned.Substring(6, 2).Equals("00"))
                        textBoxPage9Byte2.Text = "36";
                    else
                        textBoxPage9Byte2.Text = sReturned.Substring(6, 2);

                    if (sReturned.Substring(9, 2).Equals("00"))
                        textBoxPage9Byte3.Text = "37";
                    else
                        textBoxPage9Byte3.Text = sReturned.Substring(9, 2);
                }
                else
                {
                    textBoxPage9Byte0.Text = "E";
                    textBoxPage9Byte1.Text = "rr";
                    textBoxPage9Byte2.Text = "or";
                    textBoxPage9Byte3.Text = "";
                }
            }
            catch (Exception)
            {
                textBoxPage9Byte0.Text = "E";
                textBoxPage9Byte1.Text = "rr";
                textBoxPage9Byte2.Text = "or";
                textBoxPage9Byte3.Text = ".";
            }
        }

        private void GetPage20Data()
        {
            try
            {
                string sReturned = WriteToArduinoAndRead("2,20");
                if (sReturned.Length == 11)
                {
                    string sHexLength = string.Format("{0}{1}{2}{3}", sReturned.Substring(9, 2), sReturned.Substring(6, 2), sReturned.Substring(3, 2), sReturned.Substring(0, 2));
                    long lLengthRemaining = long.Parse(sHexLength, System.Globalization.NumberStyles.HexNumber);
                    labelLengthRemaining.Text = String.Format("{0:#,##0.0} m", lLengthRemaining / 1000);
                }
                else
                {
                    labelLengthRemaining.Text = "Error";
                }
            }
            catch (Exception)
            {
                labelLengthRemaining.Text = "Error.";
            }
        }

        private bool IsThisAMagicNTAGCard()
        {
            bool bRet = IsPage240Readable();
            labelOutput.Text = (bRet ? "" : csNotAMagicNTAG);

            buttonInitialiseCard.Visible = !bRet;
            buttonGetCard.Visible = bRet;

            return bRet;
        }

        private void buttonSetData_Click(object sender, EventArgs e)
        {
            ClearLabels();
            bool bSuccess = IsThisAMagicNTAGCard();
            //bSuccess = bSuccess && InitialiseAsNTAG213(false);
            bSuccess = bSuccess && WriteAllData();
        }

        private bool WriteAllData()
        {

            bool bFail = false;
            bool bSuccess;

            // ensure Page 9 data is hex..
            bool bFailHexCheck = false;
            int iPage9Byte0 = 0;
            int iPage9Byte1 = 0;
            int iPage9Byte2 = 0;
            int iPage9Byte3 = 0;

            try
            {
                iPage9Byte0 = int.Parse(textBoxPage9Byte0.Text, System.Globalization.NumberStyles.HexNumber);
                iPage9Byte1 = int.Parse(textBoxPage9Byte1.Text, System.Globalization.NumberStyles.HexNumber);
                iPage9Byte2 = int.Parse(textBoxPage9Byte2.Text, System.Globalization.NumberStyles.HexNumber);
                iPage9Byte3 = int.Parse(textBoxPage9Byte3.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                bFailHexCheck = true;
            }

            if (bFailHexCheck)
            {
                labelOutput.Text = "Invalid Page 9 data.";
                bFail = true;
            }

            if (bFail) return false;

            // Checks passed - write the data
            labelPasswordPack.Text = "";

            GetCardUIDBytes();
            bSuccess = WritePassword();
            bSuccess = bSuccess && WritePACK();
            bSuccess = bSuccess && WriteUID();


            if (!bSuccess) return false;

            MessageBox.Show("Remove and replace card");
            WriteToArduinoAndRead("9");

            // Page 9 stuff

            string sPage9 = WriteToArduinoAndRead(String.Format("3,9,{0},{1},{2},{3}", iPage9Byte0, iPage9Byte1, iPage9Byte2, iPage9Byte3));

            if (radioButton200m.Checked)
            {
                string sPage1 = WriteToArduinoAndRead("3,10,64,13,3,0");
                string sPage2 = WriteToArduinoAndRead("3,11,64,13,3,0");
                string sPage3 = WriteToArduinoAndRead("3,20,64,13,3,0");

                string sPage4 = WriteToArduinoAndRead("3,21,8,31,49,84");
                string sPage5 = WriteToArduinoAndRead("3,22,80,177,224,206");
                string sPage6 = WriteToArduinoAndRead("3,23,82,231,79,118");

                bSuccess = bSuccess && sPage1.Equals(csOK) && sPage2.Equals(csOK) && sPage3.Equals(csOK) && sPage4.Equals(csOK) && sPage5.Equals(csOK) && sPage6.Equals(csOK);
            }
            else //  (radioButton300m.Checked)
            {
                string sPage1 = WriteToArduinoAndRead("3,10,224,147,4,0");
                string sPage2 = WriteToArduinoAndRead("3,11,224,147,4,0");
                string sPage3 = WriteToArduinoAndRead("3,20,224,147,4,0");

                string sPage4 = WriteToArduinoAndRead("3,21,220,249,49,84");
                string sPage5 = WriteToArduinoAndRead("3,22,12,151,239,206");
                string sPage6 = WriteToArduinoAndRead("3,23,166,198,78,118");

                bSuccess = bSuccess && sPage1.Equals(csOK) && sPage2.Equals(csOK) && sPage3.Equals(csOK) && sPage4.Equals(csOK) && sPage5.Equals(csOK) && sPage6.Equals(csOK);
            }


            // Temp / Colour
            string sPage7;

            if (radioButton190deg.Checked)
            {
                sPage7 = WriteToArduinoAndRead("3,8,90,80,79,0");
            }
            else if (radioButton200deg.Checked)
            {
                sPage7 = WriteToArduinoAndRead("3,8,90,80,75,0"); // Black 200 deg (new)
            }
            else // (210 deg)
            {
                sPage7 = WriteToArduinoAndRead("3,8,90,80,80,0");
            }

            bSuccess = bSuccess && sPage7.Equals(csOK);

            // Configuration pages
            string sPage41 = WriteToArduinoAndRead("3,41,7,0,0,255"); // last byte = 255 opens up all pages to be read
            string sPage42 = WriteToArduinoAndRead("3,42,128,5,0,0");   // Should first byte be 128?
            bSuccess = bSuccess && sPage41.Equals(csOK) && sPage42.Equals(csOK);

            // Misc pages
            string sPage12 = WriteToArduinoAndRead("3,12,210,0,45,0");
            string sPage13 = WriteToArduinoAndRead("3,13,84,72,71,66");
            string sPage14 = WriteToArduinoAndRead("3,14,48,51,53,53");
            string sPage17 = WriteToArduinoAndRead("3,17,52,0,0,0");

            bSuccess = bSuccess && sPage12.Equals(csOK) && sPage13.Equals(csOK) && sPage14.Equals(csOK) && sPage17.Equals(csOK);

            labelOutput.Text = (bSuccess ? "Data Set" : "Data not set");
            labelOutput.ForeColor = Color.Green;

            MessageBox.Show("Remove and replace card to verify data written");
            WriteToArduinoAndRead("9");

            string sUID = GetUID(" ");

            labelWriteUID.Text = (sUID == textBoxUIDToWrite.Text.Replace('\t', ' ') ? csSuccess : csFail);
            labelWriteUID.ForeColor = (sUID == textBoxUIDToWrite.Text.Replace('\t', ' ') ? Color.Green : Color.Red);

            return bSuccess;
        }

        public bool IsPage240Readable()
        {
            // Read Page F0
            string sReturned = WriteToArduinoAndRead("2,240");
            return !sReturned.ToUpper().StartsWith("ERROR");
        }
        
        private bool InitialiseAsNTAG213(bool bFullReset)
        {
            bool bSuccess = true;
            string sTemp;

            MessageBox.Show("Remove and replace card");

            sTemp = WriteToArduinoAndRead("9");
            sTemp = WriteToArduinoAndRead("0");

            bSuccess = bSuccess && WriteToArduinoAndRead("3,250,00,04,04,02").Equals(csOK); // Page FA

            MessageBox.Show("Remove and replace card");

            sTemp = WriteToArduinoAndRead("9");
            sTemp = WriteToArduinoAndRead("0");
            sTemp = WriteToArduinoAndRead("1");
            bSuccess = bSuccess && WriteToArduinoAndRead("3,251,01,00,15,03").Equals(csOK); // Page FB

            MessageBox.Show("Remove and replace card");
            sTemp = WriteToArduinoAndRead("9");
            sTemp = WriteToArduinoAndRead("0");
            sTemp = WriteToArduinoAndRead("1");
            bSuccess = bSuccess && WriteToArduinoAndRead("3,252,00,00,00,00").Equals(csOK); // Page FC

            MessageBox.Show("Remove and replace card");

            sTemp = WriteToArduinoAndRead("9");
            sTemp = WriteToArduinoAndRead("0");
            sTemp = WriteToArduinoAndRead("1");

            // Init commands from C.Herrman's lua script
            // Basic NTAG values
            bSuccess = bSuccess && WriteToArduinoAndRead("3,3,225,16,18,00").Equals(csOK);
            bSuccess = bSuccess && WriteToArduinoAndRead("3,4,01,03,240,12").Equals(csOK);
            bSuccess = bSuccess && WriteToArduinoAndRead("3,5,52,03,00,254").Equals(csOK);
            bSuccess = bSuccess && WriteToArduinoAndRead("3,41,07,00,00,255").Equals(csOK);
            bSuccess = bSuccess && WriteToArduinoAndRead("3,42,00,05,00,00").Equals(csOK); // Should first byte be 128?

            if (bFullReset)
            {
                MessageBox.Show("Remove and replace card");

                sTemp = WriteToArduinoAndRead("0");
                sTemp = WriteToArduinoAndRead("1");

                // Default Card uid, password and pack
                bSuccess = bSuccess && WriteToArduinoAndRead("3,0,04,76,193,1").Equals(csOK);
                bSuccess = bSuccess && WriteToArduinoAndRead("3,1,34,154,61,128").Equals(csOK);
                bSuccess = bSuccess && WriteToArduinoAndRead("3,2,05,72,0,0").Equals(csOK);

                bSuccess = bSuccess && WriteToArduinoAndRead("03,240,150,91,93,142").Equals(csOK); // Page F0 = Password
                bSuccess = bSuccess && WriteToArduinoAndRead("03,241,143,104,0,0").Equals(csOK); // Page F1 = Pack

                MessageBox.Show("Remove and replace card");
            }
            
            return bSuccess;
        }

        private void buttonInitialiseCard_Click(object sender, EventArgs e)
        {
            InitialiseAsNTAG213(true);
            buttonGetCard_Click(null, null);
        }
    }

}
