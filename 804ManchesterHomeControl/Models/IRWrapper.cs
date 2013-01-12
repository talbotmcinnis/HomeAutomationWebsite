using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UsbUirt;

namespace _804ManchesterHomeControl.Models
{
    public class IRWrapper
    {
        static Controller m_irc;
        
        private static double LEARN_TIMEOUT_S = 30;

        public static void Initialize()
        {
            if (Controller.DriverVersion != 0x0100)
                throw new ApplicationException(String.Format("Unexpected Driver Version (0x%08X)", Controller.DriverVersion));

            m_irc = new Controller();

            m_irc.BlinkOnReceive = true;
            m_irc.BlinkOnTransmit = true;
        }

        public static void Uninitialize()
        {
            m_irc.Dispose();
            m_irc = null;
        }

        public static String LearnCode()
        {
            if (m_irc == null)
                Initialize();

            String learnedCode = m_irc.Learn(CodeFormat.Pronto, LearnCodeModifier.None, TimeSpan.FromSeconds(LEARN_TIMEOUT_S));
            if (!String.IsNullOrEmpty(learnedCode))
                return learnedCode;
            else
                return "Code Not Learned";
        }

        internal static string SendCode(string irCode)
        {
            if (m_irc == null)
                Initialize();


            m_irc.Transmit(irCode, CodeFormat.Pronto, 10, TimeSpan.Zero);
            //System.Threading.Thread.Sleep(100);
            //m_irc.Transmit(irCode, CodeFormat.Pronto, 1, TimeSpan.Zero);

            return "Code sent";
        }
    }
}