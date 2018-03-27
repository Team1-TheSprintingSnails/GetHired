using System.Collections.Generic;

namespace GetHired.Utils.Contracts
{
    public interface IFileReader<T>
    {
        List<T> ReadFile(string fileName);
    }
}
