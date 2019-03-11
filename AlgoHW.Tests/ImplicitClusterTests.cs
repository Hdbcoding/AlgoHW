using System.IO;
using System.Linq;
using AlgoHW.ClusteringLib;
using AlgoHW.Common;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public class ImplicitClusterTests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), "ClusterImplicitCases")]
        public void CanLoadGraphs(string inputFile, string outputFile)
        {
            (var info, var graph) = ImplicitClusterLoader.LoadData(inputFile);

            int count = 0;
            var lines = File.ReadLines(inputFile).Skip(1);
            foreach (var line in lines)
            {
                var value = graph[count];
                count++;

                var s = string.Join("", value.ToString().Reverse().Skip(1).Take(info.Bits));

                Assert.AreEqual(line.Replace(" ", ""), s);
            }
            Assert.AreEqual(count, graph.Count);
        }

        [Test, TestCaseSource(typeof(TestCaseFactory), "ClusterImplicitCases")]
        public void CorrectClusterCounts(string inputFile, string outputFile)
        {
            (var info, var graph) = ImplicitClusterLoader.LoadData(inputFile);
            var count = ImplicitClusterLoader.CountClusters(info, graph);
            var expected = File.ReadLines(outputFile).WhereNotNull().Select(int.Parse).First();
            Assert.AreEqual(expected, count);
        }
    }
}