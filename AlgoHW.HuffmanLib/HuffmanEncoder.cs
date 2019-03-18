using System;
using System.Collections.Generic;
using System.Linq;
using AlgoHW.Common;

namespace AlgoHW.HuffmanLib
{
    public static class HuffmanEncoder
    {
        public static (int, List<int>) LoadData(string inputFile)
        {
            return DataReader.ReadData(inputFile, int.Parse, int.Parse);
        }

        public static HuffmanTreeNode CalculateHuffmanCodes(List<int> data)
        {
            var nodesToProcess = new Queue<HuffmanTreeNode>();
            var nodes = data.Select((weight, index) => new HuffmanTreeNode
            {
                Id = index,
                Weight = weight
            }).OrderBy(n => n.Weight);
            foreach (var node in nodes) nodesToProcess.Enqueue(node);

            var treesToProcess = new Queue<HuffmanTreeNode>();

            while (nodesToProcess.Count > 0 || treesToProcess.Count > 1)
            {
                var combinedNode = CombineNextNodes(nodesToProcess, treesToProcess);
                treesToProcess.Enqueue(combinedNode);
            }
            return treesToProcess.Dequeue();
        }

        private static HuffmanTreeNode CombineNextNodes(Queue<HuffmanTreeNode> nodesToProcess, Queue<HuffmanTreeNode> treesToProcess)
        {
            var node1 = GetNextNode(nodesToProcess, treesToProcess);
            var node2 = GetNextNode(nodesToProcess, treesToProcess);
            return new HuffmanTreeNode{ Left = node1, Right = node2 };
        }

        private static HuffmanTreeNode GetNextNode(Queue<HuffmanTreeNode> nodesToProcess, Queue<HuffmanTreeNode> treesToProcess)
        {
            if (!nodesToProcess.Any()) return treesToProcess.Dequeue();
            if (!treesToProcess.Any()) return nodesToProcess.Dequeue();
            if (nodesToProcess.Peek().Weight < treesToProcess.Peek().TreeWeight) return nodesToProcess.Dequeue();
            return treesToProcess.Dequeue();
        }

        public static (int, int) GetTreeDepths(HuffmanTreeNode tree)
        {
            return (MinDepth(tree), MaxDepth(tree));
        }

        private static int MinDepth(HuffmanTreeNode tree) => DepthEvaluator(tree, Math.Min);
        private static int MaxDepth(HuffmanTreeNode tree) => DepthEvaluator(tree, Math.Max);

        private static int DepthEvaluator(HuffmanTreeNode tree, Func<int, int, int> tiebreaker){
            if (tree == null) return 0;

            if (tree.Left == null && tree.Right == null) return 1;

            if (tree.Left == null) return DepthEvaluator(tree.Right, tiebreaker) + 1;
            if (tree.Right == null) return DepthEvaluator(tree.Left, tiebreaker) + 1;

            return tiebreaker(DepthEvaluator(tree.Right, tiebreaker), DepthEvaluator(tree.Left, tiebreaker)) + 1;
        }
    }
}