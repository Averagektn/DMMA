namespace lab7
{
    public partial class MainForm : Form
    {
        private const int POINT_RANGE = 10;

        private Node? tail;
        private Node? head;
        private readonly Graphics g;
        private readonly List<Point> points = new();

        private int templateLength = 0;
        private bool isDrawingTemplate;

        public MainForm()
        {
            InitializeComponent();
            isDrawingTemplate = true;
            g = CreateGraphics();
        }

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

        private void TemplateIsOver(object sender, EventArgs e)
        {
            if (head is not null)
            {
                isDrawingTemplate = false;
                tail?.AddNext(head);
                templateLength++;
            }
        }

        private void CandidateIsOver(object sender, EventArgs e)
        {
            points.Add(points[0]);

            if (head is not null && templateLength == points.Count && Classifier.IsSameClass(head, points))
            {
                MessageBox.Show("Works!");
            }

            points.Clear();
        }

    }

}
