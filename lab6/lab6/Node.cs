namespace lab6
{
    public class Node
    {
        public bool IsVisited = false;

        public Node? LeftChild;
        public Node? RightChild;

        public double Height;
        public int LeftLeave;
        public int RightLeave;

        public Node(TableCell cell, Node? childL = null, Node? childR = null)
        {
            LeftLeave = cell.Column;
            RightLeave = cell.Row;
            Height = cell.Value;
            LeftChild = childL;
            RightChild = childR;
        }

        public Node(Node? childL, Node? childR, double height)
        {
            LeftLeave = -1;
            RightLeave = -1;
            Height = height;
            LeftChild = childL;
            RightChild = childR;
        }
    }
}
