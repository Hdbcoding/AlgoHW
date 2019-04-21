using System;
using AlgoHW.TSP1Lib;

namespace AlgoHW.TSP1
{
    class Program
    {
        static void Main(string[] args)
        {
            (var num, var data) = SalesmanCalculator.LoadData("tsp_data.txt");
            Console.WriteLine("Data loaded");
            var distance = SalesmanCalculator.ShortestCircuit(num, data);
            Console.WriteLine(distance);
        }
    }
}
