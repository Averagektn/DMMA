using System.Drawing;

namespace lab1
{
    public class Cluster
    {
        public Point Center;
        public List<Dot> Dots = new();
        public readonly Color Color;
        private const int WIDTH = 15;
        private const int HEIGHT = 15;

        public Cluster(Color color, int x, int y) 
        {
            Color = color;
            Center = new Point(x, y);
        }   

        public void Draw(Graphics g)
        {
            foreach(var dot in Dots)
            {
                dot.Draw(g);
            }
        }

        public void DrawCenter(Graphics g)
        {
            g.DrawEllipse(Pens.Coral, Center.X, Center.Y, WIDTH, HEIGHT);
            g.FillEllipse(new SolidBrush(Color.Coral), Center.X, Center.Y, WIDTH, HEIGHT);
        }

        public Point GetBestClusterCenter()
        {
            var bestCenter = new Point((int)Dots.Average(x => x.TopLeft.X), (int)Dots.Average(x => x.TopLeft.Y));
            var minDifferent = double.MaxValue;
            var minDifferentPoint = new Point();
            foreach (var centerCandidate in Dots)
            {
                var different = GetDotsInstance(bestCenter, centerCandidate.TopLeft);
                if (!(different < minDifferent)) continue;
                minDifferent = different;
                minDifferentPoint = centerCandidate.TopLeft;
            }

            return minDifferentPoint;
        }

        private static double GetDotsInstance(Point firstDot, Point secondDot)
        {
            var xDifferent = firstDot.X - secondDot.X;
            var yDifferent = firstDot.Y - secondDot.Y;
            return Math.Sqrt(xDifferent * xDifferent + yDifferent * yDifferent);
        }
    }
}
