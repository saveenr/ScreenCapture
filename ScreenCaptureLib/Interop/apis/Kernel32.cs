using System.Runtime.InteropServices;

namespace ScreenCaptureLib.Interop

{
    public class Kernel32
    {
        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);

        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);



    }
}