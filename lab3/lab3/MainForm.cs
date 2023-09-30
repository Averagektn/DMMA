namespace lab3
{
    public partial class MainForm : Form
    {
        private const string LBL_FALSE_ALARM_TEXT = "False alarm: ";
        private const string LBL_DETECTION_PASS_TEXT = "Detection pass:";
        private const string LBL_SUM_TEXT = "Sum: ";

        private const int POINTS_NUM = 50000;
        private const double PROBABILITY = 0.65;

        GraphDrawer drawer;

        public MainForm()
        {
            InitializeComponent();
            drawer = new GraphDrawer(Chart, POINTS_NUM);

            Calculate();
        }

        private void Calculate()
        {
            var classificator = new Classificator(POINTS_NUM, PROBABILITY, Chart.Width,
                new Range(100, 700), new Range(300, 900));

            drawer.Draw("Class 1", classificator.Density_1);
            drawer.Draw("Class 2", classificator.Density_2);

            drawer.Draw("Crossing", classificator.CrossingX, classificator.MaxY);
        }

        private void UpdateLabels()
        {
            lblFalseAlarm.Text = LBL_FALSE_ALARM_TEXT + "%";
            lblDetectionPass.Text = LBL_DETECTION_PASS_TEXT + "%";
            lblSum.Text = LBL_SUM_TEXT + "%";
        }

    }
}
