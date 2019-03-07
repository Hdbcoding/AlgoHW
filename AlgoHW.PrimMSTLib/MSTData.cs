using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.PrimMSTLib
{
    public class MSTData
    {
        public int Node1 { get; set; }
        public int Node2 { get; set; }
        public int Cost { get; set; }

        public static MSTData FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new MSTData
            {
                Node1 = numbers.First(),
                Node2 = numbers.Skip(1).First(),
                Cost = numbers.Last()
            };
        }
    }
}