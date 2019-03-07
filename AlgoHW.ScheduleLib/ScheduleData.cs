using System;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.ScheduleLib
{
    public class ScheduleData
    {
        public int Weight { get; set; }
        public int Length { get; set; }
        public static ScheduleData FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new ScheduleData { Weight = numbers.First(), Length = numbers.Last() };
        }
    }
}
