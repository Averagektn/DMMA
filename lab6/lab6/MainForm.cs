namespace lab6
{
    /// <summary>
    ///     Tree visualization
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Tree. Last element is head
        /// </summary>
        private readonly List<Node> Tree;

        /// <summary>
        ///     Drawing tool
        /// </summary>
        private readonly Graphics Graphics;
        private readonly Brush Brush = new SolidBrush(Color.Black);
        private readonly Pen Pen = new(Color.Black);

        /// <summary>
        ///     To incease height differences
        /// </summary>
        private int _heightMultiplyer = 100;

        /// <summary>
        ///     To draw branches
        /// </summary>
        private const int WIDTH_STEP = 50;

        /// <summary>
        ///     Text centralizator
        /// </summary>
        private const int TEXT_POS_CORRECTION = 15;

        /// <summary>
        ///     Axis coordinate
        /// </summary>
        private const int AXIS_X_X = 300;

        /// <summary>
        ///     To draw leaves
        /// </summary>
        private static int Width_LeaveStep
        {
            get => WIDTH_STEP / 2;
        }

        /// <summary>
        ///     Tree creator
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Graphics = CreateGraphics();

            // Minimum
            var classifier = new HierarchialClassifier();

            // Maximum
            //var classifier = new HierarchialClassifier(true);

            // Doesn't properly shows indexes
            //var classifier = new HierarchialClassifier(4, 2);

            Tree = classifier.Get_Tree();
        }

        /// <summary>
        ///     Visualizes trees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            var head = Tree[^1];

            int x = Width / 2;
            int y = 100;

            _heightMultiplyer = (Height - y) / Get_TreeH();

            CLR(head, x, y);

            Graphics.DrawLine(Pen, new(AXIS_X_X, y), new(AXIS_X_X, y + (int)(head.Height * _heightMultiplyer)));

            Font.Dispose();
            Brush.Dispose();
            Graphics.Dispose();
        }

        /// <summary>
        ///     Tree traversal<br/>
        ///     While traversing draws tree elements<br/>
        /// </summary>
        /// <param name="node">
        ///     Tree head
        /// </param>
        /// <param name="x">
        ///     X coordinate for drawing
        /// </param>
        /// <param name="y">
        ///     Y coordinate for drawing
        /// </param>
        private void CLR(Node? node, int x, int y)
        {
            if (node?.LeftChild is not null)
            {
                Graphics.DrawString(node.Height.ToString(), Font, Brush, AXIS_X_X, y - 10);

                
                // Left
                Graphics.DrawLine(Pen, new(x, y), new(x - WIDTH_STEP, y));
                // Down
                Graphics.DrawLine(Pen, new(x - WIDTH_STEP, y), new(x - WIDTH_STEP, y + Get_H(node)));

                Graphics.DrawEllipse(new Pen(Color.Orange), new Rectangle(x - 5, y - 5, 10, 10));
                Graphics.FillEllipse(new SolidBrush(Color.Orange), new Rectangle(x - 5, y - 5, 10, 10));

                CLR(node.LeftChild, x - WIDTH_STEP, y + Get_H(node));
            }

            if (node?.RightChild is not null)
            {
                Graphics.DrawString(node.Height.ToString(), Font, Brush, AXIS_X_X, y - 10);

                

                // Right
                Graphics.DrawLine(Pen, new(x, y), new(x + WIDTH_STEP, y));
                // Down
                Graphics.DrawLine(Pen, new(x + WIDTH_STEP, y), new(x + WIDTH_STEP, y + Get_H(node, false)));

                Graphics.DrawEllipse(new Pen(Color.Orange), new Rectangle(x - 5, y - 5, 10, 10));
                Graphics.FillEllipse(new SolidBrush(Color.Orange), new Rectangle(x - 5, y - 5, 10, 10));

                CLR(node.RightChild, x + WIDTH_STEP, y + Get_H(node, false));
            }

            if (node is not null && !node.IsVisited)
            {
                if (node.LeftLeave != -1)
                {
                    Draw_Leave(node.LeftLeave, x, y, -1, Get_LeaveH(node), node.Height);
                }
                if (node.RightLeave != -1)
                {
                    Draw_Leave(node.RightLeave, x, y, 1, Get_LeaveH(node), node.Height);
                }
                node.IsVisited = true;
            }
        }

        /// <summary>
        ///     Draws leave at specified coordinate<br/> 
        ///     Also draws lines down and left|right<br/>
        /// </summary>
        /// <param name="leave">
        ///     Leave value
        /// </param>
        /// <param name="x">
        ///     X coordinate
        /// </param>
        /// <param name="y">
        ///     Y coordinate
        /// </param>
        /// <param name="multiplyer">
        ///     -1 to draw left line<br/>
        ///     1 to draw right line<br/>
        /// </param>
        /// <param name="leaveH">
        ///     Leave height for drawing line down
        /// </param>
        /// <param name="height">
        ///     Height as tree payload<br/>
        ///     Value is drawn as text<br/>
        /// </param>
        private void Draw_Leave(int leave, int x, int y, int multiplyer, int leaveH, double height)
        {
            int step = multiplyer * Width_LeaveStep;
            
            Graphics.DrawString(height.ToString(), Font, Brush, AXIS_X_X, y - 10);
            // Right
            Graphics.DrawLine(Pen, new(x, y), new(x + step, y));
            // Down
            Graphics.DrawLine(Pen, new(x + step, y), new(x + step, y + leaveH));

            Graphics.DrawEllipse(new Pen(Color.Orange), new Rectangle(x - 5, y - 5, 10, 10));
            Graphics.FillEllipse(new SolidBrush(Color.Orange), new Rectangle(x - 5, y - 5, 10, 10));

            // Text
            Graphics.DrawString("x" + (leave + 1).ToString(), Font, Brush, new Point(x + step - TEXT_POS_CORRECTION,
                y + leaveH));
        }

        /// <summary>
        ///     Tree width counter
        /// </summary>
        /// <returns>
        ///     Tree width
        /// </returns>
        private int Get_TreeW()
        {
            return (int)Math.Pow(2, Get_TreeH());
        }

        /// <summary>
        ///     Tree height counter
        /// </summary>
        /// <returns>
        ///     Tree height
        /// </returns>
        private int Get_TreeH()
        {
            return (int)Math.Floor(Math.Log2(Tree.Count)) + 1;
        }

        /// <summary>
        ///     Height for line drawing
        /// </summary>
        /// <param name="node">
        ///     Current node
        /// </param>
        /// <param name="isLeft">
        ///     Which leave do count
        /// </param>
        /// <returns>
        ///     Height of the line do draw down
        /// </returns>
        private int Get_H(Node node, bool isLeft = true)
        {
            int res;

            if (isLeft)
            {
                res = (int)((node.Height - node.LeftChild!.Height) * _heightMultiplyer);
            }
            else
            {
                res = (int)((node.Height - node.RightChild!.Height) * _heightMultiplyer);
            }

            return res;
        }

        /// <summary>
        ///     Counts leave height
        /// </summary>
        /// <param name="node">
        ///     Node to count height for
        /// </param>
        /// <returns>
        ///     Leave height
        /// </returns>
        private int Get_LeaveH(Node node)
        {
            return (int)(node.Height * _heightMultiplyer);
        }

    }

}
