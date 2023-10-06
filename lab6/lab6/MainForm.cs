using System.Xml.Linq;

namespace lab6
{

    public partial class MainForm : Form
    {

        private readonly Graphics Graphics;
        private readonly List<Node> Tree;
        private readonly Brush Brush = new SolidBrush(Color.Black);
        private readonly Pen Pen = new(Color.Black);

        private int _heightMultiplyer = 100;
        private const int WIDTH_STEP = 50;
        private const int TEXT_POS_CORRECTION = 15;

        private int Width_LeaveStep 
        {
            get => WIDTH_STEP / 2;
        }

        private const int SIZE = 4;

        public MainForm()
        {
            InitializeComponent();
            Graphics = CreateGraphics();
            var classifier = new HierarchialClassifier();
            Tree = classifier.Get_Tree();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        { 
            var head = Tree[^1];

            int x = Width / 2;
            int y = 100;

            _heightMultiplyer = (Height - y) / Get_TreeH();

            CLR(head, x, y);

            Font.Dispose();
            Brush.Dispose();
            Graphics.Dispose();
        }

        private void CLR(Node? node, int x, int y)
        {
            if (node?.LeftChild is not null)
            {
                // Left
                Graphics.DrawLine(Pen, new(x, y), new(x - WIDTH_STEP, y));
                // Down
                Graphics.DrawLine(Pen, new(x - WIDTH_STEP, y), new(x - WIDTH_STEP, y + Get_H(node)));
                CLR(node.LeftChild, x - WIDTH_STEP, y + Get_H(node));
            }
            else if (node is not null && !node.IsVisited)
            {
                if (node.LeftLeave != -1)
                {
                    // Left
                    Graphics.DrawLine(Pen, new(x, y), new(x - Width_LeaveStep, y));
                    // Down
                    Graphics.DrawLine(Pen, new(x - Width_LeaveStep, y), new(x - Width_LeaveStep, y + Get_LeaveH(node)));
                    //x -= 50;
                    Graphics.DrawString("x" + (node.LeftLeave + 1).ToString(), Font, Brush, 
                        new Point(x - Width_LeaveStep - TEXT_POS_CORRECTION, y + Get_LeaveH(node)));
                }
                if (node.RightLeave != -1)
                {
                    // Right
                    Graphics.DrawLine(Pen, new(x, y), new(x + Width_LeaveStep, y));
                    // Down
                    Graphics.DrawLine(Pen, new(x + Width_LeaveStep, y), new(x + Width_LeaveStep, y + Get_LeaveH(node)));
                    //x += 50;
                    Graphics.DrawString("x" + (node.RightLeave + 1).ToString(), Font, Brush, 
                        new Point(x + Width_LeaveStep - TEXT_POS_CORRECTION, y + Get_LeaveH(node)));
                }
                node.IsVisited = true;
            }

            if (node?.RightChild is not null)
            {
                // Right
                Graphics.DrawLine(Pen, new(x, y), new(x + WIDTH_STEP, y));
                // Down
                Graphics.DrawLine(Pen, new(x + WIDTH_STEP, y), new(x + WIDTH_STEP, y + Get_H(node, false)));
                CLR(node.RightChild, x + WIDTH_STEP, y + Get_H(node, false));
            }
            else if (node is not null && !node.IsVisited)
            {
                if (node.LeftLeave != -1)
                {
                    // Left
                    Graphics.DrawLine(Pen, new(x, y), new(x - Width_LeaveStep, y));
                    // Down
                    Graphics.DrawLine(Pen, new(x - Width_LeaveStep, y), new(x - Width_LeaveStep, y + Get_LeaveH(node)));
                    x -= 50;
                    Graphics.DrawString("x" + (node.LeftLeave + 1).ToString(), Font, Brush, 
                        new Point(x - Width_LeaveStep - TEXT_POS_CORRECTION, y + Get_LeaveH(node)));
                }
                if (node.RightLeave != -1)
                {

                }
                node.IsVisited = true;
            }

        }

        private int Get_TreeW()
        {
            return (int)Math.Pow(2, Get_TreeH());
        }

        private int Get_TreeH()
        {
            return (int)Math.Floor(Math.Log2(Tree.Count)) + 1;
        }

        private int Get_H(Node node, bool isLeft = true)
        {
            int res = 0;

            if (isLeft)
            {
                res = (int)((node.Height - node!.LeftChild!.Height) * _heightMultiplyer);
            }
            else
            {
                res = (int)((node.Height - node!.RightChild!.Height) * _heightMultiplyer);
            }

            return res;
        }

        private int Get_LeaveH(Node node)
        {
            return (int)(node.Height * _heightMultiplyer);
        }

    }

}
