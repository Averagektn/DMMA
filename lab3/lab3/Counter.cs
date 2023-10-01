namespace lab3
{
    /// <summary>
    ///     Counts <see cref="FALSE_ALARM"/>, <see cref="DETECTION_PASS"/> and <see cref="SUM"/>
    /// </summary>
    public static class Counter
    {
        /// <summary>
        ///     False alarm value
        /// </summary>
        public static readonly int FALSE_ALARM = 0;

        /// <summary>
        ///     Detection pass value
        /// </summary>
        public static readonly int DETECTION_PASS = 1;

        /// <summary>
        ///     <see cref="FALSE_ALARM"/> + <see cref="DETECTION_PASS"/>
        /// </summary>
        public static readonly int SUM = 2;

        /// <summary>
        ///     X coordinate of graphs crossing
        /// </summary>
        private static int _crossingPoint;

        /// <summary>
        ///     Counts <see cref="FALSE_ALARM"/>, <see cref="DETECTION_PASS"/> and <see cref="SUM"/>
        /// </summary>
        /// <param name="crossingPoint">
        ///     X coordinate of graphs crossing
        /// </param>
        /// <param name="density_1">
        ///     First sample density
        /// </param>
        /// <param name="density_2">
        ///     Second sample density
        /// </param>
        /// <param name="probability">
        ///     Probability of value to be a part of first sample
        /// </param>
        /// <returns>
        ///     Array of false alarm, detections pass and their sum<br/> 
        ///     Keys:<br/>
        ///     * False alarm: <see cref="FALSE_ALARM"/><br/>
        ///     * Detection pass: <see cref="DETECTION_PASS"/><br/>
        ///     * Their sum: <see cref="SUM"/><br/>
        /// </returns>
        public static double[] Count(int crossingPoint, double[] density_1, double[] density_2, double probability)
        {
            double[] result = new double[3];

            _crossingPoint = crossingPoint;

            result[FALSE_ALARM] = Count_FalseAlarm(density_2);
            result[DETECTION_PASS] = Count_DetectionPass(density_1, density_2, probability);
            result[SUM] = result[FALSE_ALARM] + result[DETECTION_PASS];
  
            return result;
        }

        /// <summary>
        ///     Counts false alarm as sum of densities of the second sample from 0 to the <see cref="_crossingPoint"/>
        /// </summary>
        /// <param name="density_2">
        ///     Density of the second sample
        /// </param>
        /// <returns>
        ///     False alarm value
        /// </returns>
        private static double Count_FalseAlarm(double[] density_2) => density_2.Take(_crossingPoint).Sum();

        /// <summary>
        ///     Counts detection pass as sum of densities of the first sample from <see cref="_crossingPoint"/> + 1 
        ///     to the end of the sample
        /// /// </summary>
        /// <param name="density_1">
        ///     Density of the first sample
        /// </param>
        /// <param name="density_2">
        ///     Density of the second sample
        /// </param>
        /// <param name="probability">
        ///     Probability of value to be a part of first sample
        /// </param>
        /// <returns>
        ///     Detection pass value
        /// </returns>
        private static double Count_DetectionPass(double[] density_1, double[] density_2, double probability)
            => probability > 0.5 ? density_2.Skip(_crossingPoint).Sum() : density_1.Skip(_crossingPoint).Sum();

    }
}
