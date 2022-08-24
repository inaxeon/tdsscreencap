namespace TDSScreenCap
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGpib = new System.Windows.Forms.RadioButton();
            this.btnRs232 = new System.Windows.Forms.RadioButton();
            this.grpRs232 = new System.Windows.Forms.GroupBox();
            this.ddlRs232Port = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpGpibSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlGpibDevices = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpRs232.SuspendLayout();
            this.grpGpibSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGpib);
            this.groupBox1.Controls.Add(this.btnRs232);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interface Type";
            // 
            // btnGpib
            // 
            this.btnGpib.AutoSize = true;
            this.btnGpib.Location = new System.Drawing.Point(13, 54);
            this.btnGpib.Name = "btnGpib";
            this.btnGpib.Size = new System.Drawing.Size(50, 17);
            this.btnGpib.TabIndex = 1;
            this.btnGpib.TabStop = true;
            this.btnGpib.Text = "GPIB";
            this.btnGpib.UseVisualStyleBackColor = true;
            this.btnGpib.CheckedChanged += new System.EventHandler(this.btnGpib_CheckedChanged);
            // 
            // btnRs232
            // 
            this.btnRs232.AutoSize = true;
            this.btnRs232.Location = new System.Drawing.Point(13, 30);
            this.btnRs232.Name = "btnRs232";
            this.btnRs232.Size = new System.Drawing.Size(61, 17);
            this.btnRs232.TabIndex = 0;
            this.btnRs232.TabStop = true;
            this.btnRs232.Text = "RS-232";
            this.btnRs232.UseVisualStyleBackColor = true;
            this.btnRs232.CheckedChanged += new System.EventHandler(this.btnRs232_CheckedChanged);
            // 
            // grpRs232
            // 
            this.grpRs232.Controls.Add(this.label3);
            this.grpRs232.Controls.Add(this.ddlRs232Port);
            this.grpRs232.Controls.Add(this.label2);
            this.grpRs232.Enabled = false;
            this.grpRs232.Location = new System.Drawing.Point(13, 110);
            this.grpRs232.Name = "grpRs232";
            this.grpRs232.Size = new System.Drawing.Size(379, 68);
            this.grpRs232.TabIndex = 1;
            this.grpRs232.TabStop = false;
            this.grpRs232.Text = "RS-232 Settings";
            // 
            // ddlRs232Port
            // 
            this.ddlRs232Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRs232Port.FormattingEnabled = true;
            this.ddlRs232Port.Location = new System.Drawing.Point(52, 31);
            this.ddlRs232Port.Name = "ddlRs232Port";
            this.ddlRs232Port.Size = new System.Drawing.Size(147, 21);
            this.ddlRs232Port.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port:";
            // 
            // grpGpibSettings
            // 
            this.grpGpibSettings.Controls.Add(this.label1);
            this.grpGpibSettings.Controls.Add(this.ddlGpibDevices);
            this.grpGpibSettings.Enabled = false;
            this.grpGpibSettings.Location = new System.Drawing.Point(13, 188);
            this.grpGpibSettings.Name = "grpGpibSettings";
            this.grpGpibSettings.Size = new System.Drawing.Size(379, 67);
            this.grpGpibSettings.TabIndex = 2;
            this.grpGpibSettings.TabStop = false;
            this.grpGpibSettings.Text = "GPIB Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device:";
            // 
            // ddlGpibDevices
            // 
            this.ddlGpibDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGpibDevices.FormattingEnabled = true;
            this.ddlGpibDevices.Location = new System.Drawing.Point(52, 27);
            this.ddlGpibDevices.Name = "ddlGpibDevices";
            this.ddlGpibDevices.Size = new System.Drawing.Size(314, 21);
            this.ddlGpibDevices.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(296, 274);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 35);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(194, 274);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instrument: 3800 Baud, Hard, LF";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 321);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpGpibSettings);
            this.Controls.Add(this.grpRs232);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpRs232.ResumeLayout(false);
            this.grpRs232.PerformLayout();
            this.grpGpibSettings.ResumeLayout(false);
            this.grpGpibSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton btnGpib;
        private System.Windows.Forms.RadioButton btnRs232;
        private System.Windows.Forms.GroupBox grpRs232;
        private System.Windows.Forms.GroupBox grpGpibSettings;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlGpibDevices;
        private System.Windows.Forms.ComboBox ddlRs232Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}