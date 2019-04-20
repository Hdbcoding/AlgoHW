using System;
using System.Collections.Generic;
using AlgoHW.Common;

namespace AlgoHW.TSP1Lib
{
    public static class SalesmanCalculator
    {
        public static (int, List<City>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, int.Parse, City.FromString);
        }
    }
}
