namespace lab1
{
    /// <summary>
    /// Form to draw starting clusters
    /// </summary>
    public partial class MainForm : Form
    {
        private int PictureHeight
        {
            get
            {
                return int.Parse(tbHeight.Text);
            }
        }

        private int PictureWidth
        {
            get
            {
                return int.Parse(tbWidth.Text);
            }
        }
        /// <summary>
        /// All created clusters of different colors with dots
        /// </summary>
        private readonly List<Cluster_KAverage> _clusters = new();

        private Graphics? _graphics;
        private Bitmap? _bitmap;

        /// <summary>
        /// All created dots
        /// </summary>
        private readonly List<Dot> _dots;

        /// <summary>
        /// Generates random numbers
        /// </summary>
        private readonly Random _random = new();

        /// <summary>
        /// Cluster center on the previous step
        /// </summary>
        private readonly List<Point> _prevCenters = new();

        public MainForm()
        {
            InitializeComponent();

            DeletePrevFiles(@"Initial*");
            DeletePrevFiles(@"Final*");

            _dots = new List<Dot>();
        }

        /// <summary>
        /// Deletes previous pictures
        /// </summary>
        private static void DeletePrevFiles(string deletingPattern)
        {
            string[] fileList = Directory.GetFiles(Directory.GetCurrentDirectory(), deletingPattern);
            foreach (string file in fileList)
            {
                File.Delete(file);
            }
        }

        /// <summary>
        /// Paints resulting form and saves it in .bmp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessClusters()
        {
            bool isCounting = true;

            SaveToBMP("Initial");

            while (isCounting)
            {
                isCounting = false;

                for (int i = 0; i < _clusters.Count; i++)
                {
                    _clusters[i].Center = _clusters[i].GetBestClusterCenter();
                    _clusters[i].Dots.Clear();
                }

                for (int i = 0; i < _dots.Count; i++)
                {
                    _dots[i].FindCluster(_clusters);
                }

                for (int i = 0; i < _clusters.Count; i++)
                {
                    if (!IsSamePoint(_clusters[i].Center, _prevCenters[i]))
                    {
                        isCounting = true;
                    }
                }
            }

            SaveToBMP("Final");
        }

        private void SaveToBMP(string filename)
        {
            foreach (var cluster in _clusters)
            {
                cluster.DrawDots(_graphics!);
                cluster.DrawCenter(_graphics!);
            }
            _bitmap?.Save(filename + ".bmp");
            _graphics?.Clear(Color.White);
        }

        /// <summary>
        /// Initializes the <see cref="_dots"/> list and finds their cluster
        /// </summary>
        /// <param name="num">Number of dots to be created</param>
        private void GenerateDots(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var dot = new Dot(Color.Black, _random.Next(PictureWidth), _random.Next(PictureHeight));
                _dots.Add(dot);
                _dots[i].FindCluster(_clusters);
            }
        }

        /// <summary>
        /// Checks if the point is the same
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns><see langword="true"/> if these points are almoust qeual, 
        /// <see langword="false"/> otherwise</returns>
        private static bool IsSamePoint(Point p1, Point p2)
        {
            return !(Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1);
        }

        private void sbDotsNum_Scroll(object sender, ScrollEventArgs e)
        {
            lblDotsTotal.Text = sbDotsNum.Value.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _bitmap = new Bitmap(PictureWidth, PictureHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);

            for (int i = 0; i < numClustersNum.Value; i++)
            {
                _clusters.Add(new Cluster_KAverage(Color.FromArgb(_random.Next(0, 256), _random.Next(0, 256),
                    _random.Next(0, 256)), _random.Next(PictureWidth - 60), _random.Next(PictureHeight - 60)));
            }

            foreach (var cluster in _clusters)
            {
                _prevCenters.Add(cluster.Center);
            }

            GenerateDots(sbDotsNum.Value);
            ProcessClusters();

            int height = Size.Height;
            int width = PictureWidth > Size.Width ? PictureWidth : Size.Width;
            Size = new Size(width, Size.Height + PictureHeight);
            Graphics g = CreateGraphics();
            var bitmap = new Bitmap("Final.bmp");
            g.DrawImage(bitmap, 0, height);

            btnStart.Enabled = false;
        }
    }
}