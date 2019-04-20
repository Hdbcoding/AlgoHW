using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.TSP1Lib
{
    public class City
    {
        public float X { get; set; }
        public float Y { get; set; }
        public static City FromString(string s)
        {
            var numbers = s.ParseMany(float.Parse);
            return new City
            {
                X = numbers.First(),
                Y = numbers.Last()
            };
        }
    }
}