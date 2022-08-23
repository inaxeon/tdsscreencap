using Ivi.Visa;
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
using System.Threading;
using System.Windows.Forms;

namespace TDSScreenCap
{
    public partial class TDSScreenCapForm : Form
    {
        private InstrumentAccess _instrument;
        private Thread _workerThread;
        private byte[] _pngFile;


        public TDSScreenCapForm()
        {
            InitializeComponent();
        }

        private void TDSScreenCapForm_Load(object sender, EventArgs e)
        {

        }

        private void Connect()
        {
            if (_instrument != null)
                return;

            string device = (InterfaceType)Properties.Settings.Default.InterfaceType == InterfaceType.Gpib ?
                Properties.Settings.Default.GpibDevice : Properties.Settings.Default.ComPort;

            if (string.IsNullOrEmpty(device))
            {
                MessageBox.Show("No instrument is configured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _instrument = new InstrumentAccess((InterfaceType)Properties.Settings.Default.InterfaceType, device);
                _instrument.OpenDevice();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Failed to open {0}", device), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _instrument = null;
            }
        }

        private void StartRead()
        {
            btnCapture.Enabled = false;
            btnWait.Enabled = false;
            btnOptions.Enabled = false;

            _workerThread = new Thread(() =>
            {
                _pngFile = _instrument.ReadPng();
                EndCapture();
            });

            _workerThread.Start();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Connect();
            SetupCapture();

            _instrument.WriteDevice("HARDCOPY START");

            StartRead();
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            Connect();
            SetupCapture();
            StartRead();
        }

        private void SetupCapture()
        {
            btnSaveAs.Enabled = false;
            picScreenShot.Image = null;

            _instrument.WriteDevice(string.Format(":HARDCOPY:FORMAT PNG;PALETTE NORMAL;PORT {0};LAYOUT PORTRAIT;PREVIEW 0;INKSAVER 0;COMPRESSION 0\n\n",
                (InterfaceType)Properties.Settings.Default.InterfaceType == InterfaceType.Rs232 ? "RS232" : "GPIB"));
        }

        private void EndCapture()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(EndCapture));
                return;
            }

            btnWait.Enabled = true;
            btnCapture.Enabled = true;
            btnOptions.Enabled = true;

            try
            {
                var img = Image.FromStream(new MemoryStream(_pngFile));
                picScreenShot.Image = img;
                btnSaveAs.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No valid image received!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
            settings.ShowDialog();
        }
    }
}
