using System;
using System.Collections.Generic;
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

        public static double Optimal(ScheduleData d) => (double)d.Weight / d.Length;
        public static double Poor(ScheduleData d) => (double)d.Weight - d.Length;
    }

    public class TieBreaker : IComparer<ScheduleData>
    {
        private Func<ScheduleData, double> _rule;

        public TieBreaker(Func<ScheduleData, double> rule)
        {
            _rule = rule;
        }

        public int Compare(ScheduleData x, ScheduleData y)
        {
            double comparison = _rule(x) - _rule(y);
            if (comparison != 0) return comparison > 0 ? 1 : -1;
            return x.Weight - y.Weight;
        }
    }
}
