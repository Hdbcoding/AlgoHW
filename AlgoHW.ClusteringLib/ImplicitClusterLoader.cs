using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.ClusteringLib
{
    public static class ImplicitClusterLoader
    {
        static int[] masks;

        public static (ImplicitClusterInfo, List<BitVector32>) LoadData(string inputFile)
        {
            //init masks to load up bit vectors
            masks = new int[32];
            masks[0] = BitVector32.CreateMask();
            for (int i = 1; i < 32; i++)
            {
                masks[i] = BitVector32.CreateMask(masks[i - 1]);
            }

                return DataReader.ReadData(inputFile, ImplicitClusterInfo.FromString, ParseBits);
        }

        private static BitVector32 ParseBits(string s)
        {
            var vector = new BitVector32();

            var bits = s.ParseMany(int.Parse).ToList();
            for (int i = 0; i < bits.Count; i++)
            {
                vector[masks[i]] = bits[i] == 1;
            }

            return vector;
        }
    }
}
