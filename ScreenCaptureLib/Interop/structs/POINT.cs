using System;
using System.Runtime.InteropServices;

namespace ScreenCaptureLib.Interop

{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public Int32 x;
        public Int32 y;
    }
}