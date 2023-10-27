namespace lab7
{
    /// <summary>
    ///     Draws grammar by nodes
    /// </summary>
    internal sealed class NodeDrawer : Node
    {
        /// <summary>
        ///     Randomizer
        /// </summary>
        private readonly Random random = new();
        
        /// <summary>
        ///     List initialization
        /// </summary>
        /// <param name="center">
        ///     Head value
        /// </param>
        /// <param name="next">
        ///     Child element
        /// </param>
        /// <param name="dx">
        ///     X coordinate difference
        /// </param>
        /// <param name="dy">
        ///     Y coordinate difference
        /// </param>
        public NodeDrawer(Point center, Node? next, int dx, int dy) : base(center, next, dx, dy) { }

        /// <summary>
        ///     Draws class
        /// </summary>
        /// <param name="g">
        ///     Drawing tool
        /// </param>
        /// <param name="pen">
        ///     Color
        /// </param>
        /// <param name="max">
        ///     Max coordinates of drawing field
        /// </param>
        /// <param name="diameter">
        ///     Diameter of points
        /// </param>
        /// <param name="nodesCount">
        ///     Nodes list length
        /// </param>
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
                x += curr.DX + random.Next(ERROR / 2);
                y += curr.DY + random.Next(ERROR / 2);
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
