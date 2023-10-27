namespace lab7
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private const int POINT_RANGE = 10;

        /// <summary>
        /// 
        /// </summary>
        private Node? tail;

        /// <summary>
        /// 
        /// </summary>
        private Node? head;

        /// <summary>
        /// 
        /// </summary>
        private readonly Graphics g;

        /// <summary>
        /// 
        /// </summary>
        private readonly List<Point> points = new();

        /// <summary>
        /// 
        /// </summary>
        private int templateLength = 0;

        /// <summary>
        /// 
        /// </summary>
        private bool isDrawingTemplate;

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            isDrawingTemplate = true;
            g = CreateGraphics();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawingTemplate)
            {
                if (head is null)
                {
                    head = new Node(new Point(e.X, e.Y));
                    tail = head;
                }
                else
                {
                    tail = tail?.AddNext(new Node(new Point(e.X, e.Y)));
                }
                templateLength++;
            }
            else
            {
                points.Add(new Point(e.X, e.Y));
            }

            g.DrawEllipse(new Pen(Color.Red),
                new Rectangle(e.X - POINT_RANGE / 2, e.Y - POINT_RANGE / 2, POINT_RANGE, POINT_RANGE));
            g.FillEllipse(new SolidBrush(Color.Red),
                new Rectangle(e.X - POINT_RANGE / 2, e.Y - POINT_RANGE / 2, POINT_RANGE, POINT_RANGE));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawingTemplate)
            {
                g.DrawLine(new Pen(Color.Red), tail!.Center, e.Location);
                tail = tail?.AddNext(new Node(new Point(e.X, e.Y)));
                templateLength++;
            }
            else
            {
                g.DrawLine(new Pen(Color.Red), points[^1], e.Location);
                points.Add(new Point(e.X, e.Y));
            }

            g.DrawEllipse(new Pen(Color.Red),
                new Rectangle(e.X - POINT_RANGE / 2, e.Y - POINT_RANGE / 2, POINT_RANGE, POINT_RANGE));
            g.FillEllipse(new SolidBrush(Color.Red),
                new Rectangle(e.X - POINT_RANGE / 2, e.Y - POINT_RANGE / 2, POINT_RANGE, POINT_RANGE));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemplateIsOver(object sender, EventArgs e)
        {
            if (head is not null)
            {
                isDrawingTemplate = false;
                tail?.AddNext(head);
                templateLength++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CandidateIsOver(object sender, EventArgs e)
        {
            if (points.Count != 0)
            {
                points.Add(points[0]);

                if (head is not null && templateLength == points.Count && Classifier.IsSameClass(head, points))
                {
                    MessageBox.Show("The image corresponds to the given grammar");
                }
                else
                {
                    MessageBox.Show("The image does NOT correspond to the given grammar");
                }
            }

            points.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateImage(object sender, EventArgs e)
        {
            if (head is not null)
            {
                var drawer = new NodeDrawer(head.Center, head.Next, head.DX, head.DY);
                drawer.Draw(g, new Pen(Color.Red), new Point(Size.Width - 50, Size.Height - 200),
                    POINT_RANGE, templateLength);
            }
        }

    }

}
