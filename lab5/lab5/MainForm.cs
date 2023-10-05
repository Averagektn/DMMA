namespace lab5
{
    public partial class MainForm : Form
    {

        private readonly List<Point>? Class_1 = new();
        private readonly List<Point>? Class_2 = new();

        private const int POINTS_NUM = 50000;

        private const int POINT_WIDTH = 1;
        private const int POINT_HEIGHT = 1;

        private const string FILENAME_RESULT = "Result.bmp";

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

        private void Save_ToBMP(string filename)
        {
            var bmp = new Bitmap(Size.Width, Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            var redBrush = new SolidBrush(Color.Red);
            var redPen = new Pen(redBrush);

            var greenBrush = new SolidBrush(Color.Green);
            var greenPen = new Pen(greenBrush);

            foreach (var obj in Class_1!)
            {
                g.DrawEllipse(redPen, new Rectangle(obj.X + Size.Width / 2, obj.Y + Size.Height / 2,
                    POINT_WIDTH, POINT_HEIGHT));
                g.FillEllipse(redBrush, new Rectangle(obj.X + Size.Width / 2, obj.Y + Size.Height / 2,
                    POINT_WIDTH, POINT_HEIGHT));
            }

            foreach (var obj in Class_2!)
            {
                g.DrawEllipse(greenPen, new Rectangle(obj.X + Size.Width / 2, obj.Y + Size.Height / 2,
                    POINT_WIDTH, POINT_HEIGHT));
                g.FillEllipse(greenBrush, new Rectangle(obj.X + Size.Width / 2, obj.Y + Size.Height / 2,
                    POINT_WIDTH, POINT_HEIGHT));
            }

            bmp.Save(filename);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            var bitmap = new Bitmap(FILENAME_RESULT);
            g.DrawImage(bitmap, 0, 0, Size.Width, Size.Height);
        }
    }

}
