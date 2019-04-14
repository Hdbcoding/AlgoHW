using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public static class TestCaseFactory
    {
        public static IEnumerable<TestCaseData> PrimMSTCases => EnumerateCases("primTestCases");
        public static IEnumerable<TestCaseData> ScheduleCases => EnumerateCases("scheduleTestCases");
        public static IEnumerable<TestCaseData> ClusterExplicitCases => EnumerateCases("clusterExplicitCases");
        public static IEnumerable<TestCaseData> ClusterImplicitCases => EnumerateCases("clusterImplicitCases");
        public static IEnumerable<TestCaseData> HuffmanCases => EnumerateCases("huffmanCases");
        public static IEnumerable<TestCaseData> MWISCases => EnumerateCases("mwisCases");
        public static IEnumerable<TestCaseData> KnapsackCases => EnumerateCases("knapsackCases");
        public static IEnumerable<TestCaseData> AllPairsPathsCases => EnumerateCases("allPairsPathsCases");

        private static IEnumerable<TestCaseData> EnumerateCases(string directory)
        {
                var dict = new Dictionary<string, (string input, string output)>();
                var files = Directory.EnumerateFiles(directory);
                foreach (string entry in files)
                {
                    string key = entry.Substring(entry.IndexOf('_') + 1);
                    if (dict.ContainsKey(key))
                    {
                        dict[key] = (dict[key].input, entry);
                    }
                    else
                    {
                        dict.Add(key, (entry, null));
                    }
                }

                foreach ((string input, string output) value in dict.Values)
                {
                    yield return new TestCaseData(value.input, value.output);
                }
        }
    }
}