namespace lab5
{
    /// <summary>
    /// 
    /// </summary>
    public static class PointGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Random Random = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="leftBorderX"></param>
        /// <param name="rightBorderX"></param>
        /// <param name="leftBorderY"></param>
        /// <param name="rightBorderY"></param>
        /// <returns></returns>
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
