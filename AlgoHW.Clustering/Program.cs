using System;
using AlgoHW.ClusteringLib;

namespace AlgoHW.Clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            (var count, var data) = ExplicitClusterLoader.LoadData("cluster_data1.txt");
            var spacing = ExplicitClusterLoader.CalculateSpacing(count, data);
            Console.WriteLine($"Explicit problem - max cluster spacing: {spacing}");

            (var info, var data2) = ImplicitClusterLoader.LoadData("cluster_data2.txt");
            var count2 = ImplicitClusterLoader.CountClusters(info, data2);
            Console.WriteLine($"Implicit problem - count needed for 3-spacing: {count2}");
        }
    }
}
