namespace lab4
{
    public partial class MainForm : Form
    {
        //private Perceptron Perceptron;

        private int ClassesNum
        {
            get => tbClassesNum.Value;
        }

        private int ObjectsNum
        {
            get => tbObjectsNum.Value;
        }

        private int DistinctionsNum
        {
            get => tbDistinctionsNum.Value;
        }

        public MainForm()
        {
            InitializeComponent();

            lblClassesNum_Value.Text = tbClassesNum.Value.ToString();
            lblObjectsNum_Value.Text = tbObjectsNum.Value.ToString();
            lblDistinctionsNum_Value.Text = tbDistinctionsNum.Value.ToString();
        }

        private void On_btnGenerateSeparatingFunctions_Click(object sender, EventArgs e)
        {
            var perceptron = new Perceptron(ClassesNum, ObjectsNum, DistinctionsNum);
            tbGeneratedClasses.Text = perceptron.Get_Classes_String();
            //tbSeparatingFunctions.Text = perceptron.Get_SeparatingFunctions_String();

            btnGenerateSeparatingFunctions.Enabled = false;
        }

        private void On_tbClassesNum_Scroll(object sender, EventArgs e)
        {
            lblClassesNum_Value.Text = tbClassesNum.Value.ToString();
        }

        private void On_tbObjectsNum_Scroll(object sender, EventArgs e)
        {
            lblObjectsNum_Value.Text = tbObjectsNum.Value.ToString();
        }

        private void On_tbDistinctionsNum_Scroll(object sender, EventArgs e)
        {
            lblDistinctionsNum_Value.Text = tbDistinctionsNum.Value.ToString();
        }
    }
}