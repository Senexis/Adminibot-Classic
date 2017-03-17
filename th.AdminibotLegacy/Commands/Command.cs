
using System;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy.Command
{
    class Command : CommandBase
    {
        [CommandIsDefault(true)]
        [CommandUserLevel(Types.CommandLevel.Editor)]
        [CommandDescription("Adds command [command] which responds with [response]. Only [userlevel] can use that command.")]
        [CommandUsage("!command add [command] [userlevel] [response]")]
        public void Add(Types.UserLevel level, string user, string commandName, int commandLevel, string commandResponse)
        {
            if (!_db.CommandExists(commandName))
            {
                _db.AddCommand(commandName, commandResponse, (Types.CommandLevel)commandLevel);
                Program.Commands.CustomCommands.Add(commandName.ToLower(),
                    new CustomCommand(commandName, commandResponse, (Types.CommandLevel)commandLevel));
                Program.Irc.SendMessage(String.Format(Resources.CommandAddcomSuccess, commandName, user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandAddcomExists, commandName, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Editor)]
        [CommandDescription("Edits command [command] to respond with [response]. Changes user level to [userlevel].")]
        [CommandUsage("!command edit [command] [userlevel] [response]")]
        public void Edit(Types.UserLevel level, string user, string commandName, string commandResponse)
        {
            Edit(level, user, commandName, null, commandResponse);
        }

        [CommandUserLevel(Types.CommandLevel.Editor)]
        [CommandDescription("Edits command [command] to respond with [response]. Changes user level to [userlevel].")]
        [CommandUsage("!command edit [command] [userlevel] [response]")]
        public void Edit(Types.UserLevel level, string user, string commandName, int commandLevel, string commandResponse = null)
        {
            Edit(level, user, commandName, commandLevel, commandResponse);
        }

        private void Edit(Types.UserLevel level, string user, string commandName, int? commandLevel = null, string commandResponse = null)
        {
            if (_db.CommandExists(commandName))
            {
                if (commandResponse != null)
                {
                    _db.UpdateCommandResponse(commandName, commandResponse);
                    Program.Commands.CustomCommands[commandName.ToLower()].SetResponse(commandResponse);
                }
                if (commandLevel != null)
                {
                    _db.UpdateCommandLevel(commandName, (Types.CommandLevel)commandLevel);
                    Program.Commands.CustomCommands[commandName.ToLower()].CommandLevel = (Types.CommandLevel)commandLevel;
                }

                Program.Irc.SendMessage(String.Format(Resources.CommandEditcomSuccess, commandName, user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandEditcomNotFound, commandName, user));
            }
        }

        [CommandUserLevel(Types.CommandLevel.Editor)]
        [CommandDescription("Deletes command [command].")]
        [CommandUsage("!command remove [command]")]
        public void Remove(Types.UserLevel level, string user, string commandName)
        {
            if (_db.CommandExists(commandName))
            {
                _db.DeleteCommand(commandName);
                Program.Commands.CustomCommands.Remove(commandName.ToLower());
                Program.Irc.SendMessage(String.Format(Resources.CommandDelcomSuccess, commandName, user));
            }
            else
            {
                Program.Irc.SendMessage(String.Format(Resources.CommandDelcomNotFound, commandName, user));
            }
        }

        public Command(Database db) : base(db)
        {
        }
    }
}
