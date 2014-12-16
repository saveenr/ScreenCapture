using System;

namespace ScreenCaptureLib.Interop
{
    public static class WinConst
    {
        public const int WM_HOTKEY = 0x312;
        public const int MOD_ALT = 1;
        public const int MOD_CONTROL = 2;
        public const int MOD_SHIFT = 4;
        public const Int32 CURSOR_SHOWING = 0x00000001;
        public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
    }
}