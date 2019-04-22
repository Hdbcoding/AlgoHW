using System;
using System.Collections.Generic;
using AlgoHW.Common;

namespace AlgoHW.TSP2Lib
{
    public static class SalesmanCalculator2
    {
        public static (int, List<City>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, int.Parse, City.FromString);
        }
    }
}
