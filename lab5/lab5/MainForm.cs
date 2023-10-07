using System.Text;

namespace lab5
{
    /// <summary>
    ///     Form to show results as visualization
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     First class
        /// </summary>
        private readonly List<Point>? Class_1 = new();

        /// <summary>
        ///     Second class
        /// </summary>
        private readonly List<Point>? Class_2 = new();

        /// <summary>
        ///     Number of points to separate
        /// </summary>
        //private const int POINTS_NUM = 50000;
        private const int POINTS_NUM = 500000;

        /// <summary>
        ///     Point width for drawing
        /// </summary>
        private const int POINT_WIDTH = 2;

        /// <summary>
        ///      Point height for drawing
        /// </summary>
        private const int POINT_HEIGHT = 2;

        /// <summary>
        ///     Filename where results are saved
        /// </summary>
        private const string FILENAME_RESULT = "Result.bmp";

        /// <summary>
        ///     Creates separating polynom, generates points and saves results as .bmp
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

            MessageBox.Show($"Separating function: {PolynomToString(polynom)}");
        }

        private static string PolynomToString(List<int> polynom)
        {
            var res = new StringBuilder();
            var vars = new string[3] { "*x1", "*x2", "x1*x2" };

            res.Append(polynom[0]);
            for (int i = 1; i < polynom.Count; i++)
            {
                if (polynom[i] < 0)
                {
                    res.Append(" - " + Math.Abs(polynom[i]));
                }
                else
                {
                    res.Append(" + " + polynom[i]);
                }
                res.Append(vars[i - 1]);
            }

            return res.ToString();
        }

        /// <summary>
        ///     Saves drawing results to .bmp file
        /// </summary>
        /// <param name="points">
        ///     Points
        /// </param>
        /// <param name="filename">
        ///     Name of file to save
        /// </param>
        private void Save_ToBMP(string filename)
        {
            var bmp = new Bitmap(Size.Width, Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            var pen = new Pen(Color.Orange);
            var g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            Draw_Class(Class_1!, Color.Red, g);
            Draw_Class(Class_2!, Color.Green, g);

            bmp.Save(filename);
        }

        /// <summary>
        ///     Draws the entire class with specified color
        /// </summary>
        /// <param name="objects">
        ///     Points to draw
        /// </param>
        /// <param name="color">
        ///     Color to draw with
        /// </param>
        /// <param name="graphics">
        ///     Element to draw on
        /// </param>
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
        ///     Paints results from .bmp file
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
