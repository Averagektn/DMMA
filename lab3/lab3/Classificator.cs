﻿namespace lab3
{
    public sealed class Classificator
    {
        public int PointsNum { get; }
        public double Probability_1 { get; }
        public double Probability_2 { get; }
        public int ChartWidth { get; }
        public double[] Density_1 { get; }
        public double[] Density_2 { get; }

        private readonly Random _random = new();

        private Range _range_1;
        private Range _range_2;

        private int[] _sequence_1;
        private int[] _sequence_2;

        private double _MathExp_1;
        private double _MathExp_2;

        private double _StandartDeviation_1;
        private double _StandartDeviation_2;

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

        private void GenerateSequence()
        {
            for (int i = 0; i < PointsNum; i++)
            {
                _sequence_1[i] = _random.Next(_range_1.LeftBorder, _range_1.RightBorder);
                _sequence_2[i] = _random.Next(_range_2.LeftBorder, _range_2.RightBorder);
            }
        }

        private void Count_MathExpectation()
        {
            _MathExp_1 = _sequence_1.Sum() / PointsNum;
            _MathExp_2 = _sequence_2.Sum() / PointsNum;
        }

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

        private void Count_DistributionDensity()
        {
            Count_MathExpectation();
            Count_StandardDeviation();

            for (int x = 0; x < ChartWidth; x++)
            {
                Density_1[x] = Probability_1 * 
                    Math.Exp(-0.5 * Math.Pow((x - _MathExp_1) / _StandartDeviation_1, 2)) / 
                    _StandartDeviation_1 * Math.Sqrt(2 * Math.PI);

                Density_2[x] = Probability_2 *
                    Math.Exp(-0.5 * Math.Pow((x - _MathExp_2) / _StandartDeviation_2, 2)) /
                    _StandartDeviation_2 * Math.Sqrt(2 * Math.PI);
            }
        }

    }

    public struct Range
    {
        public int LeftBorder;
        public int RightBorder;

        public Range(int leftBorder, int rightBorder) 
        { 
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
        }
    }
}
