namespace th.AdminibotLegacy
{
    public class Types
    {
        public enum Log
        {
            Info,
            Warning,
            Error,
            IRC,
            Exception,
            Other
        };

        public enum Chat
        {
            Regular,
            Status,
            Subscribe,
            Notification,
            Unknown
        };

        public enum UserLevel
        {
            Viewer,
            Moderator,
            Editor,
            Broadcaster,
            GlobalMod,
            Admin,
            Staff
        };

        public enum CommandLevel
        {
            Viewer,
            Moderator,
            Editor,
            Broadcaster
        }

        public enum Priority
        {
            High,
            Normal,
            Low
        }
        public enum ScrollBarType : uint
        {
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }
        public enum ScrollInfoMask : uint
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS)
        }

        public static string GetUserLevelLetter(UserLevel level)
        {
            string letter = "Z";
            switch (level)
            {
                case UserLevel.Broadcaster:
                    letter = "A";
                    break;
                case UserLevel.Staff:
                    letter = "B";
                    break;
                case UserLevel.Admin:
                    letter = "C";
                    break;
                case UserLevel.GlobalMod:
                    letter = "D";
                    break;
                case UserLevel.Editor:
                    letter = "E";
                    break;
                case UserLevel.Moderator:
                    letter = "F";
                    break;
                case UserLevel.Viewer:
                    letter = "G";
                    break;
            }
            return letter;
        }
    }
}
