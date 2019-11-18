using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;

namespace MSTnTAPP.Helpers
{
    class CommonHelper
    {
        //==== Constants ===
        private static string fileName = "LogMVT.txt";
        private static int log_level = 3; //--- 1:Error 2:Warning 3:Debug
        //public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:60205" : "http://localhost:60205";
        public static string BaseAddress = "http://192.168.100.2";
        public static string DataServiceUrl = BaseAddress + "/api/{0}/{1}";

        public static void WriteLog(string msg, int level)
        {
            System.Diagnostics.Debug.WriteLine("======================");
            System.Diagnostics.Debug.WriteLine(msg);
            if (level <= log_level)
            {
                string logFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
                //System.Diagnostics.Debug.WriteLine(logFile);

                using (var writer = new StreamWriter(logFile))
                {
                    writer.WriteLine(msg);
                }
            }
        }

    }
}
