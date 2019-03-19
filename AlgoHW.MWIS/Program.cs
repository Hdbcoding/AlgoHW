using System;
using AlgoHW.MWISLib;

namespace AlgoHW.MWIS
{
    class Program
    {
        static void Main(string[] args)
        {
            (var info, var values) = MWISCalculator.LoadData("mwisData.txt");
            var weights = MWISCalculator.CalculateMWISWeights(values);
            var mwis = MWISCalculator.ReconstructMWIS(weights, values);
            var answer = MWISCalculator.AnswerQuestion(mwis);
            Console.WriteLine(answer);
            Console.ReadLine();
        }
    }
}
