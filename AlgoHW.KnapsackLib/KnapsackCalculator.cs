using AlgoHW.Common;
using System;
using System.Collections.Generic;

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
            int[,] memo = new int[info.Items + 1, info.TotalWeight + 1];

            for (int i = 1; i <= info.Items; i++)
            {
                KnapsackData item = data[i - 1];
                for (int w = 1; w <= info.TotalWeight; w++)
                {
                    var sackSkippingItem = memo[i - 1, w];
                    if (item.Weight > w) memo[i, w] = sackSkippingItem;
                    else
                    {
                        var sackIncludingItem = memo[i - 1, w - item.Weight] + item.Value;
                        memo[i, w] = Math.Max(sackSkippingItem, sackIncludingItem);
                    }
                }
            }

            return memo[info.Items, info.TotalWeight];
        }

        public static int SmarterCalculation(KnapsackInfo info, List<KnapsackData> data)
        {
            var memo = new (int cache, int result)[info.TotalWeight + 1];

            for (int i = 1; i <= info.Items; i++)
            {
                KnapsackData item = data[i - 1];
                for (int w = 1; w <= info.TotalWeight; w++)
                {
                    var sackSkippingItem = memo[w].cache;
                    if (item.Weight > w) memo[w].result = sackSkippingItem;
                    else
                    {
                        var sackIncludingItem = memo[w - item.Weight].cache + item.Value;
                        memo[w].result = Math.Max(sackSkippingItem, sackIncludingItem);
                    }
                }

                for (int w = 0; w <= info.TotalWeight; w++) memo[w].cache = memo[w].result;
            }

            return memo[info.TotalWeight].result;
        }

        public static int NaiveRecursiveCalculation(KnapsackInfo info, List<KnapsackData> data)
        {
            var memo = new Dictionary<KnapsackSubproblem, int>();
            data.Sort((a, b) => a.Weight - b.Weight);
            return KnapsackRecursive(data, info.TotalWeight, info.Items, memo);
        }

        private static int KnapsackRecursive(List<KnapsackData> items, int totalWeight, int numItems, Dictionary<KnapsackSubproblem, int> memo)
        {
            if (totalWeight == 0 || numItems == 0) return 0;
            var subproblem = new KnapsackSubproblem{Weight = totalWeight, NumItems = numItems};

            if (memo.ContainsKey(subproblem)) return memo[subproblem];

            var sackSkippingItem = KnapsackRecursive(items, totalWeight, numItems - 1, memo);
            var item = items[numItems - 1];
            int result = sackSkippingItem;
            if (item.Weight <= totalWeight)
            {
                var sackIncludingItem = KnapsackRecursive(items, totalWeight - item.Weight, numItems - 1, memo) + item.Value;
                result = Math.Max(sackIncludingItem, sackSkippingItem);
            }

            memo.Add(subproblem, result);

            return result;
        }
    }
}