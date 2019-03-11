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
        }
    }
}
