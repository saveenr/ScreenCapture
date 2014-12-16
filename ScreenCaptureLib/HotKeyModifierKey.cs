using System;
using ScreenCaptureLib.Interop;

namespace ScreenCaptureLib
{
    [Flags]
    public enum HotKeyModifierKey
    {
        CONTROL = WinConst.MOD_CONTROL,
        LEFTALT=WinConst.MOD_ALT,
        SHIFT = WinConst.MOD_SHIFT
    }
}