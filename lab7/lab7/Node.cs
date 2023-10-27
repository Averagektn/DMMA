namespace lab7
{
    /// <summary>
    /// 
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 
        /// </summary>
        protected const int ERROR = 20;

        /// <summary>
        /// 
        /// </summary>
        public readonly Point Center;
        
        /// <summary>
        /// 
        /// </summary>
        public Node? Next { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int DX { get; protected set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int DY { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center">
        /// 
        /// </param>
        public Node(Point center)
        {
            Center = center;
            Next = null;
            DX = 0;
            DY = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center">
        /// 
        /// </param>
        /// <param name="next">
        /// 
        /// </param>
        /// <param name="dx">
        /// 
        /// </param>
        /// <param name="dy">
        /// 
        /// </param>
        public Node(Point center, Node? next, int dx, int dy) : this(center)
        {
            Next = next;
            DX = dx;
            DY = dy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public Node AddNext(Node next)
        {
            Next = next;
            DX = Next.Center.X - Center.X;
            DY = Next.Center.Y - Center.Y;

            return next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curr">
        /// 
        /// </param>
        /// <param name="next">
        /// 
        /// </param>
        /// <returns>
        /// 
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
        /// 
        /// </summary>
        /// <param name="p1">
        /// 
        /// </param>
        /// <param name="p2">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        protected static int GetRange(Point p1, Point p2)
        {
            return (int)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1">
        /// 
        /// </param>
        /// <param name="p2">
        /// 
        /// </param>
        /// <returns>
        /// 
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
