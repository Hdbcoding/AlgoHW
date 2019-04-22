using System;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.TSP2Lib
{
    public class City
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        internal static City FromString(string s)
        {
            var data = s.Split(' ').WhereNotNull();
            return new City
            {
                Id = int.Parse(data.First()),
                X = double.Parse(data.Skip(1).First()),
                Y = double.Parse(data.Last())
            };
        }
    }
}