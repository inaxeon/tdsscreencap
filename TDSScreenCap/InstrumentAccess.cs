using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace TDSScreenCap
{
    public class InstrumentAccess
    {
        private readonly InterfaceType _interfaceType;
        private readonly string _device;

        private IMessageBasedSession _session;
        private SerialPort _serialPort;

        public InstrumentAccess(InterfaceType interfaceType, string device)
        {
            _interfaceType = interfaceType;
            _device = device;
        }

        public void OpenDevice()
        {
            if (_interfaceType == InterfaceType.Rs232)
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = _device;
                _serialPort.BaudRate = 38400;
                _serialPort.DataBits = 8;
                _serialPort.Handshake = Handshake.RequestToSend;
                _serialPort.Parity = Parity.None;
                _serialPort.WriteTimeout = 3000;

                _serialPort.Open();
            }
            else if (_interfaceType == InterfaceType.Gpib)
            {
                _session = GlobalResourceManager.Open(_device) as IMessageBasedSession;
                _session.TimeoutMilliseconds = 5000;
                _session.TerminationCharacterEnabled = false;
                _session.RawIO.Write("*RST\n");
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void CloseDevice()
        {
            if (_interfaceType == InterfaceType.Rs232)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
            }
            else if (_interfaceType == InterfaceType.Gpib)
            {
                _session.Dispose();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void WriteDevice(string str)
        {
            if (_interfaceType == InterfaceType.Rs232)
            {
                var bytes = Encoding.ASCII.GetBytes(str);
                _serialPort.Write(bytes.ToArray(), 0, bytes.Length);
            }
            else if (_interfaceType == InterfaceType.Gpib)
            {
                _session.RawIO.Write(str);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public byte[] ReadDevice(int len)
        {
            if (_interfaceType == InterfaceType.Rs232)
            {
                byte[] buffer = new byte[len];
                int total = 0;
                while (len > 0)
                {
                    int read = _serialPort.Read(buffer, total, len);
                    len -= read;
                    total += read;

                    if (len > 0)
                        Thread.Sleep(1);
                }

                return buffer;
            }
            else if (_interfaceType == InterfaceType.Gpib)
            {
                return _session.RawIO.Read(len);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void SetTimeout(int ms)
        {
            if (_interfaceType == InterfaceType.Rs232)
            {
                _serialPort.ReadTimeout = ms;
            }
            else if (_interfaceType == InterfaceType.Gpib)
            {
                // Not needed as "button press" mode not yet working
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public byte[] ReadPng()
        {
            if (_interfaceType == InterfaceType.Rs232)
            {
                // No way to know when the data is all sent with RS-232, so read in PNG intelligently so we know when it's all in
                List<byte> ret = new List<byte>();
                var data = ReadDevice(8); // Header
                ret.AddRange(data);

                for (;;)
                {
                    var lengthAndType = ReadDevice(8); // Length+CRC
                    ret.AddRange(lengthAndType);

                    var lengthBytes = lengthAndType.Take(4).ToArray();

                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(lengthBytes);

                    var typeBytes = lengthAndType.Skip(4).Take(4).ToArray();

                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(typeBytes);

                    var length = BitConverter.ToUInt32(lengthBytes, 0);

                    ret.AddRange(ReadDevice((int)length + 4)); // Data+CRC

                    var type = BitConverter.ToUInt32(typeBytes, 0);

                    if (type == 0x49454E44) // End
                        break;
                }

                return ret.ToArray();
            }
            else if (_interfaceType == InterfaceType.Gpib)
            {
                return _session.RawIO.Read(0x100000); // Arbitrary large number to force it to read everything
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
