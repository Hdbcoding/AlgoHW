using System;
using System.Collections.Generic;
using AlgoHW.Common;

namespace AlgoHW.AllPairsPathsLib
{
    public static class DistanceCalculator
    {
        public static (AllPairsInfo, List<EdgeData>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, AllPairsInfo.FromString, EdgeData.FromString);
        }

        public static Dictionary<int, Node> GenerateGraph(List<EdgeData> data)
        {
            var graph = new Dictionary<int, Node>();

            foreach (var edge in data){
                Node n;
                if (graph.ContainsKey(edge.NodeId1)) n = graph[edge.NodeId1];
                else {
                    n = new Node { Id = edge.NodeId1 };
                    graph.Add(edge.NodeId1, n);
                }

                if (n.Edges.ContainsKey(edge.NodeId2))
                    n.Edges[edge.NodeId2] = Math.Min(n.Edges[edge.NodeId2], edge.Cost);
                else
                    n.Edges.Add(edge.NodeId2, edge.Cost);
            }

            return graph;
        }

        public static int? FloydWarshall(Dictionary<int, Node> graph)
        {
            return null;
        }

        public static int? Johnson(Dictionary<int, Node> graph)
        {
            return null;
        }
    }
}