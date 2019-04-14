using AlgoHW.KnapsackLib;
using System;

namespace AlgoHW.Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            (var smallInfo, var smallData) = KnapsackCalculator.LoadData("knapsack_small_data.txt");
            var smallResult = KnapsackCalculator.SmarterCalculation(smallInfo, smallData);
            Console.WriteLine("SmallResult: " + smallResult);

            (var bigInfo, var bigData) = KnapsackCalculator.LoadData("knapsack_big_data.txt");
            var bigResult = KnapsackCalculator.SmarterCalculation(bigInfo, bigData);
            Console.WriteLine("BigResult: " + bigResult);
            Console.ReadLine();
        }
    }
}
