using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortal.Plugin.HotKey.Utils
{
    public static class WinAPI
    {
        public static WindowRect? GetTouchPortalPosition()
        {
            var process = Process
                .GetProcesses()
                .Where(m => m.ProcessName == "javaw")
                .Where(m => m.MainWindowTitle == "Touch Portal")
                .SingleOrDefault();

            if(process is null)
                return default;

            return GetWindowRect(process.MainWindowHandle, out var window)
                ? window
                : default;
        }



        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, out WindowRect rectangle);
    }

    public struct WindowRect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
}
