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
        public List<Cluster> clusters = new();

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

            clusters.Add(new Cluster(Color.Red, random.Next(Width - 20), random.Next(Height - 20)));
            clusters.Add(new Cluster(Color.Green, random.Next(Width - 20), random.Next(Height - 20)));
            clusters.Add(new Cluster(Color.Blue, random.Next(Width - 20), random.Next(Height - 20)));
            clusters.Add(new Cluster(Color.Yellow, random.Next(Width - 20), random.Next(Height - 20)));
            clusters.Add(new Cluster(Color.Black, random.Next(Width - 20), random.Next(Height - 20)));
            clusters.Add(new Cluster(Color.Purple, random.Next(Width - 20), random.Next(Height - 20)));
            clusters.Add(new Cluster(Color.Brown, random.Next(Width - 20), random.Next(Height - 20)));

            foreach(var cluster in clusters)
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
        /// Draws the intial state of the clusters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            bool isCounting = true;
            foreach (var cluster in clusters)
            {
                cluster.Draw(graphics);
                cluster.DrawCenter(graphics);
            }

            while(isCounting)
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

                for(int i = 0; i < clusters.Count; i++)
                {
                    if (!IsSamePoint(clusters[i].Center, prevCenters[i]))
                    {
                        isCounting = true;
                    }
                }
            }

            var resultForm = new Result(this);
            resultForm.Show();
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
            return !(Math.Abs(p1.X - p2.X) <= 5 && Math.Abs(p1.Y - p2.Y) <= 5);
        }
    }
}