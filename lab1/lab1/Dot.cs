namespace lab1
{
    public sealed class Dot
    {
        public const int WIDTH = 8;
        public const int HEIGHT = 8;
        public Point TopLeft { get; private set; }

        private Pen pen;
        private Brush brush { get => new SolidBrush(pen.Color);}
        
        public Dot(Color color, int x, int y)
        {
            TopLeft = new Point(x, y);
            pen = new Pen(color, 1);
        }

        public void Draw(Graphics g)
        {
            g.DrawEllipse(pen, TopLeft.X, TopLeft.Y, WIDTH, HEIGHT);
            g.FillEllipse(brush, TopLeft.X, TopLeft.Y, WIDTH, HEIGHT);
        }

        /// <summary>
        /// Finds the closest cluster
        /// </summary>
        /// <param name="clusters"></param>
        public void FindCluster(List<Cluster_KAverage> clusters)
        {
            int ind = 0;
            int minDistance = CountDistance(TopLeft, clusters[ind].Center);
            for (int i = 1; i < clusters.Count; i++)
            {
                int currentDistance = CountDistance(TopLeft, clusters[i].Center);
                if (minDistance > currentDistance)
                {
                    minDistance = currentDistance;
                    ind = i;
                }
            }

            pen.Color = clusters[ind].Color; 
            
            clusters[ind].Dots.Add(this);
        }

        /// <summary>
        /// Counts distance between two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static int CountDistance(Point p1, Point p2)
        {
            var a = Math.Pow((p1.X - p2.X + WIDTH / 2), 2);
            var b = Math.Pow((p1.Y - p2.Y + HEIGHT / 2), 2);
            int res = (int)Math.Sqrt(a + b);
            return res;
        }
    }
}
