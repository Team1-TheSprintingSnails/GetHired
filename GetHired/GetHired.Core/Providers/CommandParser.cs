using System.Collections.Generic;
using System.Linq;
using GetHired.Core.Commands.Contracts;
using GetHired.Core.Factories.Contracts;

namespace GetHired.Core.Providers
{
    public class CommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];

            return this.commandFactory.GetCommand(commandName);
        }


        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (!commandParts.Any())
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
