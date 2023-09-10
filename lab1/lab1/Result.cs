namespace lab1
{
    public partial class Result : Form
    {
        public Graphics graphics;
        private readonly MainForm mainForm;

        public Result(MainForm mainForm)
        {
            InitializeComponent();
            graphics = CreateGraphics();
            this.mainForm = mainForm;
        }

        public void Result_Paint(object sender, PaintEventArgs e)
        {
            foreach (var cluster in mainForm.clusters)
            {
                cluster.Draw(graphics);
                cluster.DrawCenter(graphics);
            }
        }
    }
}
