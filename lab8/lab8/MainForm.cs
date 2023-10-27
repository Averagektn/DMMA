namespace lab8
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var generator = new WordGenerator(new List<string>() { "aabc", "cabd", "bcba"});



        }

    }

}
