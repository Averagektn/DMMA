namespace lab5
{

    public static class PointGenerator
    {

        private static readonly Random Random = new();

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
