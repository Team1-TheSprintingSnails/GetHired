using System;
using Bytes2you.Validation;
using GetHired.Core.Providers.Contracts;

namespace GetHired.Core.Providers
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;

        private const string TerminationCommand = "Exit";

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandProcessor commandProcessor)
        {
            Guard.WhenArgument(reader, "reader is null").IsNull().Throw();
            Guard.WhenArgument(writer, "writer is null").IsNull().Throw();
            Guard.WhenArgument(commandProcessor, "processor is null").IsNull().Throw();

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
