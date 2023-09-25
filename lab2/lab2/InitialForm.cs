namespace lab2
{
    public partial class InitialForm : Form
    {
        private int PictureWidth
        {
            get
            {
                return int.Parse(tbWidth.Text);
            }
        }

        private int PictureHeight
        {
            get
            {
                return int.Parse(tbHeight.Text);
            }
        }

        /// <summary>
        /// Amount of steps for creating unique filenames
        /// </summary>
        private static int s_step;

        private Bitmap? _bitmap;
        private Graphics? _graphics;

        /// <summary>
        /// Minimal distance between clusters
        /// </summary>
        private int _bound;

        /// <summary>
        /// All created clusters of different colors with dots
        /// </summary>
        private readonly List<Cluster_MinMax> _clusters = new();
        private List<Cluster_KAverage> _kClusters = new();

        /// <summary>
        /// All created dots
        /// </summary>
        private readonly List<Dot> _dots;

        /// <summary>
        /// Generates random numbers
        /// </summary>
        private readonly Random _random = new();

        private readonly List<Point> _prevCenters = new();

        public InitialForm()
        {
            InitializeComponent();

            DeletePrevFiles();

            s_step = 0;
            _bound = -1;
            _clusters.Add(new Cluster_MinMax(Color.Red, _random.Next(255), _random.Next(255)));
            _dots = new List<Dot>();
        }

        /// <summary>
        /// Deletes previous pictures
        /// </summary>
        private static void DeletePrevFiles()
        {
            string filesToDelete = @"Step*";
            string[] fileList = Directory.GetFiles(Directory.GetCurrentDirectory(), filesToDelete);
            foreach (string file in fileList)
            {
                File.Delete(file);
            }
        }

        /// <summary>
        /// Forms a .bmp file from <see cref="Bitmap"/>
        /// </summary>
        private void CreatePicture()
        {
            foreach (var cluster in _clusters)
            {
                cluster.DrawDots(_graphics!);
                cluster.DrawCenter(_graphics!);
            }
            _bitmap?.Save("Step_" + s_step + ".bmp");
            _graphics?.Clear(Color.White);
            s_step++;
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
                var dot = new Dot(Color.Black, random.Next(PictureWidth), random.Next(PictureHeight));
                _dots.Add(dot);
                _dots[i].FindCluster(_clusters);
            }
        }

        /// <summary>
        /// Paints resulting form and saves it in .bmp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessClusters()
        {
            int k = 0;
            var clusterCandidate = _clusters[k].CreateNewCluster(_bound);

            while (k < _clusters.Count)
            {
                if (clusterCandidate != null)
                {
                    CreatePicture();
                    _clusters.Add(clusterCandidate);
                    k = 0;
                }
                else
                {
                    k++;
                }

                for (int i = 0; i < _clusters.Count - 1; i++)
                {
                    _clusters[i].Dots.Clear();
                }

                for (int i = 0; i < _dots.Count; i++)
                {
                    _dots[i].FindCluster(_clusters);
                }

                _bound = (int)CountBounds();

                if (k < _clusters.Count)
                {
                    clusterCandidate = _clusters[k].CreateNewCluster(_bound);
                }
            }
        }

        /// <summary>
        /// Ciunts minimal distances between cluster and it's point to be able to create a new one
        /// </summary>
        /// <returns>Distance between cluster's center and one of it's point</returns>
        private double CountBounds()
        {
            int divisor = 0;
            double distances = 0;

            for (int i = 0; i < _clusters.Count; i++)
            {
                for (int j = i + 1; j < _clusters.Count; j++)
                {
                    distances += Dot.CountDistance(_clusters[i].Center, _clusters[j].Center);
                }
            }

            for (int i = 1; i < _clusters.Count; i++)
            {
                divisor += i;
            }
            divisor *= 2;

            distances /= divisor;

            return distances;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _bitmap = new Bitmap(PictureWidth + 20, PictureHeight + 20, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            int dotsNum = sbDotsNum.Value;

            GenerateDots(dotsNum);
            _clusters[0].Dots = new List<Dot>(_dots);

            ProcessClusters();

            foreach (var cluster in _clusters)
            {
                cluster.DrawDots(_graphics);
                cluster.DrawCenter(_graphics);
            }
            _bitmap.Save("Final.bmp");

            ProcessKClusters();

            int height = Size.Height;
            int width = PictureWidth > Size.Width ? PictureWidth : Size.Width;
            Size = new Size(width, Size.Height + PictureHeight);
            Graphics g = CreateGraphics();
            var bitmap = new Bitmap("Final.bmp");
            g.DrawImage(bitmap, 0, height);

            btnStart.Enabled = false;
        }

        private void sbDotsNum_Scroll(object sender, ScrollEventArgs e)
        {
            lblNumber.Text = sbDotsNum.Value.ToString();
        }

        /// <summary>
        /// Paints resulting form and saves it in .bmp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessKClusters()
        {
            bool isCounting = true;

            foreach (var cluster in _clusters)
            {
                _prevCenters.Add(cluster.Center);
                _kClusters.Add(new Cluster_KAverage(cluster.Color, cluster.Dots, cluster.Center));
            }

            while (isCounting)
            {
                isCounting = false;

                for (int i = 0; i < _kClusters.Count; i++)
                {
                    _kClusters[i].Center = _kClusters[i].GetBestClusterCenter();
                    _kClusters[i].Dots.Clear();
                }

                for (int i = 0; i < _dots.Count; i++)
                {
                    _dots[i].FindCluster(_kClusters);
                }

                for (int i = 0; i < _kClusters.Count; i++)
                {
                    if (!IsSamePoint(_kClusters[i].Center, _prevCenters[i]))
                    {
                        isCounting = true;
                    }
                }
            }

            _graphics?.Clear(Color.White);
            foreach (var cluster in _kClusters)
            {
                cluster.DrawDots(_graphics!);
                cluster.DrawCenter(_graphics!);
            }
            _bitmap?.Save("KAverage.bmp");
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
    }
}