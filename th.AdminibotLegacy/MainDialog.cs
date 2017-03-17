using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using th.AdminibotLegacy.Properties;
// ReSharper disable LocalizableElement

namespace th.AdminibotLegacy
{
    public partial class MainDialog : Form
    {
        private Thread _addUserRangeThread;
        private bool _startButtonPressed = false;
            
        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("User32.dll")]
        public extern static bool GetScrollRange(IntPtr hWnd, int nBar, out int nMin, out int nMax);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int nBar, ref ScrollInfo lpsi);

        [DllImport("User32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        #region UI Functions
        public void UpdateStatusTextUI(string message)
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                mdStatusStripLabel.Text = DateTime.Now.ToLongTimeString() + " - " + message;
            });
        }

        public void UpdateDebugTextUI(string message)
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                string currentText = mdTabDebugLogTextBox.Text;

                message = string.IsNullOrEmpty(currentText) ? message : Environment.NewLine + message;
                mdTabDebugLogTextBox.SelectionFont = mdTabDebugLogTextBox.Font;
                mdTabDebugLogTextBox.AppendText(message);
            });
        }

        public void UpdateChatTextUI(string message)
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                string currentText = mdTabChatMessageTextBox.Text;

                message = Rtf.RtfHeader + Rtf.ColorTable + (!string.IsNullOrEmpty(currentText) ? @"\line" : "") +
                          message + Rtf.RtfFooter;

                if ((mdTabChatMessageTextBox.Text + message).Length >= Int32.MaxValue/2 - 512)
                {
                    mdTabChatMessageTextBox.Text = "";
                    mdTabChatMessageTextBox.SelectedRtf = Rtf.RtfHeader + Rtf.ColorTable + Rtf.RtfFooter;
                }

                mdTabChatMessageTextBox.Select(mdTabChatMessageTextBox.TextLength, 0);
                mdTabChatMessageTextBox.SelectedRtf = message;

                if (GetScrollPos(mdTabChatMessageTextBox) >= 80)
                {
                    if (!mdTabChatMessageTextBox.Focused)
                    {
                        mdTabChatMessageTextBox.SelectionStart = mdTabChatMessageTextBox.TextLength;
                        mdTabChatMessageTextBox.ScrollToCaret();
                    }
                }
                else
                {
                    int nPos = GetRawScrollPos(mdTabChatMessageTextBox);
                    SetRawScrollPos(mdTabChatMessageTextBox, nPos);
                }
            });
        }

        public void EnableProgressBarUI()
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                mdStatusStripProgressBar.Visible = true;
                mdStatusStripProgressBar.MarqueeAnimationSpeed = 25;
                mdStatusStripProgressBar.Style = ProgressBarStyle.Marquee;
            });
        }

        public void EnablePasswordButtonUI()
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                mdTabConnectPasswordButton.Enabled = true;
            });
        }

        public void DisableProgressBarUI()
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                mdStatusStripProgressBar.Visible = false;
                mdStatusStripProgressBar.MarqueeAnimationSpeed = 0;
                mdStatusStripProgressBar.Style = ProgressBarStyle.Marquee;
            });
        }

        public void IncreaseProgressBarUI()
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                Program.MainDialog.mdStatusStripProgressBar.Style = ProgressBarStyle.Continuous;
                Program.MainDialog.mdStatusStripProgressBar.Value++;
            });
        }

        public void InitProgressBarUI(int maximum)
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                Program.MainDialog.mdStatusStripProgressBar.Style = ProgressBarStyle.Continuous;
                Program.MainDialog.mdStatusStripProgressBar.Value = 0;
                Program.MainDialog.mdStatusStripProgressBar.Maximum = maximum;
            });
        }

        public void EnableTabsUI()
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                Program.MainDialog.mdTabControl.SelectedIndex = 1;

                Program.MainDialog.mdTabConnect.Enabled = false;
                Program.MainDialog.mdTabChat.Enabled = true;
                Program.MainDialog.mdTabOptions.Enabled = true;
                Program.MainDialog.mdTabStream.Enabled = true;
                Program.MainDialog.mdTabCommands.Enabled = true;
                Program.MainDialog.mdTabDatabase.Enabled = true;

                Program.MainDialog.mdTabStreamWebBrowser.Url = new Uri("http://www.twitch.tv/" + Settings.Default.OptionChannel.ToLower() + "/popout");

                Program.MainDialog.InitDatabaseView();
            });
        }

        public void DisableTabsUI()
        {
            Program.MainDialog.SafeInvoke(() =>
            {
                Program.MainDialog.mdTabControl.SelectedIndex = 0;

                Program.MainDialog.mdTabConnect.Enabled = true;
                Program.MainDialog.mdTabChat.Enabled = false;
                Program.MainDialog.mdTabOptions.Enabled = false;
                Program.MainDialog.mdTabStream.Enabled = false;
                Program.MainDialog.mdTabCommands.Enabled = false;
                Program.MainDialog.mdTabDatabase.Enabled = false;

                Program.MainDialog.mdTabStreamWebBrowser.Url = null;
            });
        }
        #endregion
        
        public MainDialog()
        {
            InitializeComponent();

            mdTabChatViewerList.ListViewItemSorter = new ListViewItemMultiSort();

            mdTabConnectNameBox.Text = Settings.Default.OptionName;
            mdTabConnectPasswordBox.Text = Settings.Default.OptionPassword;
            mdTabConnectChannelBox.Text = Settings.Default.OptionChannel;
            mdTabChatHideBotCheckbox.Checked = Settings.Default.OptionHideBotMsg;
            mdTabChatHideStatusCheckbox.Checked = Settings.Default.OptionHideStatusMsg;
            mdTabOptionsEnableBtagCheckbox.Checked = Settings.Default.OptionComBtagEnabled;
            mdTabOptionsEnableTimeCheckbox.Checked = Settings.Default.OptionComTimeEnabled;
            mdTabOptionsEnablePointsCheckbox.Checked = Settings.Default.OptionComPointsEnabled;
            mdTabOptionsBtagCharNumeric.Value = Settings.Default.OptionComBtagMaxChars;

            mdTabChat.Enabled = false;
            mdTabOptions.Enabled = false;
            mdTabStream.Enabled = false;
            mdTabCommands.Enabled = false;
            mdTabDatabase.Enabled = false;
            mdTabStreamWebBrowser.Url = null;

            UpdateStreamInfo();
            mdTabStreamTimer.Start();
            
            ImageList imageList = new ImageList();
            foreach (Types.UserLevel level in Enum.GetValues(typeof(Types.UserLevel)))
            {
                var img = Resources.ResourceManager.GetObject(level.ToString());
                if (img != null)
                {
                    imageList.Images.Add(level.ToString(), (Image)img);
                }
            }
            mdTabChatViewerList.SmallImageList = imageList;

            Rtf.ColorTable = @"{\colortbl;";

            foreach (var color in Rtf.Colors)
            {
                Rtf.ColorTable += @"\red" + ((Color)color.Value[1]).R +
                              @"\green" + ((Color)color.Value[1]).G +
                              @"\blue" + ((Color)color.Value[1]).B +
                              @";";

            }

            Rtf.ColorTable += "}";

            string path = Environment.CurrentDirectory + @"\cache";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (Types.UserLevel lvl in Enum.GetValues(typeof (Types.UserLevel)))
            {
                mdTabDatabaseViewUser.Groups.Add(lvl.ToString().ToLower(), lvl.ToString());
            }

            foreach (Types.CommandLevel lvl in Enum.GetValues(typeof (Types.CommandLevel)))
            {
                mdTabDatabaseViewCommand.Groups.Add(lvl.ToString().ToLower(), lvl.ToString());
            }

            AcceptButton = mdTabConnectStartButton;
        }

        private void mdTabConnectStartButton_Click(object sender, EventArgs e)
        {
            string nickname = mdTabConnectNameBox.Text.ToLower();
            string password = mdTabConnectPasswordBox.Text;
            string channel = mdTabConnectChannelBox.Text.ToLower();
            string suburl = mdTabConnectSpreadsheetBox.Text;

            if (!string.IsNullOrEmpty(channel) && !string.IsNullOrEmpty(nickname) && !string.IsNullOrEmpty(password) && password.StartsWith("oauth:"))
            {
                mdTabConnectNameLabel.ForeColor = DefaultForeColor;
                mdTabConnectPasswordLabel.ForeColor = DefaultForeColor;
                mdTabConnectChannelLabel.ForeColor = DefaultForeColor;

                mdTabConnect.Enabled = false;

                if (suburl.Contains("spreadsheets.google.com") && suburl.EndsWith("?alt=json")) Settings.Default.OptionSubUrl = suburl;
                
                Settings.Default.OptionName = nickname;
                Settings.Default.OptionPassword = password;
                Settings.Default.OptionChannel = channel;
                Settings.Default.Save();

                Thread ircThread = new Thread(delegate() { Program.Irc = new Irc(nickname, password, channel); })
                {
                    IsBackground = true
                };

                ircThread.Start();
                _startButtonPressed = true;
            }
            else
            {
                mdTabConnectRequiredLabel.Show();
                mdTabConnectNameLabel.ForeColor = Color.Red;
                mdTabConnectPasswordLabel.ForeColor = Color.Red;
                mdTabConnectChannelLabel.ForeColor = Color.Red;
            }
        }

        private void mdTabConnectNameBox_TextChanged(object sender, EventArgs e)
        {
            mdTabConnectRequiredLabel.Hide();
            mdTabConnectNameLabel.ForeColor = DefaultForeColor;
            mdTabConnectPasswordLabel.ForeColor = DefaultForeColor;
            mdTabConnectChannelLabel.ForeColor = DefaultForeColor;
        }

        private void mdTabConnectChannelBox_TextChanged(object sender, EventArgs e)
        {
            mdTabConnectRequiredLabel.Hide();
            mdTabConnectNameLabel.ForeColor = DefaultForeColor;
            mdTabConnectPasswordLabel.ForeColor = DefaultForeColor;
            mdTabConnectChannelLabel.ForeColor = DefaultForeColor;
        }

        private void mdTabConnectPasswordBox_TextChanged(object sender, EventArgs e)
        {
            mdTabConnectRequiredLabel.Hide();
            mdTabConnectNameLabel.ForeColor = DefaultForeColor;
            mdTabConnectPasswordLabel.ForeColor = DefaultForeColor;
            mdTabConnectChannelLabel.ForeColor = DefaultForeColor;
        }

        private void mdTabConnectPasswordButton_Click(object sender, EventArgs e)
        {
            mdTabConnectPasswordButton.Enabled = false;

            AuthDialog authDialog = new AuthDialog();

            if (authDialog.ShowDialog() == DialogResult.OK)
            {
                mdTabConnectPasswordBox.Text = authDialog.returnToken;
            }
        }

        private void aboutAdminibotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog abtd = new AboutDialog();
            abtd.ShowDialog();
            abtd.Dispose();
            abtd = null;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mdTabConnectPasswordManualButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://twitchapps.com/tmi/");
        }

        private void mdTabStreamWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (mdTabStreamWebBrowser.Document == null) return;
            if (mdTabStreamWebBrowser.Document.Body == null) return;
            mdTabStreamWebBrowser.Document.Body.Style = "overflow:hidden";
        }

        private void UpdateStreamInfo()
        {
            using (var w = new WebClient())
            {
                w.Proxy = null;
                try
                {
                    if (!_startButtonPressed) return;

                    if (!Program.CheckConnection())
                    {
                        Program.EventLog("Stream information couldn't be downloaded", Types.Log.Error);
                        return;
                    }

                    var jsonData =
                        w.DownloadString("https://api.twitch.tv/kraken/streams/" + Settings.Default.OptionChannel);
                    JObject stream = JObject.Parse(jsonData);

                    if (stream["stream"].HasValues)
                    {
                        // Sigh... NullReferenceExceptions, y u exist?
                        string channelDelay = stream["stream"]["channel"]["delay"].ToString();
                        string channelDisplayName = stream["stream"]["channel"]["display_name"].ToString();
                        string channelFollowers = stream["stream"]["channel"]["followers"].ToString();
                        string channelGame = stream["stream"]["channel"]["game"].ToString();
                        string channelLanguageCode = stream["stream"]["channel"]["broadcaster_language"].ToString();
                        string channelLanguageFull;
                        string channelMature = stream["stream"]["channel"]["mature"].ToString();
                        string channelPartner = stream["stream"]["channel"]["partner"].ToString();
                        string channelStatus = stream["stream"]["channel"]["status"].ToString();
                        string channelViews = stream["stream"]["channel"]["views"].ToString();
                        string streamAverageFps = stream["stream"]["average_fps"].ToString();
                        string streamCreatedAt = stream["stream"]["created_at"].ToString();
                        string streamGame = stream["stream"]["game"].ToString();
                        string streamViewers = stream["stream"]["viewers"].ToString();

                        try
                        {
                            channelLanguageFull = CultureInfo.GetCultureInfo(channelLanguageCode).DisplayName;
                        }
                        catch (Exception)
                        {
                            channelLanguageFull = "Unknown";
                        }

                        Settings.Default.InfoViewers = streamViewers;
                        Settings.Default.InfoPartnerStatus = channelPartner;
                        Settings.Default.InfoChannelDisplayName = channelDisplayName;

                        mdTabStreamStreamOnlineVar.Text = "True";

                        if (!string.IsNullOrWhiteSpace(channelStatus))
                        {
                            mdTabStreamStreamStatusVar.Text = channelStatus;
                            toolTip1.SetToolTip(mdTabStreamStreamStatusVar, channelStatus);
                        }

                        if (!string.IsNullOrWhiteSpace(streamGame)) mdTabStreamStreamGameVar.Text = streamGame;
                        if (!string.IsNullOrWhiteSpace(streamViewers)) mdTabStreamStreamViewersVar.Text = streamViewers;
                        if (!string.IsNullOrWhiteSpace(streamCreatedAt))
                            mdTabStreamStreamCreatedVar.Text = streamCreatedAt;
                        if (!string.IsNullOrWhiteSpace(streamAverageFps))
                            mdTabStreamStreamFpsVar.Text = streamAverageFps;

                        if (!string.IsNullOrWhiteSpace(channelGame)) mdTabStreamGeneralGameVar.Text = channelGame;
                        if (!string.IsNullOrWhiteSpace(channelFollowers))
                            mdTabStreamGeneralFollowersVar.Text = channelFollowers;
                        if (!string.IsNullOrWhiteSpace(channelViews)) mdTabStreamGeneralViewsVar.Text = channelViews;
                        if (!string.IsNullOrWhiteSpace(channelPartner))
                            mdTabStreamGeneralPartnerVar.Text = channelPartner;
                        if (!string.IsNullOrWhiteSpace(channelLanguageCode))
                            mdTabStreamGeneralLanguageVar.Text = channelLanguageFull + " (" + channelLanguageCode + ")";
                        if (!string.IsNullOrWhiteSpace(channelDelay)) mdTabStreamGeneralDelayVar.Text = channelDelay;
                        if (!string.IsNullOrWhiteSpace(channelMature)) mdTabStreamGeneralMatureVar.Text = channelMature;
                    }
                    else
                    {
                        mdTabStreamStreamOnlineVar.Text = "False";

                        mdTabStreamStreamStatusVar.Text = "-";
                        toolTip1.Hide(mdTabStreamStreamStatusVar);

                        mdTabStreamStreamGameVar.Text = "-";
                        mdTabStreamStreamViewersVar.Text = "-";
                        mdTabStreamStreamCreatedVar.Text = "-";
                        mdTabStreamStreamFpsVar.Text = "-";

                        mdTabStreamGeneralGameVar.Text = "-";
                        mdTabStreamGeneralFollowersVar.Text = "-";
                        mdTabStreamGeneralViewsVar.Text = "-";
                        mdTabStreamGeneralPartnerVar.Text = "-";
                        mdTabStreamGeneralLanguageVar.Text = "-";
                        mdTabStreamGeneralDelayVar.Text = "-";
                        mdTabStreamGeneralMatureVar.Text = "-";

                        //TODO: Disable stream tab
                    }
                }
                catch (NullReferenceException)
                {
                    Program.EventLog("Couldn't update one or more stream information item(s)");
                }
                catch (Exception e)
                {
                    Program.ErrorLog(e, "UpdateStreamInfo()");
                }
            }
        }

        private void StreamUpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateStreamInfo();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.OptionHideBotMsg = mdTabChatHideBotCheckbox.Checked;
            Settings.Default.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.OptionHideStatusMsg = mdTabChatHideStatusCheckbox.Checked;
            Settings.Default.Save();
        }

        public void AddUserToViewlist(string nick, Types.UserLevel level)
        {
            if (!mdTabChatViewerList.Items.ContainsKey(nick))
            {
                ListViewItem li = new ListViewItem(" " + Types.GetUserLevelLetter(level), level.ToString());
                li.SubItems.Add(nick);
                li.Name = nick;
                mdTabChatViewerList.Items.Add(li);
            }
        }

        public void RemoveUserFromViewlist(string nick)
        {
            mdTabChatViewerList.Items.RemoveByKey(nick);
        }

        public void AddUsersToViewlist(Dictionary<string, Types.UserLevel> userList)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            ListViewItem[] list = new ListViewItem[mdTabChatViewerList.Items.Count];
            mdTabChatViewerList.Items.CopyTo(list, 0);
            _addUserRangeThread = new Thread(() =>
            {
                foreach (KeyValuePair<string, Types.UserLevel> item in userList)
                {
                    if (list.All(s => s.Name != item.Key))
                    {
                        ListViewItem li = new ListViewItem(" " + Types.GetUserLevelLetter(item.Value), item.Value.ToString());
                        li.SubItems.Add(item.Key);
                        li.Name = item.Key;
                        items.Add(li);
                    }
                }

                this.SafeInvoke(() =>
                {
                    mdTabChatViewerList.Items.AddRange(items.ToArray());
                });
            }) { IsBackground = true };
            _addUserRangeThread.Start();
        }

        private void mdTabChatSendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string sendText = mdTabChatSendTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(sendText))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;

                    try
                    {
                        Program.Irc.SendMessage(sendText);
                    }
                    catch (Exception)
                    {
                        Program.EventLog("Couldn't send your message, please try again", Types.Log.Warning);
                    }

                    mdTabChatSendTextBox.Text = null;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void mdTabChatMessageTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", e.LinkText);
        }

        private void mdTabChatMessageTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        public int GetRawScrollPos(RichTextBox textBox)
        {
            return GetScrollPos(textBox.Handle, (int)Types.ScrollBarType.SbVert);
        }

        public int SetRawScrollPos(RichTextBox textBox, int nPos)
        {
            return SetScrollPos(textBox.Handle, (int)Types.ScrollBarType.SbVert, nPos, true);
        }

        public int GetScrollPos(RichTextBox textBox)
        {
            int nMin, nMax, nPos = 0;
            if (GetScrollRange(textBox.Handle, (int)Types.ScrollBarType.SbVert, out nMin, out nMax))
            {
                nPos = GetRawScrollPos(mdTabChatMessageTextBox);
                ScrollInfo scrollInfo = GetScrollInfo(mdTabChatMessageTextBox);
                nMax = nMax - (int)scrollInfo.nPage;
                nPos = nMax == 0 ? 0 : (int)((nPos / (float)nMax) * 100);
            }
            return nPos;
        }

        public ScrollInfo GetScrollInfo(RichTextBox textBox)
        {
            ScrollInfo scrollInfo = new ScrollInfo();
            scrollInfo.fMask = (uint)Types.ScrollInfoMask.SIF_ALL;
            scrollInfo.cbSize = (uint)Marshal.SizeOf(scrollInfo);
            GetScrollInfo(mdTabChatMessageTextBox.Handle, (int)Types.ScrollBarType.SbVert, ref scrollInfo);
            return scrollInfo;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.OptionComBtagEnabled = mdTabOptionsEnableBtagCheckbox.Checked;
            Settings.Default.Save();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.OptionComBtagMaxChars = Convert.ToInt32(mdTabOptionsBtagCharNumeric.Value);
            Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            Settings.Default.OptionComTimeEnabled = mdTabOptionsEnableTimeCheckbox.Checked;
            Settings.Default.Save();
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            Settings.Default.OptionComPointsEnabled = mdTabOptionsEnablePointsCheckbox.Checked;
            Settings.Default.Save();
        }

        public void InitDatabaseView()
        {
            
        }

        private void mdDatabaseTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isUserTab = mdDatabaseTabControl.SelectedIndex == 0;
            mdTabDatabaseFilterUserGroup.Visible = isUserTab;
            mdTabDatabaseFilterCommandGroup.Visible = !isUserTab;
        }
    }
}
