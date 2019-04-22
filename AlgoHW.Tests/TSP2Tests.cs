using AlgoHW.TSP2Lib;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public class TSP2Tests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), "TSP2Cases")]
        public void CanLoadSets(string inputFile, string outputFile){
            (var num, var data) = SalesmanCalculator2.LoadData(inputFile);
            Assert.AreEqual(num, data.Count);
        }
    }
}