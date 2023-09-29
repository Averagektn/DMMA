namespace lab3
{
    public sealed class Classificator
    {
        public int PointsNum { get; }
        public double Probability_1 { get; }
        public double Probability_2 { get; }

        private readonly Random_NormalDistribution _normalDistribution = new();

        private int[] _sequence_1;
        private int[] _sequence_2;

        private double _MX_1;
        private double _MX_2;

        private double _SD_1;
        private double _SD_2;

        public Classificator(int sequenceLength, double probability) 
        {
            PointsNum = sequenceLength;
            _sequence_1 = new int[PointsNum];
            _sequence_2 = new int[PointsNum];
            GenerateSequence();

            Probability_1 = probability;
            Probability_2 = 1 - probability;
        }

        public void Classify()
        {

        }

        private void GenerateSequence()
        {
            for (int i = 0; i < PointsNum; i++)
            {
                _sequence_1[i] = _normalDistribution.Next(100, 500);
                _sequence_2[i] = _normalDistribution.Next(300, 700);
            }
        }

        private void Count_MathExpectation()
        {
            _MX_1 = _sequence_1.Sum() / PointsNum;
            _MX_2 = _sequence_2.Sum() / PointsNum;
        }

        private void Count_StandardDeviation()
        {
            double numerator_1 = 0;
            double numerator_2 = 0;

            for (int i = 0; i < PointsNum; i++)
            {
                numerator_1 += Math.Pow(_sequence_1[i] - _MX_1, 2);
                numerator_2 += Math.Pow(_sequence_2[i] - _MX_2, 2);
            }

            _SD_1 = Math.Sqrt(numerator_1 / PointsNum);
            _SD_2 = Math.Sqrt(numerator_2 / PointsNum);
        }

        //private void Find
    }
}
