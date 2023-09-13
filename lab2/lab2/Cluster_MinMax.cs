using lab1;

namespace lab2
{
    public class Cluster_MinMax : Cluster
    {
        public Cluster_MinMax(Color color, int x, int y) : base(color, x, y)
        {
        }

        /// <summary>
        /// Creates a new cluster from the point farthest from the center of the current cluster
        /// </summary>
        /// <param name="bound">Minimal valid distance</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Cluster CreateNewCluster(int bound)
        {
            throw new NotImplementedException();
        }
    }
}
