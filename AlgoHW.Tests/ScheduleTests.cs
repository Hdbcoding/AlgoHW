using System.IO;
using System.Linq;
using AlgoHW.ScheduleLib;
using AlgoHW.Common;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public class ScheduleTests
    {
        // [Test, TestCaseSource(typeof(TestCaseFactory), "ScheduleCases")]
        public void CanLoadJobs(string inputFile, string outputFile)
        {
            (var info, var jobs) = ScheduleLoader.LoadData(inputFile);
            var count = File.ReadAllLines(inputFile).Count();
            Assert.AreEqual(count, jobs.Count + 1);
        }

        // [Test, TestCaseSource(typeof(TestCaseFactory), "ScheduleCases")]
        public void CanCalculateCompletionTimes(string inputFile, string outputFile)        
        {
            var times = ScheduleLoader.CalculateWeightedCompletionTime(inputFile);
            var actual = File.ReadLines(outputFile).WhereNotNull().Select(long.Parse);
            Assert.AreEqual(actual.Last(), times.optimal, message: "optimal check failed");
            Assert.AreEqual(actual.First(), times.poor, message: "poor check failed");
        }
    }
}