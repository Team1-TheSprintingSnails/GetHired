using System.Collections.Generic;

namespace GetHired.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
