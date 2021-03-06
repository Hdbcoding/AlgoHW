using System;
using System.IO;
using System.Linq;
using AlgoHW.TSP1Lib;
using NUnit.Framework;
using AlgoHW.Common;

namespace AlgoHW.Tests
{
    public class TSP1Tests
    {
        // [Test, TestCaseSource(typeof(TestCaseFactory), "TSP1Cases")]
        public void CanLoadSets(string inputFile, string outputFile)
        {
            (var num, var data) = SalesmanCalculator.LoadData(inputFile);
            Assert.AreEqual(num, data.Count);
        }

        // [Test, TestCaseSource(typeof(TestCaseFactory), "TSP1Cases")]
        public void CanEvaluateDistances(string inputFile, string outputFile)
        {
            (var num, var data) = SalesmanCalculator.LoadData(inputFile);
            var distances = SalesmanCalculator.EnumerateDistances(data);
        }

        [Test, TestCaseSource(typeof(TestCaseFactory), "TSP1Cases")]
        public void CorrectCircuitLength(string inputFile, string outputFile)
        {
            (var num, var data) = SalesmanCalculator.LoadData(inputFile);
            var distance = SalesmanCalculator.ShortestCircuit(num, data);
            var output = File.ReadAllLines(outputFile).WhereNotNull().Select(int.Parse).First();
            Assert.AreEqual(output, distance);
        }

        [Test]
        public void EnumerateSets()
        {
            var subsets = SalesmanCalculator.EnumerateSubsets(24);
            Console.WriteLine(subsets.Count);
            foreach (var set in subsets) Console.WriteLine(set.Count);
        }
    }
}