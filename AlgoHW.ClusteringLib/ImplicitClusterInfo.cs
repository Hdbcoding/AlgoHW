using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.ClusteringLib
{
    public class ImplicitClusterInfo
    {
        public int Nodes { get; set; }
        public int Bits { get; set; }

        public static ImplicitClusterInfo FromString(string s)
        {
            var numbers = s.ParseMany(int.Parse);
            return new ImplicitClusterInfo
            {
                Nodes = numbers.First(),
                Bits = numbers.Last()
            };
        }
    }
}