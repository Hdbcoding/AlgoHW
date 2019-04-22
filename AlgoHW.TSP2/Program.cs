using System;
using AlgoHW.TSP2Lib;

namespace AlgoHW.TSP2
{
    class Program
    {
        static void Main(string[] args)
        {
            (var num, var data) = SalesmanCalculator2.LoadData("tsp2_data.txt");
            Console.WriteLine("Data loaded");
            var distance = SalesmanCalculator2.ShortestCircuit(num, data);
            Console.WriteLine(distance);
        }
    }
}
