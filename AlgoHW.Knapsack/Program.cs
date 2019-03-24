using AlgoHW.KnapsackLib;
using System;

namespace AlgoHW.Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            (var smallInfo, var smallData) = KnapsackCalculator.LoadData("knapsack_data_small.txt");
            var smallResult = KnapsackCalculator.SmarterCalculation(smallInfo, smallData);
            Console.WriteLine("SmallResult: " + smallResult);

            (var bigInfo, var bigData) = KnapsackCalculator.LoadData("knapsack_data_big.txt");
            var bigResult = KnapsackCalculator.SmarterCalculation(bigInfo, bigData);
            Console.WriteLine("BigResult: " + bigResult);
            Console.ReadLine();
        }
    }
}
