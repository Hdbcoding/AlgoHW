using System;
using AlgoHW.AllPairsPathsLib;

namespace AlgoHW.AllPairsPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            (var info, var data) = DistanceCalculator.LoadData("g1_data.txt");
            Console.WriteLine("Loaded g1");
            (var labels, var graph) = DistanceCalculator.GenerateGraph(data);
            var result = DistanceCalculator.FloydWarshall(labels, graph);
            Console.WriteLine("Finished calculating g1");
            Console.WriteLine(result);

            (info, data) = DistanceCalculator.LoadData("g2_data.txt");
            Console.WriteLine("Loaded g2");
            (labels, graph) = DistanceCalculator.GenerateGraph(data);
            result = DistanceCalculator.FloydWarshall(labels, graph);
            Console.WriteLine("Finished calculating g2");
            Console.WriteLine(result);

            (info, data) = DistanceCalculator.LoadData("g3_data.txt");
            Console.WriteLine("Loaded g3");
            (labels, graph) = DistanceCalculator.GenerateGraph(data);
            result = DistanceCalculator.FloydWarshall(labels, graph);
            Console.WriteLine("Finished calculating g3");
            Console.WriteLine(result);

            (info, data) = DistanceCalculator.LoadData("g4_large_data.txt");
            Console.WriteLine("Loaded g4");
            (labels, graph) = DistanceCalculator.GenerateGraph(data);
            result = DistanceCalculator.FloydWarshall(labels, graph);
            Console.WriteLine("Finished calculating g4");
            Console.WriteLine(result);
        }
    }
}
