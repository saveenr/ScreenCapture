namespace ScreenCaptureApp
{
    partial class FormScreenCapture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScreenCapture));
            this.buttonCapture = new System.Windows.Forms.Button();
            this.linkLabelCaptureFolder = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCaptures = new System.Windows.Forms.TabPage();
            this.labelLastCaptureInfo = new System.Windows.Forms.Label();
            this.labelCapturedCount = new System.Windows.Forms.Label();
            this.linkLabelLastCapture = new System.Windows.Forms.LinkLabel();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.labelClipboardInstructions = new System.Windows.Forms.Label();
            this.labelCapLast = new System.Windows.Forms.Label();
            this.labelCapActiveWindowInstruction = new System.Windows.Forms.Label();
            this.labelCapFullScreenInstruction = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkLabelHome = new System.Windows.Forms.LinkLabel();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageCaptures.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCapture
            // 
            this.buttonCapture.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCapture.Location = new System.Drawing.Point(4, 6);
            this.buttonCapture.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(90, 90);
            this.buttonCapture.TabIndex = 0;
            this.buttonCapture.Text = "CAPTURE";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // linkLabelCaptureFolder
            // 
            this.linkLabelCaptureFolder.AutoSize = true;
            this.linkLabelCaptureFolder.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabelCaptureFolder.Location = new System.Drawing.Point(98, 9);
            this.linkLabelCaptureFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelCaptureFolder.Name = "linkLabelCaptureFolder";
            this.linkLabelCaptureFolder.Size = new System.Drawing.Size(126, 13);
            this.linkLabelCaptureFolder.TabIndex = 3;
            this.linkLabelCaptureFolder.TabStop = true;
            this.linkLabelCaptureFolder.Text = "Explore captures folder";
            this.linkLabelCaptureFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCaptureFolder_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCaptures);
            this.tabControl1.Controls.Add(this.tabPageInformation);
            this.tabControl1.Location = new System.Drawing.Point(11, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(318, 141);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageCaptures
            // 
            this.tabPageCaptures.Controls.Add(this.labelLastCaptureInfo);
            this.tabPageCaptures.Controls.Add(this.labelCapturedCount);
            this.tabPageCaptures.Controls.Add(this.linkLabelLastCapture);
            this.tabPageCaptures.Controls.Add(this.linkLabelCaptureFolder);
            this.tabPageCaptures.Controls.Add(this.buttonCapture);
            this.tabPageCaptures.Location = new System.Drawing.Point(4, 22);
            this.tabPageCaptures.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageCaptures.Name = "tabPageCaptures";
            this.tabPageCaptures.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageCaptures.Size = new System.Drawing.Size(310, 115);
            this.tabPageCaptures.TabIndex = 0;
            this.tabPageCaptures.Text = "CAPTURES";
            this.tabPageCaptures.UseVisualStyleBackColor = true;
            // 
            // labelLastCaptureInfo
            // 
            this.labelLastCaptureInfo.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelLastCaptureInfo.Location = new System.Drawing.Point(111, 99);
            this.labelLastCaptureInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastCaptureInfo.Name = "labelLastCaptureInfo";
            this.labelLastCaptureInfo.Size = new System.Drawing.Size(195, 13);
            this.labelLastCaptureInfo.TabIndex = 7;
            this.labelLastCaptureInfo.Text = "<last cap info>";
            this.labelLastCaptureInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCapturedCount
            // 
            this.labelCapturedCount.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelCapturedCount.Location = new System.Drawing.Point(257, 9);
            this.labelCapturedCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCapturedCount.Name = "labelCapturedCount";
            this.labelCapturedCount.Size = new System.Drawing.Size(49, 13);
            this.labelCapturedCount.TabIndex = 6;
            this.labelCapturedCount.Text = "###";
            this.labelCapturedCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // linkLabelLastCapture
            // 
            this.linkLabelLastCapture.AutoSize = true;
            this.linkLabelLastCapture.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabelLastCapture.Location = new System.Drawing.Point(98, 22);
            this.linkLabelLastCapture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelLastCapture.Name = "linkLabelLastCapture";
            this.linkLabelLastCapture.Size = new System.Drawing.Size(99, 13);
            this.linkLabelLastCapture.TabIndex = 4;
            this.linkLabelLastCapture.TabStop = true;
            this.linkLabelLastCapture.Text = "Open last capture";
            this.linkLabelLastCapture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLastCapture_LinkClicked);
            // 
            // tabPageInformation
            // 
            this.tabPageInformation.Controls.Add(this.labelClipboardInstructions);
            this.tabPageInformation.Controls.Add(this.labelCapLast);
            this.tabPageInformation.Controls.Add(this.labelCapActiveWindowInstruction);
            this.tabPageInformation.Controls.Add(this.labelCapFullScreenInstruction);
            this.tabPageInformation.Controls.Add(this.labelVersion);
            this.tabPageInformation.Controls.Add(this.linkLabelHome);
            this.tabPageInformation.Controls.Add(this.labelAuthor);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageInformation.Size = new System.Drawing.Size(310, 115);
            this.tabPageInformation.TabIndex = 1;
            this.tabPageInformation.Text = "HELP";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // labelClipboardInstructions
            // 
            this.labelClipboardInstructions.AutoSize = true;
            this.labelClipboardInstructions.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelClipboardInstructions.Location = new System.Drawing.Point(7, 90);
            this.labelClipboardInstructions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClipboardInstructions.Name = "labelClipboardInstructions";
            this.labelClipboardInstructions.Size = new System.Drawing.Size(198, 13);
            this.labelClipboardInstructions.TabIndex = 9;
            this.labelClipboardInstructions.Text = "Captures are copied to the Clipboard";
            // 
            // labelCapLast
            // 
            this.labelCapLast.AutoSize = true;
            this.labelCapLast.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelCapLast.Location = new System.Drawing.Point(7, 75);
            this.labelCapLast.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCapLast.Name = "labelCapLast";
            this.labelCapLast.Size = new System.Drawing.Size(169, 13);
            this.labelCapLast.TabIndex = 8;
            this.labelCapLast.Text = "<Instruction Text Last Capture>";
            // 
            // labelCapActiveWindowInstruction
            // 
            this.labelCapActiveWindowInstruction.AutoSize = true;
            this.labelCapActiveWindowInstruction.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelCapActiveWindowInstruction.Location = new System.Drawing.Point(7, 59);
            this.labelCapActiveWindowInstruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCapActiveWindowInstruction.Name = "labelCapActiveWindowInstruction";
            this.labelCapActiveWindowInstruction.Size = new System.Drawing.Size(182, 13);
            this.labelCapActiveWindowInstruction.TabIndex = 7;
            this.labelCapActiveWindowInstruction.Text = "<Instruction Text Active Window>";
            // 
            // labelCapFullScreenInstruction
            // 
            this.labelCapFullScreenInstruction.AutoSize = true;
            this.labelCapFullScreenInstruction.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelCapFullScreenInstruction.Location = new System.Drawing.Point(7, 44);
            this.labelCapFullScreenInstruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCapFullScreenInstruction.Name = "labelCapFullScreenInstruction";
            this.labelCapFullScreenInstruction.Size = new System.Drawing.Size(161, 13);
            this.labelCapFullScreenInstruction.TabIndex = 5;
            this.labelCapFullScreenInstruction.Text = "<Instruction Text Full Screen>";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(7, 21);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(82, 13);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Version 0.6.0.8";
            // 
            // linkLabelHome
            // 
            this.linkLabelHome.AutoSize = true;
            this.linkLabelHome.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabelHome.Location = new System.Drawing.Point(256, 7);
            this.linkLabelHome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelHome.Name = "linkLabelHome";
            this.linkLabelHome.Size = new System.Drawing.Size(39, 13);
            this.linkLabelHome.TabIndex = 1;
            this.linkLabelHome.TabStop = true;
            this.linkLabelHome.Text = "About";
            this.linkLabelHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHome_LinkClicked);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(7, 7);
            this.labelAuthor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(120, 13);
            this.labelAuthor.TabIndex = 0;
            this.labelAuthor.Text = "Author: Saveen Reddy";
            // 
            // FormScreenCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 163);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FormScreenCapture";
            this.Text = "Screen Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormScreenCapture_FormClosing);
            this.Load += new System.EventHandler(this.FormScreenCapture_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCaptures.ResumeLayout(false);
            this.tabPageCaptures.PerformLayout();
            this.tabPageInformation.ResumeLayout(false);
            this.tabPageInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.LinkLabel linkLabelCaptureFolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCaptures;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.LinkLabel linkLabelHome;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelCapFullScreenInstruction;
        private System.Windows.Forms.Label labelCapturedCount;
        private System.Windows.Forms.LinkLabel linkLabelLastCapture;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCapActiveWindowInstruction;
        private System.Windows.Forms.Label labelCapLast;
        private System.Windows.Forms.Label labelLastCaptureInfo;
        private System.Windows.Forms.Label labelClipboardInstructions;
    }
}

