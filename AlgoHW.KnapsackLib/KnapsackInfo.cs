using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.KnapsackLib
{
    public class KnapsackInfo
    {
        public int TotalWeight { get; set; }
        public int Items { get; set; }

        public static KnapsackInfo FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new KnapsackInfo
            {
                TotalWeight = numbers.First(),
                Items = numbers.Last()
            };
        }
    }
}