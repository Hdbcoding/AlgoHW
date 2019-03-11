using System;
using System.Collections.Generic;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.Common
{
    public class UnionFindNode
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        public UnionFindNode(int id)
        {
            Id = id;
            ParentId = id;
        }

        public static void MergeClusters(Dictionary<int, List<UnionFindNode>> clusters, UnionFindNode n1, UnionFindNode n2)
        {
            var l1 = clusters[n1.ParentId];
            var l2 = clusters[n2.ParentId];
            
            var l1Bigger = l1.Count > l2.Count;
            var bigger = l1Bigger ? l1 : l2;
            var smaller = l1Bigger ? l2 : l1;
            var parentToKeep = l1Bigger ? n1.ParentId : n2.ParentId;
            var parentToDiscard = l1Bigger ? n2.ParentId : n1.ParentId;

            foreach (var node in smaller){
                node.ParentId = parentToKeep;
                bigger.Add(node);
            }

            clusters.Remove(parentToDiscard);
        }
    }
}