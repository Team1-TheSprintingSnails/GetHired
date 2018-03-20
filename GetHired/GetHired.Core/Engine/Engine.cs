using System;
using Bytes2you.Validation;
using GetHired.Core.Engine.Contracts;
using GetHired.Core.Providers.Contracts;

namespace GetHired.Core.Engine
{
    public class Engine : IEngine
    {
        //todo: fix exit command string 

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;

        private const string TerminationCommand = "Exit";

        public Engine(IReader reader, IWriter writer, ICommandProcessor commandProcessor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(commandProcessor, "commandProcessor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.commandProcessor = commandProcessor;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.writer.WriteLine(this.commandProcessor.ProcessCommand(commandAsString));
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
