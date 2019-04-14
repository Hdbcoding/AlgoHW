using AlgoHW.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoHW.AllPairsPathsLib
{
    public static class DistanceCalculator
    {
        public static (AllPairsInfo, List<EdgeData>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, AllPairsInfo.FromString, EdgeData.FromString);
        }

        public static (int[], Dictionary<int, Node>) GenerateGraph(List<EdgeData> data)
        {
            Dictionary<int, Node> graph = new Dictionary<int, Node>();

            foreach (EdgeData edge in data)
            {
                Node n1;
                if (graph.ContainsKey(edge.NodeId1))
                {
                    n1 = graph[edge.NodeId1];
                }
                else
                {
                    n1 = new Node { Id = edge.NodeId1 };
                    graph.Add(edge.NodeId1, n1);
                }

                Node n2;
                if (graph.ContainsKey(edge.NodeId2))
                {
                    n2 = graph[edge.NodeId2];
                }
                else
                {
                    n2 = new Node { Id = edge.NodeId2 };
                    graph.Add(edge.NodeId2, n2);
                }


                if (n1.OutgoingEdges.ContainsKey(n2.Id))
                {
                    n1.OutgoingEdges[n2.Id] = Math.Min(n1.OutgoingEdges[n2.Id], edge.Cost);
                }
                else
                {
                    n1.OutgoingEdges.Add(n2.Id, edge.Cost);
                }

                n2.IncomingEdges.Add(n1.Id);
            }

            int[] nodeLabels = graph.Keys.OrderBy(n => n).ToArray();

            return (nodeLabels, graph);
        }

        //note: not thread safe
        private static bool FillSecondIndex = true;

        public static int? FloydWarshall(int[] nodeLabels, Dictionary<int, Node> graph)
        {
            FillSecondIndex = true;
            int numNodes = graph.Count;
            //note: treat "null" as "Infinity"
            int?[,,] subProblems = new int?[numNodes, numNodes, 2];

            SetupFloydWarshallBaseCases(nodeLabels, graph, numNodes, subProblems);
            try {
            FillFloydWarshallSubproblems(numNodes, subProblems);
            }
            catch{
                return null;
            }

            if (FloydWarshallNegativeCycle(numNodes, subProblems))
            {
                return null;
            }

            return FloydWarshallResult(numNodes, subProblems);
        }

        private static void SetupFloydWarshallBaseCases(int[] nodeLabels, Dictionary<int, Node> graph, int numNodes, int?[,,] subProblems)
        {
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = 0; j < numNodes; j++)
                {
                    int ni = nodeLabels[i];
                    int nj = nodeLabels[j];
                    Node node = graph[ni];
                    if (node.OutgoingEdges.ContainsKey(nj))
                    {
                        subProblems[i, j, 0] = node.OutgoingEdges[nj];
                    }
                    else if (i == j)
                    {
                        subProblems[i, j, 0] = 0;

                    }
                }
            }
        }

        private static void FillFloydWarshallSubproblems(int numNodes, int?[,,] subProblems)
        {
            for (int k = 1; k < numNodes; k++)
            {
                int lastProblem = FillSecondIndex ? 0 : 1;
                int nextProblem = FillSecondIndex ? 1 : 0;
                for (int i = 0; i < numNodes; i++)
                {
                    int? ikResult = subProblems[i, k, lastProblem];
                    for (int j = 0; j < numNodes; j++)
                    {
                        int? shorterPathResult = subProblems[i, j, lastProblem];
                        int? kjResult = subProblems[k, j, lastProblem];
                        int? differentNodeResult = ikResult.HasValue && kjResult.HasValue ? ikResult + kjResult : null;

                        if (shorterPathResult.HasValue && differentNodeResult.HasValue)
                        {
                            subProblems[i, j, nextProblem] = Math.Min(shorterPathResult.Value, differentNodeResult.Value);
                        }
                        else if (shorterPathResult.HasValue)
                        {
                            subProblems[i, j, nextProblem] = shorterPathResult;
                        }
                        else
                        {
                            subProblems[i, j, nextProblem] = differentNodeResult;
                        }

                        if (i == j && subProblems[i, j, nextProblem] < 0) throw new InvalidOperationException("negative cycle!");
                    }
                }
                FillSecondIndex = !FillSecondIndex;
            }
        }

        private static bool FloydWarshallNegativeCycle(int numNodes, int?[,,] subProblems)
        {
            int lastProblem = FillSecondIndex ? 1 : 0;
            for (int i = 0; i < numNodes; i++)
            {
                if (subProblems[i, i, lastProblem] < 0)
                {
                    return true;
                }
            }

            return false;
        }
        private static int FloydWarshallResult(int numNodes, int?[,,] subProblems)
        {
            int lastProblem = FillSecondIndex ? 1 : 0;
            int min = int.MaxValue;
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = 0; j < numNodes; j++)
                {
                    if (i != j)
                    {
                        int? result = subProblems[i, j, lastProblem];
                        if (result.HasValue)
                        {
                            min = Math.Min(min, result.Value);
                        }
                    }
                }
            }
            return min;
        }

        public static int? Johnson(Dictionary<int, Node> graph)
        {
            return null;
        }
    }
}