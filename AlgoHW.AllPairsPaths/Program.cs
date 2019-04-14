using System;
using AlgoHW.AllPairsPathsLib;

namespace AlgoHW.AllPairsPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            (var info, var data) = DistanceCalculator.LoadData("g1_data.txt");
            var graph = DistanceCalculator.GenerateGraph(data);

            (info, data) = DistanceCalculator.LoadData("g2_data.txt");
            graph = DistanceCalculator.GenerateGraph(data);

            (info, data) = DistanceCalculator.LoadData("g3_data.txt");
            graph = DistanceCalculator.GenerateGraph(data);

            (info, data) = DistanceCalculator.LoadData("g4_large_data.txt");
            graph = DistanceCalculator.GenerateGraph(data);
        }
    }
}
