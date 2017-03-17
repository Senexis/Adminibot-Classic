using System;
using System.Collections.Generic;
using th.AdminibotModern.Classes.Commands;

namespace th.AdminibotModern.Classes
{
    class CommandProcessor
    {
        /// <summary>
        /// A full list of every currently defined command.
        /// </summary>
        private static Dictionary<CommandIdentifier, Action<Types.UserLevel, string, List<string>>> Commands;

        /// <summary>
        /// Executes a command's action when called.
        /// </summary>
        /// <param name="message">The raw message from an IrcClient.</param>
        public void ExecuteCommand(string message)
        {
            
        }

        /// <summary>
        /// Executes a command's action when called.
        /// </summary>
        /// <param name="name">The primary name of the command.</param>
        /// <param name="action">The secondary names ("actions") of the command.</param>
        /// <param name="args">A list of all arguments the command takes.</param>
        public void ExecuteCommand(string name, string action, List<string> args)
        {
            
        }

        /// <summary>
        /// Define a new command to the Commands dictionary.
        /// </summary>
        /// <param name="identifier">A CommandIdentifier object containing all the command's information.</param>
        /// <param name="action">The action this command should execute on run.</param>
        public void AddCommand(CommandIdentifier identifier, Action<Types.UserLevel, string, List<string>> action)
        {
            
        }

        /// <summary>
        /// Toggles the ability to execute the command.
        /// </summary>
        /// <param name="name">The primary name of the command.</param>
        /// <param name="action">The secondary names ("actions") of the command.</param>
        /// <returns></returns>
        public bool ToggleCommand(string name, string action)
        {
            return false;
        }

        /// <summary>
        /// Executes a lookup to see whether the extracted command exists and is available to execute.
        /// </summary>
        /// <param name="args">A List of all provided arguments to execute the lookup with.</param>
        /// <returns>A CommandIdentifier object containing an existing command's information or "null".</returns>
        private CommandIdentifier CommandExists(List<string> args)
        {
            return null;
        }

        /// <summary>
        /// Executes a lookup to see whether the extracted custom command exists and is available to execute.
        /// </summary>
        /// <param name="args">A List of all provided arguments to execute the lookup with.</param>
        /// <returns>"true" when the command exists and "false" when it doesn't.</returns>
        private bool CustomCommandExists(List<string> args)
        {
            return false;
        }
    }
}
