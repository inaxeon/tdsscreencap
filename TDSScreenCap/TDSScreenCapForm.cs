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
        private bool _waiting;
        private readonly string _designTitle;


        public TDSScreenCapForm()
        {
            InitializeComponent();
            _designTitle = Text;
        }

        private void TDSScreenCapForm_Load(object sender, EventArgs e)
        {
            UpdateConfigDisplay();
        }

        private void UpdateConfigDisplay()
        {
            switch ((InterfaceType)Properties.Settings.Default.InterfaceType)
            {
                case InterfaceType.Rs232:
                    Text = _designTitle + $" [RS232: {Properties.Settings.Default.ComPort}]";
                    break;
                case InterfaceType.Gpib:
                    Text = _designTitle + $" [GPIB: {Properties.Settings.Default.GpibDevice}]";
                    break;
                default:
                    throw new NotImplementedException();
            }

            btnWait.Enabled = (InterfaceType)Properties.Settings.Default.InterfaceType == InterfaceType.Rs232;
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
            _workerThread = new Thread(() =>
            {
                try
                {
                    _pngFile = _instrument.ReadPng();
                }
                catch (Exception ex)
                {

                }
                EndCapture();
            });

            _workerThread.Start();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Connect();

            if (_instrument == null)
                return;

            _instrument.SetTimeout(5000);

            try
            {
                SetupCapture();

                _instrument.WriteDevice("HARDCOPY START\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write to instrument. Is hardware flow control correctly wired?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EndCapture();
                return;
            }

            StartRead();
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            if (_waiting)
            {
                _instrument.CloseDevice();
                _instrument = null;
            }
            else
            {
                Connect();

                if (_instrument == null)
                    return;

                _instrument.SetTimeout(-1); //Infinite

                _waiting = true;

                try
                {
                    SetupCapture();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to write to instrument. Is hardware flow control correctly wired?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _waiting = false;
                    EndCapture();
                    return;
                }

                StartRead();
            }
        }

        private void SetupCapture()
        {
            btnCapture.Enabled = false;

            if (_waiting)
                btnWait.Text = "Abort";
            else
                btnWait.Enabled = false;

            btnOptions.Enabled = false;

            btnSaveAs.Enabled = false;
            picScreenShot.Image = null;
            _pngFile = null;

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

            if (_pngFile != null)
            {
                try
                {
                    var img = Image.FromStream(new MemoryStream(_pngFile));
                    picScreenShot.Image = img;
                    btnSaveAs.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid image received!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btnCapture.Enabled = true;
            btnOptions.Enabled = true;

            if (_waiting)
            {
                _waiting = false;
                btnWait.Text = "Wait for print button press";
            }
            else
            {
                btnWait.Enabled = (InterfaceType)Properties.Settings.Default.InterfaceType == InterfaceType.Rs232;
            }

            if (_instrument != null)
            {
                _instrument.CloseDevice();
                _instrument = null;
            }

            btnCapture.Focus();
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
            UpdateConfigDisplay();
        }
    }
}
