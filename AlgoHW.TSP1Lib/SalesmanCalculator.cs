using System;
using System.Collections.Generic;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.TSP1Lib
{
    public static class SalesmanCalculator
    {
        public static (int, List<City>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, int.Parse, City.FromString);
        }

        public static int ShortestCircuit(int numCities, List<City> cities)
        {
            (var subsets, var setDictionary) = EnumerateSubsets(numCities);
            var subproblems = new int[setDictionary.Count, numCities];
            return 0;
        }

        public static (List<List<int>>, Dictionary<int, (int,int)>) EnumerateSubsets(int numCities)
        {
            var total = (int)Math.Pow(2, numCities);
            var sets = new List<List<int>>(numCities);
            for (int i = 0; i < numCities; i++) sets.Add(new List<int>());
            for (int i = 1; i < total; i++)
            {
                // skip subsets that don't include first city
                if ((i & 1) == 0) continue;

                int numBits = CountBits(i);
                if (sets[numBits - 1] == null) sets[numBits - 1] = new List<int>() { i };
                else sets[numBits - 1].Add(i);
            }

            var set = new Dictionary<int, (int, int)>();
            for (int i = 0; i < sets.Count; i++){
                var list = sets[i];
                for (int j = 0; j < list.Count; j++){
                    set.Add(list[j], (i, j));
                }
            }

            return (sets, set);
        }

        private static int CountBits(int i)
        {
            int count = 0;
            while (i > 0)
            {
                count += i & 1;
                i >>= 1;
            }
            return count;
        }
    }
}
