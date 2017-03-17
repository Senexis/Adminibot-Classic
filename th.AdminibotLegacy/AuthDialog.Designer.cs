using System.ComponentModel;
using System.Windows.Forms;

namespace th.AdminibotLegacy
{
    partial class AuthDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthDialog));
            this.adWebBrowser = new System.Windows.Forms.WebBrowser();
            this.adStatusStrip = new System.Windows.Forms.StatusStrip();
            this.adStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.adStatusStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.adTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.adStatusStrip.SuspendLayout();
            this.adTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // adWebBrowser
            // 
            this.adWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adWebBrowser.Location = new System.Drawing.Point(3, 3);
            this.adWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.adWebBrowser.Name = "adWebBrowser";
            this.adWebBrowser.ScriptErrorsSuppressed = true;
            this.adWebBrowser.Size = new System.Drawing.Size(398, 434);
            this.adWebBrowser.TabIndex = 0;
            this.adWebBrowser.Url = new System.Uri("https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=2n6yq" +
        "i2ryhkxcg5ccuw9vs4ubri821v&redirect_uri=http%3A%2F%2Flocalhost&scope=chat_login", System.UriKind.Absolute);
            this.adWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.adWebBrowser_DocumentCompleted);
            this.adWebBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.adWebBrowser_ProgressChanged);
            // 
            // adStatusStrip
            // 
            this.adStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adStatusStripLabel,
            this.adStatusStripProgressBar});
            this.adStatusStrip.Location = new System.Drawing.Point(0, 440);
            this.adStatusStrip.Name = "adStatusStrip";
            this.adStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.adStatusStrip.Size = new System.Drawing.Size(404, 22);
            this.adStatusStrip.SizingGrip = false;
            this.adStatusStrip.TabIndex = 3;
            // 
            // adStatusStripLabel
            // 
            this.adStatusStripLabel.Name = "adStatusStripLabel";
            this.adStatusStripLabel.Size = new System.Drawing.Size(272, 17);
            this.adStatusStripLabel.Spring = true;
            this.adStatusStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // adStatusStripProgressBar
            // 
            this.adStatusStripProgressBar.Margin = new System.Windows.Forms.Padding(1, 3, 4, 3);
            this.adStatusStripProgressBar.MarqueeAnimationSpeed = 0;
            this.adStatusStripProgressBar.Name = "adStatusStripProgressBar";
            this.adStatusStripProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adStatusStripProgressBar.Size = new System.Drawing.Size(125, 16);
            // 
            // adTableLayoutPanel
            // 
            this.adTableLayoutPanel.ColumnCount = 1;
            this.adTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adTableLayoutPanel.Controls.Add(this.adWebBrowser, 0, 0);
            this.adTableLayoutPanel.Controls.Add(this.adStatusStrip, 0, 1);
            this.adTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.adTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.adTableLayoutPanel.Name = "adTableLayoutPanel";
            this.adTableLayoutPanel.RowCount = 2;
            this.adTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.adTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.adTableLayoutPanel.Size = new System.Drawing.Size(404, 462);
            this.adTableLayoutPanel.TabIndex = 4;
            // 
            // AuthDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 462);
            this.Controls.Add(this.adTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthDialog";
            this.Text = "Twitch Authentication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthDialog_FormClosing);
            this.adStatusStrip.ResumeLayout(false);
            this.adStatusStrip.PerformLayout();
            this.adTableLayoutPanel.ResumeLayout(false);
            this.adTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WebBrowser adWebBrowser;
        private StatusStrip adStatusStrip;
        private ToolStripStatusLabel adStatusStripLabel;
        private ToolStripProgressBar adStatusStripProgressBar;
        private TableLayoutPanel adTableLayoutPanel;
    }
}