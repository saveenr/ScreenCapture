using System;
using System.Drawing.Imaging;
using System.IO;

namespace ScreenCaptureLib
{
    public class CaptureSettings
    {
        // capture process
        public CaptureCommand Command = CaptureCommand.CapturePrimaryScreen;

        // clipboard output settings
        public bool CopyToClipboard = true;

        // bitmap format options
        public PixelFormat CapturePixelFormat = PixelFormat.Format32bppArgb;


        // file output settings
        public string GetCaptureFolder()
        {
            string mypics = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string name = string.Format("Screen_Captures");
            return Path.Combine(mypics, name);
        }

        public string GetCaptureFilename(System.DateTimeOffset dt, int w, int h)
        {
            // construct output filename
            string time_string = dt.ToString("(yyyy_MM_dd_hh_mm_ss)");
            string dim = String.Format("({0}x{1})", w, h);
            string path = GetCaptureFolder();
            string fname = "screenshot_" + time_string + "_" + dim + ".png";
            string full_filename = Path.Combine(path, fname);

            return full_filename;
        }
    }
}