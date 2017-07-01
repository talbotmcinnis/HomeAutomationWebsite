using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.Models
{
    public class _804M_Devices
    {
        public static MRC8E AudioMatrix = new MRC8E(1, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 });
    }
}