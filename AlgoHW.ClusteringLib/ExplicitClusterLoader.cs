using System;
using System.Collections.Generic;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.ClusteringLib
{
    public class ExplicitClusterLoader
    {
        public static (int, List<EdgeData>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, int.Parse, EdgeData.FromString);
        }

        public static int CalculateSpacing(int numNodes, List<EdgeData> edges){
            (var graph, var clusters) = GenerateInitialClusters(numNodes);
            edges.Sort((x,y) => x.Cost - y.Cost);
            foreach (var edge in edges){
                if (clusters.Count <= 4) break;

                var n1 = graph[edge.NodeId1];
                var n2 = graph[edge.NodeId2];
                if (n1.ParentId != n2.ParentId)
                    UnionFindNode.MergeClusters(clusters, n1, n2);
            }
            return MaxSpacing(graph, edges);
        }

        private static (Dictionary<int, UnionFindNode>, Dictionary<int, List<UnionFindNode>>) 
            GenerateInitialClusters(int numNodes)
        {
            var graph = new Dictionary<int, UnionFindNode>();
            var clusters = new Dictionary<int, List<UnionFindNode>>();
            for (int i = 1; i <= numNodes; i++)
            {
                var node = new UnionFindNode(i);
                graph.Add(i, node);
                clusters.Add(i, new List<UnionFindNode>() { node });
            }
            return (graph, clusters);
        }

        private static int MaxSpacing(Dictionary<int, UnionFindNode> graph, List<EdgeData> edges)
        {
            var maxSpacing = int.MaxValue;
            foreach (var edge in edges){
                var n1 = graph[edge.NodeId1];
                var n2 = graph[edge.NodeId2];
                if (n1.ParentId != n2.ParentId && edge.Cost < maxSpacing)
                    maxSpacing = edge.Cost;
            }
            return maxSpacing;
        }
    }
}
