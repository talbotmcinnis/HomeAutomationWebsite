using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _804ManchesterHomeControl.Models;
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

        public string AudioOff()
        {
            try
            {
                _804M_Devices.AudioMatrix.AllZonesOff();
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string AudioOn_Matrix()
        {
            try
            {
                _804M_Devices.AudioMatrix.AllZonesOn();
                _804M_Devices.AudioMatrix.AllZonesSource(1);
                _804M_Devices.AudioMatrix.AllZonesVolume(100);
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string AudioOn_AirPlay()
        {
            try
            {
                _804M_Devices.AudioMatrix.AllZonesOn();
                _804M_Devices.AudioMatrix.AllZonesSource(2);
                _804M_Devices.AudioMatrix.AllZonesVolume(100);
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
