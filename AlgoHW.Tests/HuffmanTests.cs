using System.IO;
using System.Linq;
using AlgoHW.HuffmanLib;
using AlgoHW.Common;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public class HuffmanTests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), "HuffmanCases")]
        public void CanLoadGraphs(string inputFile, string outputFile)
        {
            (var info, var values) = HuffmanEncoder.LoadData(inputFile);
            var count = File.ReadAllLines(inputFile).Count();
            Assert.AreEqual(count, values.Count + 1);
        }

        [Test, TestCaseSource(typeof(TestCaseFactory), "HuffmanCases")]
        public void CorrectTreeDepth(string inputFile, string outputFile)
        {
            (var info, var values) = HuffmanEncoder.LoadData(inputFile);
            var tree = HuffmanEncoder.CalculateHuffmanCodes(values);
            (var min, var max) = HuffmanEncoder.GetTreeDepths(tree);
            var expected = File.ReadLines(outputFile).WhereNotNull().Select(int.Parse);
            Assert.AreEqual(expected.First(), max - 1);
            Assert.AreEqual(expected.Last(), min - 1);
        }
    }
}