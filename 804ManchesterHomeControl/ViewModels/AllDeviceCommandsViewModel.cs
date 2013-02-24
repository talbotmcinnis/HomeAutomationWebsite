using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.ViewModels
{
    public class AllDeviceCommandsViewModel
    {
        private Dictionary<String, Dictionary<Int32, String>> _DeviceCommands;

        public AllDeviceCommandsViewModel()
        {
            _DeviceCommands = new Dictionary<string, Dictionary<int, string>>();
        }

        public void AddDeviceCommand(String DeviceName, Int32 DeviceCommandId, String DeviceCommand)
        {
            if (!_DeviceCommands.ContainsKey(DeviceName))
                _DeviceCommands.Add(DeviceName, new Dictionary<int, string>());

            _DeviceCommands[DeviceName].Add(DeviceCommandId, DeviceCommand);
        }

        public Dictionary<String, Dictionary<Int32, String>> AllDeviceCommands
        {
            get
            {
                return _DeviceCommands;
            }
        }
    }
}