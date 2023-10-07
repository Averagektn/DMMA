namespace lab6
{
    /// <summary>
    /// 
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsVisited = false;

        /// <summary>
        /// 
        /// </summary>
        public Node? LeftChild;
        public Node? RightChild;

        /// <summary>
        /// 
        /// </summary>
        public double Height;

        /// <summary>
        /// 
        /// </summary>
        public int LeftLeave;
        public int RightLeave;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell">
        /// 
        /// </param>
        /// <param name="childL">
        /// 
        /// </param>
        /// <param name="childR">
        /// 
        /// </param>
        public Node(TableCell cell, Node? childL = null, Node? childR = null)
        {
            LeftLeave = cell.Column;
            RightLeave = cell.Row;
            Height = cell.Value;
            LeftChild = childL;
            RightChild = childR;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childL">
        /// 
        /// </param>
        /// <param name="childR">
        /// 
        /// </param>
        /// <param name="height">
        /// 
        /// </param>
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
