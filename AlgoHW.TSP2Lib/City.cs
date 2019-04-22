using System;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.TSP2Lib
{
    public class City
    {
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        internal static City FromString(string s)
        {
            var data = s.Split(' ').WhereNotNull();
            return new City
            {
                Id = int.Parse(data.First()),
                X = float.Parse(data.Skip(1).First()),
                Y = float.Parse(data.Last())
            };
        }
    }
}