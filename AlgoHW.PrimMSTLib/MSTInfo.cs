using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.PrimMSTLib
{
    public class MSTInfo
    {
        public int Nodes { get; set; }
        public int Edges { get; set; }

        public static MSTInfo FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new MSTInfo
            {
                Nodes = numbers.First(),
                Edges = numbers.Last()
            };
        }
    }
}