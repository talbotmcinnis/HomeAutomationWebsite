using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Security;

namespace _804ManchesterHomeControl.Models
{
    public class WMPWrapper
    {
        public static void OpenURL(String url)
        {
            // WMP doesn't open the URL from home... but IE passes it on, so... good enough!
            //ProcessStartInfo psi = new ProcessStartInfo("iexplore.exe", url);
            SecureString ssPWD = new SecureString();
            foreach (char c in "trustno1")
                ssPWD.AppendChar(c);
            System.Diagnostics.Process.Start("iexplore.exe", url, "Talbot McInnis", ssPWD, "804M_HTPC");
        }
    }
}