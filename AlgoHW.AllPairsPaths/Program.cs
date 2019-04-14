using System;
using AlgoHW.AllPairsPathsLib;

namespace AlgoHW.AllPairsPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            (var info, var data) = DistanceCalculator.LoadData("g1_data.txt");
            (var labels, var graph) = DistanceCalculator.GenerateGraph(data);

            (info, data) = DistanceCalculator.LoadData("g2_data.txt");
            (labels, graph) = DistanceCalculator.GenerateGraph(data);

            (info, data) = DistanceCalculator.LoadData("g3_data.txt");
            (labels, graph) = DistanceCalculator.GenerateGraph(data);

            (info, data) = DistanceCalculator.LoadData("g4_large_data.txt");
            (labels, graph) = DistanceCalculator.GenerateGraph(data);
        }
    }
}
