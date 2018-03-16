using GetHired.Core.Commands.Contracts;

namespace GetHired.Core.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
