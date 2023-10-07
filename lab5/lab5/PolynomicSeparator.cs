namespace lab5
{
    /// <summary>
    ///     Divides points in two classes
    /// </summary>
    public static class PolynomicSeparator
    {
        /// <summary>
        ///     First class
        /// </summary>
        public static List<Point>? Class_1 { get; private set; }

        /// <summary>
        ///     Second class
        /// </summary>
        public static List<Point>? Class_2 { get; private set; }

        /// <summary>
        ///     Separates points in two classes.<br/> 
        ///     After call you gen get classes from <see cref="Class_1"/> and <see cref="Class_2"/><br/>
        /// </summary>
        /// <param name="points">
        ///     List of point to separate
        /// </param>
        /// <param name="polynom">
        ///     Separating polynom
        /// </param>
        public static void Separate(List<PointF> points, List<int> polynom)
        {
            Class_1 = new();
            Class_2 = new();
            Class_1.Clear();
            Class_2.Clear();

            for (int i = 0; i < points.Count; i++)
            {
                if (Get_SeparatingFuncValue(points[i], polynom) >= 0)
                {
                    Class_1.Add(new((int)(points[i].X * 100), (int)(points[i].Y * 100)));
                }
                else
                {
                    Class_2.Add(new((int)(points[i].X * 100), (int)(points[i].Y * 100)));
                }
            }
        }

        /// <summary>
        ///     Gets value of point from separating function
        /// </summary>
        /// <param name="point">
        ///     Point to count
        /// </param>
        /// <param name="polynom">
        ///     Separating polynom
        /// </param>
        /// <returns>
        ///     If positive, add to first class, else add to the second class
        /// </returns>
        private static double Get_SeparatingFuncValue(PointF point, List<int> polynom) =>
            polynom[0] +
            polynom[1] * point.X +
            polynom[2] * point.Y +
            polynom[3] * point.X * point.Y;

    }

}
