namespace AlgoHW.HuffmanLib
{
    public class HuffmanTreeNode
    {
        public int? TreeWeight => Left?.TreeWeight ?? Left?.Weight ?? 0 + Right?.TreeWeight ?? Right?.Weight ?? 0;
        public int? Id { get; set; }
        public int? Weight { get; set; }
        public HuffmanTreeNode Left { get; set; }
        public HuffmanTreeNode Right { get; set; }

    }
}