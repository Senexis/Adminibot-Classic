using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy
{
    static class Program
    {
        public static MainDialog MainDialog;
        public static Irc Irc;
        public static CultureInfo CurrentCulture;
        public static Commands Commands;
        private static Thread _eventLogThread = new Thread(HandleEventLog) { IsBackground = true };
        private static Thread _errorLogThread = new Thread(HandleErrorLog) { IsBackground = true };
        private static LinkedList<string> _eventList = new LinkedList<string>();
        private static LinkedList<string> _errorList = new LinkedList<string>();

        public static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, "-");
        }
        
        //TODO: Get rid of this.
        public static void SafeInvoke(this Control control, Action handler)
        {
            try
            {
                if (control.IsDisposed) return;
                if (control.InvokeRequired)
                {
                    control.Invoke(handler);
                }
                else
                {
                    handler();
                }
            }
            catch (Exception e)
            {
                ErrorLog(e, "SafeInvoke()");
            }
        }

        public static bool CheckConnection()
        {
            while (true)
            {
                try
                {
                    using (var client = new WebClient())
                    using (client.OpenRead("http://www.twitch.tv/"))
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool CheckLength(int max, string message)
        {
            int messageCount = message.Length;
            return messageCount <= max;
        }

        public static void EventLog(string message, Types.Log type = Types.Log.Other)
        {
            string appendMessage = "[" + DateTime.Now.ToLongTimeString() + "] <" + type + "> " + message;

            // Output to the console
            Console.WriteLine(appendMessage);

            // Output to the StatusLabel and to the debug RichTextBox
            MainDialog.UpdateStatusTextUI(message);
            MainDialog.UpdateDebugTextUI(appendMessage);
            
            _eventList.AddLast(appendMessage);
        }

        private static void HandleEventLog()
        {
            string lastMessage = "";
            int tryCounter = 1;

            while (true)
            {
                if (_eventList.Count == 0) continue;

                string message = _eventList.First.Value;

                try
                {
                    StreamWriter eventStreamWriter = new StreamWriter(MakeValidFileName("events_" + DateTime.Now.ToShortDateString() + ".log"), true);
                    eventStreamWriter.WriteLine(message);
                    eventStreamWriter.Close();

                    _eventList.RemoveFirst();
                    tryCounter = 1;
                    Thread.Sleep(100);
                }
                catch (IOException)
                {
                    EventLog("Couldn't write event data to file, retrying in a second (attempt " + tryCounter + ")...", Types.Log.Error);

                    if (lastMessage == message) tryCounter++;

                    Thread.Sleep(1000);
                }
                catch (UnauthorizedAccessException)
                {
                    EventLog("Couldn't access event data file, retrying in a second (attempt " + tryCounter + ")...", Types.Log.Error);

                    if (lastMessage == message) tryCounter++;

                    Thread.Sleep(1000);
                }
                catch (SecurityException)
                {
                    EventLog("Not allowed to access event data file, retrying in a second (attempt " + tryCounter + ")...", Types.Log.Error);

                    if (lastMessage == message) tryCounter++;

                    Thread.Sleep(1000);
                }
            }
        }

        public static void ErrorLog(Exception error, string location = null)
        {
            string errorMessage;
            
            // Output to the console (disabled by default due to longness)
            // Console.WriteLine(error);

            if (!string.IsNullOrEmpty(location))
            {
                EventLog("An error occured at " + location + ". For more information, see \"" + MakeValidFileName("errors_" + DateTime.Now.ToShortDateString() + ".log") + "\"", Types.Log.Exception);
                errorMessage = "************** Error Message (from " + location + ") on " + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToLongTimeString() + " **************" + Environment.NewLine + error + Environment.NewLine;
            }
            else
            {
                EventLog("An error occured. For more information, see \"" + MakeValidFileName("errors_" + DateTime.Now.ToShortDateString() + ".log") + "\"", Types.Log.Exception);
                errorMessage = "************** Error Message on " + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToLongTimeString() + " **************" + Environment.NewLine + error + Environment.NewLine;
            }

            _errorList.AddLast(errorMessage);
        }

        private static void HandleErrorLog()
        {
            string lastMessage = "";
            int tryCounter = 1;

            while (true)
            {
                if (_errorList.Count == 0) continue;

                string message = _errorList.First.Value;

                try
                {
                    StreamWriter eventStreamWriter = new StreamWriter(MakeValidFileName("errors_" + DateTime.Now.ToShortDateString() + ".log"), true);
                    eventStreamWriter.WriteLine(message);
                    eventStreamWriter.Close();

                    _errorList.RemoveFirst();
                    tryCounter = 1;
                    Thread.Sleep(100);
                }
                catch (IOException)
                {
                    EventLog("Couldn't write error data to file, retrying in a second (attempt " + tryCounter + ")...", Types.Log.Error);

                    if (lastMessage == message) tryCounter++;

                    Thread.Sleep(1000);
                }
                catch (UnauthorizedAccessException)
                {
                    EventLog("Couldn't access error data file, retrying in a second (attempt " + tryCounter + ")...", Types.Log.Error);

                    if (lastMessage == message) tryCounter++;

                    Thread.Sleep(1000);
                }
                catch (SecurityException)
                {
                    EventLog("Not allowed to access error data file, retrying in a second (attempt " + tryCounter + ")...", Types.Log.Error);

                    if (lastMessage == message) tryCounter++;

                    Thread.Sleep(1000);
                }
            }
        }

        public static void Chat(string user, string message, Types.Chat type = Types.Chat.Regular, bool isLeave = false)
        {
            string lvlColor = @"\cf" + (int)Rtf.Colors[(Irc.UserInList(user) ? Irc.Userlist[user] : Types.UserLevel.Viewer).ToString()][0];
            string typeColor = @"\cf" + (int)Rtf.Colors[type.ToString()][0];
            string appendText;

            if ((type == Types.Chat.Regular && type == Types.Chat.Status || type == Types.Chat.Subscribe))
            {
                if (!isLeave && !Irc.UserInList(user)) Irc.AddUserToList(user);
                else if(isLeave) Irc.RemoveUserFromList(user);
            }
                

            if (Settings.Default.OptionHideBotMsg && string.Equals(user, Settings.Default.OptionName, StringComparison.OrdinalIgnoreCase)) return;
            
            switch (type)
            {
                case Types.Chat.Regular:
                    // Handle commands.
                    string[] wordArray = message.Split('"')
                     .Select((element, index) => index % 2 == 0  // If even index
                                           ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
                                           : new[] { element })  // Keep the entire item
                     .SelectMany(element => element).ToArray();
                    if (Irc.UserInList(user) && Regex.IsMatch(wordArray[0], @"^(?=^[!][\d]*[A-Z|a-z])|(?=^[!][A-Z|a-z][\d|A-Z|a-z])"))
                    {
                        string[] paramStrings = new string[wordArray.Length-1];
                        for (int i = 1; i < wordArray.Length; i++)
                            paramStrings[i - 1] = wordArray[i];
                        Commands.ExecuteCommand(user, Irc.Userlist[user], wordArray[0].Substring(1), paramStrings);
                    }

                    // Regular chat messages.
                    string userString = "{" + lvlColor + "<" + user + ">} ";
                    Dictionary<string, string> emoteList = Irc != null && Irc.Emotelist != null ? Irc.Emotelist : new Dictionary<string, string>();
                    message = Rtf.EscapeString(message);
                    appendText = typeColor + userString + (emoteList.Aggregate(message, (current, pair) => Regex.IsMatch(message, "(^| )" + pair.Key + "( |$)") ? Regex.Replace(current, "(^| )" + pair.Key + "( |$)", Rtf.GetEmbedImageString(pair.Value.ToString()) ?? pair.Key.ToString()) : current));
                    break;
                case Types.Chat.Status:
                    // "Joined" and "Left" messages.
                    if (Settings.Default.OptionHideStatusMsg) return;
                    appendText = typeColor + user + " " + message.Trim();
                    break;
                case Types.Chat.Subscribe:
                    // "[USER] just subscribed!" messages.
                    appendText = typeColor + message.Substring(message.IndexOf(":", 1) + 1).Trim();
                    break;
                default:
                    // UNKNOWN, report as ERROR event.
                    appendText = null;
                    EventLog("A chat message of an unknown type (type: " + type + ") has been received", Types.Log.Error);
                    break;
            }

            // Output to the console (disabled by default due to muchness)
            // Console.WriteLine(message.Trim());

            // Output to the chat RichTextBox
            MainDialog.UpdateChatTextUI(appendText);
        }

        public static void ChatNotification(string message)
        {
            string typeColor = @"\cf" + (int)Rtf.Colors[Types.Chat.Notification.ToString()][0];
            string appendText;

            appendText = typeColor + message.Trim();

            // Output to the chat RichTextBox
            MainDialog.UpdateChatTextUI(appendText);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _errorLogThread.Start();
            _eventLogThread.Start();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainDialog = new MainDialog();
            Application.Run(MainDialog);
        }
    }
}
