namespace lab1
{
    /// <summary>
    /// Form to draw results
    /// </summary>
    public partial class Result : Form
    {
        /// <summary>
        /// Draws dots and clusters centers
        /// </summary>
        public Graphics graphics;

        /// <summary>
        /// Initial form
        /// </summary>
        private readonly MainForm mainForm;

        /// <summary>
        /// Creates child's form
        /// </summary>
        /// <param name="mainForm">Parent</param>
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
