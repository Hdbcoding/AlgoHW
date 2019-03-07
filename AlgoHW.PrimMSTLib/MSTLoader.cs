using System;
using System.Collections.Generic;
using AlgoHW.Common;

namespace AlgoHW.PrimMSTLib
{
    public static class MSTLoader
    {
        public static (MSTInfo, List<MSTData>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, MSTInfo.FromString, MSTData.FromString);
        }
    }
}
