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

        /// <summary>
        /// Paints resulting form and saves it in .bmp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Result_Paint(object sender, PaintEventArgs e)
        {
            foreach (var cluster in mainForm.clusters)
            {
                cluster.Draw(graphics);
                cluster.DrawCenter(graphics);
            }

            var screenRC = RectangleToScreen(new Rectangle(0, 0, Width, Height));
            var bmp = new Bitmap(screenRC.Width - 20, screenRC.Height - 20);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(screenRC.Left, screenRC.Top, 0, 0, bmp.Size);
            }
            bmp.Save("Final.bmp");
        }
    }
}
