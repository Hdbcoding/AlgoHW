using System.Collections.Generic;

namespace AlgoHW.PrimMSTLib{
    public class Node
    {
        public int Id { get; set; }
        public Dictionary<int, int> Edges { get; set; } = new Dictionary<int, int>();
        public Node(int nodeId)
        {
            Id = nodeId;
        }
    }
}