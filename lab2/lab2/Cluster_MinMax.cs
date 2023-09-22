namespace lab2
{
    public class Cluster_MinMax : Cluster
    {
        public Cluster_MinMax(Color color, int x, int y) : base(color, x, y)
        {
        }

        public Cluster_MinMax(Color color, List<Dot> dots, Point center) : base(color, dots, center)
        { 
        }

        /// <summary>
        /// Creates a new cluster from the point farthest from the center of the current cluster
        /// </summary>
        /// <param name="bound">Minimal valid distance</param>
        /// <returns><see langword="null"/> if new cluster not found, otherwise new <see cref="Cluster_MinMax"/></returns>
        public Cluster_MinMax? CreateNewCluster(int bound)
        {
            int max = -1;
            var random = new Random();
            var randomColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            var newCluster = new Cluster_MinMax(randomColor, 0, 0);
            int distance = 0;

            foreach(var dot in Dots)
            {
                distance = (int)GetDotsDistance(dot.TopLeft, Center);
                if (distance > max && distance > bound)
                {
                    max = distance;
                    newCluster.Center = dot.TopLeft;
                }
            }

            if (max <= bound)
            {
                newCluster = null;
            }

            return newCluster;
        }
    }
}
