using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace lab3
{
    public class GraphDrawer
    {
        protected Chart Chart { get; }

        protected const int X = 0;
        protected const int Y = 1;

        private int _incorrectValuesNum;

        private const double INCORRECT_PERCENTAGE = 0.002;

        public GraphDrawer(Chart chart, int pointsNum)
        {
            _incorrectValuesNum = (int)(pointsNum * INCORRECT_PERCENTAGE);

            Chart = chart;
            Chart.ChartAreas.Add(new ChartArea("Name"));
        }

        public void Draw(string name, double[] points)
        {
            Chart.Dock = DockStyle.Fill;

            var seriesOfPoints = new Series(name)
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "Name"
            };

            for (int x = 100; x < points.Length; x++)
            {
                seriesOfPoints.Points.AddXY(x, points[x]);
            }

            Chart.ChartAreas[^1].Axes[X].Enabled = AxisEnabled.False;
            Chart.ChartAreas[^1].Axes[Y].Enabled = AxisEnabled.False;
            Chart.Legends.Add(name);

            Chart.Series.Add(seriesOfPoints);
        }
    }
}
