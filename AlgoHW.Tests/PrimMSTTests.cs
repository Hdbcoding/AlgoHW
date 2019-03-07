using System.IO;
using System.Linq;
using AlgoHW.PrimMSTLib;
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
    }
}