using System.Collections.Generic;

namespace GetHired.Core.Providers.Contracts
{
    public interface IFileReader<T>
    {
        List<T> ReadFile(string fileName);
    }
}
