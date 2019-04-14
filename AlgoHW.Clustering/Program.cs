using System;
using AlgoHW.ClusteringLib;

namespace AlgoHW.Clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            (var count, var data) = ExplicitClusterLoader.LoadData("cluster1_data.txt");
            var spacing = ExplicitClusterLoader.CalculateSpacing(count, data);
            Console.WriteLine($"Explicit problem - max cluster spacing: {spacing}");

            (var info, var data2) = ImplicitClusterLoader.LoadData("cluster2_data.txt");
            var count2 = ImplicitClusterLoader.CountClusters(info, data2);
            Console.WriteLine($"Implicit problem - count needed for 3-spacing: {count2}");
        }
    }
}
