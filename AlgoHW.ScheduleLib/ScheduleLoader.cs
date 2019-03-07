using System;
using System.Collections.Generic;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.ScheduleLib
{
    public static class ScheduleLoader
    {
        public static (int info, List<ScheduleData> data) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, int.Parse, ScheduleData.FromString);
        }

        public static (long poor, long optimal) CalculateWeightedCompletionTime(string inputFile)
        {
            return CalculateWeightedCompletionTime(LoadData(inputFile).data);
        }

        public static (long poor, long optimal) CalculateWeightedCompletionTime(List<ScheduleData> data)
        {
            return (SumCompletionTIme(data, ScheduleData.Poor), SumCompletionTIme(data, ScheduleData.Optimal));
        }

        private static long SumCompletionTIme(List<ScheduleData> data, Func<ScheduleData, double> rule)
        {
            var ordered = data.OrderByDescending(n => n, new TieBreaker(rule));
            var sum = 0L;
            var timeSoFar = 0L;
            foreach (var job in ordered)
            {
                timeSoFar += job.Length;
                sum += job.Weight * timeSoFar;
            }
            return sum;
        }
    }
}