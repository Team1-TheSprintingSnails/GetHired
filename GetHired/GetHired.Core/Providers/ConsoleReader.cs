using System;
using GetHired.Core.Providers.Contracts;

namespace GetHired.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
