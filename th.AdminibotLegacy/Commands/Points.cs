using System;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy.Command
{
    class Points : CommandBase
    {
        [CommandUserLevel(Types.CommandLevel.Viewer)]
        [CommandDescription("Returns the amount of points you have.")]
        [CommandUsage("!points / !currency / ![currency]")]
        public void Default(Types.UserLevel level, string user)
        {
            if (!Settings.Default.OptionComPointsEnabled) return;

            if (_db.UserExists(user))
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandPointsMainSuccess, _db.GetPoints(user), user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandPointsMainWait, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Editor)]
        [CommandDescription("Changes whether regular users can use the !currency command.")]
        [CommandUsage("!points / !currency / ![currency] enabled [boolean]")]
        public void Enabled(Types.UserLevel level, string user, bool onoff)
        {
            if (onoff)
            {
                Settings.Default.OptionComPointsEnabled = true;
                Settings.Default.Save();
                Program.Irc.SendMessage(String.Format(Resources.CommandPointsEnabledOnSuccess, user));
            }
            else
            {
                Settings.Default.OptionComPointsEnabled = false;
                Settings.Default.Save();
                Program.Irc.SendMessage(String.Format(Resources.CommandPointsEnabledOffSuccess, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Returns the amount of points [username] has.")]
        [CommandUsage("!points / !currency / ![currency] get [username]")]
        public void Get(Types.UserLevel level, string user, string target)
        {
            if (!Settings.Default.OptionComPointsEnabled) return;

            if (_db.UserExists(target))
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandPointsGetSuccess, target, _db.GetPoints(target), user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandPointsGetNotFound, target, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Editor)]
        [CommandDescription("Adds [integer] points to [username], [online] users, or [all] users.")]
        [CommandUsage("!points / !currency / ![currency] add [username / online / all] [integer]")]
        public void Add(Types.UserLevel level, string user, string target, int amount)
        {
            if (!Settings.Default.OptionComPointsEnabled) return;

            switch (target)
            {
                case "all":
                    _db.AddPointsAll(amount);
                    Program.Irc.SendMessage(String.Format(Resources.CommandPointsAddAllSuccess, amount, user));
                    break;
                case "online":
                    foreach (var onlineViewer in Program.Irc.Userlist)
                    {
                        if (!string.IsNullOrWhiteSpace(onlineViewer.Key)) _db.AddPoints(onlineViewer.Key, amount);
                    }
                    Program.Irc.SendMessage(String.Format(Resources.CommandPointsAddOnlineSuccess, amount, user));
                    break;
                default:
                    if (_db.UserExists(target))
                    {
                        _db.AddPoints(target, amount);
                        Program.Irc.SendMessage(String.Format(Resources.CommandPointsAddSuccess, target, amount, user));
                    }
                    else
                    {
                        Program.Irc.SendMessage(String.Format(Resources.CommandPointsAddNotFound, target, user));
                    }
                    break;
            }
        }

        [CommandUserLevel(Types.CommandLevel.Editor)]
        [CommandDescription("Removes [integer] points from [username], [online] users, or [all] users.")]
        [CommandUsage("!points / !currency / ![currency] remove [username / online / all] [integer]")]
        public void Remove(Types.UserLevel level, string user, string target, int amount)
        {
            if (!Settings.Default.OptionComPointsEnabled) return;

            switch (target)
            {
                case "all":
                    _db.RemovePointsAll(amount);
                    Program.Irc.SendMessage(String.Format(Resources.CommandPointsRemoveAllSuccess, user, amount));
                    break;
                case "online":
                    foreach (var onlineViewer in Program.Irc.Userlist)
                    {
                        if (!string.IsNullOrWhiteSpace(onlineViewer.Key)) _db.RemovePoints(onlineViewer.Key, amount);
                    }
                    Program.Irc.SendMessage(String.Format(Resources.CommandPointsRemoveOnlineSuccess, user, amount));
                    break;
                default:
                    if (_db.UserExists(target))
                    {
                        _db.RemovePoints(target, amount);
                        Program.Irc.SendMessage(String.Format(Resources.CommandPointsRemoveSuccess, user, amount, target));
                    }
                    else
                    {
                        Program.Irc.SendMessage(String.Format(Resources.CommandPointsRemoveNotFound, target, user));
                    }
                    break;
            }
        }

        [CommandUserLevel(Types.CommandLevel.Broadcaster)]
        [CommandDescription("Sets the points from [username], [online] users, or [all] users to [integer].")]
        [CommandUsage("!points / !currency / ![currency] set [username / online / all]")]
        public void Set(Types.UserLevel level, string user, string target, int amount)
        {
            if (!Settings.Default.OptionComPointsEnabled) return;

            switch (target)
            {
                case "all":
                    _db.SetPointsAll(amount);
                    Program.Irc.SendMessage(String.Format(Resources.CommandPointsSetAllSuccess, amount, user));
                    break;
                case "online":
                    foreach (var onlineViewer in Program.Irc.Userlist)
                    {
                        if (!string.IsNullOrWhiteSpace(onlineViewer.Key)) _db.SetPoints(onlineViewer.Key, amount);
                    }
                    Program.Irc.SendMessage(String.Format(Resources.CommandPointsSetOnlineSuccess, amount, user));
                    break;
                default:
                    if (_db.UserExists(target))
                    {
                        _db.SetPoints(target, amount);
                        Program.Irc.SendMessage(String.Format(Resources.CommandPointsSetSuccess, target, amount, user));
                    }
                    else
                    {
                        Program.Irc.SendMessage(String.Format(Resources.CommandPointsSetNotFound, target, user));
                    }
                    break;
            }
        }

        [CommandUserLevel(Types.CommandLevel.Broadcaster)]
        [CommandDescription("Clears the amount of points [all] users, [online] users, or [username] has (sets points to 0).")]
        [CommandUsage("!points / !currency / ![currency] clear [username / online / all]")]
        public void Clear(Types.UserLevel level, string user, string target)
        {
            if (!Settings.Default.OptionComPointsEnabled) return;

            switch (target)
            {
                case "all":
                    _db.ClearPointsAll();
                    Program.Irc.SendMessage(String.Format(Resources.CommandPointsClearAllSuccess, user));
                    break;
                case "online":
                    foreach (var onlineViewer in Program.Irc.Userlist)
                    {
                        if (!string.IsNullOrWhiteSpace(onlineViewer.Key)) _db.ClearPoints(onlineViewer.Key);
                    }
                    Program.Irc.SendMessage(String.Format(Resources.CommandPointsClearOnlineSuccess, user));
                    break;
                default:
                    if (_db.UserExists(target))
                    {
                        _db.ClearPoints(target);
                        Program.Irc.SendMessage(String.Format(Resources.CommandPointsClearSuccess, target, user));
                    }
                    else
                    {
                        Program.Irc.SendMessage(String.Format(Resources.CommandPointsClearNotFound, target, user));
                    }
                    break;
            }
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Returns the top [integer] of users with the most points.")]
        [CommandUsage("!points / !currency / ![currency] top [integer]")]
        public void Top(Types.UserLevel level, string user, int number = 3)
        {
            if (!Settings.Default.OptionComPointsEnabled) return;

            string userTop = _db.GetPointsTop(number);

            if (!string.IsNullOrWhiteSpace(userTop))
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandPointsTopSuccess, userTop, user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandPointsTopNoResults, user));
            }
        }

        public Points(Database db) : base(db)
        {
        }
    }
}
