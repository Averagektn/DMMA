namespace lab6
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<Node> Tree;

        /// <summary>
        /// 
        /// </summary>
        private readonly Graphics Graphics;

        /// <summary>
        /// 
        /// </summary>
        private readonly Brush Brush = new SolidBrush(Color.Black);
        private readonly Pen Pen = new(Color.Black);

        /// <summary>
        /// 
        /// </summary>
        private int _heightMultiplyer = 100;

        /// <summary>
        /// 
        /// </summary>
        private const int WIDTH_STEP = 50;

        /// <summary>
        /// 
        /// </summary>
        private const int TEXT_POS_CORRECTION = 15;

        /// <summary>
        /// 
        /// </summary>
        private const int AXIS_X_X = 200;

        /// <summary>
        /// 
        /// </summary>
        private int Width_LeaveStep
        {
            get => WIDTH_STEP / 2;
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="node">
        /// 
        /// </param>
        /// <param name="x">
        /// 
        /// </param>
        /// <param name="y">
        /// 
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
                CLR(node.LeftChild, x - WIDTH_STEP, y + Get_H(node));
            }

            if (node?.RightChild is not null)
            {
                Graphics.DrawString(node.Height.ToString(), Font, Brush, AXIS_X_X, y - 10);
                // Right
                Graphics.DrawLine(Pen, new(x, y), new(x + WIDTH_STEP, y));
                // Down
                Graphics.DrawLine(Pen, new(x + WIDTH_STEP, y), new(x + WIDTH_STEP, y + Get_H(node, false)));
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
        /// 
        /// </summary>
        /// <param name="leave">
        /// 
        /// </param>
        /// <param name="x">
        /// 
        /// </param>
        /// <param name="y">
        /// 
        /// </param>
        /// <param name="multiplyer">
        /// 
        /// </param>
        /// <param name="leaveH">
        /// 
        /// </param>
        /// <param name="height">
        /// 
        /// </param>
        private void Draw_Leave(int leave, int x, int y, int multiplyer, int leaveH, double height)
        {
            int step = multiplyer * Width_LeaveStep;
            Graphics.DrawString(height.ToString(), Font, Brush, AXIS_X_X, y - 10);
            // Right
            Graphics.DrawLine(Pen, new(x, y), new(x + step, y));
            // Down
            Graphics.DrawLine(Pen, new(x + step, y), new(x + step, y + leaveH));
            // Text
            Graphics.DrawString("x" + (leave + 1).ToString(), Font, Brush, new Point(x + step - TEXT_POS_CORRECTION,
                y + leaveH));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        private int Get_TreeW()
        {
            return (int)Math.Pow(2, Get_TreeH());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        private int Get_TreeH()
        {
            return (int)Math.Floor(Math.Log2(Tree.Count)) + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node">
        /// 
        /// </param>
        /// <param name="isLeft">
        /// 
        /// </param>
        /// <returns>
        /// 
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
        /// 
        /// </summary>
        /// <param name="node">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        private int Get_LeaveH(Node node)
        {
            return (int)(node.Height * _heightMultiplyer);
        }

    }

}
