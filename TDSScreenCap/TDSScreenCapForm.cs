using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDSScreenCap
{
    public partial class TDSScreenCapForm : Form
    {
        private List<byte> _pngFile = new List<byte>();
        private bool _capturing = false;
        private delegate void SerialReceiveEventHandler(object sender, SerialDataReceivedEventArgs e);

        public TDSScreenCapForm()
        {
            InitializeComponent();
        }

        private void TDSScreenCapForm_Load(object sender, EventArgs e)
        {
            var _lastComPort = Properties.Settings.Default.LastComPort;
            ddlPorts.DataSource = SerialPort.GetPortNames();
            if (!string.IsNullOrEmpty(_lastComPort))
                ddlPorts.SelectedIndex = ddlPorts.FindString(_lastComPort);
            ddlPorts_SelectedIndexChanged(ddlPorts, null);
            if (Properties.Settings.Default.CompletionTimeout == 0)
                nudCompletionTimeout.Value = 4000;
            else
                nudCompletionTimeout.Value = Properties.Settings.Default.CompletionTimeout;
        }

        private void ddlPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.PortName = ddlPorts.SelectedItem.ToString();
            serialPort.BaudRate = 38400;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.RequestToSend;
            serialPort.Parity = Parity.None;

            try
            {
                serialPort.Open();
                btnCapture.Enabled = true;
                Properties.Settings.Default.LastComPort = serialPort.PortName;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Failed to open {0}", serialPort.PortName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapture.Enabled = false;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new TDSScreenCapForm.SerialReceiveEventHandler(serialPort1_DataReceived), new object[] { sender, e });
                return;
            }

            if (_capturing)
            {
                if (rxFinishedTimer.Enabled == false)
                    rxFinishedTimer.Enabled = true;
            }

            var thisRead = serialPort.BytesToRead;
            var bytes = new byte[thisRead];
            serialPort.Read(bytes, 0, thisRead);

            if (_capturing)
            {
                _pngFile.AddRange(bytes);
                lblReceived.Text = string.Format("Received bytes: {0}", _pngFile.Count);
                rxFinishedTimer.Enabled = false;
                rxFinishedTimer.Enabled = true;
            }
        }

        private void rxFinishedTimer_Tick(object sender, EventArgs e)
        {
            _capturing = false;
            EndCapture();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!_capturing)
            {
                btnWait.Enabled = false;
                btnCapture.Text = "Abort";
                SetupCapture();
                WriteSerial("HARDCOPY START\n");
                _capturing = true;
            }
            else
            {
                AbortCapture();
                _capturing = false;
            }
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            if (!_capturing)
            {
                btnCapture.Enabled = false;
                btnWait.Text = "Abort";
                SetupCapture();
                _capturing = true;
            }
            else
            {
                AbortCapture();
                _capturing = false;
            }
        }

        private void AbortCapture()
        {
            rxFinishedTimer.Enabled = false;
            btnCapture.Enabled = true;
            btnWait.Enabled = true;
            btnWait.Text = "Wait for print button press";
            btnCapture.Text = "Capture";
            _pngFile.Clear();
            _capturing = true;
            picScreenShot.Image = null;
            lblReceived.Text = string.Format("Received bytes: {0}", 0);
        }

        private void SetupCapture()
        {
            btnSaveAs.Enabled = false;
            _pngFile.Clear();
            picScreenShot.Image = null;
            lblReceived.Text = string.Format("Received bytes: {0}", 0);

            WriteSerial(":HARDCOPY:FORMAT PNG;PALETTE NORMAL;PORT RS232;LAYOUT PORTRAIT;PREVIEW 0;INKSAVER 0;COMPRESSION 0\n\n");
        }

        private void EndCapture()
        {
            rxFinishedTimer.Enabled = false;
            btnWait.Enabled = true;
            btnCapture.Enabled = true;
            btnWait.Text = "Wait for print button press";
            btnCapture.Text = "Capture";

            try
            {
                var img = Image.FromStream(new MemoryStream(_pngFile.ToArray()));
                picScreenShot.Image = img;
                btnSaveAs.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No valid image received!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteSerial(string str)
        {
            var bytes = Encoding.ASCII.GetBytes(str);
            serialPort.Write(bytes.ToArray(), 0, bytes.Length);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastSavePath))
                saveFileDialog.InitialDirectory = Properties.Settings.Default.LastSavePath;
    
            saveFileDialog.Title = "Save PNG File";
            saveFileDialog.FileName = "tek.png";
            saveFileDialog.Filter = "PNG files (*.png)|*.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                picScreenShot.Image.Save(fs, ImageFormat.Png);
                fs.Close();
                Properties.Settings.Default.LastSavePath = Path.GetDirectoryName(saveFileDialog.FileName);
                Properties.Settings.Default.Save();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nudCompletionTimeout_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CompletionTimeout = (int)nudCompletionTimeout.Value;
            Properties.Settings.Default.Save();
            rxFinishedTimer.Interval = (int)nudCompletionTimeout.Value;
        }
    }
}
