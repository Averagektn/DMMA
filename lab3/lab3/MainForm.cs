namespace lab3
{
    public partial class MainForm : Form
    {
        private const int POINTS_NUM = 50000;
        private const double PROBABILITY = 0.65;

        public MainForm()
        {
            InitializeComponent();

            var classificator = new Classificator(POINTS_NUM, PROBABILITY, Chart.Width,
                new Range(100, 700), new Range(300, 900));

            var drawer = new GraphDrawer(Chart, POINTS_NUM);
            drawer.Draw("Class 1", classificator.Density_1);
            drawer.Draw("Class 2", classificator.Density_2);

            drawer.Draw("Crossing", classificator.CrossingX, classificator.MaxY);
        }
    }
}
