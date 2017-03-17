namespace th.AdminibotModern.Classes
{
    public static class Types
    {
        /// <summary>
        /// Collection of IrcStatus object states.
        /// </summary>
        public enum StatusLevel
        {
            Running,
            Starting,
            Stopping,
            Stopped,
            Error
        }

        /// <summary>
        /// Collection of EventLogger event levels of severity.
        /// </summary>
        public enum EventLevel
        {
            Irc,
            Info,
            Warning,
            Error,
            Exception
        }

        /// <summary>
        /// Collection of chat event / message types.
        /// </summary>
        public enum ChatType
        {
            Regular,
            Status,
            Subscribe,
            Notification,
            Unknown
        }

        /// <summary>
        /// Collection of Twitch user levels.
        /// </summary>
        public enum UserLevel
        {
            Viewer,
            Moderator,
            Editor,
            Broadcaster,
            GlobalMod,
            Admin,
            Staff
        }
    }
}
