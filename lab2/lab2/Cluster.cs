namespace lab2
{
    public class Cluster
    {
        /// <summary>
        /// Clusters center
        /// </summary>
        public Point Center { get; set; }

        /// <summary>
        /// Dots of the cluster
        /// </summary>
        public List<Dot> Dots { get; set; }

        /// <summary>
        /// Cluster's unique color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Size of cluster center to be drawn
        /// </summary>
        protected const int WIDTH = 20, HEIGHT = 20;

        /// <summary>
        /// Generates cluster with specified <see cref="System.Drawing.Color"/> and coordinates
        /// </summary>
        /// <param name="color"><see cref="Color"></param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Cluster(Color color, int x, int y)
        {
            Dots = new();
            Color = color;
            Center = new Point(x, y);
        }

        public Cluster(Color color, List<Dot> dots, Point center)
        {
            Color = color;
            Dots = dots;
            Center = center;
        }

        /// <summary>
        /// Draws all the point of the cluster
        /// </summary>
        /// <param name="g"><see cref="Graphics"/> to draw on</param>
        public void DrawDots(Graphics g)
        {
            foreach (var dot in Dots)
            {
                dot.Draw(g);
            }
        }

        /// <summary>
        /// Draws cluster's center at <see cref="Center"/> with <see cref="WIDTH"/> and <see cref="HEIGHT"/> sizes
        /// </summary>
        /// <param name="g"><see cref="Graphics"/> to draw on</param>
        public void DrawCenter(Graphics g)
        {
            g.DrawEllipse(Pens.Coral, Center.X, Center.Y, WIDTH, HEIGHT);
            g.FillEllipse(new SolidBrush(Color.Coral), Center.X, Center.Y, WIDTH, HEIGHT);
        }

        /// <summary>
        /// Counts the distance between two dots
        /// </summary>
        /// <param name="firstDot"></param>
        /// <param name="secondDot"></param>
        /// <returns>Distance</returns>
        protected static double GetDotsDistance(Point firstDot, Point secondDot)
        {
            var xDifferent = firstDot.X - secondDot.X;
            var yDifferent = firstDot.Y - secondDot.Y;
            return Math.Sqrt(xDifferent * xDifferent + yDifferent * yDifferent);
        }

    }
}