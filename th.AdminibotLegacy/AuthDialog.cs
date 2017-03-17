using System;
using System.Linq;
using System.Windows.Forms;

namespace th.AdminibotLegacy
{
    public partial class AuthDialog : Form
    {
        public string returnToken { get; set; } 
        
        public AuthDialog()
        {
            InitializeComponent();
        }

        private void adWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Program.Log(adWebBrowser.Url.AbsoluteUri);
            if (adWebBrowser.Url.Authority == "localhost")
            {
                string token = "oauth:" + adWebBrowser.Url.AbsoluteUri.Split('/').Last().Replace("#access_token=", "").Replace("&scope=chat_login", "");
                if (!string.IsNullOrEmpty(token))
                {
                    Hide();
                    adWebBrowser.Navigate("http://www.twitch.tv/logout");
                    this.DialogResult = DialogResult.OK;
                    this.returnToken = token;
                }
            
            }
            else if (adWebBrowser.Url.AbsoluteUri.Contains("/login"))
            {
                adWebBrowser.Navigate("https://api.twitch.tv/kraken/oauth2/authorize?response_type=token&client_id=2n6yqi2ryhkxcg5ccuw9vs4ubri821v&redirect_uri=http%3A%2F%2Flocalhost&scope=chat_login");
            }
            else if (adWebBrowser.Url.Authority == "www.twitch.tv")
            {
                adWebBrowser.Stop();
                Close();
                Program.MainDialog.EnablePasswordButtonUI();
                Dispose();
            }
        }

        private void AuthDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            adWebBrowser.Stop();
            Program.MainDialog.EnablePasswordButtonUI();
        }

        private void adWebBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                Invoke((Action)delegate
                {
                    adStatusStripProgressBar.Maximum = e.MaximumProgress < 0 ? 0 : (int)e.MaximumProgress;
                    adStatusStripProgressBar.Value   = e.CurrentProgress < 0 ? 0 : (int)e.CurrentProgress;
                    adStatusStripLabel.Text = adWebBrowser.StatusText;
                });
            }
            catch (Exception exception)
            {
                Program.ErrorLog(exception, "adWebBrowser_ProgressChanged()");
            }
        }
    }
}
