namespace lab7
{
    public partial class MainForm : Form
    {
        private const int POINT_RANGE = 10;
        Node? tail;
        Node? head;
        List<Point> points = new();
        int length = 0;
        bool a;
        Graphics g;
        public MainForm()
        {
            InitializeComponent();
            a = true;
            g = CreateGraphics();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (a)
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
                length++;
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
            if (a)
            {
                g.DrawLine(new Pen(Color.Red), tail!.Center, e.Location);
                tail = tail?.AddNext(new Node(new Point(e.X, e.Y)));
                length++;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (head is not null)
            {
                a = false;
                tail?.AddNext(head);
                length++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            points.Add(points[0]);
            if (length == points.Count && Classifier.IsSameClass(head, points))
            {
                MessageBox.Show("Works!");
            }
        }

    }

}
