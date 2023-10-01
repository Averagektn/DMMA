namespace lab3
{
    /// <summary>
    ///     Generates points from two samples with given ranges<br/> 
    ///     Counts their density<br/>
    ///     Finds their crossing coordinate<br/>
    /// </summary>
    public sealed class Classificator
    {
        /// <summary>
        ///     X coordinate of graphs cross
        /// </summary>
        public int CrossX { get; private set; }

        /// <summary>
        ///     Maximum value of both densities
        /// </summary>
        public double MaxY 
        { 
            get
            {
                var max_1 = Density_1.Max();
                var max_2 = Density_2.Max();

                return max_1 > max_2 ? max_1 : max_2;
            }
        }

        /// <summary>
        ///     Density of sample
        /// </summary>
        public readonly double[] Density_1;
        public readonly double[] Density_2;

        /// <summary>
        ///     Number of points to be generated
        /// </summary>
        public readonly int PointsNum;

        /// <summary>
        ///     Width of provided chart, number of X coordinates
        /// </summary>
        public readonly int ChartWidth;

        /// <summary>
        ///     Probability of value to be in given sample
        /// </summary>
        public readonly double Probability_1;
        public readonly double Probability_2;

        /// <summary>
        ///     Sample generation
        /// </summary>
        private readonly Random _random = new();

        /// <summary>
        ///     Ranges of possible sample values
        /// </summary>
        private Range _range_1;
        private Range _range_2;

        /// <summary>
        ///     Mathematical expectation
        /// </summary>
        private double _MathExp_1;
        private double _MathExp_2;

        /// <summary>
        ///     Stndart deviation
        /// </summary>
        private double _StandartDeviation_1;
        private double _StandartDeviation_2;

        /// <summary>
        ///     Sequence of numbers, sample
        /// </summary>
        private readonly int[] _sequence_1;
        private readonly int[] _sequence_2;

        /// <summary>
        ///     Makes approximately equal numbers equal
        /// </summary>
        private const double CMP_DIFF = 0.00002;

        public Classificator(int sequenceLength, double probability, int chartWidth, Range range_1, Range range_2) 
        {
            ChartWidth = chartWidth;
            PointsNum = sequenceLength;

            _range_1 = range_1;
            _range_2 = range_2;

            _sequence_1 = new int[PointsNum];
            _sequence_2 = new int[PointsNum];
            GenerateSequence();

            Probability_1 = probability;
            Probability_2 = 1 - probability;

            Density_1 = new double[chartWidth];
            Density_2 = new double[chartWidth];
           
            Count_DistributionDensity();
        }

        /// <summary>
        ///     Sample generation
        /// </summary>
        private void GenerateSequence()
        {
            for (int i = 0; i < PointsNum; i++)
            {
                _sequence_1[i] = _random.Next(_range_1.LeftBorder, _range_1.RightBorder);
                _sequence_2[i] = _random.Next(_range_2.LeftBorder, _range_2.RightBorder);
            }
        }

        /// <summary>
        ///     Mathematical expectation of samples
        /// </summary>
        private void Count_MathExpectation()
        {
            _MathExp_1 = _sequence_1.Sum() / PointsNum;
            _MathExp_2 = _sequence_2.Sum() / PointsNum;
        }

        /// <summary>
        ///     Standart deviation of samples
        /// </summary>
        private void Count_StandardDeviation()
        {
            double numerator_1 = 0;
            double numerator_2 = 0;

            for (int i = 0; i < PointsNum; i++)
            {
                numerator_1 += Math.Pow(_sequence_1[i] - _MathExp_1, 2);
                numerator_2 += Math.Pow(_sequence_2[i] - _MathExp_2, 2);
            }

            _StandartDeviation_1 = Math.Sqrt(numerator_1 / PointsNum);
            _StandartDeviation_2 = Math.Sqrt(numerator_2 / PointsNum);
        }

        /// <summary>
        ///     Distribution density of samples
        /// </summary>
        private void Count_DistributionDensity()
        {
            Count_MathExpectation();
            Count_StandardDeviation(); 

            for (int x = 0; x < ChartWidth; x++)
            {
                Density_1[x] = Probability_1 * 
                    Math.Exp(-0.5 * Math.Pow((x - _MathExp_1) / _StandartDeviation_1, 2)) / 
                    (_StandartDeviation_1 * Math.Sqrt(2 * Math.PI));

                Density_2[x] = Probability_2 *
                    Math.Exp(-0.5 * Math.Pow((x - _MathExp_2) / _StandartDeviation_2, 2)) /
                    (_StandartDeviation_2 * Math.Sqrt(2 * Math.PI));

                if (Math.Abs(Density_1[x] - Density_2[x]) <= CMP_DIFF)
                {
                    CrossX = x;
                }
            }
        }

    }

    /// <summary>
    ///     Number range
    /// </summary>
    public struct Range
    {
        /// <summary>
        ///     Minimal value
        /// </summary>
        public int LeftBorder;

        /// <summary>
        ///     Maximal value
        /// </summary>
        public int RightBorder;

        public Range(int leftBorder, int rightBorder) 
        { 
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
        }

    }
}
