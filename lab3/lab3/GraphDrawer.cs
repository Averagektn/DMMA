using System.Windows.Forms.DataVisualization.Charting;

namespace lab3
{

    /// <summary>
    /// Draws graphs using <see cref="System.Windows.Forms.DataVisualization.Charting.Chart"/>
    /// </summary>
    public sealed class GraphDrawer
    {
        /// <summary>
        ///     Chart to draw on
        /// </summary>
        private readonly Chart Chart;

        /// <summary>
        ///     Coordinates
        /// </summary>
        private const int X = 0;
        private const int Y = 1;

        /// <summary>
        ///     Skipping the first values to smooth the graph
        /// </summary>
        private readonly int _incorrectValuesNum;

        /// <summary>
        ///     Name template
        /// </summary> 
        private const string CHART_AREA_NAME = "Lab 3";

        /// <summary>
        ///     Counts <see cref="_incorrectValuesNum"/>
        /// </summary>
        private const double INCORRECT_PERCENTAGE = 0.001;

        /// <summary>
        ///     Reset
        /// </summary>
        /// <param name="chart">
        ///     Chart to draw on
        /// </param>
        /// <param name="pointsNum">
        ///     Sample size
        /// </param>
        public GraphDrawer(Chart chart, int pointsNum)
        {
            _incorrectValuesNum = (int)(pointsNum * INCORRECT_PERCENTAGE);

            Chart = chart;
            Chart.Dock = DockStyle.Left;
            Chart.ChartAreas.Clear();
            Chart.Series.Clear();
            Chart.Legends.Clear();
            Chart.ChartAreas.Add(new ChartArea(CHART_AREA_NAME));
        }

        /// <summary>
        ///     Draws new graph
        /// </summary>
        /// <param name="name">
        ///     Line name
        /// </param>
        /// <param name="points">
        ///     Points on graph, where <see cref="X"/> is index and <see cref="Y"/> is value
        /// </param>
        public void Draw(string name, double[] points)
        {
            var seriesOfPoints = new Series(name)
            {
                ChartType = SeriesChartType.Line,
                ChartArea = CHART_AREA_NAME
            };

            for (int x = _incorrectValuesNum; x < points.Length; x++)
            {
                seriesOfPoints.Points.AddXY(x, points[x]);
            }

            //Chart.ChartAreas[^1].Axes[X].Enabled = AxisEnabled.False;
            //Chart.ChartAreas[^1].Axes[Y].Enabled = AxisEnabled.False;
            Chart.Legends.Add(name);

            Chart.Series.Add(seriesOfPoints);
        }

        /// <summary>
        ///     Draws vertical line through graph crossing point (X, 0)
        /// </summary>
        /// <param name="name">
        ///     Line name
        /// </param>>
        /// <param name="crossingX">
        ///     X coordinate, where one graph crosses another
        /// </param>
        /// <param name="maxY">
        ///     Height of <see cref="Chart"/>
        /// </param>
        public void Draw(string name, int crossingX, double maxY)
        {
            var seriesOfPoints = new Series(name)
            {
                ChartType = SeriesChartType.Candlestick,
                ChartArea = CHART_AREA_NAME
            };

            seriesOfPoints.Points.AddXY(crossingX, 0);
            seriesOfPoints.Points.AddXY(crossingX, maxY);
            
            //Chart.ChartAreas[^1].Axes[X].Enabled = AxisEnabled.False;
            //Chart.ChartAreas[^1].Axes[Y].Enabled = AxisEnabled.False;
            Chart.Legends.Add(name);

            Chart.Series.Add(seriesOfPoints);
        }
    }
}
