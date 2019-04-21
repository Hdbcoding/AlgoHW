using System;
using System.Linq;
using AlgoHW.TSP1Lib;
using NUnit.Framework;

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

        [Test, TestCaseSource(typeof(TestCaseFactory), "TSP1Cases")]
        public void CanEvaluateDistances(string inputFile, string outputFile){
            (var num, var data) = SalesmanCalculator.LoadData(inputFile);
            var distances = SalesmanCalculator.EnumerateDistances(data);
        }

        [Test]
        public void EnumerateSets()
        {
            (var subsets, var setDictionary) = SalesmanCalculator.EnumerateSubsets(24);
            Console.WriteLine(setDictionary.Count);
        }
    }
}