using System;
using System.Collections.Generic;
using th.AdminibotModern.Classes.Database;

namespace th.AdminibotModern.Classes
{
    class ChatClient : IrcClient
    {
        private string _nickname;
        private string _passwordToken;
        private string _channel;
        private string _user;
        public Dictionary<string, Types.UserLevel> Userlist = new Dictionary<string, Types.UserLevel>();

        public ChatClient(string nickname, string passwordToken, string channel) : base(nickname, passwordToken, channel)
        {
            _nickname = nickname;
            _passwordToken = passwordToken;
            _channel = channel;
        }

        public void SendMessage(string message)
        {
            AddToQueue("PRIVMSG #" + _channel + " :" + message);
        }

        protected override void ReceivedMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            string[] argumentStrings = message.Split(' ');
            _user = GetUser(message).ToLower();

            if (string.IsNullOrWhiteSpace(_user))
            {
                EventLogger.AddEvent(Types.EventLevel.Warning, "Could not determine the username from a chat message, using a placeholder user instead.");
                _user = "Unknown User";
            }

            if (_user == "twitchnotify") // Hit when "{User} just subscribed!" messages are received.
            {
                string currentMessage = message.Substring(message.IndexOf(":", 1, StringComparison.Ordinal) + 1);
                // TODO: Post to GUI here.
            }
            else if (_user == "jtv") // Hit when JTV / Twitch status messages are received.
            {
                string currentMessage = message.Substring(message.IndexOf(":", 1, StringComparison.Ordinal) + 1);
                // TODO: Post to GUI here.
            }
            else if (argumentStrings[0].Equals("PING")) // Hit when IRC sends a ping to the client.
            {
                AddToQueue("PONG " + argumentStrings[1]);
            }
            else if (argumentStrings[1].Equals("PRIVMSG")) // Hit when another user's messages are received.
            {
                string currentMessage = message.Substring(message.IndexOf(":", 1, StringComparison.Ordinal) + 1);
                // TODO: Post to GUI here.
            }
            else if (argumentStrings[1].Equals("JOIN")) // Hit when another user joins the chat.
            {
                _user = GetUser(message);
                // TODO: Post to GUI here.
            }
            else if (argumentStrings[1].Equals("PART")) // Hit when another user leaves the chat.
            {
                _user = GetUser(message);
                // TODO: Post to GUI here.
                RemoveUser(_user);
            }
            else if (argumentStrings[1].Equals("NOTICE")) // Hit when IRC report messages are received.
            {
                string currentMessage = message.Substring(message.IndexOf(":", 1, StringComparison.Ordinal) + 1);
                EventLogger.AddEvent(Types.EventLevel.Irc, "Received the following IRC notification: " + currentMessage);

                if (currentMessage.Contains("Login unsuccessful") || currentMessage.Contains("Error logging in"))
                {
                    EventLogger.AddEvent(Types.EventLevel.Error, "IRC reported that it could not successfully connect to the Twitch chat services, disconnecting from the services.");
                    Disconnect();
                }
            }
            else if (argumentStrings[1].Equals("001"))
            {
                EventLogger.AddEvent(Types.EventLevel.Irc, "IRC sent us a welcoming message, confirming that now have a connection.");
            }
            else if (argumentStrings[1].Equals("352")) // Hit when another user gets identified by IRC "WHO" reponses.
            {
                AddUser(argumentStrings[4]);
            }
            else
            {
                EventLogger.AddEvent(Types.EventLevel.Irc, message);
            }
        }

        private string GetUser(string message)
        {
            string[] argumentStrings = message.Split('!');
            _user = argumentStrings[0].Substring(1);
            return _user;
        }

        private void AddUser(string username, bool isBot = false, bool isBroadcaster = false)
        {
            
        }

        private void AddUsers(Dictionary<string, Types.UserLevel> userList)
        {
            
        }

        private void RemoveUser(string username)
        {
            
        }

        private bool UserExists(string username)
        {
            return false;
        }

        private void GenerateUserList()
        {
            
        }
    }
}
