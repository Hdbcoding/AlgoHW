using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.ClusteringLib
{
    public static class ImplicitClusterLoader
    {
        static int[] masks;

        public static (ImplicitClusterInfo, List<BitVector32>) LoadData(string inputFile)
        {
            //init masks to load up bit vectors
            masks = new int[32];
            masks[0] = BitVector32.CreateMask();
            for (int i = 1; i < 32; i++)
            {
                masks[i] = BitVector32.CreateMask(masks[i - 1]);
            }

            return DataReader.ReadData(inputFile, ImplicitClusterInfo.FromString, ParseBits);
        }

        private static BitVector32 ParseBits(string s)
        {
            var vector = new BitVector32();

            var bits = s.ParseMany(int.Parse).ToList();
            for (int i = 0; i < bits.Count; i++)
            {
                vector[masks[i]] = bits[i] == 1;
            }

            return vector;
        }

        public static int CountClusters(ImplicitClusterInfo info, List<BitVector32> data)
        {
            //locations of all values in original data
            var locations = new Dictionary<BitVector32, List<int>>();
            for (int i = 0; i < data.Count; i++)
            {
                if (!locations.ContainsKey(data[i])) locations.Add(data[i], new List<int>() { i + 1 });
                else locations[data[i]].Add(i + 1);
            }

            (var graph, var clusters) = ExplicitClusterLoader.GenerateInitialClusters(info.Nodes);

            foreach (var localCluster in locations)
            {
                var same = localCluster.Value;
                //merge localCluster
                for (int i = 0; i < same.Count - 1; i++)
                {
                    for (int j = i + 1; j < same.Count; j++)
                    {
                        var n1 = graph[same[i]];
                        var n2 = graph[same[j]];
                        if (n1.ParentId != n2.ParentId)
                            UnionFindNode.MergeClusters(clusters, n1, n2);
                    }
                }

                var parent = same[0];
                var key = localCluster.Key;
                //merge all similar (distances 1, 2) nodes to this local cluster
                var candidate = new BitVector32(key);
                for (int i = 0; i < info.Bits; i++)
                {
                    //merge any single bit differences
                    candidate = FlipBit(candidate, i);
                    TryMerge(locations, graph, clusters, candidate, parent);
                    for (int j = i + 1; j < info.Bits; j++)
                    {
                        //merge any double bit differences
                        candidate = FlipBit(candidate, j);
                        TryMerge(locations, graph, clusters, candidate, parent);
                        candidate = FlipBit(candidate, j);
                    }
                    candidate = FlipBit(candidate, i);
                }
            }
            return clusters.Count;
        }

        private static BitVector32 FlipBit(BitVector32 key, int i){
            key[masks[i]] = !key[masks[i]];
            return key;
        }

        private static void TryMerge(Dictionary<BitVector32, List<int>> locations,
            Dictionary<int, UnionFindNode> graph,
            Dictionary<int, List<UnionFindNode>> clusters,
            BitVector32 candidate,
            int parent)
        {
            if (!locations.ContainsKey(candidate)) return;
            var n1 = graph[parent];
            foreach (var location in locations[candidate])
            {
                var n2 = graph[location];
                if (n1.ParentId != n2.ParentId)
                    UnionFindNode.MergeClusters(clusters, n1, n2);
            }
        }
    }
}
