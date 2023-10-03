namespace lab4
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Provided sie of classes list
        /// </summary>
        private int ClassesNum
        {
            get => tbClassesNum.Value;
        }

        /// <summary>
        ///     Provided size of objects list
        /// </summary>
        private int ObjectsNum
        {
            get => tbObjectsNum.Value;
        }

        /// <summary>
        ///     Provided size of distinctions of every object
        /// </summary>
        private int DistinctionsNum
        {
            get => tbDistinctionsNum.Value;
        }

        /// <summary>
        ///     Initializes numeric labels
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            lblClassesNum_Value.Text = tbClassesNum.Value.ToString();
            lblObjectsNum_Value.Text = tbObjectsNum.Value.ToString();
            lblDistinctionsNum_Value.Text = tbDistinctionsNum.Value.ToString();
        }

        /// <summary>
        ///     Calculates separating functions and visializes them and objects distribution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_btnGenerateSeparatingFunctions_Click(object sender, EventArgs e)
        {
            var perceptron = new Perceptron(ClassesNum, ObjectsNum, DistinctionsNum);
            tbGeneratedClasses.Text = perceptron.Get_Classes_String();
            tbSeparatingFunctions.Text = perceptron.Get_SeparatingFunctions_String();

            btnGenerateSeparatingFunctions.Enabled = false;
        }

        /// <summary>
        ///     Label update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_tbClassesNum_Scroll(object sender, EventArgs e)
        {
            lblClassesNum_Value.Text = tbClassesNum.Value.ToString();
        }

        /// <summary>   
        ///     Label update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_tbObjectsNum_Scroll(object sender, EventArgs e)
        {
            lblObjectsNum_Value.Text = tbObjectsNum.Value.ToString();
        }

        /// <summary>
        ///     Label update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_tbDistinctionsNum_Scroll(object sender, EventArgs e)
        {
            lblDistinctionsNum_Value.Text = tbDistinctionsNum.Value.ToString();
        }

    }
}
