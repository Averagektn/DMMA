namespace lab7
{
    internal sealed class NodeDrawer : Node
    {
        private readonly Random random = new();
        
        public NodeDrawer(Point center, Node? next, int dx, int dy) : base(center, next, dx, dy, 0) { }

        public void Draw(Graphics g, Pen pen, Point max, int diameter, int nodesCount)
        {
            Node? curr = this;
            int x = random.Next(max.X);
            int y = random.Next(max.Y);
            var point = new Point(x, y);

            g.DrawEllipse(pen, new Rectangle(x, y, diameter, diameter));
            g.FillEllipse(new SolidBrush(pen.Color), new Rectangle(x, y, diameter, diameter));

            while (nodesCount > 1 && curr is not null)
            {
                x += curr.dx + random.Next(ERROR / 2);
                y += curr.dy + random.Next(ERROR / 2);
                curr = curr.Next;
                g.DrawEllipse(pen, new Rectangle(x - diameter / 2, y - diameter / 2, diameter, diameter));
                g.FillEllipse(new SolidBrush(pen.Color), new Rectangle(x - diameter / 2, y - diameter / 2, diameter, diameter));
                g.DrawLine(pen, point, new Point(x, y));
                point = new Point(x, y);
                curr = curr?.Next;
                nodesCount -= 2;
            }
        }

    }

}
