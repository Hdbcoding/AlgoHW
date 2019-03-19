using System;
using System.Collections.Generic;
using AlgoHW.Common;

namespace AlgoHW.MWISLib
{
    public static class MWISCalculator
    {
        public static (int, List<int>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, int.Parse, int.Parse);
        }

        public static int[] CalculateMWISWeights(List<int> data)
        {
            var memo = new int[data.Count];
            memo[0] = data[0];
            for (int i = 1; i < data.Count; i++)
            {
                var back1 = memo[i - 1];
                var back2 = i > 1 ? memo[i - 2] : 0;
                memo[i] = Math.Max(back1, back2 + data[i]);
            }

            return memo;
        }

        public static bool[] ReconstructMWIS(int[] memo, List<int> data)
        {
            var mwis = new bool[data.Count];
            var i = data.Count - 1;

            while (i >= 1)
            {
                var back1 = memo[i - 1];
                var back2 = i > 1 ? memo[i - 2] : 0;
                if (back1 >= back2 + data[i]) i -= 1;
                else
                {
                    mwis[i] = true;
                    i -= 2;
                }
                var weight = data[i];
            }
            return mwis;
        }

        public static string AnswerQuestion(bool[] mwis)
        {
            var indices = new[] { 1, 2, 3, 4, 17, 117, 517, 997 };
            var result = new char[8];
            for (int i = 0; i < 8; i++)
            {
                if (mwis.Length >= indices[i] && mwis[indices[i] - 1]) result[i] = '1';
                else result[i] = '0';
            }
            return new string(result);
        }
    }
}