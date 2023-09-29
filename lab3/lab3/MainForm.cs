using System.Windows.Forms.DataVisualization.Charting;

namespace lab3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //������� ������� Chart
            Chart myChart = new Chart();
            //������ ��� �� ����� � ����������� �� ��� ����.
            myChart.Parent = this;
            myChart.Dock = DockStyle.Fill;
            //��������� � Chart ������� ��� ��������� ��������, �� ����� ����
            //�����, ������� ���� �� ���.
            myChart.ChartAreas.Add(new ChartArea("Lab 3"));
            //������� � ����������� ����� ����� ��� ��������� �������, � ���
            //�� ����� ������� ��� ������� �� ������� ����� ���������� ����
            //����� �����.
            Series mySeriesOfPoint = new Series("Sinus");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Lab 3";
            for (double x = -Math.PI; x <= Math.PI; x += Math.PI / 10.0)
            {
                mySeriesOfPoint.Points.AddXY(x, Math.Sin(x));
            }
            //��������� ��������� ����� ����� � Chart
            myChart.Series.Add(mySeriesOfPoint);
        }
    }
}
