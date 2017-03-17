using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy
{
    class Irc
    {
        public bool IsConnected;
        public bool IsClosing;
        private string _nickname;
        private string _password;
        private string _channel;
        private string _user;
        private int _connectCount = 1;
        private decimal _payout;
        public Dictionary<string, Types.UserLevel> Userlist = new Dictionary<string, Types.UserLevel>();
        public Dictionary<string, string> Emotelist;
        public Database Db;
        private TcpClient _irc;
        private StreamReader _reader;
        private StreamWriter _writer;
        private Thread _listenerThread;
        private Thread _timerThread;
        private Thread _keepAliveThread;
        private Thread _userListProcessorThread;
        private Thread _messageQueueThread;
        private LinkedList<string> _messageList = new LinkedList<string>();
        private LinkedList<string> _sendRawList = new LinkedList<string>();

        public Irc(string nickname, string password, string channel)
        {
            if (_irc != null)
            {
                Program.EventLog("A connection is already established. Cancelling the other request...", Types.Log.Warning);
                return;
            }
            
            IsConnected = false;
            IsClosing = false;
            
            _nickname = nickname;
            _password = password;
            _channel = channel;

            Db = new Database();

            Thread sendRawThread = new Thread(HandleSendRawQueue) { IsBackground = true };
            sendRawThread.Start();

            Connect();
        }

        private void Connect()
        {
            _irc = new TcpClient();

            if (!Program.CheckConnection())
            {
                Program.EventLog("Couldn't connect to Twitch, please check your internet connection", Types.Log.Error);

                Close(true);

                return;
            }
            
            while (!_irc.Connected)
            {
                Program.MainDialog.EnableProgressBarUI();

                if (_connectCount < 2)
                {
                    Program.EventLog("Attempting to connect...", Types.Log.Info);
                }
                else
                {
                    Program.EventLog("Reattempting to connect (tried " + _connectCount + " times)...", Types.Log.Warning);
                }
                
                try
                {
                    // TODO: Give users a way to choose which one to use even.
                    _irc.Connect("192.16.64.144", 80);

                    _reader = new StreamReader(_irc.GetStream());
                    _writer = new StreamWriter(_irc.GetStream()) {AutoFlush = true};
                    
                    SendRaw("PASS " + _password);
                    SendRaw("NICK " + _nickname);
                    SendRaw("USER " + _nickname + " 8 * :" + _nickname);
                    SendRaw("JOIN #" + _channel);
                }
                catch (SocketException e)
                {
                    Program.EventLog("Unable to connect. Retrying in 5 seconds...", Types.Log.Error);
                    Program.ErrorLog(e, "Connect()");

                    _irc.Close();
                    _connectCount++;

                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    Program.EventLog("An error occured while trying to connect. Aborting...", Types.Log.Error);
                    Program.ErrorLog(e, "Connect()");

                    Close(true);
                }
                
                Program.MainDialog.DisableProgressBarUI();

                if (_irc.Connected)
                {
                    Program.EventLog("Successfully connected to the IRC-channel", Types.Log.Info);

                    Program.MainDialog.EnableTabsUI();

                    if (_nickname != _channel) AddUserToList(_nickname.ToLower(), true);
                    AddUserToList(_channel.ToLower(), false, true);

                    Program.Commands = new Commands(Db);
                    Program.Commands.InitializeCustomCommands();

                    GetEmotes();
                    StartThreads();

                    Program.ChatNotification(string.Format("Welcome to {0}'s chat room!", char.ToUpper(_channel[0]) + _channel.Substring(1)));
                    IsConnected = true;
                    IsClosing = false;
                }
            }
        }

        private void Close(bool hideChatNotification = false)
        {
            if (IsClosing)
            {
                Program.EventLog("The connection is already being closed. Cancelling the other request...", Types.Log.Warning);
                return;
            }
            
            IsConnected = false;
            IsClosing = true;
            
            if (_irc != null) _irc.Close();

            if (!hideChatNotification) Program.ChatNotification(string.Format("You have been disconnected from {0}'s chat room.", char.ToUpper(_channel[0]) + _channel.Substring(1)));

            Program.MainDialog.DisableTabsUI();

            Thread.CurrentThread.Join();
        }

        private void SendRaw(string message)
        {
            _sendRawList.AddLast(message);
        }

        private void HandleSendRawQueue(Object state)
        {
            string lastMessage = "";
            int tryCounter = 1;
            
            while (true)
            {
                if (_sendRawList.Count == 0) continue;

                string message = _sendRawList.First.Value;

                try
                {
                    lastMessage = message;
                    _writer.WriteLine(message);

                    _sendRawList.RemoveFirst();
                    tryCounter = 1;
                }
                catch (IOException)
                {
                    if (tryCounter <= 15)
                    {
                        Program.EventLog("Couldn't send data, retrying in 5 seconds (attempt " + tryCounter + ")...", Types.Log.Error);

                        if (lastMessage == message) tryCounter++;

                        Thread.Sleep(5000);
                    }
                    else
                    {
                        Program.EventLog("Couldn't send data a minute or longer, disconnecting...", Types.Log.Error);

                        Close();
                    }
                }
                catch (ObjectDisposedException)
                {
                    Program.EventLog("Couldn't send data because the connection is closed, skipping...", Types.Log.Error);
                }
                catch (Exception e)
                {
                    Program.ErrorLog(e, "HandleSendRawQueue()");
                    Close();
                }
            }
        }

        private void StartThreads()
        {
            _listenerThread = new Thread(ListenAction) { IsBackground = true };
            _listenerThread.Start();

            _timerThread = new Thread(WorkAction) { IsBackground = true };
            _timerThread.Start();

            _keepAliveThread = new Thread(KeepAliveAction) { IsBackground = true };
            _keepAliveThread.Start();

            _userListProcessorThread = new Thread(BuildUserList) { IsBackground = true };
            _userListProcessorThread.Start();

            _messageQueueThread = new Thread(HandleMessageQueue) { IsBackground = true };
            _messageQueueThread.Start();
        }

        public void SendMessage(string message)
        {
            _messageList.AddLast(message);
        }

        private void HandleMessageQueue(Object state)
        {
            while (_irc.Connected)
            {
                if (_messageList.Count == 0) continue;
                
                string message = _messageList.First.Value;

                Program.Chat(_nickname, message);
                SendRaw("PRIVMSG #" + _channel + " :" + message);

                _messageList.RemoveFirst();
            }
        }

        private void ListenAction()
        {
            try
            {
                while (_irc.Connected)
                {
                    string temp = _reader.ReadLine();
                    if (IsConnected) ParseMessage(temp);
                }
            }
            catch (IOException e)
            {
                Program.EventLog("A network error occured while trying to read the chat. Disconnecting...", Types.Log.Error);
                
                // We already notify the user what the error is, don't ErrorLog it.
                // Program.ErrorLog(e, "ListenAction()");
                
                Close();
            }
            catch (Exception e)
            {
                Program.EventLog("An error occured while trying to read the chat. Disconnecting...", Types.Log.Error);
                Program.ErrorLog(e, "ListenAction()");
                Close();
            }
        }

        private void KeepAliveAction()
        {
            while (_irc.Connected)
            {
                SendRaw("PING 1245");
                Thread.Sleep(30000);
            }
        }

        private void WorkAction()
        {
            if (!StreamOnline()) return;
            
            Thread.Sleep(60000);
            
            Console.WriteLine("Reached the WorkAction() -> StreamOnline() function.");

            // HandoutPoints();
        }

        private bool StreamOnline()
        {
            if (!_irc.Connected) return false;
            using (var w = new WebClient())
            {
                try
                {
                    w.Proxy = null;
                    var jsonData = w.DownloadString("https://api.twitch.tv/kraken/streams/" + _channel.ToLower());
                    JObject stream = JObject.Parse(jsonData);
                    if (stream["stream"].HasValues)
                    {
                        Program.EventLog("Stream status: Online", Types.Log.Info);
                        return true;
                    }
                }
                catch (SocketException)
                {
                    Program.EventLog("Stream status: Offline", Types.Log.Warning);
                    return false;
                }
                catch (WebException)
                {
                    Program.EventLog("Stream status: Offline", Types.Log.Warning);
                    return false;
                }
                catch (Exception e)
                {
                    Program.EventLog("Unable to connect to the Twitch API to check stream status", Types.Log.Error);
                    Program.ErrorLog(e, "StreamOnline()");
                    return false;
                }
            }

            Program.EventLog("Stream status: Offline", Types.Log.Warning);
            return false;
        }

        private void HandoutPoints()
        {
            Thread.Sleep(5000);

            _payout = Settings.Default.OptionPayout;
            var userlist = Program.Irc.Userlist;
            string users = "";

            lock (userlist)
            {
                foreach (var onlineViewer in userlist)
                {
                    if (!string.IsNullOrWhiteSpace(onlineViewer.Key)) users += onlineViewer.Key + ", ";
                }
            }

            users = users.TrimEnd(',', ' ');

            Program.EventLog(users, Types.Log.Info);
        }

        private void ParseMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            string[] msg = message.Split(' ');
            _user = GetUser(message).ToLower();

            if (string.IsNullOrWhiteSpace(_user))
            {
                Program.EventLog("Couldn't determine the username of a chat message, using \"[Unknown User]\" instead...");
                _user = "[Unknown User]";
            }

            if (_user == "twitchnotify")
            {
                // INFO: Twitch user "twitchnotify" posts "[USER] just subscribed!" messages.
                string temp = message.Substring(message.IndexOf(":", 1, StringComparison.Ordinal) + 1);
                Program.Chat(_user, temp, Types.Chat.Subscribe);
            }
            else if (_user == "jtv")
            {
                string temp = message.Substring(message.IndexOf(":", 1, StringComparison.Ordinal) + 1);
                Program.Chat(_user, temp, Types.Chat.Status);
            }
            else if (msg[0].Equals("PING"))
            {
                // INFO: These message are related to KeepAlive.

                SendRaw("PONG " + msg[1]);
            }
            else if (msg[1].Equals("PRIVMSG"))
            {
                // INFO: These message are the actual user messages.

                string temp = message.Substring(message.IndexOf(":", 1, StringComparison.Ordinal) + 1);
                Program.Chat(_user, temp);

                // handleMessage(temp);
            }
            else if (msg[1].Equals("JOIN"))
            {
                // INFO: These message show when a user joins the room.

                _user = GetUser(message);
                Program.Chat(_user, "joined.", Types.Chat.Status);
            }
            else if (msg[1].Equals("PART"))
            {
                // INFO: These message show when a user leaves the room.

                _user = GetUser(message);
                Program.Chat(_user, "left.", Types.Chat.Status, true);
                RemoveUserFromList(_user);
            }
            else if (msg[1].Equals("NOTICE"))
            {
                // INFO: These message show when IRC reports something.

                string temp = message.Substring(message.IndexOf(":", 1, StringComparison.Ordinal) + 1);

                Program.EventLog(temp, Types.Log.IRC);

                // Special conditions...
                if (temp.Contains("Login unsuccessful")) Close();
            }
            else if (msg[1].Equals("352"))
            {
                // INFO: These messages do something, I guess?

                AddUserToList(msg[4]);
            }
        }

        private void GetEmotes(string channel = null)
        {
            channel = channel ?? Settings.Default.OptionChannel.ToLower();

            using (var w = new WebClient())
            {
                w.Proxy = null;
                try
                {
                    if (!Program.CheckConnection())
                    {
                        Program.EventLog("Emoticons couldn't be downloaded", Types.Log.Error);
                        return;
                    }

                    var jsonData = w.DownloadString("https://api.twitch.tv/kraken/chat/" + channel + "/emoticons");
                    JObject stream = JObject.Parse(jsonData);

                    if (stream["emoticons"].HasValues)
                    {
                        Emotelist = stream["emoticons"].ToDictionary(
                            item => item["regex"].ToString(),
                            item => item["url"].ToString()
                        );

                    }
                }
                catch (Exception e)
                {
                    Program.ErrorLog(e, "GetEmotes()");
                }
            }
        }

        private string GetUser(string message)
        {
            string[] temp = message.Split('!');
            _user = temp[0].Substring(1);
            return _user;
        }

        public bool UserInList(string nick)
        {
            lock (Userlist)
            {
                return Userlist.ContainsKey(nick);
            }
        }

        public void AddUserToList(string nick, bool isBot = false, bool isBroadcaster = false)
        {
            lock (Userlist)
            {
                Db.NewUser(nick, isBot ? Types.UserLevel.Moderator : isBroadcaster ? Types.UserLevel.Broadcaster : Types.UserLevel.Viewer);
                var level = Db.GetUserLevel(nick);
                if (!UserInList(nick))
                {
                    Userlist.Add(nick, level);
                    Program.MainDialog.SafeInvoke(() =>
                    {
                        Program.MainDialog.AddUserToViewlist(nick, level);
                    });
                }
            }
        }

        private void AddUsersToList(List<string> nickList, Types.UserLevel level = Types.UserLevel.Viewer, Action progressAction = null)
        {
            //Add the userlist to the database, with level
            Db.NewUsers(nickList, level, progressAction);
            lock (Userlist)
            {
                //Convert the list to a dictionary (list value, param level)
                Dictionary<string, Types.UserLevel> newList = nickList
                                .ToDictionary(item => item, value => level);

                //Merge ^ this dictionary to the userlist.
                Userlist = Userlist.Concat(newList)
                    .GroupBy(kvp => kvp.Key, kvp => kvp.Value)
                    .ToDictionary(g => g.Key, g => g.First());

                Program.MainDialog.SafeInvoke(() =>
                {
                    Program.MainDialog.AddUsersToViewlist(newList);
                    Program.MainDialog.mdTabChat.Enabled = true; //TODO: Remove this!
                });
            }
        }

        public void RemoveUserFromList(string nick)
        {
            lock (Userlist)
            {
                if (!UserInList(nick)) return;
                Userlist.Remove(nick);
                Program.MainDialog.SafeInvoke(() =>
                {
                    Program.MainDialog.RemoveUserFromViewlist(nick);
                });
            }
        }

        private void BuildUserList()
        {
            Console.WriteLine(1);
            Program.EventLog("Downloading chat user list...", Types.Log.Info);

            Program.MainDialog.EnableProgressBarUI();

            string jsonData = "";
            bool error;

            if (Program.CheckConnection())
            {
                try
                {
                    using (var w = new WebClient())
                    {
                        jsonData = w.DownloadString("https://tmi.twitch.tv/group/user/" + Settings.Default.OptionChannel.ToLower() + "/chatters");
                        error = false;
                    }
                }
                catch (Exception)
                {
                    error = true;
                }
            }
            else
            {
                error = true;
            }

            if (!error)
            {
                if (!String.IsNullOrWhiteSpace(jsonData) || jsonData == "\"\"")
                {
                    JObject stream = JObject.Parse(jsonData);

                    int chatterCount = stream["chatter_count"].ToObject<int>();

                    if (chatterCount != 0)
                    {

                        Dictionary<string, List<string>> chattersListList = stream["chatters"].ToObject<Dictionary<string, List<string>>>();
                        Program.EventLog("Processing chat user list...", Types.Log.Info);
                        
                        Program.MainDialog.InitProgressBarUI(chatterCount);
                        
                        foreach (var list in chattersListList)
                        {
                            
                            Types.UserLevel level;

                            switch (list.Key)
                            {
                                case "moderators":
                                    level = Types.UserLevel.Moderator;
                                    break;
                                case "global_mods":
                                    level = Types.UserLevel.GlobalMod;
                                    break;
                                case "staff":
                                    level = Types.UserLevel.Staff;
                                    break;
                                case "admins":
                                    level = Types.UserLevel.Admin;
                                    break;
                                default:
                                    level = Types.UserLevel.Viewer;
                                    break;
                            }

                            Program.EventLog("Adding chat '" + level + "s' to database...", Types.Log.Info);

                            AddUsersToList(list.Value, level, () =>
                            {
                                Program.MainDialog.IncreaseProgressBarUI();
                            });

                            
                            
                        }
                        Program.EventLog("Chat user list succesfully processed", Types.Log.Info);

                        Program.MainDialog.DisableProgressBarUI();
                        
                    }
                    else
                    {
                        Program.EventLog("Chat user list contained no users", Types.Log.Info);
                    }
                }
                else
                {
                    Program.EventLog("Couldn't download chat user list", Types.Log.Warning);
                }
            }

            Program.MainDialog.DisableProgressBarUI();
        }
    }
}
