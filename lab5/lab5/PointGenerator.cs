namespace lab5
{
    /// <summary>
    ///     Generates rndomized points
    /// </summary>
    public static class PointGenerator
    {
        /// <summary>
        ///     Randomizator
        /// </summary>
        private static readonly Random Random = new();

        /// <summary>
        ///     Creates new point list
        /// </summary>
        /// <param name="size">
        ///     Size of list
        /// </param>
        /// <param name="leftBorderX">
        ///     X minimal coordinate
        /// </param>
        /// <param name="rightBorderX">
        ///     X maximal coordinate
        /// </param>
        /// <param name="leftBorderY">
        ///     Y minimal coordinate
        /// </param>
        /// <param name="rightBorderY">
        ///     Y maximal coordinate
        /// </param>
        /// <returns>
        ///     Randomly generated points
        /// </returns>
        public static List<Point> Get_NewPointList(int size, int leftBorderX, int rightBorderX, 
            int leftBorderY, int rightBorderY)
        {
            var points = new List<Point>();

            for (int i = 0; i < size; i++)
            {
                points.Add(new Point(Random.Next(leftBorderX, rightBorderX), Random.Next(leftBorderY, rightBorderY)));
            }

            return points;
        }

    }

}
