using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _804ManchesterHomeControl.Models;
using _804ManchesterHomeControl.ViewModels;
using System.Net;

namespace _804ManchesterHomeControl.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IR()
        {
            return View();
        }

        public String LearnIRCode()
        {
            return IRWrapper.LearnCode();
        }

        public String SendIRCode(String IRCode, int randomParam)
        {
            return IRWrapper.SendCode(IRCode);
        }
        
        public ActionResult AllDeviceCommands()
        {
            MyDatabaseEntities dbe = new MyDatabaseEntities();

            AllDeviceCommandsViewModel vm = new AllDeviceCommandsViewModel();

            foreach (Device device in dbe.Devices)
            {
                foreach (DeviceCommand deviceCommand in device.DeviceCommands)
                    vm.AddDeviceCommand(device.DeviceName, deviceCommand.Id, deviceCommand.Name);
            }

            return View("AllDeviceCommands", vm);
        }

        public String ExecuteDeviceCommand(Int32 DeviceCommandId)
        {
            MyDatabaseEntities dbe = new MyDatabaseEntities();

            DeviceCommand deviceCommand = dbe.DeviceCommands.Single(dc => dc.Id == DeviceCommandId);

            return ExecuteDeviceCommand(deviceCommand);
        }

        internal String ExecuteDeviceCommand(DeviceCommand deviceCommand)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(deviceCommand.SerialCommand))
            {
                try
                {
                    SerialPortWrapper.SerialCommand serCmd = new SerialPortWrapper.SerialCommand(
                        deviceCommand.Device.SerialPort.Value, deviceCommand.SerialCommand);
                    serCmd.BaudRate = deviceCommand.Device.BaudRate.Value;
                    serCmd.Hex = deviceCommand.Device.HexMode;
                    result += SerialPortWrapper.SendSerialCommand(serCmd) + "<br/>";
                }
                catch (Exception ex)
                {
                    result += ex.Message + "<br/>";
                }
            }

            if (!String.IsNullOrEmpty(deviceCommand.URL) )
            {
                try
                {
                    WebRequest myRequest = WebRequest.Create(deviceCommand.URL);
                    myRequest.Credentials = new NetworkCredential("admin", "McAdmin");
                    WebResponse response = myRequest.GetResponse();
                }
                catch (Exception ex)
                {
                    result += ex.Message + "<br/>";
                }
            }

            if(!String.IsNullOrEmpty(deviceCommand.IRCode))
            {
                try
                {
                    result += IRWrapper.SendCode(deviceCommand.IRCode);
                }
                catch (Exception ex)
                {
                    result += ex.Message + "<br/>";
                }
            }

            return result;
        }

        public ActionResult ChooseRoom()
        {
            MyDatabaseEntities dbe = new MyDatabaseEntities();

            ChooseRoomViewModel vm = new ChooseRoomViewModel();

            foreach( Models.Room room in dbe.Rooms )
            {
                vm.AddRoom(room.Id, room.RoomName);
            }
            
            return View("ChooseRoom", vm);
        }

        public ActionResult ChooseActivity(Int32 RoomId)
        {
            MyDatabaseEntities dbe = new MyDatabaseEntities();

            ChooseActivityViewModel vm = new ChooseActivityViewModel();

            Room room = dbe.Rooms.Single(rm => rm.Id == RoomId);

            vm.RoomName = room.RoomName;
            foreach (RoomActivity roomActivitiy in room.RoomActivities)
            {
                vm.AddActivity(roomActivitiy.Id, roomActivitiy.Activity.Activity1);
            }

            return View("ChooseActivity", vm);
        }

        public String ExecuteRoomActivity(Int32 RoomActivityId)
        {
            MyDatabaseEntities dbe = new MyDatabaseEntities();

            RoomActivity roomActivity = dbe.RoomActivities.Single(ra => ra.Id == RoomActivityId);

            String result = String.Empty;
            foreach (RequiredCommand rc in roomActivity.RequiredCommands.OrderBy( rc => rc.Sequence ))
            {
                result += String.Format("{0} {1}:", rc.DeviceCommand.Device.DeviceName, rc.DeviceCommand.Name);
                result += ExecuteDeviceCommand(rc.DeviceCommand);
                result += "</br>";
            }

            return result;
        }
    }
}
