namespace lab6
{
    /// <summary>
    ///     Tree node with:<br/> 
    ///     * 2 values: <see cref="LeftLeave"/>, <see cref="RightLeave"/><br/>  
    ///     * 2 children: <see cref="LeftChild"/>, <see cref="RightChild"/><br/>
    /// </summary>
    public class Node
    {
        /// <summary>
        ///     Mark visited to avoid multiple visits. Unset after algorithm is over
        /// </summary>
        public bool IsVisited = false;

        /// <summary>
        ///     Down elements
        /// </summary>
        public Node? LeftChild;
        public Node? RightChild;

        /// <summary>
        ///     Distance to the bottom
        /// </summary>
        public double Height;

        /// <summary>
        ///     Values
        /// </summary>
        public int LeftLeave;
        public int RightLeave;

        /// <summary>
        ///     Creates node with 2 values and 0, 1 or 2 children
        /// </summary>
        /// <param name="cell">
        ///     Payload
        /// </param>
        /// <param name="childL">
        ///     Left child
        /// </param>
        /// <param name="childR">
        ///     Right child
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
        ///     Creates node with 2 children and no payload
        /// </summary>
        /// <param name="childL">
        ///     Left child
        /// </param>
        /// <param name="childR">
        ///     Right child
        /// </param>
        /// <param name="height">
        ///     Distance to the bottom
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
