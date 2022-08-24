using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDSScreenCap
{
    public partial class SettingsForm : Form
    {
        ResourceManager _manager;
        private InterfaceType _uiInterfaceType;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.InterfaceType = (int)_uiInterfaceType;
            Properties.Settings.Default.GpibDevice = (string)ddlGpibDevices.SelectedItem;
            Properties.Settings.Default.ComPort = (string)ddlRs232Port.SelectedItem;
            Properties.Settings.Default.Save();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                _manager = new ResourceManager();
                var devices = _manager.Find("(ASRL|GPIB|TCPIP|USB)?*");
                ddlGpibDevices.Items.AddRange(devices.Cast<object>().ToArray());
            }
            catch (Exception ex)
            {
                btnGpib.Enabled = false;
                grpGpibSettings.Text += " (NI-VISA load failed)";
                btnGpib.Checked = false;
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.GpibDevice))
                ddlGpibDevices.SelectedItem = Properties.Settings.Default.GpibDevice;

            var _lastComPort = Properties.Settings.Default.ComPort;

            ddlRs232Port.Items.AddRange(SerialPort.GetPortNames());

            if (!string.IsNullOrEmpty(_lastComPort))
                ddlRs232Port.SelectedItem = _lastComPort;

            _uiInterfaceType = (InterfaceType)Properties.Settings.Default.InterfaceType;

            switch (_uiInterfaceType)
            {
                case InterfaceType.Rs232:
                    btnRs232.Checked = true;
                    break;
                case InterfaceType.Gpib:
                    btnGpib.Checked = true;
                    break;
                default:
                    throw new NotImplementedException();
            }

            UpdateUi();
        }

        private void btnRs232_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRs232.Checked)
                _uiInterfaceType = InterfaceType.Rs232;

            UpdateUi();
        }

        private void btnGpib_CheckedChanged(object sender, EventArgs e)
        {
            if (btnGpib.Checked)
                _uiInterfaceType = InterfaceType.Gpib;

            UpdateUi();
        }

        private void UpdateUi()
        {
            switch (_uiInterfaceType)
            {
                case InterfaceType.Rs232:
                    grpRs232.Enabled = true;
                    grpGpibSettings.Enabled = false;
                    break;
                case InterfaceType.Gpib:
                    grpRs232.Enabled = false;
                    grpGpibSettings.Enabled = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
