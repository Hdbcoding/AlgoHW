using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoHW.Common
{
    public static class DataReader
    {
        public static (TInfo, List<TData>) ReadData<TInfo, TData>(
            string inputFile,
            Func<string, TInfo> infoParser,
            Func<string, TData> dataParser)
        {
            var data = File.ReadAllLines(inputFile).WhereNotNull();
            return (infoParser(data.First()), data.Skip(1).Select(dataParser).ToList());
        }
    }
}