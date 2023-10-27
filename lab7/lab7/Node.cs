namespace lab7
{
    public class Node
    {
        public readonly Point Center;
        public Node? Next { get; private set; }

        protected const int ERROR = 20;
        public int dx { get; protected set; }
        public int dy { get; protected set; }
        protected int range;

        public Node(Point center)
        {
            Center = center;
            Next = null;
            dx = 0;
            dy = 0;
            range = 0;
        }

        public Node(Point center, Node? next, int dx, int dy, int range) : this(center)
        {
            Next = next;
            this.dx = dx;
            this.dy = dy;
            this.range = range;
        }

        public Node AddNext(Node next)
        {
            Next = next;
            range = GetRange(Next.Center, Center);
            dx = Next.Center.X - Center.X;
            dy = Next.Center.Y - Center.Y;

            return next;
        }

        public bool Equals(Point curr, Point next)
        {
            if (IsInBounds(curr, next))
            {
                return true;
            }
            return false;
        }

        protected static int GetRange(Point p1, Point p2)
        {
            return (int)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        protected bool IsInBounds(Point p1, Point p2)
        {
            //int dRange = GetRange(new Point(ERROR, 0), new Point(0, ERROR));

            bool isInXBounds;
            if (dx >= 0)
            {
                isInXBounds = p2.X - p1.X <= dx + ERROR && p2.X - p1.X >= dx - ERROR;
            }
            else
            {
                isInXBounds = p2.X - p1.X >= dx - ERROR && p2.X - p1.X <= dx + ERROR;
            }

            bool isInYBounds;
            if (dy >= 0)
            {
                isInYBounds = p2.Y - p1.Y <= dy + ERROR && p2.Y - p1.Y >= dy - ERROR;
            }
            else
            {
                isInYBounds = p2.Y - p1.Y >= dy - ERROR && p2.Y - p1.Y <= dy + ERROR;
            }
            
            //bool isInRangeBounds = GetRange(p1, p2) <= range + dRange && GetRange(p1, p2) >= range - dRange;

            //return isInXBounds && isInYBounds && isInRangeBounds;
            return isInXBounds && isInYBounds;
        }

    }

}
