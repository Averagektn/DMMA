namespace lab6
{

    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            var classifier = new HierarchialClassifier(4, 10);
            classifier.Get_Tree();
        }
    }
}