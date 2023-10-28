namespace lab7
{
    /// <summary>
    ///     Grammar node
    /// </summary>
    public class Node
    {
        /// <summary>
        ///     Error range
        /// </summary>
        protected const int ERROR = 40;

        /// <summary>
        ///     Grammar value
        /// </summary>
        public readonly Point Center;
        
        /// <summary>
        ///     Next grammar element
        /// </summary>
        public Node? Next { get; private set; }

        /// <summary>
        ///     Difference between <see cref="Next"/> center and <see cref="Center"/> X coordinate
        /// </summary>
        public int DX { get; protected set; }

        /// <summary>
        ///     Difference between <see cref="Next"/> center and <see cref="Center"/> Y coordinate
        /// </summary>
        public int DY { get; protected set; }

        /// <summary>
        ///     New grammar element with specified center
        /// </summary>
        /// <param name="center">
        ///     Node value
        /// </param>
        public Node(Point center)
        {
            Center = center;
            Next = null;
            DX = 0;
            DY = 0;
        }

        /// <summary>
        ///     New node with child element
        /// </summary>
        /// <param name="center">
        ///     Node value
        /// </param>
        /// <param name="next">
        ///     Next node
        /// </param>
        /// <param name="dx">
        ///     Nodes difference in X coordinate
        /// </param>
        /// <param name="dy">
        ///     Nodes difference in Y coordinate
        /// </param>
        public Node(Point center, Node? next, int dx, int dy) : this(center)
        {
            Next = next;
            DX = dx;
            DY = dy;
        }

        /// <summary>
        ///     Adds new child element
        /// </summary>
        /// <param name="next">
        ///     Child element
        /// </param>
        /// <returns>
        ///     Child element
        /// </returns>
        public Node AddNext(Node next)
        {
            Next = next;
            DX = Next.Center.X - Center.X;
            DY = Next.Center.Y - Center.Y;

            return next;
        }

        /// <summary>
        ///     Checks if point is equal to node
        /// </summary>
        /// <param name="curr">
        ///     Point to check
        /// </param>
        /// <param name="next">
        ///     Point's child element
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if point and node are equal, otherwise <see langword="false"/>
        /// </returns>
        public bool Equals(Point curr, Point next)
        {
            if (IsInBounds(curr, next))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Counts range between points
        /// </summary>
        /// <param name="p1">
        ///     First point
        /// </param>
        /// <param name="p2">
        ///     Second point
        /// </param>
        /// <returns>
        ///     Range
        /// </returns>
        protected static int GetRange(Point p1, Point p2)
        {
            return (int)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        /// <summary>
        ///     Checks if points are in node's bounds
        /// </summary>
        /// <param name="p1">
        ///     First point
        /// </param>
        /// <param name="p2">
        ///     Second point
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if points are in node's bounds, otherwise <see langword="false"/>
        /// </returns>
        protected bool IsInBounds(Point p1, Point p2)
        {
            bool isInXBounds;
            bool isInYBounds;

            if (DX >= 0)
            {
                isInXBounds = p2.X - p1.X <= DX + ERROR && p2.X - p1.X >= DX - ERROR;
            }
            else
            {
                isInXBounds = p2.X - p1.X >= DX - ERROR && p2.X - p1.X <= DX + ERROR;
            }

            if (DY >= 0)
            {
                isInYBounds = p2.Y - p1.Y <= DY + ERROR && p2.Y - p1.Y >= DY - ERROR;
            }
            else
            {
                isInYBounds = p2.Y - p1.Y >= DY - ERROR && p2.Y - p1.Y <= DY + ERROR;
            }
            
            return isInXBounds && isInYBounds;
        }

    }

}
