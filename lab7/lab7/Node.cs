namespace lab7
{
    public class Node
    {
        public readonly Point Center;
        public Node? Next { get; private set; }

        protected const int ERROR = 20;
        protected int dx, dy, range;

        public Node(Point center)
        {
            Center = center;
            dx = 0;
            dy = 0;
            range = 0;
            Next = null;
        }

        public Node AddNext(Node next)
        {
            Next = next;
            range = GetRange(Next.Center, Center);
            dx = Math.Abs(Next.Center.X - Center.X);
            dy = Math.Abs(Next.Center.Y - Center.Y);

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
            int dRange = GetRange(new Point(ERROR, 0), new Point(0, ERROR));

            bool isInXBounds = Math.Abs(p1.X - p2.X) <= dx + ERROR;
            bool isInYBounds = Math.Abs(p1.Y - p2.Y) <= dy + ERROR;
            bool isInRangeBounds = GetRange(p1, p2) <= range + dRange && GetRange(p1, p2) >= range - dRange;

            return isInXBounds && isInYBounds && isInRangeBounds;
        }

    }

}
