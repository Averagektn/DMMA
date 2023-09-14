using System.Drawing;
using System;

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
        private List<Cluster_KAverage> _clusters = new();

        private readonly Graphics _graphics;
        private readonly Bitmap _bitmap;

        private static int s_step;
        private int _bound;

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

            DeletePrevFiles();

            s_step = 0;
            _bound = -1;

            _clusters.Add(new Cluster_KAverage(Color.Red, _random.Next(Width - 60), _random.Next(Height - 60)));
            _clusters.Add(new Cluster_KAverage(Color.Green, _random.Next(Width - 60), _random.Next(Height - 60)));
            _clusters.Add(new Cluster_KAverage(Color.Blue, _random.Next(Width - 60), _random.Next(Height - 60)));
            _clusters.Add(new Cluster_KAverage(Color.Yellow, _random.Next(Width - 60), _random.Next(Height - 60)));
            _clusters.Add(new Cluster_KAverage(Color.Black, _random.Next(Width - 60), _random.Next(Height - 60)));
            _clusters.Add(new Cluster_KAverage(Color.Purple, _random.Next(Width - 60), _random.Next(Height - 60)));
            _clusters.Add(new Cluster_KAverage(Color.Brown, _random.Next(Width - 60), _random.Next(Height - 60)));

            foreach (var cluster in _clusters)
            {
                _prevCenters.Add(cluster.Center);
            }
            _dots = new List<Dot>();
            GenerateDots(10000);
            _bitmap = new Bitmap(Width + 40, Height + 40, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);

            ProcessClusters();
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
        /// Paints resulting form and saves it in .bmp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessClusters()
        {
            bool isCounting = true;

            foreach (var cluster in _clusters)
            {
                cluster.DrawDots(_graphics);
                cluster.DrawCenter(_graphics);
            }
            _bitmap.Save("Initial.bmp");
            _graphics.Clear(Color.White);

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

            foreach (var cluster in _clusters)
            {
                cluster.DrawDots(_graphics);
                cluster.DrawCenter(_graphics);
            }
            _bitmap.Save("Final.bmp");
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
                var dot = new Dot(Color.Black, _random.Next(Size.Width), _random.Next(Size.Height));
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
        private bool IsSamePoint(Point p1, Point p2)
        {
            return !(Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1);
        }
    }
}