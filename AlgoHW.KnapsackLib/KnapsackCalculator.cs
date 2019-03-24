using System;
using System.Collections.Generic;
using AlgoHW.Common;

namespace AlgoHW.KnapsackLib
{
    public static class KnapsackCalculator
    {
        public static (KnapsackInfo, List<KnapsackData>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, KnapsackInfo.FromString, KnapsackData.FromString);
        }

        public static int NaiveCalculation(KnapsackInfo info, List<KnapsackData> data)
        {
            var memo = new int[info.TotalWeight + 1, info.Items + 1];

            for (int i = 1; i <= info.Items; i++){
                var item = data[i - 1];
                for (int w = 1; w <= info.TotalWeight; w++){
                    var sackSkippingItem = memo[i - 1, w];
                    var sackIncludingItem = (item.Weight > w ? 0 : memo[i - 1, w - item.Weight]) + item.Value;

                    memo[i, w] = Math.Max(sackSkippingItem, sackIncludingItem);
                }
            }

            return memo[info.TotalWeight, info.Items];
        }
    }
}