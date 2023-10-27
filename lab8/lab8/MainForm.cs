namespace lab8
{
    public partial class MainForm : Form
    {
        private Grammar grammar;

        public MainForm()
        {
            InitializeComponent();

            grammar = new Grammar(new List<string>());
        }

        private void GenetateChains(object sender, EventArgs e)
        {
            var generator = new WordGenerator(grammar.ParsingTree);

            dgvChains.Rows.Clear();

            for (int i = 0; i < dgvGrammar.Rows.Count - 1; i++)
            {
                dgvChains.Rows.Add(generator.GetString());
            }
        }

        private void GenerateGrammar(object sender, EventArgs e)
        {
            var words = new List<string>();

            foreach (DataGridViewRow row in dgvGrammar.Rows)
            {

                var val = row.Cells[0].Value?.ToString();

                if (val is not null)
                {
                    words.Add(val);
                }
            }

            grammar = new Grammar(words);
        }

        private void Verify(object sender, EventArgs e)
        {
            var checker = new WordChecker(grammar.ParsingTree);

            if (checker.Contains(tbVerifyngString.Text))
            {
                MessageBox.Show("This word is subject of a given grammar");
            }
            else
            {
                MessageBox.Show("This word is NOT subject of a given grammar");
            }
        }

    }

}
