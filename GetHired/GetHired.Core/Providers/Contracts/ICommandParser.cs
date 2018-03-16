using System.Collections.Generic;
using GetHired.Core.Commands.Contracts;

namespace GetHired.Core.Providers.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);
        IList<string> ParseParameters(string fullCommand);
    }
}
