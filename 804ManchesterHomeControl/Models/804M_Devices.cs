using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.Models
{
    public class _804M_Devices
    {
        public static MRC8E AudioMatrix = new MRC8E(int.Parse(ConfigurationManager.AppSettings["MRC8EComPort"]), new Dictionary<int, double>()
        {
            { 1, 1.0 },
            { 2, 1.0 },
            { 3, 1.0 },
            { 4, 1.0 },
            { 5, 1.0 },
            { 6, 0.5 }
        });
    }
}