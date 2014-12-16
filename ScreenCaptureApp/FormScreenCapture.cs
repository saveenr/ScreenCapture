using System;
using System.Windows.Forms;

namespace ScreenCaptureApp
{
    public partial class FormScreenCapture : Form
    {
        private string about_url = "https://github.com/saveenr";
        private ScreenCaptureLib.ScreenCapture cap_obj = new ScreenCaptureLib.ScreenCapture();

        public ScreenCaptureLib.HotKey m_capfullscreen_hotkey;
        public ScreenCaptureLib.HotKey m_capactivewindow_hotkey;
        public ScreenCaptureLib.HotKey m_caplast_hotkey;

        public bool PlayCaptureSound = true;

        public FormScreenCapture()
        {
            InitializeComponent();

            var tooltip_about = new System.Windows.Forms.ToolTip();
            tooltip_about.SetToolTip(this.linkLabelHome, about_url);
            this.update_capture_count();
            this.RegisterHotKeys();
            this.labelLastCaptureInfo.Text = "";
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            this.cap_obj.m_settings.Command = ScreenCaptureLib.CaptureCommand.CapturePrimaryScreen;
            var old_opacity = this.Opacity;
            
            try
            {
                this.Opacity = 0;
                this.PerformCapture();
            }
            finally
            {
                this.Opacity = old_opacity;
            }
        }
        
        private void update_capture_count()
        {
            this.labelCapturedCount.Text = this.cap_obj.NumCaptured.ToString();
        }

        private void FormScreenCapture_Load(object sender, EventArgs e)
        {
            this.set_capture_folder();
        }
        
        private void set_capture_folder()
        {
            var tooltip = new System.Windows.Forms.ToolTip();
            tooltip.SetToolTip(this.linkLabelCaptureFolder, this.cap_obj.m_settings.GetCaptureFolder());
        }

        private void linkLabelCaptureFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.cap_obj.PrepareCaptureFolder();

            System.Diagnostics.Process.Start("explorer.exe", this.cap_obj.m_settings.GetCaptureFolder());
        }
        
        protected override void WndProc(ref Message m)
        {
            handlehotkeys(ref m);
            base.WndProc(ref m);
        }
        
        protected void handlehotkeys(ref Message m)
        {
            if (m.Msg != ScreenCaptureLib.Interop.WinConst.WM_HOTKEY)
            {
                return;
            }

            int wparam = m.WParam.ToInt32();
            if (wparam == this.m_capfullscreen_hotkey.HotkeyID)
            {
                this.cap_obj.m_settings.Command = ScreenCaptureLib.CaptureCommand.CapturePrimaryScreen;
                this.PerformCapture();
            }
            else if (wparam == this.m_capactivewindow_hotkey.HotkeyID)
            {
                this.cap_obj.m_settings.Command = ScreenCaptureLib.CaptureCommand.CaptureActiveWindow;
                this.PerformCapture();
            }
            else if (wparam == this.m_caplast_hotkey.HotkeyID)
            {
                this.cap_obj.m_settings.Command = ScreenCaptureLib.CaptureCommand.CaptureRepeat;
                this.PerformCapture();
                //MessageBox.Show("Repeat last capture - Not yet implemented.");
            }
        }

        private void FormScreenCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.UnregisterHotkeys();
        }

        private void set_key_text(ScreenCaptureLib.HotKey hotkey, Label label, string text)
        {
            if (hotkey.IsRegistered)
            {
                string msg = string.Format("{0} -> {1}", hotkey.DisplayName, text);
                label.Text = msg;
            }
            else
            {
                string msg = string.Format("Could not register {0} hotkey", hotkey.DisplayName);
                label.Text = msg;
            }
        }

        private void RegisterHotKeys()
        {
            this.m_capfullscreen_hotkey = new ScreenCaptureLib.HotKey(this.Handle, Keys.PrintScreen, 0);
            this.m_capactivewindow_hotkey = new ScreenCaptureLib.HotKey(this.Handle, Keys.PrintScreen, ScreenCaptureLib.HotKeyModifierKey.LEFTALT);
            this.m_caplast_hotkey = new ScreenCaptureLib.HotKey(this.Handle, Keys.PrintScreen, ScreenCaptureLib.HotKeyModifierKey.CONTROL);

            set_key_text(this.m_capfullscreen_hotkey, this.labelCapFullScreenInstruction, "Capture screen");
            set_key_text(this.m_capactivewindow_hotkey, this.labelCapActiveWindowInstruction, "Capture active window");
            set_key_text(this.m_caplast_hotkey, this.labelCapLast, "Repeat last capture");
        }

        private void UnregisterHotkeys()
        {
            this.m_capfullscreen_hotkey.Unregister();
            this.m_capactivewindow_hotkey.Unregister();
        }

        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(about_url);
        }

        private void linkLabelLastCapture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((this.cap_obj.m_current_cap_metadata == null) ||
                (string.IsNullOrEmpty(this.cap_obj.m_current_cap_metadata.Filename)))
            {
                MessageBox.Show("No last capture to show");
                return;
            }

            System.Diagnostics.Process.Start(this.cap_obj.m_current_cap_metadata.Filename);
        }

        public void PerformCapture()
        {
            this.cap_obj.Capture();
            this.update_capture_count();
            var md = this.cap_obj.m_current_cap_metadata;

            if (md.BitmapCaptured)
            {
                string s = string.Format("{0}x{1}", md.SourceRect.Width, md.SourceRect.Height);
                this.labelLastCaptureInfo.Text = s;

                if (this.PlayCaptureSound)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                }
            }
        }
    }
}