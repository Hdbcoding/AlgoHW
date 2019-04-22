using System;
using System.Collections.Generic;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.TSP2Lib
{
    public static class SalesmanCalculator2
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

            var visitedCities = new List<int>();
            visitedCities.Add(1);

            var citiesToVisit = new HashSet<int>(cities.Skip(1).Select(n => n.Id));
            double totalDistance = 0;
            int i = 1;
            while (citiesToVisit.Any())
            {
                int bestId = -1;
                double bestDistance = double.MaxValue;

                foreach (var j in citiesToVisit)
                {
                    var distance = Distance(cities[i - 1], cities[j - 1]);
                    if (distance < bestDistance) {
                        bestId = j;
                        bestDistance = distance;
                    }
                }

                totalDistance += bestDistance;
                i = bestId;
                visitedCities.Add(bestId);
                citiesToVisit.Remove(bestId);
            }
            return (int)(totalDistance + Distance(cities[i - 1], cities[0]));
        }

        public static Dictionary<(int, int), double> EnumerateDistances(List<City> cities)
        {
            var distances = new Dictionary<(int, int), double>();
            for (int i = 0; i < cities.Count - 1; i++)
            {
                var ci = cities[i];
                for (int j = i + 1; j < cities.Count; j++)
                {
                    var cj = cities[j];
                    distances.Add((ci.Id, cj.Id), Distance(ci, cj));
                }
            }
            return distances;
        }

        private static double Distance(City ci, City cj)
        {
            var dx = ci.X - cj.X;
            var dy = ci.Y - cj.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private static double Distance(Dictionary<(int, int), double> distances, int j, int k)
        {
            if (k < j) return Distance(distances, k, j);
            return distances[(j, k)];
        }
    }
}
