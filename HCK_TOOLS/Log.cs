using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCK_TOOLS
{
    public static class Log
    {
        public static void WriteLog(string pMessage)
        {
            string logPath = AppDomain.CurrentDomain.BaseDirectory + "/" + DateTime.Today.ToShortDateString();

            if (!File.Exists(logPath))
            {
                File.Create(logPath);
            }

            using (StreamWriter sw = new StreamWriter(logPath))
            {
                sw.WriteLine(DateTime.Now.ToShortDateString() + " - " + pMessage);
            }
        }

        public static void WriteLog(Exception pEx)
        {
            string logPath = AppDomain.CurrentDomain.BaseDirectory + "/" + DateTime.Today.ToShortDateString();

            if (!File.Exists(logPath))
            {
                File.Create(logPath);
            }

            using (StreamWriter sw = new StreamWriter(logPath))
            {
                sw.WriteLine(DateTime.Now.ToShortDateString() + " - " + pEx.Message
                    + Environment.NewLine + pEx.InnerException
                    + Environment.NewLine + pEx.StackTrace);
            }
        }
    }
}
