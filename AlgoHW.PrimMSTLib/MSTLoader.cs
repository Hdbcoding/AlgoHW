using System;
using System.Collections.Generic;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.PrimMSTLib
{
    public static class MSTLoader
    {
        public static (MSTInfo, List<MSTData>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, MSTInfo.FromString, MSTData.FromString);
        }

        public static Dictionary<int, Node> GenerateGraph(List<MSTData> data)
        {
            var graph = new Dictionary<int, Node>();
            foreach (var value in data)
            {
                var node1 = EnsureAdded(graph, value.NodeId1);
                var node2 = EnsureAdded(graph, value.NodeId2);

                EnsureLowerCostEdge(node1, node2, value.Cost);
                EnsureLowerCostEdge(node2, node1, value.Cost);
            }
            return graph;
        }

        private static Node EnsureAdded(Dictionary<int, Node> graph, int nodeId)
        {
            if (graph.ContainsKey(nodeId)) return graph[nodeId];
            var node = new Node(nodeId);
            graph.Add(nodeId, node);
            return node;
        }

        private static void EnsureLowerCostEdge(Node node1, Node node2, int cost)
        {
            //if we have a duplicate edge of lower cost, use the lower cost
            if (node1.Edges.ContainsKey(node2.Id))
            {
                if (node1.Edges[node2.Id] > cost) node1.Edges[node2.Id] = cost;
            }
            else node1.Edges.Add(node2.Id, cost);
        }

        public static (long totalCost, HashSet<int> NodeIds) CalculateMST(Dictionary<int, Node> graph)
        {
            var totalCost = 0L;
            var NodeIds = new HashSet<int>() { 1 };
            var outgoingEdges = graph[1].Edges.ToDictionary(k => k.Key, k => k.Value);
            graph.Remove(1);
            while (graph.Any()){
                (Node next, int cost) = GetNextNode(graph, outgoingEdges);
                NodeIds.Add(next.Id);
                graph.Remove(next.Id);
                outgoingEdges.Remove(next.Id);
                totalCost += cost;
                IncorporateEdges(NodeIds, outgoingEdges, next);
            }
            return (totalCost, NodeIds);
        }

        private static (Node next, int cost) GetNextNode(Dictionary<int, Node> graph, Dictionary<int, int> outgoingEdges)
        {
            var cost = int.MaxValue;
            var nextId = -1;
            foreach (var edge in outgoingEdges){
                if (edge.Value < cost) { 
                    cost = edge.Value;
                    nextId = edge.Key;
                }
            }
            return (graph[nextId], cost);
        }

        private static void IncorporateEdges(HashSet<int> nodeIds, Dictionary<int, int> outgoingEdges, Node next)
        {
            foreach (var edge in next.Edges){
                if (!nodeIds.Contains(edge.Key))
                {
                    if (!outgoingEdges.ContainsKey(edge.Key)) outgoingEdges.Add(edge.Key, edge.Value);
                    else if (outgoingEdges[edge.Key] > edge.Value) outgoingEdges[edge.Key] = edge.Value;
                }
            }
        }
    }
}
