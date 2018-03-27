using System.IO;
using GetHired.Utils.Contracts;
using Newtonsoft.Json;

namespace GetHired.Utils
{
    public class JSONReader : IFileReader
    {
        public object ReadFile(string fileName)
        {
            dynamic result;

            using (StreamReader sr = new StreamReader(fileName))
            {
                string json = sr.ReadToEnd();

                result = JsonConvert.DeserializeObject<dynamic>(json);
            }

            return result;
        }
    }
}
