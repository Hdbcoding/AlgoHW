using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.PrimMSTLib
{
    public class MSTData
    {
        public int NodeId1 { get; set; }
        public int NodeId2 { get; set; }
        public int Cost { get; set; }

        public static MSTData FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new MSTData
            {
                NodeId1 = numbers.First(),
                NodeId2 = numbers.Skip(1).First(),
                Cost = numbers.Last()
            };
        }
    }
}