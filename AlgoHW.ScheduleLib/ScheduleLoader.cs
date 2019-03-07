using System;
using System.Collections.Generic;
using AlgoHW.Common;

namespace AlgoHW.ScheduleLib
{
    public static class ScheduleLoader
    {
        public static (int, List<ScheduleData>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, int.Parse, ScheduleData.FromString);
        }
    }
}