using System;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy.Command
{
    class Time : CommandBase
    {
        [CommandUserLevel(Types.CommandLevel.Viewer)]
        [CommandDescription("Returns the time you have watched the stream.")]
        [CommandUsage("!time")]
        public void Default(Types.UserLevel level, string user)
        {
            if (!Settings.Default.OptionComTimeEnabled) return;

            if (_db.UserExists(user))
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandTimeMainSuccess, _db.GetTime(user), user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandTimeMainWait, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Returns the time [username] has watched the stream.")]
        [CommandUsage("!time get [username]")]
        public void Get(Types.UserLevel level, string user, string target)
        {
            if (!Settings.Default.OptionComTimeEnabled) return;

            if (_db.UserExists(target))
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandTimeGetSuccess, target, _db.GetTime(target), user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandTimeGetNotFound, target, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Editor)]
        [CommandDescription("Changes whether regular users can use !time command.")]
        [CommandUsage("!time enabled [boolean]")]
        public void Enabled(Types.UserLevel level, string user, bool onoff)
        {
            if (onoff)
            {
                Settings.Default.OptionComTimeEnabled = true;
                Settings.Default.Save();
                Program.Irc.SendMessage(String.Format(Resources.CommandTimeEnabledOnSuccess, user));
            }
            else
            {
                Settings.Default.OptionComTimeEnabled = false;
                Settings.Default.Save();
                Program.Irc.SendMessage(String.Format(Resources.CommandTimeEnabledOffSuccess, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Returns the top [integer] of users who watched the stream the longest.")]
        [CommandUsage("!time top [integer]")]
        public void Top(Types.UserLevel level, string user, int number = 3)
        {
            if (!Settings.Default.OptionComTimeEnabled) return;

            string userTop = _db.GetTimeTop(number);

            if (!string.IsNullOrWhiteSpace(userTop))
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandTimeTopSuccess, userTop, user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandTimeTopNoResults, user));
            }
        }

        public Time(Database db) : base(db)
        {
        }
    }
}
