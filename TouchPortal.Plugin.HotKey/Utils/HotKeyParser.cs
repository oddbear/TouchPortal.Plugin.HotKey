using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using WK.Libraries.HotkeyListenerNS;

namespace TouchPortal.Plugin.HotKey.Utils
{
    public static class HotKeyParser
    {
        //Modified from HotkeyListener: Try convert instead of convert:
        public static bool TryConvert(string hotkey, out Hotkey hotKey, out string key)
        {
            var modifiers = Keys.None;

            hotkey = hotkey.Replace(" ", "");
            hotkey = hotkey.Replace(",", "");
            hotkey = hotkey.Replace("+", "");
            
            if (hotkey.Contains("Control", StringComparison.OrdinalIgnoreCase) ||
                hotkey.Contains("Ctrl", StringComparison.OrdinalIgnoreCase))
            {
                modifiers |= Keys.Control;
                hotkey = Regex.Replace(hotkey, "Control", "", RegexOptions.IgnoreCase);
            }

            if (hotkey.Contains("Shift", StringComparison.OrdinalIgnoreCase))
            {
                modifiers |= Keys.Shift;
                hotkey = Regex.Replace(hotkey, "Shift", "", RegexOptions.IgnoreCase);
            }

            if (hotkey.Contains("Alt", StringComparison.OrdinalIgnoreCase))
            {
                modifiers |= Keys.Alt;
                hotkey = Regex.Replace(hotkey, "Alt", "", RegexOptions.IgnoreCase);
            }

            key = hotkey.Trim();

            var lines = File.ReadAllLines("key.map");
            foreach (var line in lines)
            {
                var index = line.IndexOf('=');
                if (index == -1)
                    continue;

                //Replace key:
                var trueKey = line.Substring(0, index);
                var falseKey = line.Substring(index + 1);
                if (key == falseKey)
                {
                    key = trueKey;
                }
            }

            if (Enum.TryParse<Keys>(key, true, out var keyCode))
            {
                hotKey = new Hotkey(modifiers, keyCode);
                return true;
            }
            else
            {
                hotKey = new Hotkey(modifiers, Keys.None);
                return false;
            }
        }

        private static Key GetKey(string value)
        {
            if (Enum.TryParse(value, true, out Key key))
                return key;

            value = value?.ToLower();
            switch (value)
            {
                //Can be fetched with the KeySelector:
                case "æ": return Key.Oem7;
                case "ø": return Key.OemTilde;
                case "å": return Key.Oem6;
                default:
                    return Key.None;
            }
        }
    }
}
