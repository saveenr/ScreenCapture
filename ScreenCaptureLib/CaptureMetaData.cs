using System.Drawing;

namespace ScreenCaptureLib
{
    public class CaptureMetaData
    {
        // File Output info
        public string Filename;
        public bool SavedToFilesystem;

        // Clipboard Output info
        public bool CopiedToClipboard;

        // Information about capture process
        public int Index;
        //public Size Size;
        public System.DateTimeOffset TimeCaptured;
        public bool BitmapCaptured;


        // Information about the Command of the Capture
        public CaptureCommand Command;
        public Rectangle SourceRect;
        public System.Windows.Forms.Screen SourceScreen;
    }
}