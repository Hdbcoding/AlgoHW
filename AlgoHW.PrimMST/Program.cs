using System;
using AlgoHW.PrimMSTLib;

namespace AlgoHW.PrimMST
{
    class Program
    {
        static void Main(string[] args)
        {
            (var info, var data) = MSTLoader.LoadData("prim_data.txt");
            var graph = MSTLoader.GenerateGraph(data);
            (var length, var path) = MSTLoader.CalculateMST(graph);
            Console.WriteLine(length);
        }
    }
}
