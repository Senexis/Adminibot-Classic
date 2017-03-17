using System.Collections.Generic;
using System.Linq;

namespace th.AdminibotLegacy
{
    public class CustomCommand
    {
        private string CommandResponse;
        public string DisplayName;
        public Types.CommandLevel CommandLevel;
    

        public CustomCommand(string displayName, string commandResponse, Types.CommandLevel commandLevel)
        {
            this.CommandResponse = commandResponse;
            this.CommandLevel = commandLevel;
            this.DisplayName = displayName;
        }

        public string ToString(string[] paramStrings, string user)
        {
            string response = CommandResponse;
            int i = 1;
            Dictionary<string, string> replacements = paramStrings.ToDictionary(str => "{p" + i++ + "}");

            replacements.Add("{user}", user);
            foreach (KeyValuePair<string, string> item in replacements)
            {
                response = response.Replace(item.Key, item.Value);
            }
            return response;
        }

        public override string ToString()
        {
            return CommandResponse;
        }

        public void SetResponse(string response)
        {
            this.CommandResponse = response;
        }
    }
}
