using System;
using GetHired.Core.Providers.Contracts;

namespace GetHired.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandParser commandParser;

        public CommandProcessor(ICommandParser commandParser)
        {
            this.commandParser = commandParser;
        }

        public string ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException($"Command cannot be null or empty.");
            }

            var command = this.commandParser.ParseCommand(commandAsString);
            var parameters = this.commandParser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            return executionResult;
        }
    }
}
