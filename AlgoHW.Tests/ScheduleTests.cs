using System.IO;
using System.Linq;
using AlgoHW.ScheduleLib;
using NUnit.Framework;

namespace AlgoHW.Tests
{
    public class ScheduleTests
    {
        [Test, TestCaseSource(typeof(TestCaseFactory), "ScheduleCases")]
        public void CanLoadJobs(string inputFile, string outputFile)
        {
            (var info, var jobs) = ScheduleLoader.LoadData(inputFile);
            var count = File.ReadAllLines(inputFile).Count();
            Assert.AreEqual(count, jobs.Count + 1);
        }
    }
}