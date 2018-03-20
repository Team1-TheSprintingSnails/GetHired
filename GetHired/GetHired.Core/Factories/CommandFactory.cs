using Autofac;
using GetHired.Core.Commands.Contracts;

namespace GetHired.Core.Factories
{
    public class CommandFactory
    {
        private readonly IComponentContext container;

        public CommandFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.container.ResolveNamed<ICommand>(commandName);
        }
    }
}
