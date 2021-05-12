# WIP: TouchPortal.Plugin.HotKey
Hotkey Plugin for TouchPortal 2.3+ Windows.

This plugin can be used to bind hotkeys on the keyboard to TouchPortal events that will trigger other actions.

![Settings dialog](./Assets/settings.png)
![Event setup](./Assets/events.png)

This plugin is in a **early stage**, and does have limits when it somes to unicode caracters.

There is a mapper dialog that pops up when there is unknown characters, so you can map them to the "real" keys on the keyboard. Ex. Æ is Oem7.

However, some keys does not work. I have tested Æ Ø Å (norwegian characters), and Ø seems to work after mapping, but not the two others. The simplest is just to use simple characters like A-Z.

### Dependencies

- [HotkeyListener](https://github.com/Willy-Kimura/HotkeyListener) (Might change in the future)
- [TouchPortalSDK](https://github.com/oddbear/TouchPortalSDK)
