namespace lab5
{
    /// <summary>
    /// 
    /// </summary>
    public static class PolynomicSeparator
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<Point>? Class_1 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public static List<Point>? Class_2 { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="polynom"></param>
        public static void Separate(List<Point> points, List<int> polynom)
        {
            Class_1 = new();
            Class_2 = new();
            Class_1.Clear();
            Class_2.Clear();

            for (int i = 0; i < points.Count; i++)
            {
                if (Get_SeparatingFuncValue(points[i], polynom) >= 0)
                {
                    Class_1.Add(points[i]);
                }
                else
                {
                    Class_2.Add(points[i]);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="polynom"></param>
        /// <returns></returns>
        private static int Get_SeparatingFuncValue(Point point, List<int> polynom) =>
            polynom[0] +
            polynom[1] * point.X +
            polynom[2] * point.Y +
            polynom[3] * point.X * point.Y;

    }

}
