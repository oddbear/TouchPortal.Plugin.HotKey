using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
using TouchPortal.Plugin.HotKey.Utils;
using TouchPortalSDK;
using TouchPortalSDK.Interfaces;
using TouchPortalSDK.Messages.Events;
using TouchPortalSDK.Messages.Models;
using WK.Libraries.HotkeyListenerNS;

namespace TouchPortal.Plugin.HotKey
{
    public class TouchPortalListener : ITouchPortalEventHandler
    {
        private readonly ITouchPortalClient _client;
        private readonly Dispatcher _dispatcher;
        private readonly HotkeyListener _hotkeyListener;
        private readonly List<HotKeySetup> _hotkeys = new List<HotKeySetup>();

        public string PluginId => "oddbear.touchportal.hotkeys";
        
        public TouchPortalListener(Dispatcher dispatcher)
        {
            _client = TouchPortalFactory.CreateClient(this);
            _dispatcher = dispatcher;

            _hotkeyListener = new HotkeyListener();
            _hotkeyListener.HotkeyPressed += HotkeyListenerOnHotkeyPressed;
        }

        public void Connect()
            => _client.Connect();
        
        public void SettingsChanges(IReadOnlyCollection<Setting> settings)
        {
            _dispatcher.Invoke(() => _hotkeyListener.RemoveAll());
            _hotkeys.Clear();

            foreach (var setting in settings)
            {
                if (string.IsNullOrWhiteSpace(setting.Value))
                    continue;

                if (HotKeyParser.TryConvert(setting.Value, out var hotkey, out var key))
                {
                    _hotkeys.Add(new HotKeySetup
                    {
                        Name = setting.Name,
                        Value = setting.Value,
                        HotKey = hotkey
                    });
                }
                else
                {
                    try
                    {
                        var keyMappings = File.ReadAllLines("key.map");
                        if (keyMappings.All(line => line != "DO_NOT_SHOW_DIALOG"))
                        {
                            ShowForm(key);
                        }
                    }
                    catch
                    {
                        //
                    }
                }
            }

            _dispatcher.Invoke(() =>
            {
                foreach (var hotKeySetup in _hotkeys)
                {
                    try
                    {
                        _hotkeyListener.Add(hotKeySetup.HotKey);
                    }
                    catch
                    {
                        //
                    }
                }
            });
        }

        private void HotkeyListenerOnHotkeyPressed(object sender, HotkeyEventArgs e)
        {
            var key = _hotkeys.FirstOrDefault(k => k.HotKey.Equals(e.Hotkey));
            if (key == null)
                return;

            //Set this to dummy value:
            _client.StateUpdate("oddbear.touchportal.hotkey.state", "none");
            //Then raise event:
            _client.StateUpdate("oddbear.touchportal.hotkey.state", key.Name);
        }

        private void ShowForm(string unknownKey)
        {
            var form = new Form1(unknownKey);

            //Centers the form on top of TouchPortal:
            var result = WinAPI.GetTouchPortalPosition();
            if (result is WindowRect position)
            {
                var tpWidth = position.Right - position.Left;
                var tpHeight = position.Bottom - position.Top;

                form.StartPosition = FormStartPosition.Manual;
                form.Left = position.Left + ((tpWidth - form.Width) / 2);
                form.Top = position.Top + ((tpHeight - form.Height) / 2);
            }

            form.TopMost = true;
            form.BringToFront();
            form.ShowDialog();
        }

        public void OnInfoEvent(InfoEvent message)
            => SettingsChanges(message.Settings);

        public void OnSettingsEvent(SettingsEvent message)
            => SettingsChanges(message.Values);

        //Optional force exits this plugin.
        public void OnClosedEvent(string message)
            => Environment.Exit(0);

        public void OnListChangedEvent(ListChangeEvent message) { /* Ignored */ }

        public void OnBroadcastEvent(BroadcastEvent message) { /* Ignored */ }

        public void OnActionEvent(ActionEvent message) { /* Ignored */ }

        public void OnUnhandledEvent(string jsonMessage) { /* Ignored */ }
    }
}
