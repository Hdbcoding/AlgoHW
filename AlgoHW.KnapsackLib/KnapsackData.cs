using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.KnapsackLib
{
    public class KnapsackData
    {
        public int Value { get; set; }
        public int Weight { get; set; }

        public static KnapsackData FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new KnapsackData
            {
                Value = numbers.First(),
                Weight = numbers.Last()
            };
        }
    }
}