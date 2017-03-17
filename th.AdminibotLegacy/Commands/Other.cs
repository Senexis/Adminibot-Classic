using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Newtonsoft.Json.Linq;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy.Command
{
    class Other : CommandBase
    {
        #region Shoutout

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Gives a shoutout by the bot to [username]")]
        [CommandUsage("!shoutout [username]")]
        public void Shoutout(Types.UserLevel level, string user, string strUser)
        {
            using (var w = new WebClient())
            {
                w.Proxy = null;
                try
                {
                    if (Program.CheckConnection())
                    {
                        var jsonData =
                            w.DownloadString("https://api.twitch.tv/kraken/channels/" + Uri.EscapeDataString(strUser));
                        JObject stream = JObject.Parse(jsonData);

                        if (stream.Property("error") == null)
                        {
                            user = user.Substring(0, 1).ToUpper() + user.Substring(1);
                            Program.Irc.SendMessage(String.Format(Resources.CommandShoutoutSuccess, strUser));
                        }
                        else
                        {
                            Program.Irc.SendMessage(String.Format(Resources.CommandShoutoutError, user));
                        }
                    }


                }
                catch (WebException)
                {
                    Program.Irc.SendMessage(String.Format(Resources.CommandShoutoutNotFound, strUser, user));
                }
                catch (Exception e)
                {
                    Program.Irc.SendMessage(String.Format(Resources.CommandShoutoutError, user));
                    Program.ErrorLog(e, "Shoutout()");
                }
            }
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Gives a shoutout by the bot to [username]")]
        [CommandUsage("!shoutout [username]")]
        public void So(Types.UserLevel level, string user, string strUser)
        {
            Shoutout(level, user, strUser);
        }

        #endregion

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Gives a list of information, or sub commands, or commands usage")]
        [CommandUsage("!help [command] [subcommand]")]
        public void Help(Types.UserLevel level, string user)
        {
            List<string> comList = new List<string>();
            foreach (var com in Program.Commands.InternalCommands)
            {
                var methods = com.Value.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                if (!methods.Any(c => Program.Commands.CommandHasLevel(Program.Commands.GetCommandLevel(level), c)))
                    continue;
                string comStr = "";
                if (com.Key != "other")
                {
                    comStr = "!" + com.Key;
                    List<string> aliasList = new List<string>();
                    foreach (var alias in Program.Commands.CommandAliases)
                    {
                        if (com.Value == alias.Value) aliasList.Add(alias.Key);
                    }

                    aliasList.Sort();

                    comStr = aliasList.Aggregate(comStr, (current, alias) => current + ("/!" + alias));
                
                    comList.Add(comStr);
                }
                else
                {
                    List<string> methodList = new List<string>();
                    foreach (var method in methods)
                        if(Program.Commands.CommandHasLevel(Program.Commands.GetCommandLevel(level), method))
                            if(!methodList.Contains(method.Name))
                                methodList.Add(method.Name);

                    methodList.Sort();

                    comList.AddRange(methodList.Select(method => "!" + method.ToLower()));
                }
            }
            comList.Sort();
            string commands = "";
            foreach (var s in comList)
                commands += s + ", ";
            commands = commands.Remove(commands.Length-2);
            Program.Irc.SendMessage(string.Format(Resources.CommandHelp, Program.Commands.GetCommandLevel(level).ToString().ToLower(), commands, user));
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Gives a list of information, or sub commands, or commands usage")]
        [CommandUsage("!help [command] [subcommand]")]
        public void Help(Types.UserLevel level, string user, string commandName)
        {
            if (commandName == "other") return;

            if (Program.Commands.InternalCommands.ContainsKey(commandName.ToLower())
                || Program.Commands.CommandAliases.ContainsKey(commandName.ToLower()))
            {
                CommandBase cmd;
                if (Program.Commands.InternalCommands.ContainsKey(commandName.ToLower()))
                    cmd = Program.Commands.InternalCommands[commandName.ToLower()];
                else
                    cmd = Program.Commands.CommandAliases[commandName.ToLower()];

                var methods = cmd.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                List<string> methodList = new List<string>();
                foreach(var method in methods)
                    if(Program.Commands.CommandHasLevel(Program.Commands.GetCommandLevel(level), method) && !methodList.Contains(method.Name.ToLower()))
                        methodList.Add(method.Name.ToLower());

                methodList.Sort();
                string commands = methodList.Aggregate("", (current, str) => current + str + ", ");
                commands = commands.Remove(commands.Length - 2);

                Program.Irc.SendMessage(string.Format(Resources.CommandHelpGroup, "!" + commandName, commands, user));
            }
            else
            {
                Help(level, user, "other", commandName);
            }
            
        }

        [CommandUserLevel(Types.CommandLevel.Moderator)]
        [CommandDescription("Gives a list of information, or sub commands, or commands usage")]
        [CommandUsage("!help [command] [subcommand]")]
        public void Help(Types.UserLevel level, string user, string commandName, string subCommand)
        {
            if (!Program.Commands.InternalCommands.ContainsKey(commandName.ToLower())) return;
            var methods = Program.Commands.InternalCommands[commandName].GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (methods.Length != 0 && methods.Any(c => c.Name.ToLower() == subCommand.ToLower()))
            {
                var method = methods.First(c => c.Name.ToLower() == subCommand.ToLower());
                string usage = Program.Commands.GetCommandUsage(method);
                string description = Program.Commands.GetCommandDescription(method);
                Program.Irc.SendMessage(string.Format(Resources.CommandHelpCommand, "!" + commandName == "other" ? subCommand : commandName, usage, description, user));
            }
        }

        public Other(Database db) : base(db)
        {
        }
    }
}
