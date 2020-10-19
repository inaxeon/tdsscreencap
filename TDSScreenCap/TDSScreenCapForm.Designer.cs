namespace TDSScreenCap
{
    partial class TDSScreenCapForm
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
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.ddlPorts = new System.Windows.Forms.ComboBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblReceived = new System.Windows.Forms.Label();
            this.picScreenShot = new System.Windows.Forms.PictureBox();
            this.rxFinishedTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnWait = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.nudCompletionTimeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenShot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompletionTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // ddlPorts
            // 
            this.ddlPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPorts.FormattingEnabled = true;
            this.ddlPorts.Location = new System.Drawing.Point(12, 12);
            this.ddlPorts.Name = "ddlPorts";
            this.ddlPorts.Size = new System.Drawing.Size(94, 21);
            this.ddlPorts.TabIndex = 0;
            this.ddlPorts.SelectedIndexChanged += new System.EventHandler(this.ddlPorts_SelectedIndexChanged);
            // 
            // btnCapture
            // 
            this.btnCapture.Enabled = false;
            this.btnCapture.Location = new System.Drawing.Point(12, 39);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(94, 33);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.Location = new System.Drawing.Point(282, 49);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(0, 13);
            this.lblReceived.TabIndex = 2;
            // 
            // picScreenShot
            // 
            this.picScreenShot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScreenShot.Location = new System.Drawing.Point(12, 78);
            this.picScreenShot.Name = "picScreenShot";
            this.picScreenShot.Size = new System.Drawing.Size(640, 480);
            this.picScreenShot.TabIndex = 3;
            this.picScreenShot.TabStop = false;
            // 
            // rxFinishedTimer
            // 
            this.rxFinishedTimer.Interval = 4000;
            this.rxFinishedTimer.Tick += new System.EventHandler(this.rxFinishedTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "COM Port. 38400 Baud, Hard, LF";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Location = new System.Drawing.Point(570, 39);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(82, 33);
            this.btnSaveAs.TabIndex = 5;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnWait
            // 
            this.btnWait.Location = new System.Drawing.Point(113, 39);
            this.btnWait.Name = "btnWait";
            this.btnWait.Size = new System.Drawing.Size(163, 33);
            this.btnWait.TabIndex = 6;
            this.btnWait.Text = "Wait for print button press";
            this.btnWait.UseVisualStyleBackColor = true;
            this.btnWait.Click += new System.EventHandler(this.btnWait_Click);
            // 
            // nudCompletionTimeout
            // 
            this.nudCompletionTimeout.Location = new System.Drawing.Point(570, 13);
            this.nudCompletionTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCompletionTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCompletionTimeout.Name = "nudCompletionTimeout";
            this.nudCompletionTimeout.Size = new System.Drawing.Size(82, 20);
            this.nudCompletionTimeout.TabIndex = 7;
            this.nudCompletionTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCompletionTimeout.ValueChanged += new System.EventHandler(this.nudCompletionTimeout_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transfer complete wait (ms):";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TDSScreenCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 570);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudCompletionTimeout);
            this.Controls.Add(this.btnWait);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picScreenShot);
            this.Controls.Add(this.lblReceived);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.ddlPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TDSScreenCapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tek Screen Capture Utility";
            this.Load += new System.EventHandler(this.TDSScreenCapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picScreenShot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompletionTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox ddlPorts;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.PictureBox picScreenShot;
        private System.Windows.Forms.Timer rxFinishedTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnWait;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.NumericUpDown nudCompletionTimeout;
        private System.Windows.Forms.Label label2;
    }
}

