using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Threading;

namespace TouchPortal.Plugin.HotKey
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists("key.map"))
                File.WriteAllText("key.map", "");

            var listener = new TouchPortalListener(Dispatcher.CurrentDispatcher);
            listener.Connect();

            Application.Run();
        }
    }
}
