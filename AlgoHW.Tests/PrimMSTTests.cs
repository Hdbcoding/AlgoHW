using System.IO;
using System.Linq;
using AlgoHW.PrimMSTLib;
using AlgoHW.Common;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public class PrimMSTTests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), "PrimMSTCases")]
        public void CanLoadGraphs(string inputFile, string outputFile)
        {
            (var info, var graph) = MSTLoader.LoadData(inputFile);
            var count = File.ReadAllLines(inputFile).Count();
            Assert.AreEqual(count, graph.Count + 1);
        }

        [Test, TestCaseSource(typeof(TestCaseFactory), "PrimMSTCases")]
        public void CanGenerateGraphs(string inputFile, string outputFile)
        {
            (var info, var data) = MSTLoader.LoadData(inputFile);
            var graph = MSTLoader.GenerateGraph(data);
            Assert.AreEqual(info.Nodes, graph.Count);
        }

        [Test, TestCaseSource(typeof(TestCaseFactory), "PrimMSTCases")]
        public void CanCalculateMST(string inputFile, string outputFile)
        {
            (var info, var data) = MSTLoader.LoadData(inputFile);
            var graph = MSTLoader.GenerateGraph(data);
            (var length, var path) = MSTLoader.CalculateMST(graph);
            var actual = File.ReadLines(outputFile).WhereNotNull().Select(long.Parse);
            Assert.AreEqual(actual.First(), length);
        }
    }
}