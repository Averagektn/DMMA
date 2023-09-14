namespace lab2
{
    public partial class InitialForm : Form
    {
        /// <summary>
        /// Amount of steps for creating unique filenames
        /// </summary>
        private static int s_step;

        private readonly Bitmap _bitmap;
        private readonly Graphics _graphics;

        /// <summary>
        /// Minimal distance between clusters
        /// </summary>
        private int _bound;

        /// <summary>
        /// All created clusters of different colors with dots
        /// </summary>
        private List<Cluster_MinMax> _clusters = new();

        /// <summary>
        /// All created dots
        /// </summary>
        private readonly List<Dot> _dots;

        /// <summary>
        /// Generates random numbers
        /// </summary>
        private readonly Random _random = new();

        public InitialForm()
        {
            InitializeComponent();

            DeletePrevFiles();

            s_step = 0;
            _bound = -1;
            _clusters.Add(new Cluster_MinMax(Color.Red, _random.Next(255), _random.Next(255)));
            _dots = new List<Dot>();
            _bitmap = new Bitmap(Width + 20, Height + 20, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
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
                cluster.DrawDots(_graphics);
                cluster.DrawCenter(_graphics);
            }
            _bitmap.Save("Step_" + s_step + ".bmp");
            _graphics.Clear(Color.White);
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
                var dot = new Dot(Color.Black, random.Next(Size.Width), random.Next(Size.Height));
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
            btnStart.Enabled = false;
            Close();
        }

        private void sbDotsNum_Scroll(object sender, ScrollEventArgs e)
        {
            lblNumber.Text = sbDotsNum.Value.ToString();
        }
    }
}