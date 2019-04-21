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
            var distances = EnumerateDistances(cities);
            var subproblems = new float?[setDictionary.Count, numCities];
            subproblems[1, 0] = 0;

            for (int m = 1; m < numCities; m++)
            { //size of problem = m + 1
                foreach (var subset in subsets[m])
                {
                    // hey that set dictionary isn't that helpful, I need a map from subproblem to array index
                    // does it really need to be a map?...
                    for (int j = 1; j < numCities; j++)
                    {
                        var setWithoutJ = subset & ~(1 << j);
                        int subsetCopy = subset;
                        int k = 0;
                        int shortestK = 0;
                        float shortest = float.MaxValue;
                        while (subsetCopy > 0)
                        {
                            if ((subsetCopy & 1) == 1)
                            {
                                float distance = subproblems[setWithoutJ, k].GetValueOrDefault() + Distance(distances, j, k);
                                if (distance < shortest)
                                {
                                    shortest = distance;
                                    shortestK = k;
                                }
                            }
                            subsetCopy <<= 1;
                            k++;
                        }
                        // false, need a dictionary!
                        subproblems[subset, j] = shortest;
                    }
                }
            }

            float shortestCircuit = float.MaxValue;
            for (int j = 1; j < numCities; j++){
                float distance = subproblems[setDictionary.Count - 1, j].GetValueOrDefault() + Distance(distances, j, 0);
                shortestCircuit = Math.Min(shortestCircuit, distance);
            }
            return (int)shortestCircuit;
        }

        public static (List<List<int>>, Dictionary<int, (int, int)>) EnumerateSubsets(int numCities)
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
            for (int i = 0; i < sets.Count; i++)
            {
                var list = sets[i];
                for (int j = 0; j < list.Count; j++)
                {
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

        public static Dictionary<int, float> EnumerateDistances(List<City> cities)
        {
            var distances = new Dictionary<int, float>();
            for (int i = 0; i < cities.Count - 1; i++)
            {
                var ci = cities[i];
                for (int j = 1; j < cities.Count; j++)
                {
                    var cj = cities[j];
                    var key = (1 << i) | (1 << j);
                    distances.Add(key, Distance(ci, cj));
                }
            }
            return distances;
        }

        private static float Distance(City ci, City cj)
        {
            var dx = ci.X - cj.X;
            var dy = ci.Y - cj.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private static float Distance(Dictionary<int, float> distances, int j, int k)
        {
            var key = (1 << j) | (1 << k);
            return distances[key];
        }
    }
}
