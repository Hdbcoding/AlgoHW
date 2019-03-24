using System.IO;
using AlgoHW.KnapsackLib;
using NUnit.Framework;
using AlgoHW.Common;
using System.Linq;

namespace AlgoHW.Tests
{
    public class KnapsackTests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), "KnapsackCases")]
        public void CorrectKnapsackValue(string inputFile, string outputFile)
        {
            (var info, var data) = KnapsackCalculator.LoadData(inputFile);
            var actual = KnapsackCalculator.NaiveCalculation(info, data);
            var expected = File.ReadAllLines(outputFile).WhereNotNull().Select(int.Parse).First();
            Assert.AreEqual(expected, actual);
        }
    }
}