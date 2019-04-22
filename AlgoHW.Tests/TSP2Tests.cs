using System.IO;
using AlgoHW.TSP2Lib;
using NUnit.Framework;
using AlgoHW.Common;
using System.Linq;

namespace AlgoHW.Tests
{
    public class TSP2Tests
    {
        // [Test, TestCaseSource(typeof(TestCaseFactory), "TSP2Cases")]
        public void CanLoadSets(string inputFile, string outputFile)
        {
            (var num, var data) = SalesmanCalculator2.LoadData(inputFile);
            Assert.AreEqual(num, data.Count);
        }

        [Test, TestCaseSource(typeof(TestCaseFactory), "TSP2Cases")]
        public void CorrectCircuitLength(string inputFile, string outputFile)
        {
            (var num, var data) = SalesmanCalculator2.LoadData(inputFile);
            var distance = SalesmanCalculator2.ShortestCircuit(num, data);
            var output = File.ReadAllLines(outputFile).WhereNotNull().Select(int.Parse).First();
            Assert.AreEqual(output, distance);
        }
    }
}