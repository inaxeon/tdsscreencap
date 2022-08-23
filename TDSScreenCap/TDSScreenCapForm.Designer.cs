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
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblReceived = new System.Windows.Forms.Label();
            this.picScreenShot = new System.Windows.Forms.PictureBox();
            this.rxFinishedTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnWait = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnOptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenShot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(12, 12);
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
            this.picScreenShot.Location = new System.Drawing.Point(12, 55);
            this.picScreenShot.Name = "picScreenShot";
            this.picScreenShot.Size = new System.Drawing.Size(640, 480);
            this.picScreenShot.TabIndex = 3;
            this.picScreenShot.TabStop = false;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Location = new System.Drawing.Point(570, 12);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(82, 33);
            this.btnSaveAs.TabIndex = 5;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnWait
            // 
            this.btnWait.Location = new System.Drawing.Point(113, 12);
            this.btnWait.Name = "btnWait";
            this.btnWait.Size = new System.Drawing.Size(163, 33);
            this.btnWait.TabIndex = 6;
            this.btnWait.Text = "Wait for print button press";
            this.btnWait.UseVisualStyleBackColor = true;
            this.btnWait.Click += new System.EventHandler(this.btnWait_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(282, 12);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(94, 33);
            this.btnOptions.TabIndex = 7;
            this.btnOptions.Text = "Options...";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // TDSScreenCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 549);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnWait);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.picScreenShot);
            this.Controls.Add(this.lblReceived);
            this.Controls.Add(this.btnCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TDSScreenCapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tek Screen Capture Utility";
            this.Load += new System.EventHandler(this.TDSScreenCapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picScreenShot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.PictureBox picScreenShot;
        private System.Windows.Forms.Timer rxFinishedTimer;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnWait;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnOptions;
    }
}

