using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace ScreenCaptureLib.Interop

{
    public class User32
    {
        //http://msdn.microsoft.com/en-us/library/ms646309.aspx
        [DllImport("user32", SetLastError = true)]
        public static extern int RegisterHotKey(IntPtr hWnd, int id, int modifier, System.Windows.Forms.Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out CURSORINFO pci);

        public static CURSORINFO GetCursorInfo()
        {
            // Fill the cursor info struct
            CURSORINFO cursor_info;
            cursor_info.cbSize = Marshal.SizeOf(typeof (CURSORINFO));
            if (!User32.GetCursorInfo(out cursor_info))
            {
                throw new Exception("Failed to get cursor info");
            }
            return cursor_info;
        }

        [DllImport("user32.dll")]
        public static extern IconHandle CopyIcon(IntPtr hIcon);


        [DllImport("user32.dll")]
        public static extern bool GetIconInfo(IconHandle hIcon, out ICONINFO piconinfo);

        public static ICONINFO GetIconInfo(IconHandle hIcon)
        {
            ICONINFO iconinfo;
            if (!User32.GetIconInfo(hIcon, out iconinfo))
            {
                throw new Exception("Failed to get icon info");
            }
            return iconinfo;
        }

        [DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr GetDesktopWindow();

        [SuppressUnmanagedCodeSecurity, SecurityCritical,
         DllImport("user32.dll", EntryPoint = "DestroyIcon", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DestroyIcon(IntPtr hIcon);


        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

        public static RECT GetWindowRect(IntPtr hWnd)
        {
            var window_bounds = new Interop.RECT();
            User32.GetWindowRect(hWnd, ref window_bounds);
            return window_bounds;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);


        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, System.Text.StringBuilder title, int size);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(int hWnd);

        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(int hWndParent, EnumWindowsProc ewp, int lParam);

        // delegate used for EnumWindows() callback function
        public delegate bool EnumWindowsProc(int hWnd, int lParam);



        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        public static WINDOWPLACEMENT GetWindowPlacement( IntPtr hWnd )
        {
            var window_placement = new Interop.WINDOWPLACEMENT();
            Interop.User32.GetWindowPlacement(hWnd, ref window_placement);
            return window_placement;
        }
    }
}