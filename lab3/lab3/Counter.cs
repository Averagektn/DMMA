namespace lab3
{
    public static class Counter
    {
        public static readonly int FALSE_ALARM = 0;
        public static readonly int DETECTION_PASS = 1;
        public static readonly int SUM = 2;

        private static int _crossingPoint;

        public static double[] Count(int crossingPoint, double[] density_1, double[] density_2, double probability)
        {
            double[] result = new double[3];

            _crossingPoint = crossingPoint;

            result[FALSE_ALARM] = Count_FalseAlarm(density_2);
            result[DETECTION_PASS] = Count_DetectionPass(density_1, density_2, probability);
            result[SUM] = result[FALSE_ALARM] + result[DETECTION_PASS];
  
            return result;
        }

        private static double Count_FalseAlarm(double[] density_2) => density_2.Take(_crossingPoint).Sum();

        private static double Count_DetectionPass(double[] density_1, double[] density_2, double probability)
            => probability > 0.5 ? density_2.Skip(_crossingPoint).Sum() : density_1.Skip(_crossingPoint).Sum();

    }
}
