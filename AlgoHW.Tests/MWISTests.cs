using System.IO;
using System.Linq;
using AlgoHW.Common;
using AlgoHW.MWISLib;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public class MWISTests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), "MWISCases")]
        public void CorrectMWIS(string inputFile, string outputFile)
        {
            (var info, var values) = MWISCalculator.LoadData(inputFile);
            var weights = MWISCalculator.CalculateMWISWeights(values);
            var mwis = MWISCalculator.ReconstructMWIS(weights, values);
            var answer = MWISCalculator.AnswerQuestion(mwis);
            var expected = File.ReadLines(outputFile).WhereNotNull();
            Assert.AreEqual(expected.First(), answer);
        }
    }
}