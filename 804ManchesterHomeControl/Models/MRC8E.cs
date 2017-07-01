using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.Models
{
    public class MRC8E
    {
        public MRC8E(int serialPort, List<int> activeZones)
        {
            this.SerialPort = serialPort;
            this.ActiveZones = activeZones;
        }

        private int SerialPort { get; set; }
        private List<int> ActiveZones { get; set; }

        public void AllZonesOn()
        {
            this.SendCommand("ZA1");
        }

        public void AllZonesOff()
        {
            this.SendCommand("ZA0");
        }

        public void AllZonesVolume(double vol_percent)
        {
            foreach (int z in this.ActiveZones)
                this.SendCommand(string.Format("V{0:D1}{1:D2}", z, 31 * vol_percent / 100));
        }

        public void AllZonesSource(int source)
        {
            foreach (int z in this.ActiveZones)
                this.SendCommand(string.Format("S{0:D1}{1:D2}", z, source));
        }

        private void SendCommand(string command)
        {
            SerialPortWrapper.SerialCommand serCmd = new SerialPortWrapper.SerialCommand(
                        this.SerialPort, command);
            serCmd.BaudRate = 4800;
            serCmd.Hex = false;
            string response = SerialPortWrapper.SendSerialCommand(serCmd);

            if (response != "OK")
                throw new ApplicationException("Bad Response:" + response);
        }
    }
}