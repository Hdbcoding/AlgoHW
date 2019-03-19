using System.IO;
using System.Linq;
using AlgoHW.ClusteringLib;
using AlgoHW.Common;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public class ExplicitClusterTests
    {
        // [Test, TestCaseSource(typeof(TestCaseFactory), "ClusterExplicitCases")]
        public void CanLoadGraphs(string inputFile, string outputFile)
        {
            (var info, var graph) = ExplicitClusterLoader.LoadData(inputFile);
            var count = File.ReadAllLines(inputFile).Count();
            Assert.AreEqual(count, graph.Count + 1);
        }

        // [Test, TestCaseSource(typeof(TestCaseFactory), "ClusterExplicitCases")]
        public void CorrectSpacing(string inputFile, string outputFile)
        {
            (var info, var graph) = ExplicitClusterLoader.LoadData(inputFile);
            var spacing = ExplicitClusterLoader.CalculateSpacing(info, graph);
            var expected = File.ReadLines(outputFile).WhereNotNull().Select(int.Parse).First();
            Assert.AreEqual(expected, spacing);
        }
    }
}