namespace lab5
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<Point>? Class_1 = new();

        /// <summary>
        /// 
        /// </summary>
        private readonly List<Point>? Class_2 = new();

        /// <summary>
        /// 
        /// </summary>
        private const int POINTS_NUM = 50000;

        /// <summary>
        /// 
        /// </summary>
        private const int POINT_WIDTH = 1;

        /// <summary>
        /// 
        /// </summary>
        private const int POINT_HEIGHT = 1;

        /// <summary>
        /// 
        /// </summary>
        private const string FILENAME_RESULT = "Result.bmp";

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            var counter = new PolynomGenerator();
            var polynom = counter.Get_SeparatingPolynom();
            var points = PointGenerator.Get_NewPointList(POINTS_NUM, -Size.Width / 2, Size.Width / 2,
                -Size.Height / 2, Size.Height / 2);

            PolynomicSeparator.Separate(points, polynom);

            Class_1 = PolynomicSeparator.Class_1;
            Class_2 = PolynomicSeparator.Class_2;

            Save_ToBMP(FILENAME_RESULT);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        private void Save_ToBMP(string filename)
        {
            var bmp = new Bitmap(Size.Width, Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            Draw_Class(Class_1!, Color.Red, g);
            Draw_Class(Class_2!, Color.Green, g);

            bmp.Save(filename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="color"></param>
        /// <param name="graphics"></param>
        private void Draw_Class(List<Point> objects, Color color, Graphics graphics)
        {
            var brush = new SolidBrush(color);
            var pen = new Pen(brush);

            foreach (var obj in objects)
            {
                graphics.DrawEllipse(pen, new Rectangle(obj.X + Size.Width / 2, obj.Y + Size.Height / 2,
                    POINT_WIDTH, POINT_HEIGHT));
                graphics.FillEllipse(brush, new Rectangle(obj.X + Size.Width / 2, obj.Y + Size.Height / 2,
                    POINT_WIDTH, POINT_HEIGHT));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            var bitmap = new Bitmap(FILENAME_RESULT);
            g.DrawImage(bitmap, 0, 0, Size.Width, Size.Height);
        }

    }

}
