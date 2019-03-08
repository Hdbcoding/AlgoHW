using System;
using AlgoHW.ScheduleLib;

namespace AlgoHW.Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            var times = ScheduleLoader.CalculateWeightedCompletionTime("schedule_data.txt");
            Console.WriteLine($"poor: {times.poor}, optimal: {times.optimal}");
        }
    }
}
