using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.Models
{
    public class MyDeviceDatabase
    {
        public enum Device
        {
            HDMI44Matrix,
            SonyTV,
            AudioMatrix,
            AudioMatrixOut1,
            AudioMatrixOut2,
            AudioMatrixOut3,
            AudioMatrixOut4,
            Insteon,
            OptomaHD66,
            DenonAVR2805
        }

        public class Action
        {
            public Device Device { get; set; }
            public String Name { get; set; }
            public String IRCode { get; set; }
            public String URL { get; set; }


            private List<SerialPortWrapper.SerialCommand> _SerialCommands = new List<SerialPortWrapper.SerialCommand>();

            public List<SerialPortWrapper.SerialCommand> SerialCommands
            {
                get
                {
                    return _SerialCommands;
                }

                set
                {
                    _SerialCommands.AddRange(value);
                }
            }

            public SerialPortWrapper.SerialCommand SerialCommand
            {
                get
                {
                    System.Diagnostics.Debug.Assert(_SerialCommands != null);
                    System.Diagnostics.Debug.Assert(_SerialCommands.Count == 1);

                    return _SerialCommands.First();
                }

                set
                {
                    _SerialCommands.Add(value);
                }
            }
        }

        private static HashSet<Action> _Actions;

        private static HashSet<Action> Actions
        {
            get
            {
                if (_Actions == null)
                {
                    _Actions = new HashSet<Action>();

                    #region SonyTV
                    _Actions.Add(new Action() { Device = Device.SonyTV, Name = "Volume Up", IRCode = "0000 0067 0000 000D 005F 0018 0018 0018 002F 0018 0018 0018 0018 0018 002F 0018 0018 0018 0018 0018 002F 0018 0018 0018 0018 0018 0018 0018 0018 0C35" });
                    _Actions.Add(new Action() { Device = Device.SonyTV, Name = "Power", IRCode = "0000 0066 0000 000D 0060 0019 0030 0019 0018 0019 0030 0019 0018 0019 0030 0019 0018 0019 0018 0019 0030 0019 0018 0019 0018 0019 0018 0019 0018 0C40" });
                    #endregion

                    #region Insteon
                    _Actions.Add(new Action() { Device = Device.Insteon, Name = "Entryway On", URL = "http://192.168.0.100/rest/nodes/19 36 FF 1/cmd/DON/255" });
                    _Actions.Add(new Action() { Device = Device.Insteon, Name = "Entryway Off", URL = "http://192.168.0.100/rest/nodes/19 36 FF 1/cmd/DOF" });
                    #endregion

                    #region HDMI44Matrix
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "A1", SerialCommand = new SerialPortWrapper.SerialCommand(3, "00FFD57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "A2", SerialCommand = new SerialPortWrapper.SerialCommand(3, "01FED57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "A3", SerialCommand = new SerialPortWrapper.SerialCommand(3, "02FDD57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "A4", SerialCommand = new SerialPortWrapper.SerialCommand(3, "03FCD57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });

                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "B1", SerialCommand = new SerialPortWrapper.SerialCommand(3, "04FBD57B") { BaudRate = 9600, Hex = true, SleepTime=TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "B2", SerialCommand = new SerialPortWrapper.SerialCommand(3, "05FAD57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "B3", SerialCommand = new SerialPortWrapper.SerialCommand(3, "06F9D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "B4", SerialCommand = new SerialPortWrapper.SerialCommand(3, "07F8D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });

                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "C1", SerialCommand = new SerialPortWrapper.SerialCommand(3, "08F7D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "C2", SerialCommand = new SerialPortWrapper.SerialCommand(3, "09F6D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "C3", SerialCommand = new SerialPortWrapper.SerialCommand(3, "0AF5D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "C4", SerialCommand = new SerialPortWrapper.SerialCommand(3, "0BF4D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });

                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "D1", SerialCommand = new SerialPortWrapper.SerialCommand(3, "0CF3D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "D2", SerialCommand = new SerialPortWrapper.SerialCommand(3, "0DF2D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "D3", SerialCommand = new SerialPortWrapper.SerialCommand(3, "0EF1D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    _Actions.Add(new Action() { Device = Device.HDMI44Matrix, Name = "D4", SerialCommand = new SerialPortWrapper.SerialCommand(3, "0FF0D57B") { BaudRate = 9600, Hex = true, SleepTime = TimeSpan.FromMilliseconds(100) } });
                    #endregion

                    #region OptomaHD66
                    _Actions.Add(new Action() { Device = Device.OptomaHD66, Name = "On", SerialCommand = new SerialPortWrapper.SerialCommand(4, "~0000 1") { BaudRate = 9600 } });
                    _Actions.Add(new Action() { Device = Device.OptomaHD66, Name = "Off", SerialCommand = new SerialPortWrapper.SerialCommand(4, "~0000 0") { BaudRate = 9600 } });
                    #endregion

                    #region AudioMatrix
                    _Actions.Add(new Action() { Device = Device.AudioMatrix, Name = "D1", SerialCommand = new SerialPortWrapper.SerialCommand(1, "0CF3D57B") { BaudRate = 4800 } });
                    #endregion

                    #region AudioMatrixOutX
                    for (int x = 0; x < 4; x++)
                    {
                        _Actions.Add(new Action() { Device = Device.AudioMatrixOut1 + x, Name = "Off", SerialCommand = new SerialPortWrapper.SerialCommand(1, String.Format("Z{0}0", x + 1)) { BaudRate = 4800 } });
                        _Actions.Add(new Action() { Device = Device.AudioMatrixOut1 + x, Name = "On", SerialCommand = new SerialPortWrapper.SerialCommand(1, String.Format("Z{0}1", x + 1)) { BaudRate = 4800 } });
                        _Actions.Add(new Action() { Device = Device.AudioMatrixOut1 + x, Name = "Volume Up", SerialCommand = new SerialPortWrapper.SerialCommand(1, String.Format("V{0}++", x + 1)) { BaudRate = 4800 } });
                        _Actions.Add(new Action() { Device = Device.AudioMatrixOut1 + x, Name = "Volume Down", SerialCommand = new SerialPortWrapper.SerialCommand(1, String.Format("V{0}--", x + 1)) { BaudRate = 4800 } });
                        _Actions.Add(new Action() { Device = Device.AudioMatrixOut1 + x, Name = "Treble Up", SerialCommand = new SerialPortWrapper.SerialCommand(1, String.Format("T{0}++", x + 1)) { BaudRate = 4800 } });
                        _Actions.Add(new Action() { Device = Device.AudioMatrixOut1 + x, Name = "Treble Down", SerialCommand = new SerialPortWrapper.SerialCommand(1, String.Format("T{0}--", x + 1)) { BaudRate = 4800 } });
                        _Actions.Add(new Action() { Device = Device.AudioMatrixOut1 + x, Name = "Bass Up", SerialCommand = new SerialPortWrapper.SerialCommand(1, String.Format("B{0}++", x + 1)) { BaudRate = 4800 } });
                        _Actions.Add(new Action() { Device = Device.AudioMatrixOut1 + x, Name = "Bass Down", SerialCommand = new SerialPortWrapper.SerialCommand(1, String.Format("B{0}--", x + 1)) { BaudRate = 4800 } });

                        for (int i = 1; i <= 4; i++)
                        {
                            _Actions.Add(new Action()
                            {
                                Device = Device.AudioMatrixOut1 + x,
                                Name = "Input " + i,
                                SerialCommands = new List<SerialPortWrapper.SerialCommand>{
                                                    new SerialPortWrapper.SerialCommand(1, String.Format("Z{0}1",x+1)) { BaudRate = 4800 },
                                                    new SerialPortWrapper.SerialCommand(1, String.Format("S{0}{1}",x+1,i)) { BaudRate = 4800 },
                                                    new SerialPortWrapper.SerialCommand(1, String.Format("V{0}29",x+1)) { BaudRate = 4800 } 
                                    }
                            });
                        }
                    }
                    #endregion

                    #region DenonAVR2805
                    _Actions.Add(new Action() { Device = Device.DenonAVR2805, Name = "On", SerialCommand = new SerialPortWrapper.SerialCommand(5, "PWON") { BaudRate = 9600 } });
                    _Actions.Add(new Action() { Device = Device.DenonAVR2805, Name = "Off", SerialCommand = new SerialPortWrapper.SerialCommand(5, "PWSTANDBY") { BaudRate = 9600 } });
                    _Actions.Add(new Action() { Device = Device.DenonAVR2805, Name = "Matrix", SerialCommand = new SerialPortWrapper.SerialCommand(5, "SIVDP") { BaudRate = 9600 } });
                    _Actions.Add(new Action() { Device = Device.DenonAVR2805, Name = "Apple TV", SerialCommand = new SerialPortWrapper.SerialCommand(5, "SIDBS/SAT") { BaudRate = 9600 } });
                    _Actions.Add(new Action() { Device = Device.DenonAVR2805, Name = "Default Volume", SerialCommand = new SerialPortWrapper.SerialCommand(5, "MV50") { BaudRate = 9600 } });
                    #endregion

                }

                return _Actions;
            }
        }

        public static Action GetAction(Device device, String name)
        {
            return Actions.Single(a => a.Device == device && a.Name == name);
        }

        public static SerialPortWrapper.SerialCommand GetSerialCommand(Device device, String name)
        {
            return Actions.Single(a => a.Device == device && a.Name == name).SerialCommand;
        }

        public static String GetIRCode(Device device, String name)
        {
            return Actions.Single(a => a.Device == device && a.Name == name).IRCode;
        }
    }
}