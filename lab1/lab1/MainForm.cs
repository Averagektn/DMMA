using System.Drawing.Text;

namespace lab1
{
    /// <summary>
    /// Form to draw starting clusters
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// All created clusters of different colors with dots
        /// </summary>
        public List<Cluster_KAverage> clusters = new();

        /// <summary>
        /// Draws dots and clusters centers
        /// </summary>
        private readonly Graphics graphics;

        /// <summary>
        /// All created dots
        /// </summary>
        private readonly List<Dot> dots;

        /// <summary>
        /// Generates random numbers
        /// </summary>
        private readonly Random random = new();

        /// <summary>
        /// Cluster center on the previous step
        /// </summary>
        private readonly List<Point> prevCenters = new();

        public MainForm()
        {
            InitializeComponent();

            clusters.Add(new Cluster_KAverage(Color.Red,    random.Next(Width - 60), random.Next(Height - 60)));
            clusters.Add(new Cluster_KAverage(Color.Green,  random.Next(Width - 60), random.Next(Height - 60)));
            clusters.Add(new Cluster_KAverage(Color.Blue,   random.Next(Width - 60), random.Next(Height - 60)));
            clusters.Add(new Cluster_KAverage(Color.Yellow, random.Next(Width - 60), random.Next(Height - 60)));
            clusters.Add(new Cluster_KAverage(Color.Black,  random.Next(Width - 60), random.Next(Height - 60)));
            clusters.Add(new Cluster_KAverage(Color.Purple, random.Next(Width - 60), random.Next(Height - 60)));
            clusters.Add(new Cluster_KAverage(Color.Brown,  random.Next(Width - 60), random.Next(Height - 60)));

            foreach (var cluster in clusters)
            {
                prevCenters.Add(cluster.Center);
            }

            dots = new List<Dot>();
            GenerateDots(10000);
            graphics = CreateGraphics();
        }

        /// <summary>
        /// Initializes the <see cref="dots"/> list and finds their cluster
        /// </summary>
        /// <param name="num">Number of dots to be created</param>
        private void GenerateDots(int num)
        {
            var random = new Random();

            for (int i = 0; i < num; i++)
            {
                var dot = new Dot(Color.Black, random.Next(Size.Width), random.Next(Size.Height));
                dots.Add(dot);
                dots[i].FindCluster(clusters);
            }
        }

        /// <summary>
        /// Paints resulting form and saves it in .bmp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            bool isCounting = true;

            foreach (var cluster in clusters)
            {
                cluster.DrawDots(graphics);
                cluster.DrawCenter(graphics);
            }

            while (isCounting)
            {
                isCounting = false;

                for (int i = 0; i < clusters.Count; i++)
                {
                    clusters[i].Center = clusters[i].GetBestClusterCenter();
                    clusters[i].Dots.Clear();
                }

                for (int i = 0; i < dots.Count; i++)
                {
                    dots[i].FindCluster(clusters);
                }

                for (int i = 0; i < clusters.Count; i++)
                {
                    if (!IsSamePoint(clusters[i].Center, prevCenters[i]))
                    {
                        isCounting = true;
                    }
                }
            }

            var resultForm = new Result(this);
            resultForm.Show();

            var screenRC = RectangleToScreen(new Rectangle(0, 0, Width, Height));
            var bmp = new Bitmap(screenRC.Width - 20, screenRC.Height - 20);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(screenRC.Left, screenRC.Top, 0, 0, bmp.Size);
            }
            bmp.Save("Initial.bmp");
        }

        /// <summary>
        /// Checks if the point is the same
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns><see langword="true"/> if these points are almoust qeual, 
        /// <see langword="false"/> otherwise</returns>
        private bool IsSamePoint(Point p1, Point p2)
        {
            return !(Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1);
        }
    }
}