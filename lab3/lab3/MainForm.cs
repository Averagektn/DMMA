namespace lab3
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Current probabiltity in range of 0.01 to 0.97
        /// </summary>
        private double Probability 
        { 
            get => (double)tbProbability.Value / 100;
        }

        /// <summary>
        /// Label text templates
        /// </summary>
        private const string LBL_FALSE_ALARM_TEXT = "False alarm: ";
        private const string LBL_DETECTION_PASS_TEXT = "Detection pass: ";
        private const string LBL_SUM_TEXT = "Sum: ";

        /// <summary>
        /// Initial points number
        /// </summary>
        private const int POINTS_NUM = 50000;

        /// <summary>
        /// Initial probability
        /// </summary>
        private const double INITIAL_PROBABILITY = 0.5;

        public MainForm()
        {
            InitializeComponent();

            var result = Calculate(INITIAL_PROBABILITY);

            tbProbability.Value = (int)(INITIAL_PROBABILITY * 100);
            UpdateLabels(result);
        }

        /// <summary>
        /// Calculates distribution density with given probability
        /// </summary>
        /// <param name="probability">Probability of a number being in the desired sample</param>
        /// <returns>
        ///     <see cref="Classificator"/> as container of information about: <br/>
        ///     * Densities <see cref="Classificator.Density_1"/>> and <see cref="Classificator.Density_2"/><br/>
        ///     * Crossing X coordinate <see cref="Classificator.CrossX"/><br/>
        /// </returns>
        private Classificator Calculate(double probability)
        {
            var classificator = new Classificator(POINTS_NUM, probability, Chart.Width,
                new Range(100, 700), new Range(300, 900));
            var drawer = new GraphDrawer(Chart, POINTS_NUM);

            drawer.Draw("Distribution 1", classificator.Density_1);
            drawer.Draw("Distribution 2", classificator.Density_2);
            drawer.Draw("Crossing", classificator.CrossX, classificator.MaxY);

            return classificator;
        }

        /// <summary>
        ///     Counts false alarm, detection pass and their sum
        ///     Updates labels:<br/>
        ///     * <see cref="lblFalseAlarm"/><br/> 
        ///     * <see cref="lblDetectionPass"/><br/>
        ///     * <see cref="lblSum"/><br/>
        ///     * <see cref="lblProbabilityPercentage"/><br/>
        /// </summary>
        /// <param name="calculations">
        ///     Densities from <see cref="Classificator.Density_1"/>, <see cref="Classificator.Density_2"> 
        ///     and crossing coordinate from <see cref="Classificator.CrossX"/>
        /// </param>
        private void UpdateLabels(Classificator calculations)
        {
            double[] stats = Counter.Count(calculations.CrossX, calculations.Density_1, 
                calculations.Density_2, Probability);

            lblFalseAlarm.Text = LBL_FALSE_ALARM_TEXT + Math.Round(stats[Counter.FALSE_ALARM] * 100) + "%";
            lblDetectionPass.Text = LBL_DETECTION_PASS_TEXT + Math.Round(stats[Counter.DETECTION_PASS] * 100) + "%";
            lblSum.Text = LBL_SUM_TEXT + Math.Round(stats[Counter.SUM] * 100) + "%";
            lblProbabilityPercentage.Text = tbProbability.Value.ToString() + "%";
        }

        private void On_tbProbability_Scroll(object sender, EventArgs e)
        {
            var result = Calculate(Probability);

            UpdateLabels(result);
        }

    }
}
