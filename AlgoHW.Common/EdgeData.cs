using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.Common
{
    public class EdgeData
    {
        public int NodeId1 { get; set; }
        public int NodeId2 { get; set; }
        public int Cost { get; set; }

        public static EdgeData FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new EdgeData
            {
                NodeId1 = numbers.First(),
                NodeId2 = numbers.Skip(1).First(),
                Cost = numbers.Last()
            };
        }
    }
}