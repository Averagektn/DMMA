namespace lab3
{
    public partial class MainForm : Form
    {
        private double Probability 
        { 
            get => (double)tbProbability.Value / 100;
        }

        private const string LBL_FALSE_ALARM_TEXT = "False alarm: ";
        private const string LBL_DETECTION_PASS_TEXT = "Detection pass:";
        private const string LBL_SUM_TEXT = "Sum: ";

        private const int POINTS_NUM = 50000;
        private const double INITIAL_PROBABILITY = 0.5;

        public MainForm()
        {
            InitializeComponent();

            var result = Calculate(INITIAL_PROBABILITY);

            tbProbability.Value = (int)(INITIAL_PROBABILITY * 100);
            UpdateLabels(result);
        }

        private Classificator Calculate(double probability)
        {
            var classificator = new Classificator(POINTS_NUM, probability, Chart.Width,
                new Range(100, 700), new Range(300, 900));
            var drawer = new GraphDrawer(Chart, POINTS_NUM);

            drawer.Draw("Distribution 1", classificator.Density_1);
            drawer.Draw("Distribution 2", classificator.Density_2);
            drawer.Draw("Crossing", classificator.CrossingX, classificator.MaxY);

            return classificator;
        }

        private void UpdateLabels(Classificator calculations)
        {
            double[] stats = Counter.Count(calculations.CrossingX, calculations.Density_1, 
                calculations.Density_2, Probability);

            lblFalseAlarm.Text = LBL_FALSE_ALARM_TEXT + stats[Counter.FALSE_ALARM] + "%";
            lblDetectionPass.Text = LBL_DETECTION_PASS_TEXT + stats[Counter.DETECTION_PASS] + "%";
            lblSum.Text = LBL_SUM_TEXT + stats[Counter.SUM] + "%";
            lblProbabilityPercentage.Text = tbProbability.Value.ToString() + "%";
        }

        private void On_tbProbability_Scroll(object sender, EventArgs e)
        {
            var result = Calculate(Probability);

            UpdateLabels(result);
        }

    }
}
