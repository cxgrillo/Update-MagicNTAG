namespace UpdateMagicNTAG
{
    partial class UpdateMagicNTAG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelConnect = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelPasswordPack = new System.Windows.Forms.Label();
            this.labelLengthRemaining = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonGetCard = new System.Windows.Forms.Button();
            this.labelOutput = new System.Windows.Forms.Label();
            this.textBoxPage9Byte3 = new System.Windows.Forms.TextBox();
            this.textBoxUIDToWrite = new System.Windows.Forms.TextBox();
            this.textBoxPage9Byte2 = new System.Windows.Forms.TextBox();
            this.textBoxPage9Byte1 = new System.Windows.Forms.TextBox();
            this.textBoxPage9Byte0 = new System.Windows.Forms.TextBox();
            this.labelWriteUID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGetCard = new System.Windows.Forms.Label();
            this.groupBoxLength = new System.Windows.Forms.GroupBox();
            this.radioButton300m = new System.Windows.Forms.RadioButton();
            this.radioButton200m = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSetData = new System.Windows.Forms.Button();
            this.groupBoxTemp = new System.Windows.Forms.GroupBox();
            this.radioButton200deg = new System.Windows.Forms.RadioButton();
            this.radioButton210deg = new System.Windows.Forms.RadioButton();
            this.radioButton190deg = new System.Windows.Forms.RadioButton();
            this.buttonInitialiseCard = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.checkBoxLogIt = new System.Windows.Forms.CheckBox();
            this.tabPage1.SuspendLayout();
            this.groupBoxLength.SuspendLayout();
            this.groupBoxTemp.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(27, 21);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(89, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelConnect
            // 
            this.labelConnect.AutoSize = true;
            this.labelConnect.Location = new System.Drawing.Point(134, 26);
            this.labelConnect.Name = "labelConnect";
            this.labelConnect.Size = new System.Drawing.Size(0, 13);
            this.labelConnect.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.checkBoxLogIt);
            this.tabPage1.Controls.Add(this.labelPasswordPack);
            this.tabPage1.Controls.Add(this.labelLengthRemaining);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.buttonGetCard);
            this.tabPage1.Controls.Add(this.labelOutput);
            this.tabPage1.Controls.Add(this.textBoxPage9Byte3);
            this.tabPage1.Controls.Add(this.textBoxUIDToWrite);
            this.tabPage1.Controls.Add(this.textBoxPage9Byte2);
            this.tabPage1.Controls.Add(this.textBoxPage9Byte1);
            this.tabPage1.Controls.Add(this.textBoxPage9Byte0);
            this.tabPage1.Controls.Add(this.labelWriteUID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.labelGetCard);
            this.tabPage1.Controls.Add(this.groupBoxLength);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.buttonSetData);
            this.tabPage1.Controls.Add(this.groupBoxTemp);
            this.tabPage1.Controls.Add(this.buttonInitialiseCard);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(297, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Refill";
            // 
            // labelPasswordPack
            // 
            this.labelPasswordPack.AutoSize = true;
            this.labelPasswordPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordPack.Location = new System.Drawing.Point(9, 77);
            this.labelPasswordPack.Name = "labelPasswordPack";
            this.labelPasswordPack.Size = new System.Drawing.Size(0, 13);
            this.labelPasswordPack.TabIndex = 29;
            // 
            // labelLengthRemaining
            // 
            this.labelLengthRemaining.AutoSize = true;
            this.labelLengthRemaining.Location = new System.Drawing.Point(118, 107);
            this.labelLengthRemaining.Name = "labelLengthRemaining";
            this.labelLengthRemaining.Size = new System.Drawing.Size(0, 13);
            this.labelLengthRemaining.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Remaining Length :";
            // 
            // buttonGetCard
            // 
            this.buttonGetCard.Enabled = false;
            this.buttonGetCard.Location = new System.Drawing.Point(6, 6);
            this.buttonGetCard.Name = "buttonGetCard";
            this.buttonGetCard.Size = new System.Drawing.Size(89, 23);
            this.buttonGetCard.TabIndex = 2;
            this.buttonGetCard.Text = "Get Card";
            this.buttonGetCard.UseVisualStyleBackColor = true;
            this.buttonGetCard.Click += new System.EventHandler(this.buttonGetCard_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.ForeColor = System.Drawing.Color.Red;
            this.labelOutput.Location = new System.Drawing.Point(95, 282);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(0, 13);
            this.labelOutput.TabIndex = 25;
            this.labelOutput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxPage9Byte3
            // 
            this.textBoxPage9Byte3.Location = new System.Drawing.Point(233, 249);
            this.textBoxPage9Byte3.MaxLength = 2;
            this.textBoxPage9Byte3.Name = "textBoxPage9Byte3";
            this.textBoxPage9Byte3.Size = new System.Drawing.Size(32, 20);
            this.textBoxPage9Byte3.TabIndex = 18;
            this.textBoxPage9Byte3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxUIDToWrite
            // 
            this.textBoxUIDToWrite.Location = new System.Drawing.Point(78, 42);
            this.textBoxUIDToWrite.MaxLength = 20;
            this.textBoxUIDToWrite.Name = "textBoxUIDToWrite";
            this.textBoxUIDToWrite.Size = new System.Drawing.Size(140, 20);
            this.textBoxUIDToWrite.TabIndex = 3;
            // 
            // textBoxPage9Byte2
            // 
            this.textBoxPage9Byte2.Location = new System.Drawing.Point(192, 249);
            this.textBoxPage9Byte2.MaxLength = 2;
            this.textBoxPage9Byte2.Name = "textBoxPage9Byte2";
            this.textBoxPage9Byte2.Size = new System.Drawing.Size(32, 20);
            this.textBoxPage9Byte2.TabIndex = 17;
            this.textBoxPage9Byte2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPage9Byte1
            // 
            this.textBoxPage9Byte1.Location = new System.Drawing.Point(151, 249);
            this.textBoxPage9Byte1.MaxLength = 2;
            this.textBoxPage9Byte1.Name = "textBoxPage9Byte1";
            this.textBoxPage9Byte1.Size = new System.Drawing.Size(32, 20);
            this.textBoxPage9Byte1.TabIndex = 16;
            this.textBoxPage9Byte1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPage9Byte0
            // 
            this.textBoxPage9Byte0.Location = new System.Drawing.Point(110, 249);
            this.textBoxPage9Byte0.MaxLength = 2;
            this.textBoxPage9Byte0.Name = "textBoxPage9Byte0";
            this.textBoxPage9Byte0.Size = new System.Drawing.Size(32, 20);
            this.textBoxPage9Byte0.TabIndex = 15;
            this.textBoxPage9Byte0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelWriteUID
            // 
            this.labelWriteUID.AutoSize = true;
            this.labelWriteUID.Location = new System.Drawing.Point(225, 46);
            this.labelWriteUID.Name = "labelWriteUID";
            this.labelWriteUID.Size = new System.Drawing.Size(0, 13);
            this.labelWriteUID.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Page9 Data:";
            // 
            // labelGetCard
            // 
            this.labelGetCard.AutoSize = true;
            this.labelGetCard.Location = new System.Drawing.Point(113, 11);
            this.labelGetCard.Name = "labelGetCard";
            this.labelGetCard.Size = new System.Drawing.Size(0, 13);
            this.labelGetCard.TabIndex = 18;
            // 
            // groupBoxLength
            // 
            this.groupBoxLength.Controls.Add(this.radioButton300m);
            this.groupBoxLength.Controls.Add(this.radioButton200m);
            this.groupBoxLength.Location = new System.Drawing.Point(12, 137);
            this.groupBoxLength.Name = "groupBoxLength";
            this.groupBoxLength.Size = new System.Drawing.Size(260, 43);
            this.groupBoxLength.TabIndex = 9;
            this.groupBoxLength.TabStop = false;
            this.groupBoxLength.Text = "Length";
            // 
            // radioButton300m
            // 
            this.radioButton300m.AutoSize = true;
            this.radioButton300m.Checked = true;
            this.radioButton300m.Location = new System.Drawing.Point(180, 19);
            this.radioButton300m.Name = "radioButton300m";
            this.radioButton300m.Size = new System.Drawing.Size(51, 17);
            this.radioButton300m.TabIndex = 11;
            this.radioButton300m.TabStop = true;
            this.radioButton300m.Text = "300m";
            this.radioButton300m.UseVisualStyleBackColor = true;
            // 
            // radioButton200m
            // 
            this.radioButton200m.AutoSize = true;
            this.radioButton200m.Location = new System.Drawing.Point(7, 20);
            this.radioButton200m.Name = "radioButton200m";
            this.radioButton200m.Size = new System.Drawing.Size(51, 17);
            this.radioButton200m.TabIndex = 10;
            this.radioButton200m.Text = "200m";
            this.radioButton200m.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "UID :";
            // 
            // buttonSetData
            // 
            this.buttonSetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSetData.Enabled = false;
            this.buttonSetData.Location = new System.Drawing.Point(6, 298);
            this.buttonSetData.Name = "buttonSetData";
            this.buttonSetData.Size = new System.Drawing.Size(272, 23);
            this.buttonSetData.TabIndex = 19;
            this.buttonSetData.Text = "Set Data";
            this.buttonSetData.UseVisualStyleBackColor = true;
            this.buttonSetData.Click += new System.EventHandler(this.buttonSetData_Click);
            // 
            // groupBoxTemp
            // 
            this.groupBoxTemp.Controls.Add(this.radioButton200deg);
            this.groupBoxTemp.Controls.Add(this.radioButton210deg);
            this.groupBoxTemp.Controls.Add(this.radioButton190deg);
            this.groupBoxTemp.Location = new System.Drawing.Point(12, 186);
            this.groupBoxTemp.Name = "groupBoxTemp";
            this.groupBoxTemp.Size = new System.Drawing.Size(260, 43);
            this.groupBoxTemp.TabIndex = 12;
            this.groupBoxTemp.TabStop = false;
            this.groupBoxTemp.Text = "Temp";
            // 
            // radioButton200deg
            // 
            this.radioButton200deg.AutoSize = true;
            this.radioButton200deg.Location = new System.Drawing.Point(98, 19);
            this.radioButton200deg.Name = "radioButton200deg";
            this.radioButton200deg.Size = new System.Drawing.Size(54, 17);
            this.radioButton200deg.TabIndex = 15;
            this.radioButton200deg.Text = "200°C";
            this.radioButton200deg.UseVisualStyleBackColor = true;
            // 
            // radioButton210deg
            // 
            this.radioButton210deg.AutoSize = true;
            this.radioButton210deg.Checked = true;
            this.radioButton210deg.Location = new System.Drawing.Point(180, 20);
            this.radioButton210deg.Name = "radioButton210deg";
            this.radioButton210deg.Size = new System.Drawing.Size(54, 17);
            this.radioButton210deg.TabIndex = 14;
            this.radioButton210deg.TabStop = true;
            this.radioButton210deg.Text = "210°C";
            this.radioButton210deg.UseVisualStyleBackColor = true;
            // 
            // radioButton190deg
            // 
            this.radioButton190deg.AutoSize = true;
            this.radioButton190deg.Location = new System.Drawing.Point(7, 20);
            this.radioButton190deg.Name = "radioButton190deg";
            this.radioButton190deg.Size = new System.Drawing.Size(54, 17);
            this.radioButton190deg.TabIndex = 13;
            this.radioButton190deg.Text = "190°C";
            this.radioButton190deg.UseVisualStyleBackColor = true;
            // 
            // buttonInitialiseCard
            // 
            this.buttonInitialiseCard.Location = new System.Drawing.Point(6, 6);
            this.buttonInitialiseCard.Name = "buttonInitialiseCard";
            this.buttonInitialiseCard.Size = new System.Drawing.Size(89, 23);
            this.buttonInitialiseCard.TabIndex = 26;
            this.buttonInitialiseCard.Text = "Initialise Card";
            this.buttonInitialiseCard.UseVisualStyleBackColor = true;
            this.buttonInitialiseCard.Visible = false;
            this.buttonInitialiseCard.Click += new System.EventHandler(this.buttonInitialiseCard_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(27, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(305, 363);
            this.tabControl1.TabIndex = 26;
            // 
            // checkBoxLogIt
            // 
            this.checkBoxLogIt.AutoSize = true;
            this.checkBoxLogIt.Location = new System.Drawing.Point(245, 7);
            this.checkBoxLogIt.Name = "checkBoxLogIt";
            this.checkBoxLogIt.Size = new System.Drawing.Size(52, 17);
            this.checkBoxLogIt.TabIndex = 30;
            this.checkBoxLogIt.Text = "Log it";
            this.checkBoxLogIt.UseVisualStyleBackColor = true;
            // 
            // UpdateMagicNTAG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(352, 430);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelConnect);
            this.Controls.Add(this.buttonConnect);
            this.MinimizeBox = false;
            this.Name = "UpdateMagicNTAG";
            this.Text = "Update MagicNTAG Nano";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxLength.ResumeLayout(false);
            this.groupBoxLength.PerformLayout();
            this.groupBoxTemp.ResumeLayout(false);
            this.groupBoxTemp.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelConnect;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonGetCard;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox textBoxPage9Byte3;
        private System.Windows.Forms.TextBox textBoxUIDToWrite;
        private System.Windows.Forms.TextBox textBoxPage9Byte2;
        private System.Windows.Forms.TextBox textBoxPage9Byte1;
        private System.Windows.Forms.TextBox textBoxPage9Byte0;
        private System.Windows.Forms.Label labelWriteUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGetCard;
        private System.Windows.Forms.GroupBox groupBoxLength;
        private System.Windows.Forms.RadioButton radioButton300m;
        private System.Windows.Forms.RadioButton radioButton200m;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSetData;
        private System.Windows.Forms.GroupBox groupBoxTemp;
        private System.Windows.Forms.RadioButton radioButton210deg;
        private System.Windows.Forms.RadioButton radioButton190deg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonInitialiseCard;
        private System.Windows.Forms.Label labelLengthRemaining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton200deg;
        private System.Windows.Forms.Label labelPasswordPack;
        private System.Windows.Forms.CheckBox checkBoxLogIt;
    }
}

