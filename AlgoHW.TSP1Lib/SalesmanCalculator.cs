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
            if (numCities <= 1) return 0;
            if (numCities == 2) return (int)(Distance(cities[0], cities[1]) * 2);
            if (numCities == 3) return (int)(Distance(cities[0], cities[1]) + Distance(cities[1], cities[2]) + Distance(cities[0], cities[2]));

            var subsets = EnumerateSubsets(numCities);
            var distances = EnumerateDistances(cities);
            // note: treat null as infinity
            var oldProblems = new float?[subsets[0].Count, numCities];
            oldProblems[0, 0] = 0;
            var oldDict = new Dictionary<int, int>();
            oldDict.Add(1, 0);
            for (int m = 1; m < numCities; m++)
            { //size of problem = m + 1
                var start = DateTime.Now;
                var sizeMSets = subsets[m];
                var newProblems = new float?[sizeMSets.Count, numCities];
                var newDict = new Dictionary<int, int>();
                Console.WriteLine((m + 1) + ": num subsets: " + sizeMSets.Count);
                for (int s = 0; s < sizeMSets.Count; s++)
                {
                    var subset = sizeMSets[s];
                    newDict.Add(subset, s);
                    for (int j = 1; j < numCities; j++)
                    {
                        if ((subset & (1 << j)) == 0) continue;
                        var setWithoutJ = subset & ~(1 << j);
                        var withoutJIndex = oldDict[setWithoutJ];
                        int subsetCopy = subset;
                        int k = 0;
                        float shortest = float.MaxValue;
                        while (subsetCopy > 0)
                        {
                            if (j != k && (subsetCopy & 1) == 1)
                            {
                                float? distance = oldProblems[withoutJIndex, k] + Distance(distances, j, k);
                                if (distance < shortest)
                                {
                                    shortest = distance.Value;
                                }
                            }
                            subsetCopy >>= 1;
                            k++;
                        }
                        newProblems[s, j] = shortest;
                    }
                }
                var elapsed = DateTime.Now.Ticks - start.Ticks;
                Console.WriteLine((m + 1) + ": elapsed: " + elapsed / 10000 + "ms");

                subsets[m - 1] = null;
                oldProblems = newProblems;
                oldDict = newDict;
            }

            float shortestCircuit = float.MaxValue;
            for (int j = 1; j < numCities; j++)
            {
                float distance = oldProblems[0, j].GetValueOrDefault() + Distance(distances, j, 0);
                shortestCircuit = Math.Min(shortestCircuit, distance);
            }
            return (int)shortestCircuit;
        }

        public static List<List<int>> EnumerateSubsets(int numCities)
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

            return sets;
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
                for (int j = i + 1; j < cities.Count; j++)
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
