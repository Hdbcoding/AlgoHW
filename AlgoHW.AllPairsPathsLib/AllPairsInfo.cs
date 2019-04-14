using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.AllPairsPathsLib
{
    public class AllPairsInfo
    {
        public int Nodes { get; set; }
        public int Edges { get; set; }

        public static AllPairsInfo FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new AllPairsInfo
            {
                Nodes = numbers.First(),
                Edges = numbers.Last()
            };
        }
    }
}