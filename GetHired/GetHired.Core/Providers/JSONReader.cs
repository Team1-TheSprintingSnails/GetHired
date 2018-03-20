﻿using System.Collections.Generic;
using System.IO;
using GetHired.Core.Providers.Contracts;
using Newtonsoft.Json;

namespace GetHired.Core.Providers
{
    public class JSONReader<T> : IFileReader<T>
    {
        public List<T> ReadFile(string fileName)
        {
            List<T> listT = new List<T>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string json = sr.ReadToEnd();
                listT = JsonConvert.DeserializeObject<List<T>>(json);
            }

            return listT;
        }
    }
}
