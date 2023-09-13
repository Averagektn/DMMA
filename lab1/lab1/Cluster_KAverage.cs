using System.Drawing;

namespace lab1
{
    public class Cluster_KAverage : Cluster
    {
        public Cluster_KAverage(Color color, int x, int y) : base(color, x, y)
        {
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
        protected static double GetDotsDistance(Point firstDot, Point secondDot)
        {
            var xDifferent = firstDot.X - secondDot.X;
            var yDifferent = firstDot.Y - secondDot.Y;
            return Math.Sqrt(xDifferent * xDifferent + yDifferent * yDifferent);
        }
    }
}
