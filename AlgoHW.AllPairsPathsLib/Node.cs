using System.Collections.Generic;

namespace AlgoHW.AllPairsPathsLib
{
    public class Node
    {
        public int Id { get; set; }

        // key = nodeId
        // value = weight
        public Dictionary<int, int> OutgoingEdges { get; set; } = new Dictionary<int, int>();

        public HashSet<int> IncomingEdges { get; set; } = new HashSet<int>();
    }
}