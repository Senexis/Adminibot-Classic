using System.Collections.Generic;

namespace th.AdminibotModern.Classes.Commands
{
    class CommandIdentifier
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public Types.UserLevel MinLevel { get; set; }
        public int ArgCount { get; set; }
        public string Action { get; set; }
        public List<string> Aliases { get; set; }
    }
}
