using System;
using AlgoHW.HuffmanLib;

namespace AlgoHW.Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            (var info, var values) = HuffmanEncoder.LoadData("huffmanData.txt");
            var tree = HuffmanEncoder.CalculateHuffmanCodes(values);
            (var min, var max) = HuffmanEncoder.GetTreeDepths(tree);
            Console.WriteLine(max - 1);
            Console.WriteLine(min - 1);
            Console.ReadLine();
        }
    }
}
