using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO.Ports;

namespace _804ManchesterHomeControl.Models
{
    public class SerialPortWrapper
    {
        public class SerialCommand
        {
            public SerialCommand(int SerialPort, String Command)
            {
                BaudRate = 4800;
                Parity = Parity.None;
                DataBits = 8;
                StopBits = StopBits.One;
                SleepTime = TimeSpan.Zero;

                this.SerialPort = SerialPort;
                this.Command = Command;

                this.ExpectedResponse = "OK";
            }

            public int SerialPort { get; set; }
            public String SerialPortString
            {
                get { return String.Format("COM{0}", SerialPort); }
            }
            public int BaudRate { get; set; }
            public Parity Parity { get; set; }
            public int DataBits { get; set; }
            public StopBits StopBits { get; set; }

            public TimeSpan SleepTime { get; set; }

            public String Command { get; set; }
            public Boolean Hex { get; set; }

            public String ExpectedResponse { get; set; }
        }

        static public String SendSerialCommand(String command)
        {
            SerialCommand cmd = new SerialCommand(1, command);

            return SendSerialCommand(cmd);
        }

        static public String SendSerialCommand(SerialCommand cmd)
        {
            System.Diagnostics.Debug.Assert(!String.IsNullOrEmpty(cmd.Command));
            System.Diagnostics.Debug.Assert(cmd.SerialPort != 0);

            using (SerialPort serialPort = new SerialPort(cmd.SerialPortString, cmd.BaudRate, cmd.Parity, cmd.DataBits, cmd.StopBits))
            {
                try
                {
                    serialPort.ReadTimeout = 1000;

                    serialPort.Open();
                    if (cmd.Hex)
                    {
                        byte[] buffer = HexStringToBytes(cmd.Command);
                        serialPort.Write(buffer, 0, buffer.Length);
                    }
                    else
                        serialPort.WriteLine(cmd.Command);

                    string actualResponse = String.Empty;
                    foreach (char c in cmd.ExpectedResponse)
                    {
                        char rcvdChar = (char)serialPort.ReadChar();
                        actualResponse += rcvdChar;
                        if (rcvdChar != c)
                        {
                            actualResponse += serialPort.ReadExisting();
                            return actualResponse + "!=" + cmd.ExpectedResponse;
                        }
                    }

                    //System.Threading.Thread.Sleep(cmd.SleepTime);
                    return actualResponse;
                }
                finally
                {
                    serialPort.Close();
                }
            }
        }

        internal static byte[] HexStringToBytes(String command)
        {
            System.Diagnostics.Debug.Assert(command.Length % 2 == 0);
            int idx = 0;
            byte[] buffer = new byte[command.Length / 2];

            while (idx * 2 < command.Length)
            {
                buffer[idx] = byte.Parse(command.Substring(idx * 2, 2), System.Globalization.NumberStyles.HexNumber);
                idx++;
            }

            return buffer;
        }
    }
}