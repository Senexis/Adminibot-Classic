using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using th.AdminibotLegacy.Command;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy
{
    public class Commands
    {
        public Dictionary<string, CommandBase> InternalCommands;

        public Dictionary<string, CommandBase> CommandAliases;
        public Dictionary<string, CustomCommand> CustomCommands = new Dictionary<string, CustomCommand>();
        private Database _db;

        public Commands(Database db)
        {
            _db = db;
            InternalCommands = new Dictionary<string, CommandBase>
            {
                {"other", new Other(_db)},
                {"command", new Command.Command(_db)},
                {"battletag", new Battletag(_db)},
                {"points", new Points(_db)},
                {"time", new Time(_db)}
            };

            CommandAliases = new Dictionary<string, CommandBase>
            {
                {"com", InternalCommands["command"]},
                {"currency", InternalCommands["points"]},
                // {dynamicNameHere, InternalCommands["points"]},
                {"btag", InternalCommands["battletag"]},
                {"tag", InternalCommands["battletag"]}
            };
        }

        protected MethodInfo GetCommand(string commandName)
        {
            return typeof(Commands).GetMethod(commandName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
        }

        protected bool CommandExists(string commandName)
        {
            return InternalCommands.ContainsKey(commandName.ToLower()) || CommandAliases.ContainsKey(commandName.ToLower());
        }

        public bool CommandHasLevel(Types.CommandLevel level, MethodInfo methodInfo)
        {
            if (methodInfo == null) return false; //TODO: This shouldn't happen, ever.
            var attributes = Attribute.GetCustomAttributes(methodInfo);
            return attributes.Any(at => at is CommandUserLevel && ((CommandUserLevel)at).Level <= level);
        }

        private bool CommandCheckParamsCount(MethodInfo methodInfo, int paramCount)
        {
            if (methodInfo == null) return false; //TODO: This shouldn't happen, ever.
            ParameterInfo[] parameters = methodInfo.GetParameters();
            int c = 0;
            foreach (var p in parameters)
            {
                if (!p.HasDefaultValue) c++;
            }
            return paramCount >= c && paramCount <= parameters.Length;
        }

        private bool CommandCheckParams(MethodInfo methodInfo, object[] paramObject)
        {
            if (methodInfo == null) return false; //TODO: This shouldn't happen, ever.
            ParameterInfo[] parameters = methodInfo.GetParameters();
            for (int i = 0; i < paramObject.Length; i++)
            {
                if (paramObject[i] == null)
                {
                    if (!parameters[i].HasDefaultValue || parameters[i].RawDefaultValue != null) return false;
                }
                else
                {
                    if (parameters[i].ParameterType != paramObject[i].GetType()) return false;
                }
            }

            return true;
        }

        private object[] GetParamObject(MethodInfo methodInfo, Types.UserLevel level, string user, string[] paramStrings)
        {
            if (methodInfo == null || !CommandCheckParamsCount(methodInfo, paramStrings.Length + 2)) return null;
            ParameterInfo[] parameters = methodInfo.GetParameters();
            object[] paramObject = new object[parameters.Length];
            paramObject[0] = level;
            paramObject[1] = user;
            int c = -2;
            foreach (var pi in parameters)
            {
                if (c < 0)
                {
                    c++;
                    continue;
                }
                if (paramStrings.Length != 0 && paramStrings.Length > c)
                {
                    var str = paramStrings[c];
                    int i = 0;
                    double d = 0;
                    bool b = true;
                    object res = null;
                    if (pi.ParameterType == i.GetType())
                    {
                        if (Int32.TryParse(str, NumberStyles.None, Program.CurrentCulture, out i)) res = i;
                    }
                    else if (pi.ParameterType == d.GetType())
                    {
                        if (Double.TryParse(str, NumberStyles.Float, Program.CurrentCulture, out d)) res = d;
                    }
                    else if (pi.ParameterType == b.GetType())
                    {
                        if (Boolean.TryParse(str, out b)) 
                            res = b;
                        else if (Int32.TryParse(str, NumberStyles.None, Program.CurrentCulture, out i) && (i == 0 ||
                                 i == 1))
                            res = i == 1;
                    }
                    else
                    {
                        res = str;
                    }

                    if (res == null) return null;

                    paramObject[2 + c++] = res;
                }
                else
                {
                    if (!pi.HasDefaultValue) return null;
                    paramObject[2 + c++] = pi.DefaultValue;
                }
            }
            return paramObject;
        }

        public string GetCommandUsage(MethodInfo methodInfo)
        {
            var attributes = Attribute.GetCustomAttributes(methodInfo);
            return attributes.OfType<CommandUsage>().Select(at => (at).Usage).FirstOrDefault();
        }

        public string GetCommandDescription(MethodInfo methodInfo)
        {
            var attributes = Attribute.GetCustomAttributes(methodInfo);
            return attributes.OfType<CommandDescription>().Select(at => (at).Description).FirstOrDefault();
        }

        private bool CustomCommandExists(string commandName)
        {
            return CustomCommands.ContainsKey(commandName);
        }

        private bool CustomCommandHasLevel(Types.CommandLevel level, string commandName)
        {
            return CustomCommands[commandName].CommandLevel <= level;
        }

        protected string GetCustomCommandResponse(string commandName, string[] paramStrings, string user)
        {
            return CustomCommands[commandName].ToString(paramStrings, user);
        }

        private bool CommandGroupExists(string commandName, out bool isAlias)
        {
            isAlias = false;
            if(InternalCommands.ContainsKey(commandName))
            {
                return true;
            } 
            if (CommandAliases.ContainsKey(commandName))
            {
                isAlias = true;
                return true;
            }
            return false;
        }

        public void ExecuteCommand(string user, Types.UserLevel userLevel, string commandName, string[] paramStrings)
        {
            Types.CommandLevel level = GetCommandLevel(userLevel);
            bool isAlias;
            commandName = commandName.ToLower();
            bool isOther = true;
            CommandBase cmd = InternalCommands["other"];
            if (CommandGroupExists(commandName, out isAlias))
            {
                cmd = isAlias ? CommandAliases[commandName] : InternalCommands[commandName];
                isOther = false;
            }
            
            var methods = cmd.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);


            if (!isOther || methods.Any(m => m.Name.ToLower() == commandName))
            {
                string subCommandName = isOther ? commandName : "default";
                bool isDefault = true;
                if (!isOther && paramStrings.Length > 0)
                {
                    isDefault = false;
                    subCommandName = paramStrings[0];
                }

                List<MethodInfo> foundMethods = methods.Where(method => method.Name.ToLower() == subCommandName.ToLower()).ToList();

                if (foundMethods.Count == 0)
                {
                    if (!isDefault)
                    {
                        subCommandName = "default";
                        isDefault = true;
                        foundMethods =
                            methods.Where(method => method.Name.ToLower() == subCommandName.ToLower()).ToList();
                    }
                }
                else
                {
                    if (!isDefault)
                    {
                        string[] newParams = new string[paramStrings.Length - 1];
                        for (int i = 1; i < paramStrings.Length; i++)
                        {
                            newParams[i - 1] = paramStrings[i];
                        }
                        paramStrings = newParams;
                    }
                }

                if (foundMethods.Count != 0)
                {
                    bool succes = false;
                    foreach (var methodInfo in foundMethods)
                    {
                        if (CommandHasLevel(level, methodInfo))
                        {
                            object[] paramObject = GetParamObject(methodInfo, userLevel, user, paramStrings);
                            if (paramObject != null && CommandCheckParams(methodInfo, paramObject))
                            {
                                succes = true;
                                methodInfo.Invoke(cmd, paramObject);
                            }
                        }
                    }

                    if (!succes)
                    {
                        if (isOther || !isDefault)
                        {
                            string usage = null;
                            foreach (var method in foundMethods)
                            {
                                if (CommandHasLevel(level, method))
                                {
                                    usage = GetCommandUsage(method);
                                    break;
                                }
                            }
                            if(usage != null)
                                Program.Irc.SendMessage(String.Format(Resources.CommandUsage, usage, user));
                        }
                    }
                }
            }
            else
            {
                commandName = commandName.ToLower();
                if (CustomCommandExists(commandName))
                {
                    if (CustomCommandHasLevel(level, commandName))
                    {
                        Program.Irc.SendMessage(GetCustomCommandResponse(commandName, paramStrings, user));
                    }
                }
            }
        }

        public Types.CommandLevel GetCommandLevel(Types.UserLevel level)
        {
            return level == Types.UserLevel.Viewer
                ? Types.CommandLevel.Viewer
                : level == Types.UserLevel.Moderator
                    ? Types.CommandLevel.Moderator
                    : level == Types.UserLevel.Editor
                        ? Types.CommandLevel.Editor
                        : Types.CommandLevel.Broadcaster;
        }

        public void InitializeCustomCommands()
        {
            List<string[]> commandsList = _db.GetAllCommands();
            foreach (string[] command in commandsList)
            {
                Types.CommandLevel level;
                if (Types.CommandLevel.TryParse(command[2], out level))
                {
                    CustomCommand cmd = new CustomCommand(command[1], command[3], level);
                    CustomCommands.Add(command[1].ToLower(), cmd);
                }
            }
        }
    }
}
