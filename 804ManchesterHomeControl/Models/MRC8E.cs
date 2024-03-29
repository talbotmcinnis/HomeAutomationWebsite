﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.Models
{
    public class MRC8E
    {
        public MRC8E(int serialPort, Dictionary<int, double> activeZones)
        {
            this.SerialPort = serialPort;
            this.ActiveZones = activeZones;
        }

        private int SerialPort { get; set; }
        private Dictionary<int, double> ActiveZones { get; set; }

        public void AllZonesOn()
        {
            
            this.SendCommand("ZA1");

            // All zones on was over heating, so turn off any inactive zones
            var z = 1;
            do
            {
                if( !ActiveZones.Any(az => az.Key == z) )
                    this.SendCommand($"Z{z}0");
            } while (++z <= 8);
        }

        public void AllZonesOff()
        {
            this.SendCommand("ZA0");
        }

        public void AllZonesVolume(double vol_percent)
        {
            foreach (var z in this.ActiveZones)
            {
                this.SendCommand(string.Format("V{0:D1}{1:D2}", z.Key, (int)(31 * (vol_percent / 100) * z.Value) ));
            }
        }

        public void AllZonesSource(int source)
        {
            foreach (int z in this.ActiveZones.Keys)
                this.SendCommand(string.Format("S{0:D1}{1:D1}", z, source));
        }

        private void SendCommand(string command)
        {
            //System.Diagnostics.Debug.WriteLine(command); return;

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