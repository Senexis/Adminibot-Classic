using System.ComponentModel;
using System.Windows.Forms;

namespace th.AdminibotLegacy
{
    partial class MainDialog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox mdTabConnectSigninGroup;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.mdTabConnectTable = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabConnectNameLabel = new System.Windows.Forms.Label();
            this.mdTabConnectPasswordButton = new System.Windows.Forms.Button();
            this.mdTabConnectStartButton = new System.Windows.Forms.Button();
            this.mdTabConnectNameBox = new System.Windows.Forms.TextBox();
            this.mdTabConnectPasswordLabel = new System.Windows.Forms.Label();
            this.mdTabConnectSpreadsheetBox = new System.Windows.Forms.TextBox();
            this.mdTabConnectChannelLabel = new System.Windows.Forms.Label();
            this.mdTabConnectChannelBox = new System.Windows.Forms.TextBox();
            this.mdTabConnectSpreadsheetLabel = new System.Windows.Forms.Label();
            this.mdTabConnectPasswordBox = new System.Windows.Forms.MaskedTextBox();
            this.mdTabConnectRequiredLabel = new System.Windows.Forms.Label();
            this.mdTabConnectPasswordManualButton = new System.Windows.Forms.Button();
            this.mdMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.technicalSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutAdminibotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mdStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mdStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mdStatusStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mdTabControl = new System.Windows.Forms.TabControl();
            this.mdTabConnect = new System.Windows.Forms.TabPage();
            this.mdTabChat = new System.Windows.Forms.TabPage();
            this.mdTabChatTable = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabChatSendTextBox = new System.Windows.Forms.TextBox();
            this.mdTabChatBorderFixPanel = new System.Windows.Forms.Panel();
            this.mdTabChatMessageTextBox = new System.Windows.Forms.RichTextBox();
            this.mdTabChatViewerList = new System.Windows.Forms.ListView();
            this.mdViewListHeaderIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdViewListHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabChatStatsGroup = new System.Windows.Forms.GroupBox();
            this.mdTabChatChattersLabel = new System.Windows.Forms.Label();
            this.mdTabChatViewersLabel = new System.Windows.Forms.Label();
            this.mdTabChatFiltersGroup = new System.Windows.Forms.GroupBox();
            this.mdTabChatTableFilters = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabChatHideCommandsCheckbox = new System.Windows.Forms.CheckBox();
            this.mdTabChatHideBotCheckbox = new System.Windows.Forms.CheckBox();
            this.mdTabChatHideStatusCheckbox = new System.Windows.Forms.CheckBox();
            this.mdTabCommands = new System.Windows.Forms.TabPage();
            this.mdTabCommandsScrollPanel = new System.Windows.Forms.Panel();
            this.mdTabStream = new System.Windows.Forms.TabPage();
            this.mdTabStreamTable = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabStreamWebBrowser = new System.Windows.Forms.WebBrowser();
            this.mdTabStreamInfoPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabStreamStreamInfoGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabStreamStreamOnline = new System.Windows.Forms.Label();
            this.mdTabStreamStreamFps = new System.Windows.Forms.Label();
            this.mdTabStreamStreamStatus = new System.Windows.Forms.Label();
            this.mdTabStreamStreamCreated = new System.Windows.Forms.Label();
            this.mdTabStreamStreamGame = new System.Windows.Forms.Label();
            this.mdTabStreamStreamViewers = new System.Windows.Forms.Label();
            this.mdTabStreamStreamOnlineVar = new System.Windows.Forms.Label();
            this.mdTabStreamStreamStatusVar = new System.Windows.Forms.Label();
            this.mdTabStreamStreamGameVar = new System.Windows.Forms.Label();
            this.mdTabStreamStreamViewersVar = new System.Windows.Forms.Label();
            this.mdTabStreamStreamCreatedVar = new System.Windows.Forms.Label();
            this.mdTabStreamStreamFpsVar = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralInfoGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabStreamGeneralMature = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralGame = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralFollowers = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralDelay = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralViews = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralLanguage = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralPartner = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralGameVar = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralFollowersVar = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralViewsVar = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralPartnerVar = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralLanguageVar = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralDelayVar = new System.Windows.Forms.Label();
            this.mdTabStreamGeneralMatureVar = new System.Windows.Forms.Label();
            this.mdTabOptions = new System.Windows.Forms.TabPage();
            this.mdTabOptionsScrollPanel = new System.Windows.Forms.Panel();
            this.mdTabOptionsTable = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabOptionsBtagGroup = new System.Windows.Forms.GroupBox();
            this.mdTabOptionsBtagTable = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabOptionsBtagCharLabel = new System.Windows.Forms.Label();
            this.mdTabOptionsBtagCharNumeric = new System.Windows.Forms.NumericUpDown();
            this.mdTabOptionsEnableBtagCheckbox = new System.Windows.Forms.CheckBox();
            this.mdTabOptionsEnableBtagLabel = new System.Windows.Forms.Label();
            this.mdTabOptionsPointsGroup = new System.Windows.Forms.GroupBox();
            this.mdTabOptionsTablePoints = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabOptionsEnablePointsLabel = new System.Windows.Forms.Label();
            this.mdTabOptionsAddPointsCombo = new System.Windows.Forms.ComboBox();
            this.mdTabOptionsEnablePointsCheckbox = new System.Windows.Forms.CheckBox();
            this.mdTabOptionsAddPointsButton = new System.Windows.Forms.Button();
            this.mdTabOptionsTimeGroup = new System.Windows.Forms.GroupBox();
            this.mdTabOptionsTimeTable = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabOptionsEnableTimeLabel = new System.Windows.Forms.Label();
            this.mdTabOptionsEnableTimeCheckbox = new System.Windows.Forms.CheckBox();
            this.mdTabDatabase = new System.Windows.Forms.TabPage();
            this.mdTabDatabaseTable = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mdTabDatabaseFilterCommandGroup = new System.Windows.Forms.GroupBox();
            this.mdTabDatabaseFilterCommandActive = new System.Windows.Forms.CheckBox();
            this.mdTabDatabaseFilterUserGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.mdTabDatabaseFilterUserOnline = new System.Windows.Forms.CheckBox();
            this.mdTabDatabaseSearchGroup = new System.Windows.Forms.GroupBox();
            this.mdTabDatabaseSearchButton = new System.Windows.Forms.Button();
            this.mdTabDatabaseSearchBox = new System.Windows.Forms.TextBox();
            this.mdDatabaseTabControl = new System.Windows.Forms.TabControl();
            this.mdDatabaseTabUsers = new System.Windows.Forms.TabPage();
            this.mdTabDatabaseViewUser = new System.Windows.Forms.ListView();
            this.mdTabDatabaseHeaderUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderBtag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderPoints = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderJoin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderFollow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderUserlevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdDatabaseTabCommands = new System.Windows.Forms.TabPage();
            this.mdTabDatabaseViewCommand = new System.Windows.Forms.ListView();
            this.mdTabDatabaseHeaderComId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderComLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDatabaseHeaderComResponse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdTabDebug = new System.Windows.Forms.TabPage();
            this.mdTabDebugBorderFixPanel = new System.Windows.Forms.Panel();
            this.mdTabDebugLogTextBox = new System.Windows.Forms.RichTextBox();
            this.mdContainerPanel = new System.Windows.Forms.Panel();
            this.mdTabStreamTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            mdTabConnectSigninGroup = new System.Windows.Forms.GroupBox();
            mdTabConnectSigninGroup.SuspendLayout();
            this.mdTabConnectTable.SuspendLayout();
            this.mdMenuStrip.SuspendLayout();
            this.mdStatusStrip.SuspendLayout();
            this.mdTabControl.SuspendLayout();
            this.mdTabConnect.SuspendLayout();
            this.mdTabChat.SuspendLayout();
            this.mdTabChatTable.SuspendLayout();
            this.mdTabChatBorderFixPanel.SuspendLayout();
            this.mdTabChatStatsGroup.SuspendLayout();
            this.mdTabChatFiltersGroup.SuspendLayout();
            this.mdTabChatTableFilters.SuspendLayout();
            this.mdTabCommands.SuspendLayout();
            this.mdTabStream.SuspendLayout();
            this.mdTabStreamTable.SuspendLayout();
            this.mdTabStreamInfoPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.mdTabStreamStreamInfoGroup.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.mdTabStreamGeneralInfoGroup.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.mdTabOptions.SuspendLayout();
            this.mdTabOptionsScrollPanel.SuspendLayout();
            this.mdTabOptionsTable.SuspendLayout();
            this.mdTabOptionsBtagGroup.SuspendLayout();
            this.mdTabOptionsBtagTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdTabOptionsBtagCharNumeric)).BeginInit();
            this.mdTabOptionsPointsGroup.SuspendLayout();
            this.mdTabOptionsTablePoints.SuspendLayout();
            this.mdTabOptionsTimeGroup.SuspendLayout();
            this.mdTabOptionsTimeTable.SuspendLayout();
            this.mdTabDatabase.SuspendLayout();
            this.mdTabDatabaseTable.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mdTabDatabaseFilterCommandGroup.SuspendLayout();
            this.mdTabDatabaseFilterUserGroup.SuspendLayout();
            this.mdTabDatabaseSearchGroup.SuspendLayout();
            this.mdDatabaseTabControl.SuspendLayout();
            this.mdDatabaseTabUsers.SuspendLayout();
            this.mdDatabaseTabCommands.SuspendLayout();
            this.mdTabDebug.SuspendLayout();
            this.mdTabDebugBorderFixPanel.SuspendLayout();
            this.mdContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mdTabConnectSigninGroup
            // 
            resources.ApplyResources(mdTabConnectSigninGroup, "mdTabConnectSigninGroup");
            mdTabConnectSigninGroup.Controls.Add(this.mdTabConnectTable);
            mdTabConnectSigninGroup.Name = "mdTabConnectSigninGroup";
            mdTabConnectSigninGroup.TabStop = false;
            // 
            // mdTabConnectTable
            // 
            resources.ApplyResources(this.mdTabConnectTable, "mdTabConnectTable");
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectNameLabel, 0, 0);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectPasswordButton, 2, 1);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectStartButton, 0, 4);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectNameBox, 1, 0);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectPasswordLabel, 0, 1);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectSpreadsheetBox, 1, 3);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectChannelLabel, 0, 2);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectChannelBox, 1, 2);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectSpreadsheetLabel, 0, 3);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectPasswordBox, 1, 1);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectRequiredLabel, 1, 4);
            this.mdTabConnectTable.Controls.Add(this.mdTabConnectPasswordManualButton, 3, 1);
            this.mdTabConnectTable.Name = "mdTabConnectTable";
            // 
            // mdTabConnectNameLabel
            // 
            resources.ApplyResources(this.mdTabConnectNameLabel, "mdTabConnectNameLabel");
            this.mdTabConnectNameLabel.Name = "mdTabConnectNameLabel";
            // 
            // mdTabConnectPasswordButton
            // 
            resources.ApplyResources(this.mdTabConnectPasswordButton, "mdTabConnectPasswordButton");
            this.mdTabConnectPasswordButton.Name = "mdTabConnectPasswordButton";
            this.mdTabConnectPasswordButton.UseVisualStyleBackColor = true;
            this.mdTabConnectPasswordButton.Click += new System.EventHandler(this.mdTabConnectPasswordButton_Click);
            // 
            // mdTabConnectStartButton
            // 
            resources.ApplyResources(this.mdTabConnectStartButton, "mdTabConnectStartButton");
            this.mdTabConnectStartButton.Name = "mdTabConnectStartButton";
            this.mdTabConnectStartButton.UseVisualStyleBackColor = true;
            this.mdTabConnectStartButton.Click += new System.EventHandler(this.mdTabConnectStartButton_Click);
            // 
            // mdTabConnectNameBox
            // 
            resources.ApplyResources(this.mdTabConnectNameBox, "mdTabConnectNameBox");
            this.mdTabConnectNameBox.Name = "mdTabConnectNameBox";
            this.mdTabConnectNameBox.TextChanged += new System.EventHandler(this.mdTabConnectNameBox_TextChanged);
            // 
            // mdTabConnectPasswordLabel
            // 
            resources.ApplyResources(this.mdTabConnectPasswordLabel, "mdTabConnectPasswordLabel");
            this.mdTabConnectPasswordLabel.Name = "mdTabConnectPasswordLabel";
            // 
            // mdTabConnectSpreadsheetBox
            // 
            resources.ApplyResources(this.mdTabConnectSpreadsheetBox, "mdTabConnectSpreadsheetBox");
            this.mdTabConnectSpreadsheetBox.Name = "mdTabConnectSpreadsheetBox";
            // 
            // mdTabConnectChannelLabel
            // 
            resources.ApplyResources(this.mdTabConnectChannelLabel, "mdTabConnectChannelLabel");
            this.mdTabConnectChannelLabel.Name = "mdTabConnectChannelLabel";
            // 
            // mdTabConnectChannelBox
            // 
            resources.ApplyResources(this.mdTabConnectChannelBox, "mdTabConnectChannelBox");
            this.mdTabConnectChannelBox.Name = "mdTabConnectChannelBox";
            this.mdTabConnectChannelBox.TextChanged += new System.EventHandler(this.mdTabConnectChannelBox_TextChanged);
            // 
            // mdTabConnectSpreadsheetLabel
            // 
            resources.ApplyResources(this.mdTabConnectSpreadsheetLabel, "mdTabConnectSpreadsheetLabel");
            this.mdTabConnectSpreadsheetLabel.Name = "mdTabConnectSpreadsheetLabel";
            // 
            // mdTabConnectPasswordBox
            // 
            resources.ApplyResources(this.mdTabConnectPasswordBox, "mdTabConnectPasswordBox");
            this.mdTabConnectPasswordBox.Name = "mdTabConnectPasswordBox";
            this.mdTabConnectPasswordBox.PasswordChar = '•';
            this.mdTabConnectPasswordBox.TextChanged += new System.EventHandler(this.mdTabConnectPasswordBox_TextChanged);
            // 
            // mdTabConnectRequiredLabel
            // 
            resources.ApplyResources(this.mdTabConnectRequiredLabel, "mdTabConnectRequiredLabel");
            this.mdTabConnectRequiredLabel.ForeColor = System.Drawing.Color.Red;
            this.mdTabConnectRequiredLabel.Name = "mdTabConnectRequiredLabel";
            // 
            // mdTabConnectPasswordManualButton
            // 
            resources.ApplyResources(this.mdTabConnectPasswordManualButton, "mdTabConnectPasswordManualButton");
            this.mdTabConnectPasswordManualButton.Name = "mdTabConnectPasswordManualButton";
            this.mdTabConnectPasswordManualButton.UseVisualStyleBackColor = true;
            this.mdTabConnectPasswordManualButton.Click += new System.EventHandler(this.mdTabConnectPasswordManualButton_Click);
            // 
            // mdMenuStrip
            // 
            this.mdMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mdMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.mdMenuStrip, "mdMenuStrip");
            this.mdMenuStrip.Name = "mdMenuStrip";
            this.mdMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // quitToolStripMenuItem
            // 
            resources.ApplyResources(this.quitToolStripMenuItem, "quitToolStripMenuItem");
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.technicalSupportToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutAdminibotToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // viewHelpToolStripMenuItem
            // 
            resources.ApplyResources(this.viewHelpToolStripMenuItem, "viewHelpToolStripMenuItem");
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            // 
            // technicalSupportToolStripMenuItem
            // 
            resources.ApplyResources(this.technicalSupportToolStripMenuItem, "technicalSupportToolStripMenuItem");
            this.technicalSupportToolStripMenuItem.Name = "technicalSupportToolStripMenuItem";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // aboutAdminibotToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutAdminibotToolStripMenuItem, "aboutAdminibotToolStripMenuItem");
            this.aboutAdminibotToolStripMenuItem.Name = "aboutAdminibotToolStripMenuItem";
            this.aboutAdminibotToolStripMenuItem.Click += new System.EventHandler(this.aboutAdminibotToolStripMenuItem_Click);
            // 
            // mdStatusStrip
            // 
            this.mdStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mdStatusStripLabel,
            this.mdStatusStripProgressBar});
            resources.ApplyResources(this.mdStatusStrip, "mdStatusStrip");
            this.mdStatusStrip.Name = "mdStatusStrip";
            this.mdStatusStrip.SizingGrip = false;
            // 
            // mdStatusStripLabel
            // 
            this.mdStatusStripLabel.Name = "mdStatusStripLabel";
            resources.ApplyResources(this.mdStatusStripLabel, "mdStatusStripLabel");
            this.mdStatusStripLabel.Spring = true;
            // 
            // mdStatusStripProgressBar
            // 
            this.mdStatusStripProgressBar.Margin = new System.Windows.Forms.Padding(1, 3, 4, 3);
            this.mdStatusStripProgressBar.MarqueeAnimationSpeed = 0;
            this.mdStatusStripProgressBar.Name = "mdStatusStripProgressBar";
            resources.ApplyResources(this.mdStatusStripProgressBar, "mdStatusStripProgressBar");
            this.mdStatusStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // mdTabControl
            // 
            this.mdTabControl.Controls.Add(this.mdTabConnect);
            this.mdTabControl.Controls.Add(this.mdTabChat);
            this.mdTabControl.Controls.Add(this.mdTabCommands);
            this.mdTabControl.Controls.Add(this.mdTabStream);
            this.mdTabControl.Controls.Add(this.mdTabOptions);
            this.mdTabControl.Controls.Add(this.mdTabDatabase);
            this.mdTabControl.Controls.Add(this.mdTabDebug);
            resources.ApplyResources(this.mdTabControl, "mdTabControl");
            this.mdTabControl.Name = "mdTabControl";
            this.mdTabControl.SelectedIndex = 0;
            // 
            // mdTabConnect
            // 
            this.mdTabConnect.Controls.Add(mdTabConnectSigninGroup);
            resources.ApplyResources(this.mdTabConnect, "mdTabConnect");
            this.mdTabConnect.Name = "mdTabConnect";
            this.mdTabConnect.UseVisualStyleBackColor = true;
            // 
            // mdTabChat
            // 
            this.mdTabChat.Controls.Add(this.mdTabChatTable);
            resources.ApplyResources(this.mdTabChat, "mdTabChat");
            this.mdTabChat.Name = "mdTabChat";
            this.mdTabChat.UseVisualStyleBackColor = true;
            // 
            // mdTabChatTable
            // 
            resources.ApplyResources(this.mdTabChatTable, "mdTabChatTable");
            this.mdTabChatTable.Controls.Add(this.mdTabChatSendTextBox, 0, 2);
            this.mdTabChatTable.Controls.Add(this.mdTabChatBorderFixPanel, 0, 1);
            this.mdTabChatTable.Controls.Add(this.mdTabChatViewerList, 1, 1);
            this.mdTabChatTable.Controls.Add(this.mdTabChatStatsGroup, 1, 0);
            this.mdTabChatTable.Controls.Add(this.mdTabChatFiltersGroup, 0, 0);
            this.mdTabChatTable.Name = "mdTabChatTable";
            // 
            // mdTabChatSendTextBox
            // 
            this.mdTabChatSendTextBox.AcceptsReturn = true;
            resources.ApplyResources(this.mdTabChatSendTextBox, "mdTabChatSendTextBox");
            this.mdTabChatSendTextBox.Name = "mdTabChatSendTextBox";
            this.mdTabChatSendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mdTabChatSendTextBox_KeyDown);
            // 
            // mdTabChatBorderFixPanel
            // 
            this.mdTabChatBorderFixPanel.BackColor = System.Drawing.SystemColors.Window;
            this.mdTabChatBorderFixPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mdTabChatBorderFixPanel.Controls.Add(this.mdTabChatMessageTextBox);
            resources.ApplyResources(this.mdTabChatBorderFixPanel, "mdTabChatBorderFixPanel");
            this.mdTabChatBorderFixPanel.Name = "mdTabChatBorderFixPanel";
            // 
            // mdTabChatMessageTextBox
            // 
            this.mdTabChatMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.mdTabChatMessageTextBox, "mdTabChatMessageTextBox");
            this.mdTabChatMessageTextBox.Name = "mdTabChatMessageTextBox";
            this.mdTabChatMessageTextBox.ReadOnly = true;
            this.mdTabChatMessageTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.mdTabChatMessageTextBox_LinkClicked);
            this.mdTabChatMessageTextBox.TextChanged += new System.EventHandler(this.mdTabChatMessageTextBox_TextChanged);
            // 
            // mdTabChatViewerList
            // 
            this.mdTabChatViewerList.AutoArrange = false;
            this.mdTabChatViewerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mdViewListHeaderIcon,
            this.mdViewListHeader});
            resources.ApplyResources(this.mdTabChatViewerList, "mdTabChatViewerList");
            this.mdTabChatViewerList.FullRowSelect = true;
            this.mdTabChatViewerList.MultiSelect = false;
            this.mdTabChatViewerList.Name = "mdTabChatViewerList";
            this.mdTabChatTable.SetRowSpan(this.mdTabChatViewerList, 2);
            this.mdTabChatViewerList.ShowGroups = false;
            this.mdTabChatViewerList.TileSize = new System.Drawing.Size(168, 30);
            this.mdTabChatViewerList.UseCompatibleStateImageBehavior = false;
            this.mdTabChatViewerList.View = System.Windows.Forms.View.Details;
            // 
            // mdViewListHeaderIcon
            // 
            resources.ApplyResources(this.mdViewListHeaderIcon, "mdViewListHeaderIcon");
            // 
            // mdViewListHeader
            // 
            resources.ApplyResources(this.mdViewListHeader, "mdViewListHeader");
            // 
            // mdTabChatStatsGroup
            // 
            resources.ApplyResources(this.mdTabChatStatsGroup, "mdTabChatStatsGroup");
            this.mdTabChatStatsGroup.Controls.Add(this.mdTabChatChattersLabel);
            this.mdTabChatStatsGroup.Controls.Add(this.mdTabChatViewersLabel);
            this.mdTabChatStatsGroup.Name = "mdTabChatStatsGroup";
            this.mdTabChatStatsGroup.TabStop = false;
            // 
            // mdTabChatChattersLabel
            // 
            resources.ApplyResources(this.mdTabChatChattersLabel, "mdTabChatChattersLabel");
            this.mdTabChatChattersLabel.Name = "mdTabChatChattersLabel";
            // 
            // mdTabChatViewersLabel
            // 
            resources.ApplyResources(this.mdTabChatViewersLabel, "mdTabChatViewersLabel");
            this.mdTabChatViewersLabel.Name = "mdTabChatViewersLabel";
            // 
            // mdTabChatFiltersGroup
            // 
            resources.ApplyResources(this.mdTabChatFiltersGroup, "mdTabChatFiltersGroup");
            this.mdTabChatFiltersGroup.Controls.Add(this.mdTabChatTableFilters);
            this.mdTabChatFiltersGroup.Name = "mdTabChatFiltersGroup";
            this.mdTabChatFiltersGroup.TabStop = false;
            // 
            // mdTabChatTableFilters
            // 
            resources.ApplyResources(this.mdTabChatTableFilters, "mdTabChatTableFilters");
            this.mdTabChatTableFilters.Controls.Add(this.mdTabChatHideCommandsCheckbox, 0, 0);
            this.mdTabChatTableFilters.Controls.Add(this.mdTabChatHideBotCheckbox, 1, 0);
            this.mdTabChatTableFilters.Controls.Add(this.mdTabChatHideStatusCheckbox, 2, 0);
            this.mdTabChatTableFilters.Name = "mdTabChatTableFilters";
            // 
            // mdTabChatHideCommandsCheckbox
            // 
            resources.ApplyResources(this.mdTabChatHideCommandsCheckbox, "mdTabChatHideCommandsCheckbox");
            this.mdTabChatHideCommandsCheckbox.Name = "mdTabChatHideCommandsCheckbox";
            this.mdTabChatHideCommandsCheckbox.UseVisualStyleBackColor = true;
            // 
            // mdTabChatHideBotCheckbox
            // 
            resources.ApplyResources(this.mdTabChatHideBotCheckbox, "mdTabChatHideBotCheckbox");
            this.mdTabChatHideBotCheckbox.Name = "mdTabChatHideBotCheckbox";
            this.mdTabChatHideBotCheckbox.UseVisualStyleBackColor = true;
            this.mdTabChatHideBotCheckbox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // mdTabChatHideStatusCheckbox
            // 
            resources.ApplyResources(this.mdTabChatHideStatusCheckbox, "mdTabChatHideStatusCheckbox");
            this.mdTabChatHideStatusCheckbox.Name = "mdTabChatHideStatusCheckbox";
            this.mdTabChatHideStatusCheckbox.UseVisualStyleBackColor = true;
            this.mdTabChatHideStatusCheckbox.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // mdTabCommands
            // 
            this.mdTabCommands.Controls.Add(this.mdTabCommandsScrollPanel);
            resources.ApplyResources(this.mdTabCommands, "mdTabCommands");
            this.mdTabCommands.Name = "mdTabCommands";
            this.mdTabCommands.UseVisualStyleBackColor = true;
            // 
            // mdTabCommandsScrollPanel
            // 
            resources.ApplyResources(this.mdTabCommandsScrollPanel, "mdTabCommandsScrollPanel");
            this.mdTabCommandsScrollPanel.Name = "mdTabCommandsScrollPanel";
            // 
            // mdTabStream
            // 
            this.mdTabStream.Controls.Add(this.mdTabStreamTable);
            resources.ApplyResources(this.mdTabStream, "mdTabStream");
            this.mdTabStream.Name = "mdTabStream";
            this.mdTabStream.UseVisualStyleBackColor = true;
            // 
            // mdTabStreamTable
            // 
            resources.ApplyResources(this.mdTabStreamTable, "mdTabStreamTable");
            this.mdTabStreamTable.Controls.Add(this.mdTabStreamWebBrowser, 0, 0);
            this.mdTabStreamTable.Controls.Add(this.mdTabStreamInfoPanel, 1, 0);
            this.mdTabStreamTable.Name = "mdTabStreamTable";
            // 
            // mdTabStreamWebBrowser
            // 
            resources.ApplyResources(this.mdTabStreamWebBrowser, "mdTabStreamWebBrowser");
            this.mdTabStreamWebBrowser.Name = "mdTabStreamWebBrowser";
            this.mdTabStreamWebBrowser.ScriptErrorsSuppressed = true;
            this.mdTabStreamWebBrowser.ScrollBarsEnabled = false;
            this.mdTabStreamWebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.mdTabStreamWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.mdTabStreamWebBrowser_DocumentCompleted);
            // 
            // mdTabStreamInfoPanel
            // 
            this.mdTabStreamInfoPanel.Controls.Add(this.tableLayoutPanel4);
            resources.ApplyResources(this.mdTabStreamInfoPanel, "mdTabStreamInfoPanel");
            this.mdTabStreamInfoPanel.Name = "mdTabStreamInfoPanel";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.mdTabStreamStreamInfoGroup, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.mdTabStreamGeneralInfoGroup, 0, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // mdTabStreamStreamInfoGroup
            // 
            resources.ApplyResources(this.mdTabStreamStreamInfoGroup, "mdTabStreamStreamInfoGroup");
            this.mdTabStreamStreamInfoGroup.Controls.Add(this.tableLayoutPanel3);
            this.mdTabStreamStreamInfoGroup.Name = "mdTabStreamStreamInfoGroup";
            this.mdTabStreamStreamInfoGroup.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamOnline, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamFps, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamStatus, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamCreated, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamGame, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamViewers, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamOnlineVar, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamStatusVar, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamGameVar, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamViewersVar, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamCreatedVar, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.mdTabStreamStreamFpsVar, 1, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // mdTabStreamStreamOnline
            // 
            resources.ApplyResources(this.mdTabStreamStreamOnline, "mdTabStreamStreamOnline");
            this.mdTabStreamStreamOnline.Name = "mdTabStreamStreamOnline";
            // 
            // mdTabStreamStreamFps
            // 
            resources.ApplyResources(this.mdTabStreamStreamFps, "mdTabStreamStreamFps");
            this.mdTabStreamStreamFps.Name = "mdTabStreamStreamFps";
            // 
            // mdTabStreamStreamStatus
            // 
            this.mdTabStreamStreamStatus.AutoEllipsis = true;
            resources.ApplyResources(this.mdTabStreamStreamStatus, "mdTabStreamStreamStatus");
            this.mdTabStreamStreamStatus.Name = "mdTabStreamStreamStatus";
            // 
            // mdTabStreamStreamCreated
            // 
            resources.ApplyResources(this.mdTabStreamStreamCreated, "mdTabStreamStreamCreated");
            this.mdTabStreamStreamCreated.Name = "mdTabStreamStreamCreated";
            // 
            // mdTabStreamStreamGame
            // 
            resources.ApplyResources(this.mdTabStreamStreamGame, "mdTabStreamStreamGame");
            this.mdTabStreamStreamGame.Name = "mdTabStreamStreamGame";
            // 
            // mdTabStreamStreamViewers
            // 
            resources.ApplyResources(this.mdTabStreamStreamViewers, "mdTabStreamStreamViewers");
            this.mdTabStreamStreamViewers.Name = "mdTabStreamStreamViewers";
            // 
            // mdTabStreamStreamOnlineVar
            // 
            resources.ApplyResources(this.mdTabStreamStreamOnlineVar, "mdTabStreamStreamOnlineVar");
            this.mdTabStreamStreamOnlineVar.Name = "mdTabStreamStreamOnlineVar";
            // 
            // mdTabStreamStreamStatusVar
            // 
            this.mdTabStreamStreamStatusVar.AutoEllipsis = true;
            resources.ApplyResources(this.mdTabStreamStreamStatusVar, "mdTabStreamStreamStatusVar");
            this.mdTabStreamStreamStatusVar.Name = "mdTabStreamStreamStatusVar";
            // 
            // mdTabStreamStreamGameVar
            // 
            resources.ApplyResources(this.mdTabStreamStreamGameVar, "mdTabStreamStreamGameVar");
            this.mdTabStreamStreamGameVar.Name = "mdTabStreamStreamGameVar";
            // 
            // mdTabStreamStreamViewersVar
            // 
            resources.ApplyResources(this.mdTabStreamStreamViewersVar, "mdTabStreamStreamViewersVar");
            this.mdTabStreamStreamViewersVar.Name = "mdTabStreamStreamViewersVar";
            // 
            // mdTabStreamStreamCreatedVar
            // 
            resources.ApplyResources(this.mdTabStreamStreamCreatedVar, "mdTabStreamStreamCreatedVar");
            this.mdTabStreamStreamCreatedVar.Name = "mdTabStreamStreamCreatedVar";
            // 
            // mdTabStreamStreamFpsVar
            // 
            resources.ApplyResources(this.mdTabStreamStreamFpsVar, "mdTabStreamStreamFpsVar");
            this.mdTabStreamStreamFpsVar.Name = "mdTabStreamStreamFpsVar";
            // 
            // mdTabStreamGeneralInfoGroup
            // 
            resources.ApplyResources(this.mdTabStreamGeneralInfoGroup, "mdTabStreamGeneralInfoGroup");
            this.mdTabStreamGeneralInfoGroup.Controls.Add(this.tableLayoutPanel5);
            this.mdTabStreamGeneralInfoGroup.Name = "mdTabStreamGeneralInfoGroup";
            this.mdTabStreamGeneralInfoGroup.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralMature, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralGame, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralFollowers, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralDelay, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralViews, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralLanguage, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralPartner, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralGameVar, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralFollowersVar, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralViewsVar, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralPartnerVar, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralLanguageVar, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralDelayVar, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.mdTabStreamGeneralMatureVar, 1, 6);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // mdTabStreamGeneralMature
            // 
            resources.ApplyResources(this.mdTabStreamGeneralMature, "mdTabStreamGeneralMature");
            this.mdTabStreamGeneralMature.Name = "mdTabStreamGeneralMature";
            // 
            // mdTabStreamGeneralGame
            // 
            resources.ApplyResources(this.mdTabStreamGeneralGame, "mdTabStreamGeneralGame");
            this.mdTabStreamGeneralGame.Name = "mdTabStreamGeneralGame";
            // 
            // mdTabStreamGeneralFollowers
            // 
            resources.ApplyResources(this.mdTabStreamGeneralFollowers, "mdTabStreamGeneralFollowers");
            this.mdTabStreamGeneralFollowers.Name = "mdTabStreamGeneralFollowers";
            // 
            // mdTabStreamGeneralDelay
            // 
            resources.ApplyResources(this.mdTabStreamGeneralDelay, "mdTabStreamGeneralDelay");
            this.mdTabStreamGeneralDelay.Name = "mdTabStreamGeneralDelay";
            // 
            // mdTabStreamGeneralViews
            // 
            resources.ApplyResources(this.mdTabStreamGeneralViews, "mdTabStreamGeneralViews");
            this.mdTabStreamGeneralViews.Name = "mdTabStreamGeneralViews";
            // 
            // mdTabStreamGeneralLanguage
            // 
            resources.ApplyResources(this.mdTabStreamGeneralLanguage, "mdTabStreamGeneralLanguage");
            this.mdTabStreamGeneralLanguage.Name = "mdTabStreamGeneralLanguage";
            // 
            // mdTabStreamGeneralPartner
            // 
            resources.ApplyResources(this.mdTabStreamGeneralPartner, "mdTabStreamGeneralPartner");
            this.mdTabStreamGeneralPartner.Name = "mdTabStreamGeneralPartner";
            // 
            // mdTabStreamGeneralGameVar
            // 
            resources.ApplyResources(this.mdTabStreamGeneralGameVar, "mdTabStreamGeneralGameVar");
            this.mdTabStreamGeneralGameVar.Name = "mdTabStreamGeneralGameVar";
            // 
            // mdTabStreamGeneralFollowersVar
            // 
            resources.ApplyResources(this.mdTabStreamGeneralFollowersVar, "mdTabStreamGeneralFollowersVar");
            this.mdTabStreamGeneralFollowersVar.Name = "mdTabStreamGeneralFollowersVar";
            // 
            // mdTabStreamGeneralViewsVar
            // 
            resources.ApplyResources(this.mdTabStreamGeneralViewsVar, "mdTabStreamGeneralViewsVar");
            this.mdTabStreamGeneralViewsVar.Name = "mdTabStreamGeneralViewsVar";
            // 
            // mdTabStreamGeneralPartnerVar
            // 
            resources.ApplyResources(this.mdTabStreamGeneralPartnerVar, "mdTabStreamGeneralPartnerVar");
            this.mdTabStreamGeneralPartnerVar.Name = "mdTabStreamGeneralPartnerVar";
            // 
            // mdTabStreamGeneralLanguageVar
            // 
            resources.ApplyResources(this.mdTabStreamGeneralLanguageVar, "mdTabStreamGeneralLanguageVar");
            this.mdTabStreamGeneralLanguageVar.Name = "mdTabStreamGeneralLanguageVar";
            // 
            // mdTabStreamGeneralDelayVar
            // 
            resources.ApplyResources(this.mdTabStreamGeneralDelayVar, "mdTabStreamGeneralDelayVar");
            this.mdTabStreamGeneralDelayVar.Name = "mdTabStreamGeneralDelayVar";
            // 
            // mdTabStreamGeneralMatureVar
            // 
            resources.ApplyResources(this.mdTabStreamGeneralMatureVar, "mdTabStreamGeneralMatureVar");
            this.mdTabStreamGeneralMatureVar.Name = "mdTabStreamGeneralMatureVar";
            // 
            // mdTabOptions
            // 
            this.mdTabOptions.Controls.Add(this.mdTabOptionsScrollPanel);
            resources.ApplyResources(this.mdTabOptions, "mdTabOptions");
            this.mdTabOptions.Name = "mdTabOptions";
            this.mdTabOptions.UseVisualStyleBackColor = true;
            // 
            // mdTabOptionsScrollPanel
            // 
            resources.ApplyResources(this.mdTabOptionsScrollPanel, "mdTabOptionsScrollPanel");
            this.mdTabOptionsScrollPanel.Controls.Add(this.mdTabOptionsTable);
            this.mdTabOptionsScrollPanel.Name = "mdTabOptionsScrollPanel";
            // 
            // mdTabOptionsTable
            // 
            resources.ApplyResources(this.mdTabOptionsTable, "mdTabOptionsTable");
            this.mdTabOptionsTable.Controls.Add(this.mdTabOptionsBtagGroup, 0, 1);
            this.mdTabOptionsTable.Controls.Add(this.mdTabOptionsPointsGroup, 0, 0);
            this.mdTabOptionsTable.Controls.Add(this.mdTabOptionsTimeGroup, 0, 2);
            this.mdTabOptionsTable.Name = "mdTabOptionsTable";
            // 
            // mdTabOptionsBtagGroup
            // 
            resources.ApplyResources(this.mdTabOptionsBtagGroup, "mdTabOptionsBtagGroup");
            this.mdTabOptionsBtagGroup.Controls.Add(this.mdTabOptionsBtagTable);
            this.mdTabOptionsBtagGroup.Name = "mdTabOptionsBtagGroup";
            this.mdTabOptionsBtagGroup.TabStop = false;
            // 
            // mdTabOptionsBtagTable
            // 
            resources.ApplyResources(this.mdTabOptionsBtagTable, "mdTabOptionsBtagTable");
            this.mdTabOptionsBtagTable.Controls.Add(this.mdTabOptionsBtagCharLabel, 0, 1);
            this.mdTabOptionsBtagTable.Controls.Add(this.mdTabOptionsBtagCharNumeric, 1, 1);
            this.mdTabOptionsBtagTable.Controls.Add(this.mdTabOptionsEnableBtagCheckbox, 1, 0);
            this.mdTabOptionsBtagTable.Controls.Add(this.mdTabOptionsEnableBtagLabel, 0, 0);
            this.mdTabOptionsBtagTable.Name = "mdTabOptionsBtagTable";
            // 
            // mdTabOptionsBtagCharLabel
            // 
            resources.ApplyResources(this.mdTabOptionsBtagCharLabel, "mdTabOptionsBtagCharLabel");
            this.mdTabOptionsBtagCharLabel.Name = "mdTabOptionsBtagCharLabel";
            // 
            // mdTabOptionsBtagCharNumeric
            // 
            resources.ApplyResources(this.mdTabOptionsBtagCharNumeric, "mdTabOptionsBtagCharNumeric");
            this.mdTabOptionsBtagCharNumeric.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.mdTabOptionsBtagCharNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.mdTabOptionsBtagCharNumeric.Name = "mdTabOptionsBtagCharNumeric";
            this.mdTabOptionsBtagCharNumeric.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.mdTabOptionsBtagCharNumeric.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // mdTabOptionsEnableBtagCheckbox
            // 
            resources.ApplyResources(this.mdTabOptionsEnableBtagCheckbox, "mdTabOptionsEnableBtagCheckbox");
            this.mdTabOptionsEnableBtagCheckbox.Checked = true;
            this.mdTabOptionsEnableBtagCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mdTabOptionsEnableBtagCheckbox.Name = "mdTabOptionsEnableBtagCheckbox";
            this.mdTabOptionsEnableBtagCheckbox.UseVisualStyleBackColor = true;
            this.mdTabOptionsEnableBtagCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // mdTabOptionsEnableBtagLabel
            // 
            resources.ApplyResources(this.mdTabOptionsEnableBtagLabel, "mdTabOptionsEnableBtagLabel");
            this.mdTabOptionsEnableBtagLabel.Name = "mdTabOptionsEnableBtagLabel";
            // 
            // mdTabOptionsPointsGroup
            // 
            resources.ApplyResources(this.mdTabOptionsPointsGroup, "mdTabOptionsPointsGroup");
            this.mdTabOptionsPointsGroup.Controls.Add(this.mdTabOptionsTablePoints);
            this.mdTabOptionsPointsGroup.Name = "mdTabOptionsPointsGroup";
            this.mdTabOptionsPointsGroup.TabStop = false;
            // 
            // mdTabOptionsTablePoints
            // 
            resources.ApplyResources(this.mdTabOptionsTablePoints, "mdTabOptionsTablePoints");
            this.mdTabOptionsTablePoints.Controls.Add(this.mdTabOptionsEnablePointsLabel, 0, 0);
            this.mdTabOptionsTablePoints.Controls.Add(this.mdTabOptionsAddPointsCombo, 0, 1);
            this.mdTabOptionsTablePoints.Controls.Add(this.mdTabOptionsEnablePointsCheckbox, 1, 0);
            this.mdTabOptionsTablePoints.Controls.Add(this.mdTabOptionsAddPointsButton, 1, 1);
            this.mdTabOptionsTablePoints.Name = "mdTabOptionsTablePoints";
            // 
            // mdTabOptionsEnablePointsLabel
            // 
            resources.ApplyResources(this.mdTabOptionsEnablePointsLabel, "mdTabOptionsEnablePointsLabel");
            this.mdTabOptionsEnablePointsLabel.Name = "mdTabOptionsEnablePointsLabel";
            // 
            // mdTabOptionsAddPointsCombo
            // 
            resources.ApplyResources(this.mdTabOptionsAddPointsCombo, "mdTabOptionsAddPointsCombo");
            this.mdTabOptionsAddPointsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mdTabOptionsAddPointsCombo.Items.AddRange(new object[] {
            resources.GetString("mdTabOptionsAddPointsCombo.Items"),
            resources.GetString("mdTabOptionsAddPointsCombo.Items1"),
            resources.GetString("mdTabOptionsAddPointsCombo.Items2"),
            resources.GetString("mdTabOptionsAddPointsCombo.Items3"),
            resources.GetString("mdTabOptionsAddPointsCombo.Items4"),
            resources.GetString("mdTabOptionsAddPointsCombo.Items5"),
            resources.GetString("mdTabOptionsAddPointsCombo.Items6")});
            this.mdTabOptionsAddPointsCombo.Name = "mdTabOptionsAddPointsCombo";
            // 
            // mdTabOptionsEnablePointsCheckbox
            // 
            resources.ApplyResources(this.mdTabOptionsEnablePointsCheckbox, "mdTabOptionsEnablePointsCheckbox");
            this.mdTabOptionsEnablePointsCheckbox.Checked = true;
            this.mdTabOptionsEnablePointsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mdTabOptionsEnablePointsCheckbox.Name = "mdTabOptionsEnablePointsCheckbox";
            this.mdTabOptionsEnablePointsCheckbox.UseVisualStyleBackColor = true;
            this.mdTabOptionsEnablePointsCheckbox.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged_1);
            // 
            // mdTabOptionsAddPointsButton
            // 
            resources.ApplyResources(this.mdTabOptionsAddPointsButton, "mdTabOptionsAddPointsButton");
            this.mdTabOptionsAddPointsButton.Name = "mdTabOptionsAddPointsButton";
            this.mdTabOptionsAddPointsButton.UseVisualStyleBackColor = true;
            // 
            // mdTabOptionsTimeGroup
            // 
            resources.ApplyResources(this.mdTabOptionsTimeGroup, "mdTabOptionsTimeGroup");
            this.mdTabOptionsTimeGroup.Controls.Add(this.mdTabOptionsTimeTable);
            this.mdTabOptionsTimeGroup.Name = "mdTabOptionsTimeGroup";
            this.mdTabOptionsTimeGroup.TabStop = false;
            // 
            // mdTabOptionsTimeTable
            // 
            resources.ApplyResources(this.mdTabOptionsTimeTable, "mdTabOptionsTimeTable");
            this.mdTabOptionsTimeTable.Controls.Add(this.mdTabOptionsEnableTimeLabel, 0, 0);
            this.mdTabOptionsTimeTable.Controls.Add(this.mdTabOptionsEnableTimeCheckbox, 1, 0);
            this.mdTabOptionsTimeTable.Name = "mdTabOptionsTimeTable";
            // 
            // mdTabOptionsEnableTimeLabel
            // 
            resources.ApplyResources(this.mdTabOptionsEnableTimeLabel, "mdTabOptionsEnableTimeLabel");
            this.mdTabOptionsEnableTimeLabel.Name = "mdTabOptionsEnableTimeLabel";
            // 
            // mdTabOptionsEnableTimeCheckbox
            // 
            resources.ApplyResources(this.mdTabOptionsEnableTimeCheckbox, "mdTabOptionsEnableTimeCheckbox");
            this.mdTabOptionsEnableTimeCheckbox.Checked = true;
            this.mdTabOptionsEnableTimeCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mdTabOptionsEnableTimeCheckbox.Name = "mdTabOptionsEnableTimeCheckbox";
            this.mdTabOptionsEnableTimeCheckbox.UseVisualStyleBackColor = true;
            this.mdTabOptionsEnableTimeCheckbox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_1);
            // 
            // mdTabDatabase
            // 
            this.mdTabDatabase.Controls.Add(this.mdTabDatabaseTable);
            resources.ApplyResources(this.mdTabDatabase, "mdTabDatabase");
            this.mdTabDatabase.Name = "mdTabDatabase";
            this.mdTabDatabase.UseVisualStyleBackColor = true;
            // 
            // mdTabDatabaseTable
            // 
            resources.ApplyResources(this.mdTabDatabaseTable, "mdTabDatabaseTable");
            this.mdTabDatabaseTable.Controls.Add(this.panel1, 1, 0);
            this.mdTabDatabaseTable.Controls.Add(this.mdDatabaseTabControl, 0, 0);
            this.mdTabDatabaseTable.Name = "mdTabDatabaseTable";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mdTabDatabaseFilterCommandGroup);
            this.panel1.Controls.Add(this.mdTabDatabaseFilterUserGroup);
            this.panel1.Controls.Add(this.mdTabDatabaseSearchGroup);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // mdTabDatabaseFilterCommandGroup
            // 
            resources.ApplyResources(this.mdTabDatabaseFilterCommandGroup, "mdTabDatabaseFilterCommandGroup");
            this.mdTabDatabaseFilterCommandGroup.Controls.Add(this.mdTabDatabaseFilterCommandActive);
            this.mdTabDatabaseFilterCommandGroup.Name = "mdTabDatabaseFilterCommandGroup";
            this.mdTabDatabaseFilterCommandGroup.TabStop = false;
            // 
            // mdTabDatabaseFilterCommandActive
            // 
            resources.ApplyResources(this.mdTabDatabaseFilterCommandActive, "mdTabDatabaseFilterCommandActive");
            this.mdTabDatabaseFilterCommandActive.Name = "mdTabDatabaseFilterCommandActive";
            this.mdTabDatabaseFilterCommandActive.UseVisualStyleBackColor = true;
            // 
            // mdTabDatabaseFilterUserGroup
            // 
            resources.ApplyResources(this.mdTabDatabaseFilterUserGroup, "mdTabDatabaseFilterUserGroup");
            this.mdTabDatabaseFilterUserGroup.Controls.Add(this.tableLayoutPanel6);
            this.mdTabDatabaseFilterUserGroup.Controls.Add(this.mdTabDatabaseFilterUserOnline);
            this.mdTabDatabaseFilterUserGroup.Name = "mdTabDatabaseFilterUserGroup";
            this.mdTabDatabaseFilterUserGroup.TabStop = false;
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // mdTabDatabaseFilterUserOnline
            // 
            resources.ApplyResources(this.mdTabDatabaseFilterUserOnline, "mdTabDatabaseFilterUserOnline");
            this.mdTabDatabaseFilterUserOnline.Name = "mdTabDatabaseFilterUserOnline";
            this.mdTabDatabaseFilterUserOnline.UseVisualStyleBackColor = true;
            // 
            // mdTabDatabaseSearchGroup
            // 
            this.mdTabDatabaseSearchGroup.Controls.Add(this.mdTabDatabaseSearchButton);
            this.mdTabDatabaseSearchGroup.Controls.Add(this.mdTabDatabaseSearchBox);
            resources.ApplyResources(this.mdTabDatabaseSearchGroup, "mdTabDatabaseSearchGroup");
            this.mdTabDatabaseSearchGroup.Name = "mdTabDatabaseSearchGroup";
            this.mdTabDatabaseSearchGroup.TabStop = false;
            // 
            // mdTabDatabaseSearchButton
            // 
            resources.ApplyResources(this.mdTabDatabaseSearchButton, "mdTabDatabaseSearchButton");
            this.mdTabDatabaseSearchButton.Name = "mdTabDatabaseSearchButton";
            this.mdTabDatabaseSearchButton.UseVisualStyleBackColor = true;
            // 
            // mdTabDatabaseSearchBox
            // 
            resources.ApplyResources(this.mdTabDatabaseSearchBox, "mdTabDatabaseSearchBox");
            this.mdTabDatabaseSearchBox.Name = "mdTabDatabaseSearchBox";
            // 
            // mdDatabaseTabControl
            // 
            this.mdDatabaseTabControl.Controls.Add(this.mdDatabaseTabUsers);
            this.mdDatabaseTabControl.Controls.Add(this.mdDatabaseTabCommands);
            resources.ApplyResources(this.mdDatabaseTabControl, "mdDatabaseTabControl");
            this.mdDatabaseTabControl.Name = "mdDatabaseTabControl";
            this.mdDatabaseTabControl.SelectedIndex = 0;
            this.mdDatabaseTabControl.SelectedIndexChanged += new System.EventHandler(this.mdDatabaseTabControl_SelectedIndexChanged);
            // 
            // mdDatabaseTabUsers
            // 
            this.mdDatabaseTabUsers.Controls.Add(this.mdTabDatabaseViewUser);
            resources.ApplyResources(this.mdDatabaseTabUsers, "mdDatabaseTabUsers");
            this.mdDatabaseTabUsers.Name = "mdDatabaseTabUsers";
            this.mdDatabaseTabUsers.UseVisualStyleBackColor = true;
            // 
            // mdTabDatabaseViewUser
            // 
            this.mdTabDatabaseViewUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mdTabDatabaseHeaderUsername,
            this.mdTabDatabaseHeaderBtag,
            this.mdTabDatabaseHeaderPoints,
            this.mdTabDatabaseHeaderHours,
            this.mdTabDatabaseHeaderJoin,
            this.mdTabDatabaseHeaderFollow,
            this.mdTabDatabaseHeaderUserlevel});
            resources.ApplyResources(this.mdTabDatabaseViewUser, "mdTabDatabaseViewUser");
            this.mdTabDatabaseViewUser.FullRowSelect = true;
            this.mdTabDatabaseViewUser.GridLines = true;
            this.mdTabDatabaseViewUser.MultiSelect = false;
            this.mdTabDatabaseViewUser.Name = "mdTabDatabaseViewUser";
            this.mdTabDatabaseViewUser.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.mdTabDatabaseViewUser.UseCompatibleStateImageBehavior = false;
            this.mdTabDatabaseViewUser.View = System.Windows.Forms.View.Details;
            // 
            // mdTabDatabaseHeaderUsername
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderUsername, "mdTabDatabaseHeaderUsername");
            // 
            // mdTabDatabaseHeaderBtag
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderBtag, "mdTabDatabaseHeaderBtag");
            // 
            // mdTabDatabaseHeaderPoints
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderPoints, "mdTabDatabaseHeaderPoints");
            // 
            // mdTabDatabaseHeaderHours
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderHours, "mdTabDatabaseHeaderHours");
            // 
            // mdTabDatabaseHeaderJoin
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderJoin, "mdTabDatabaseHeaderJoin");
            // 
            // mdTabDatabaseHeaderFollow
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderFollow, "mdTabDatabaseHeaderFollow");
            // 
            // mdTabDatabaseHeaderUserlevel
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderUserlevel, "mdTabDatabaseHeaderUserlevel");
            // 
            // mdDatabaseTabCommands
            // 
            this.mdDatabaseTabCommands.Controls.Add(this.mdTabDatabaseViewCommand);
            resources.ApplyResources(this.mdDatabaseTabCommands, "mdDatabaseTabCommands");
            this.mdDatabaseTabCommands.Name = "mdDatabaseTabCommands";
            this.mdDatabaseTabCommands.UseVisualStyleBackColor = true;
            // 
            // mdTabDatabaseViewCommand
            // 
            this.mdTabDatabaseViewCommand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mdTabDatabaseHeaderComId,
            this.mdTabDatabaseHeaderCommand,
            this.mdTabDatabaseHeaderComLevel,
            this.mdTabDatabaseHeaderComResponse});
            resources.ApplyResources(this.mdTabDatabaseViewCommand, "mdTabDatabaseViewCommand");
            this.mdTabDatabaseViewCommand.FullRowSelect = true;
            this.mdTabDatabaseViewCommand.MultiSelect = false;
            this.mdTabDatabaseViewCommand.Name = "mdTabDatabaseViewCommand";
            this.mdTabDatabaseViewCommand.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.mdTabDatabaseViewCommand.UseCompatibleStateImageBehavior = false;
            this.mdTabDatabaseViewCommand.View = System.Windows.Forms.View.Details;
            // 
            // mdTabDatabaseHeaderComId
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderComId, "mdTabDatabaseHeaderComId");
            // 
            // mdTabDatabaseHeaderCommand
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderCommand, "mdTabDatabaseHeaderCommand");
            // 
            // mdTabDatabaseHeaderComLevel
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderComLevel, "mdTabDatabaseHeaderComLevel");
            // 
            // mdTabDatabaseHeaderComResponse
            // 
            resources.ApplyResources(this.mdTabDatabaseHeaderComResponse, "mdTabDatabaseHeaderComResponse");
            // 
            // mdTabDebug
            // 
            this.mdTabDebug.Controls.Add(this.mdTabDebugBorderFixPanel);
            resources.ApplyResources(this.mdTabDebug, "mdTabDebug");
            this.mdTabDebug.Name = "mdTabDebug";
            this.mdTabDebug.UseVisualStyleBackColor = true;
            // 
            // mdTabDebugBorderFixPanel
            // 
            this.mdTabDebugBorderFixPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mdTabDebugBorderFixPanel.Controls.Add(this.mdTabDebugLogTextBox);
            resources.ApplyResources(this.mdTabDebugBorderFixPanel, "mdTabDebugBorderFixPanel");
            this.mdTabDebugBorderFixPanel.Name = "mdTabDebugBorderFixPanel";
            // 
            // mdTabDebugLogTextBox
            // 
            this.mdTabDebugLogTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.mdTabDebugLogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.mdTabDebugLogTextBox, "mdTabDebugLogTextBox");
            this.mdTabDebugLogTextBox.Name = "mdTabDebugLogTextBox";
            this.mdTabDebugLogTextBox.ReadOnly = true;
            // 
            // mdContainerPanel
            // 
            this.mdContainerPanel.Controls.Add(this.mdTabControl);
            resources.ApplyResources(this.mdContainerPanel, "mdContainerPanel");
            this.mdContainerPanel.Name = "mdContainerPanel";
            // 
            // mdTabStreamTimer
            // 
            this.mdTabStreamTimer.Interval = 30000;
            this.mdTabStreamTimer.Tick += new System.EventHandler(this.StreamUpdateTimer_Tick);
            // 
            // MainDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.mdContainerPanel);
            this.Controls.Add(this.mdMenuStrip);
            this.Controls.Add(this.mdStatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainDialog";
            mdTabConnectSigninGroup.ResumeLayout(false);
            mdTabConnectSigninGroup.PerformLayout();
            this.mdTabConnectTable.ResumeLayout(false);
            this.mdTabConnectTable.PerformLayout();
            this.mdMenuStrip.ResumeLayout(false);
            this.mdMenuStrip.PerformLayout();
            this.mdStatusStrip.ResumeLayout(false);
            this.mdStatusStrip.PerformLayout();
            this.mdTabControl.ResumeLayout(false);
            this.mdTabConnect.ResumeLayout(false);
            this.mdTabConnect.PerformLayout();
            this.mdTabChat.ResumeLayout(false);
            this.mdTabChatTable.ResumeLayout(false);
            this.mdTabChatTable.PerformLayout();
            this.mdTabChatBorderFixPanel.ResumeLayout(false);
            this.mdTabChatStatsGroup.ResumeLayout(false);
            this.mdTabChatStatsGroup.PerformLayout();
            this.mdTabChatFiltersGroup.ResumeLayout(false);
            this.mdTabChatFiltersGroup.PerformLayout();
            this.mdTabChatTableFilters.ResumeLayout(false);
            this.mdTabChatTableFilters.PerformLayout();
            this.mdTabCommands.ResumeLayout(false);
            this.mdTabStream.ResumeLayout(false);
            this.mdTabStreamTable.ResumeLayout(false);
            this.mdTabStreamInfoPanel.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.mdTabStreamStreamInfoGroup.ResumeLayout(false);
            this.mdTabStreamStreamInfoGroup.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.mdTabStreamGeneralInfoGroup.ResumeLayout(false);
            this.mdTabStreamGeneralInfoGroup.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.mdTabOptions.ResumeLayout(false);
            this.mdTabOptionsScrollPanel.ResumeLayout(false);
            this.mdTabOptionsTable.ResumeLayout(false);
            this.mdTabOptionsTable.PerformLayout();
            this.mdTabOptionsBtagGroup.ResumeLayout(false);
            this.mdTabOptionsBtagGroup.PerformLayout();
            this.mdTabOptionsBtagTable.ResumeLayout(false);
            this.mdTabOptionsBtagTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdTabOptionsBtagCharNumeric)).EndInit();
            this.mdTabOptionsPointsGroup.ResumeLayout(false);
            this.mdTabOptionsPointsGroup.PerformLayout();
            this.mdTabOptionsTablePoints.ResumeLayout(false);
            this.mdTabOptionsTablePoints.PerformLayout();
            this.mdTabOptionsTimeGroup.ResumeLayout(false);
            this.mdTabOptionsTimeGroup.PerformLayout();
            this.mdTabOptionsTimeTable.ResumeLayout(false);
            this.mdTabOptionsTimeTable.PerformLayout();
            this.mdTabDatabase.ResumeLayout(false);
            this.mdTabDatabaseTable.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mdTabDatabaseFilterCommandGroup.ResumeLayout(false);
            this.mdTabDatabaseFilterCommandGroup.PerformLayout();
            this.mdTabDatabaseFilterUserGroup.ResumeLayout(false);
            this.mdTabDatabaseFilterUserGroup.PerformLayout();
            this.mdTabDatabaseSearchGroup.ResumeLayout(false);
            this.mdTabDatabaseSearchGroup.PerformLayout();
            this.mdDatabaseTabControl.ResumeLayout(false);
            this.mdDatabaseTabUsers.ResumeLayout(false);
            this.mdDatabaseTabCommands.ResumeLayout(false);
            this.mdTabDebug.ResumeLayout(false);
            this.mdTabDebugBorderFixPanel.ResumeLayout(false);
            this.mdContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button mdTabConnectPasswordButton;
        private Button mdTabConnectPasswordManualButton;
        private Button mdTabConnectStartButton;
        private Button mdTabDatabaseSearchButton;
        private Button mdTabOptionsAddPointsButton;
        private CheckBox mdTabChatHideBotCheckbox;
        private CheckBox mdTabChatHideCommandsCheckbox;
        private CheckBox mdTabChatHideStatusCheckbox;
        private CheckBox mdTabDatabaseFilterCommandActive;
        private CheckBox mdTabDatabaseFilterUserOnline;
        private CheckBox mdTabOptionsEnableBtagCheckbox;
        private CheckBox mdTabOptionsEnablePointsCheckbox;
        private CheckBox mdTabOptionsEnableTimeCheckbox;
        private ColumnHeader mdTabDatabaseHeaderBtag;
        private ColumnHeader mdTabDatabaseHeaderComId;
        private ColumnHeader mdTabDatabaseHeaderComLevel;
        private ColumnHeader mdTabDatabaseHeaderCommand;
        private ColumnHeader mdTabDatabaseHeaderComResponse;
        private ColumnHeader mdTabDatabaseHeaderFollow;
        private ColumnHeader mdTabDatabaseHeaderHours;
        private ColumnHeader mdTabDatabaseHeaderJoin;
        private ColumnHeader mdTabDatabaseHeaderPoints;
        private ColumnHeader mdTabDatabaseHeaderUserlevel;
        private ColumnHeader mdTabDatabaseHeaderUsername;
        private ColumnHeader mdViewListHeader;
        private ColumnHeader mdViewListHeaderIcon;
        private ComboBox mdTabOptionsAddPointsCombo;
        private GroupBox mdTabChatFiltersGroup;
        private GroupBox mdTabChatStatsGroup;
        private GroupBox mdTabDatabaseFilterCommandGroup;
        private GroupBox mdTabDatabaseFilterUserGroup;
        private GroupBox mdTabDatabaseSearchGroup;
        private GroupBox mdTabOptionsBtagGroup;
        private GroupBox mdTabOptionsPointsGroup;
        private GroupBox mdTabOptionsTimeGroup;
        private GroupBox mdTabStreamGeneralInfoGroup;
        private GroupBox mdTabStreamStreamInfoGroup;
        private Label mdTabChatChattersLabel;
        private Label mdTabChatViewersLabel;
        private Label mdTabConnectChannelLabel;
        private Label mdTabConnectNameLabel;
        private Label mdTabConnectPasswordLabel;
        private Label mdTabConnectRequiredLabel;
        private Label mdTabConnectSpreadsheetLabel;
        private Label mdTabOptionsBtagCharLabel;
        private Label mdTabOptionsEnableBtagLabel;
        private Label mdTabOptionsEnablePointsLabel;
        private Label mdTabOptionsEnableTimeLabel;
        private Label mdTabStreamGeneralDelay;
        private Label mdTabStreamGeneralDelayVar;
        private Label mdTabStreamGeneralFollowers;
        private Label mdTabStreamGeneralFollowersVar;
        private Label mdTabStreamGeneralGame;
        private Label mdTabStreamGeneralGameVar;
        private Label mdTabStreamGeneralLanguage;
        private Label mdTabStreamGeneralLanguageVar;
        private Label mdTabStreamGeneralMature;
        private Label mdTabStreamGeneralMatureVar;
        private Label mdTabStreamGeneralPartner;
        private Label mdTabStreamGeneralPartnerVar;
        private Label mdTabStreamGeneralViews;
        private Label mdTabStreamGeneralViewsVar;
        private Label mdTabStreamStreamCreated;
        private Label mdTabStreamStreamCreatedVar;
        private Label mdTabStreamStreamFps;
        private Label mdTabStreamStreamFpsVar;
        private Label mdTabStreamStreamGame;
        private Label mdTabStreamStreamGameVar;
        private Label mdTabStreamStreamOnline;
        private Label mdTabStreamStreamOnlineVar;
        private Label mdTabStreamStreamStatus;
        private Label mdTabStreamStreamStatusVar;
        private Label mdTabStreamStreamViewers;
        private Label mdTabStreamStreamViewersVar;
        private ListView mdTabChatViewerList;
        private ListView mdTabDatabaseViewCommand;
        private ListView mdTabDatabaseViewUser;
        private MaskedTextBox mdTabConnectPasswordBox;
        private MenuStrip mdMenuStrip;
        private NumericUpDown mdTabOptionsBtagCharNumeric;
        private Panel mdContainerPanel;
        private Panel mdTabChatBorderFixPanel;
        private Panel mdTabCommandsScrollPanel;
        private Panel mdTabDebugBorderFixPanel;
        private Panel mdTabOptionsScrollPanel;
        private Panel mdTabStreamInfoPanel;
        private Panel panel1;
        private RichTextBox mdTabChatMessageTextBox;
        private RichTextBox mdTabDebugLogTextBox;
        private StatusStrip mdStatusStrip;
        private TabControl mdDatabaseTabControl;
        public TabControl mdTabControl;
        private TableLayoutPanel mdTabChatTable;
        private TableLayoutPanel mdTabChatTableFilters;
        private TableLayoutPanel mdTabConnectTable;
        private TableLayoutPanel mdTabDatabaseTable;
        private TableLayoutPanel mdTabOptionsBtagTable;
        private TableLayoutPanel mdTabOptionsTable;
        private TableLayoutPanel mdTabOptionsTablePoints;
        private TableLayoutPanel mdTabOptionsTimeTable;
        private TableLayoutPanel mdTabStreamTable;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private TabPage mdDatabaseTabCommands;
        private TabPage mdDatabaseTabUsers;
        public TabPage mdTabChat;
        public TabPage mdTabCommands;
        public TabPage mdTabConnect;
        public TabPage mdTabDatabase;
        private TabPage mdTabDebug;
        public TabPage mdTabOptions;
        public TabPage mdTabStream;
        private TextBox mdTabChatSendTextBox;
        private TextBox mdTabConnectChannelBox;
        private TextBox mdTabConnectNameBox;
        private TextBox mdTabConnectSpreadsheetBox;
        private TextBox mdTabDatabaseSearchBox;
        private Timer mdTabStreamTimer;
        private ToolStripMenuItem aboutAdminibotToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem technicalSupportToolStripMenuItem;
        private ToolStripMenuItem viewHelpToolStripMenuItem;
        public ToolStripProgressBar mdStatusStripProgressBar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripStatusLabel mdStatusStripLabel;
        private ToolTip toolTip1;
        public WebBrowser mdTabStreamWebBrowser;
    }
}

