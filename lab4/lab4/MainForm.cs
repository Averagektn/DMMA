namespace lab4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var perceptron = new Perceptron(5, 10, 3);
        }
    }
}