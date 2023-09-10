using System.Drawing;

namespace lab1
{
    public class Cluster
    {
        /// <summary>
        /// Clusters center
        /// </summary>
        public Point Center;

        /// <summary>
        /// Dots of the cluster
        /// </summary>
        public List<Dot> Dots = new();

        /// <summary>
        /// Cluster's unique color
        /// </summary>
        public readonly Color Color;

        /// <summary>
        /// Size of cluster center to be drawn
        /// </summary>
        private const int WIDTH = 15, HEIGHT = 15;

        /// <summary>
        /// Generates cluster with specified <see cref="System.Drawing.Color"/> and coordinates
        /// </summary>
        /// <param name="color"><see cref="Color"></param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Cluster(Color color, int x, int y) 
        {
            Color = color;
            Center = new Point(x, y);
        }   

        /// <summary>
        /// Draws all the point of the cluster
        /// </summary>
        /// <param name="g"><see cref="Graphics"/> to draw on</param>
        public void Draw(Graphics g)
        {
            foreach(var dot in Dots)
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
        /// Counts the best center in the middle of the cluster
        /// </summary>
        /// <returns>new <see cref="Center"/></returns>
        public Point GetBestClusterCenter()
        {
            var bestCenter = new Point((int)Dots.Average(x => x.TopLeft.X), (int)Dots.Average(x => x.TopLeft.Y));
            var minDifferent = double.MaxValue;
            var minDifferentPoint = new Point();
            foreach (var centerCandidate in Dots)
            {
                var different = GetDotsDistance(bestCenter, centerCandidate.TopLeft);
                if (!(different < minDifferent)) continue;
                minDifferent = different;
                minDifferentPoint = centerCandidate.TopLeft;
            }

            return minDifferentPoint;
        }

        /// <summary>
        /// Counts the distance between two dots
        /// </summary>
        /// <param name="firstDot"></param>
        /// <param name="secondDot"></param>
        /// <returns>Distance</returns>
        private static double GetDotsDistance(Point firstDot, Point secondDot)
        {
            var xDifferent = firstDot.X - secondDot.X;
            var yDifferent = firstDot.Y - secondDot.Y;
            return Math.Sqrt(xDifferent * xDifferent + yDifferent * yDifferent);
        }
    }
}
