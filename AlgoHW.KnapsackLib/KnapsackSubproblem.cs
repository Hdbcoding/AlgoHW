using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoHW.KnapsackLib
{
    public class KnapsackSubproblem
    {
        public int Weight { get; set; }
        public int NumItems { get; set; }

        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 37 + Weight;
            hash = hash * 37 + NumItems;
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj is KnapsackSubproblem other)
            {
                return other.Weight == Weight && other.NumItems == NumItems;
            }
            return false;
        }
    }
}
