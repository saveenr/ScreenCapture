using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using ScreenCaptureLib.Interop;

namespace ScreenCaptureLib
{
    public class ScreenCapture
    {
        public int NumCaptured;

        public CaptureMetaData m_current_cap_metadata;
        public CaptureSettings m_settings = new CaptureSettings();
        private LastCapRegion m_lastcapregion;

        public ScreenCapture()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.NumCaptured = 0;
            this.m_current_cap_metadata = null;
        }


        public CaptureMetaData CaptureInfo
        {
            get
            {
                return this.m_current_cap_metadata;
            }
        }

        public void Capture()
        {

            this.m_current_cap_metadata = new CaptureMetaData();


            using (var bmp = capture_bitmap())
            {

                if (bmp != null)
                {
                    this.m_current_cap_metadata.Command = this.m_settings.Command;
                    this.m_current_cap_metadata.BitmapCaptured = true;
                    this.m_current_cap_metadata.Index = NumCaptured;
                    this.m_current_cap_metadata.TimeCaptured = System.DateTimeOffset.Now;
                    NumCaptured++;

                    //
                    this.m_lastcapregion = new LastCapRegion();
                    this.m_lastcapregion.Screen = this.m_current_cap_metadata.SourceScreen;
                    this.m_lastcapregion.Region = this.m_current_cap_metadata.SourceRect;

                    // Save to disk
                    handle_disk_output(bmp);

                    // put to clipboard
                    handle_clipboard_output(bmp);


                }
            }

        }

        private Bitmap capture_bitmap()
        {
            IntPtr foreground_hwnd = IntPtr.Zero;
            Screen screen = null;
            Rectangle capture_rect = default(Rectangle);



            if (this.m_settings.Command == CaptureCommand.CapturePrimaryScreen)
            {
                foreground_hwnd = IntPtr.Zero;
                screen = Screen.PrimaryScreen;
                capture_rect = screen.Bounds;
            }
            else if (this.m_settings.Command == CaptureCommand.CaptureScreenWithMouse)
            {
                foreground_hwnd = IntPtr.Zero;
                screen = Screen.FromPoint(Cursor.Position);
                capture_rect = screen.Bounds;
            }
            else if (this.m_settings.Command == CaptureCommand.CaptureActiveWindow)
            {
                foreground_hwnd = User32.GetForegroundWindow();
                screen = Screen.FromHandle(foreground_hwnd);
                capture_rect = GetWindowRectangle(foreground_hwnd);
            }
            else if (this.m_settings.Command == CaptureCommand.CaptureRepeat)
            {
                if ( this.m_lastcapregion ==null)
                {
                    return null;
                }

                screen = this.m_lastcapregion.Screen;
                capture_rect = this.m_lastcapregion.Region;
            }

            else
            {
                string msg = string.Format("Unknown source: {0}", this.m_settings.Command);
                throw new CaptureException(msg);
            }

            this.m_current_cap_metadata.SourceScreen = screen;
            this.m_current_cap_metadata.SourceRect = capture_rect;

            const bool capture_mouse = true;
            
            var bmp = DrawingUtil.CaptureScreen(screen, capture_rect, this.m_settings.CapturePixelFormat, capture_mouse);
            return bmp;
        }


        private void handle_disk_output(Bitmap bmp)
        {
            this.PrepareCaptureFolder();
            this.m_current_cap_metadata.SavedToFilesystem = false;
            if (bmp == null)
            {
                return;
            }

            string full_filename = m_settings.GetCaptureFilename(this.m_current_cap_metadata.TimeCaptured,bmp.Size.Width, bmp.Size.Height);
            m_current_cap_metadata.Filename = full_filename;

            try
            {
                bmp.Save(full_filename, System.Drawing.Imaging.ImageFormat.Png);
                this.m_current_cap_metadata.SavedToFilesystem = true;
            }
            catch (System.ArgumentException exc)
            {
                MessageBox.Show(string.Format("Argument Exception {0}", exc.Message));
            }
            catch (System.IO.IOException exc)
            {
                MessageBox.Show(string.Format("IO Exception {0}", exc.Message));
            }
        }

        private void handle_clipboard_output(Bitmap bmp)
        {
            this.m_current_cap_metadata.CopiedToClipboard = false;
            if (bmp == null)
            {
                return;
            }
            if (this.m_settings.CopyToClipboard)
            {
                Clipboard.SetImage(bmp);
                this.m_current_cap_metadata.CopiedToClipboard = true;
            }
        }

        private Rectangle GetWindowRectangle(IntPtr hwnd)
        {
            var window_bounds = User32.GetWindowRect(hwnd);
            var window_placement = User32.GetWindowPlacement(hwnd);
            var size = new Size(window_bounds.right - window_bounds.left, window_bounds.bottom - window_bounds.top);

            Point p0 = (window_placement.showCmd == (int)WindowState.SW_SHOWMAXIMIZED)
                           ?
                               window_placement.ptMaxPosition
                           : window_placement.rcNormalPosition.Location;


            if ((p0.X + size.Width) > Screen.PrimaryScreen.WorkingArea.Width)
            {
                size.Width = size.Width - ((p0.X + size.Width) - Screen.PrimaryScreen.WorkingArea.Width);
            }

            if ((p0.Y + size.Height) > Screen.PrimaryScreen.WorkingArea.Height)
            {
                size.Height = size.Height - ((p0.Y + size.Height) - Screen.PrimaryScreen.WorkingArea.Height);
            }

            return new System.Drawing.Rectangle(p0, size);
        }



        public void PrepareCaptureFolder()
        {
            var f = this.m_settings.GetCaptureFolder();
            if (!System.IO.Directory.Exists(f))
            {
                System.IO.Directory.CreateDirectory(f);
            }
        }
    }
}