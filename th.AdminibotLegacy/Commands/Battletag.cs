using System;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy.Command
{
    class Battletag : CommandBase
    {
        [CommandUserLevel(Types.CommandLevel.Viewer)]
        [CommandDescription("Returns your current battle tag.")]
        [CommandUsage("!btag / !battletag")]
        public void Default(Types.UserLevel level, string user)
        {
            if (!Settings.Default.OptionComBtagEnabled) return;

            if (_db.BtagExists(user))
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagMainSuccess, _db.GetBtag(user), user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagMainNotFound, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Viewer)]
        [CommandDescription("Change your current battle tag to [message].")]
        [CommandUsage("!btag / !battletag [message]")]
        public void Set(Types.UserLevel level, string user, string message)
        {
            if (!Settings.Default.OptionComBtagEnabled) return;

            int maxChars = Settings.Default.OptionComBtagMaxChars;
            bool msgLength = Program.CheckLength(maxChars, message);

            if (msgLength)
            {
                _db.UpdateBtag(user, message);
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagSetSuccess, message, user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagSetTooLong, maxChars, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Changes the battletag of [username] to [message].")]
        [CommandUsage("!btag / !battletag [username] [message]")]
        public void Set(Types.UserLevel level, string user, string target, string message)
        {
            if (!Settings.Default.OptionComBtagEnabled) return;

            int maxChars = Settings.Default.OptionComBtagMaxChars;
            bool userExists = _db.UserExists(target);
            bool msgLength = Program.CheckLength(maxChars, message);

            if (userExists && msgLength)
            {
                _db.UpdateBtag(target, message);
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagSetModSuccess, target, message, user));
            }
            else if (!userExists)
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagSetModNotFound, target, user));
            }
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            else if (!msgLength)
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagSetModTooLong, maxChars, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Viewer)]
        [CommandDescription("Removes your own battletag.")]
        [CommandUsage("!btag / !battletag remove")]
        public void Remove(Types.UserLevel level, string user)
        {
            if (!Settings.Default.OptionComBtagEnabled) return;

            if (_db.BtagExists(user))
            {
                _db.DeleteBtag(user);
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagRemoveSuccess, user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagRemoveNoTag, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Removes the battletag of [username].")]
        [CommandUsage("!btag / !battletag remove [username]")]
        public void Remove(Types.UserLevel level, string user, string target)
        {
            if (!Settings.Default.OptionComBtagEnabled) return;

            bool userExists = _db.UserExists(target);
            bool btagExists = _db.BtagExists(target);

            if (userExists && btagExists)
            {
                _db.DeleteBtag(target);
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagRemoveModSuccess, target, user));
            }
            else if (!userExists)
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagRemoveModNotFound, target, user));
            }
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            else if (!btagExists)
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandBtagRemoveModNoTag, target, user));
            }
        }

        public Battletag(Database db) : base(db)
        {
        }
    }
}
