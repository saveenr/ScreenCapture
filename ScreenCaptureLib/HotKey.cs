using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ScreenCaptureLib.Interop;

namespace ScreenCaptureLib
{
    public class HotKey : IDisposable
    {
        private bool m_registered;

        private readonly Atom m_atom;
        private readonly string m_displayname;

        public readonly Keys Key;
        public readonly IntPtr WindowHandle;
        public readonly HotKeyModifierKey Modifier;

        /// <summary>
        /// Creates a new hotkey
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="key"></param>
        /// <param name="modifier"></param>
        public HotKey(IntPtr hwnd, Keys key, HotKeyModifierKey modifier)
        {
            this.m_atom = new Atom();
            this.Key = key;
            this.WindowHandle = hwnd;
            this.Modifier = modifier;
            this.m_displayname = this.get_display_name();
            this.Register();
        }

        public string AtomName
        {
            get { return this.m_atom.Name; }
        }

        public string DisplayName
        {
            get { return this.m_displayname; }
        }

        /// <summary>
        /// Returns a user-readable descriptive name for the hotkey
        /// </summary>
        /// <returns></returns>
        private string get_display_name()
        {
            var tokens = new List<string>(5);
            if ((this.Modifier & HotKeyModifierKey.SHIFT) > 0)
            {
                tokens.Add("SHIFT");
            }
            if ((this.Modifier & HotKeyModifierKey.CONTROL) > 0)
            {
                tokens.Add("CONTROL");
            }
            if ((this.Modifier & HotKeyModifierKey.LEFTALT) > 0)
            {
                tokens.Add("LEFTALT");
            }
            tokens.Add(this.Key.ToString());
            return string.Join(" ", tokens.ToArray());
        }

        /// <summary>
        /// Registers the hotkey
        /// </summary>
        public void Register()
        {
            if (this.IsRegistered)
            {
                return;
            }
            int mod = (int) this.Modifier;
            int status = User32.RegisterHotKey(this.WindowHandle, this.HotkeyID, mod,
                                                                                this.Key);

            if (status == 0)
            {
                // failed to register
                this.m_registered = false;
            }
            else
            {
                // sucessfully registered
                this.m_registered = true;
            }
        }

        /// <summary>
        /// Unregisters the hotkey
        /// </summary>
        public void Unregister()
        {
            if (!this.IsRegistered)
            {
                return;
            }


            this.m_registered = false;

            this.m_atom.Unregister();
        }
        
        /// <summary>
        /// Will unregister the hotkey if needed
        /// </summary>
        public void Dispose()
        {
            this.Unregister();
        }

        /// <summary>
        /// Identifies whether the hotkey is current registered
        /// </summary>
        public bool IsRegistered
        {
            get { return this.m_registered; }
        }

        public short HotkeyID
        {
            get { return this.m_atom.AtomID; }
        }
    }
}