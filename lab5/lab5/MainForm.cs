using System.Drawing;
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
        private const int POINTS_NUM = 5000;
        //private const int POINTS_NUM = 50000;
        //private const int POINTS_NUM = 500000;

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
            var points = PointGenerator.Get_NewPointList(POINTS_NUM, Size.Width / 200, Size.Height / 200);
            var coordinates = Create_A(polynom);

            PolynomicSeparator.Separate(points, polynom);

            Class_1 = PolynomicSeparator.Class_1;
            Class_2 = PolynomicSeparator.Class_2;

            Save_ToBMP(FILENAME_RESULT, coordinates);

            //MessageBox.Show($"Separating function: {PolynomToString(polynom)}");
            //MessageBox.Show(Get_SeparatingRule(polynom));
        }

        /// <summary>
        ///     Counts separating rule by given polynom: x2 = (-p1 - p2*x1) / (p3 + p4*x1)
        /// </summary>
        /// <param name="polynom">
        ///     Polynom to count separating rule
        /// </param>
        /// <returns>
        ///     Separating rule
        /// </returns>
        private static string Get_SeparatingRule(List<int> polynom)
        {
            polynom[0] *= -1;
            polynom[1] *= -1;

            return $"x2 = ({polynom[0]}+{polynom[1]}*x1)/({polynom[2]}+{polynom[3]}*x1)";
        }

        /// <summary>
        ///     Converts given polynom to string
        /// </summary>
        /// <param name="polynom">
        ///     Polynom to convert
        /// </param>
        /// <returns>
        ///     Polynom as string
        /// </returns>
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

        private List<Point> Create_A(List<int> polynom)
        {
            var graph = new List<Point>();

            polynom[0] *= -1;
            polynom[1] *= -1;
            for (double i = 0; i < (double)Width / 100; i += 0.01)
            {
                double x = i - (double)Width / 200;
                graph.Add(new((int)(x * 100) + Width / 2, Get_Y(polynom, x) + Height / 2));
            }

            return graph;
        }

        private static int Get_Y(List<int> polynom, double x)
        {
            return (int)(((polynom[0] + polynom[1] * x) / (polynom[2] + polynom[3] * x)) * 100);
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
        private void Save_ToBMP(string filename, List<Point> coords)
        {
            var bmp = new Bitmap(Size.Width, Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            var pen = new Pen(Color.Orange);
            var g = Graphics.FromImage(bmp);
            int i;

            g.Clear(Color.White);

            Draw_Class(Class_1!, Color.Red, g);
            Draw_Class(Class_2!, Color.Green, g);

            for (int k = 0; k < coords.Count; k++)
            {
                if (coords[k].Y < 0)
                {
                    coords.RemoveAt(k);
                }
            }
            coords[0] = new(coords[0].X, Height - coords[0].Y);
            for (i = 0; i < 459; i++)
            {
                coords[i + 1] = new(coords[i + 1].X, Height - coords[i + 1].Y);
                g.DrawLine(pen, coords[i], coords[i + 1]);
            }
            g.DrawLine(pen, coords[i], new(coords[i + 10].X, 0));
            
            i = 478;
            coords[478] = coords[468];
            for (; i < coords.Count - 1; i++)
            {
                if (coords[i + 1].Y > 0 && coords[i].Y > 0)
                {
                    coords[i + 1] = new(coords[i + 1].X, Height - coords[i + 1].Y);
                    g.DrawLine(pen, coords[i], coords[i + 1]);
                }
            }

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
