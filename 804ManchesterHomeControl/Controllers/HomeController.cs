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
            //ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Insteon()
        {
            return View();
        }

        public ActionResult AudioMatrixControl()
        {
            return View();
        }

        public ActionResult IR()
        {
            return View();
        }

        public String AudioAction(String audioActionName, Nullable<int> audioZone, Nullable<int> zoneSource, String wmpURL)
        {
            try
            {
                if (!String.IsNullOrEmpty(wmpURL))
                {
                    WMPWrapper.OpenURL(wmpURL);
                }

                switch (audioActionName)
                {
                    case "OFF":
                        SerialPortWrapper.SendSerialCommand(String.Format("Z{0}0", audioZone));
                        break;

                    case "SOURCE":
                        SerialPortWrapper.SendSerialCommand(String.Format("Z{0}1", audioZone));
                        SerialPortWrapper.SendSerialCommand(String.Format("S{0}{1}", audioZone, zoneSource));
                        SerialPortWrapper.SendSerialCommand(String.Format("V{0}29", audioZone));
                        break;

                    case "VOLUMEUP":
                        SerialPortWrapper.SendSerialCommand(String.Format("V{0}++", audioZone, zoneSource));
                        SerialPortWrapper.SendSerialCommand(String.Format("V{0}++", audioZone, zoneSource));
                        break;

                    case "VOLUMEDOWN":
                        SerialPortWrapper.SendSerialCommand(String.Format("V{0}--", audioZone, zoneSource));
                        SerialPortWrapper.SendSerialCommand(String.Format("V{0}--", audioZone, zoneSource));
                        SerialPortWrapper.SendSerialCommand(String.Format("V{0}--", audioZone, zoneSource));
                        SerialPortWrapper.SendSerialCommand(String.Format("V{0}--", audioZone, zoneSource));
                        break;

                    case "TREBLEUP":
                        SerialPortWrapper.SendSerialCommand(String.Format("T{0}++", audioZone, zoneSource));
                        break;

                    case "TREBLEDOWN":
                        SerialPortWrapper.SendSerialCommand(String.Format("T{0}--", audioZone, zoneSource));
                        break;

                    case "BASSUP":
                        SerialPortWrapper.SendSerialCommand(String.Format("B{0}++", audioZone, zoneSource));
                        break;

                    case "BASSDOWN":
                        SerialPortWrapper.SendSerialCommand(String.Format("B{0}--", audioZone, zoneSource));
                        break;

                    default:
                        SerialPortWrapper.SendSerialCommand(audioActionName);
                        break;
                }

                //return View("AudioMatrixControl");
                // return new EmptyResult();
                //return new JsonResult();
                //return Json(null, JsonRequestBehavior.AllowGet);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String LearnIRCode()
        {
            return IRWrapper.LearnCode();
        }

        public String SendIRCode(String IRCode, int randomParam)
        {
            return IRWrapper.SendCode(IRCode);
        }
        
        public ActionResult Activities()
        {
            ActivitiesViewModel avm = new ActivitiesViewModel();
            avm.SelectedRoom = HomeActivities.Room.HomeTheater;
            return View(avm);
        }

        public String MyExecuteAction(MyDeviceDatabase.Device device, String actionName)
        {
            try
            {
                MyDeviceDatabase.Action action = MyDeviceDatabase.GetAction(device, actionName);

                String result = String.Empty;

                try
                {
                    foreach (SerialPortWrapper.SerialCommand serCmd in action.SerialCommands)
                    {
                        result += SerialPortWrapper.SendSerialCommand(serCmd) + "<br/>";
                    }
                }
                catch (TimeoutException ex)
                {
                    result += ex.Message + "<br/>";
                }

                if (action.URL != null)
                {
                    WebRequest myRequest = WebRequest.Create(action.URL);
                    myRequest.Credentials = new NetworkCredential("admin", "McAdmin");
                    WebResponse response = myRequest.GetResponse();
                }

                if (action.IRCode != null)
                {
                    result += IRWrapper.SendCode(action.IRCode);
                }

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
