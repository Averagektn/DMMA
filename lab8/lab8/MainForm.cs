namespace lab8
{
    /// <summary>
    ///     Main form of the programm
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     User-defined grammar
        /// </summary>
        private Grammar grammar;

        /// <summary>
        ///     Generates empry grammar
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            grammar = new Grammar(new List<string>());
        }

        /// <summary>
        ///     Generates chains of characters corresponding to a given <see cref="lab8.Grammar"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenetateChains(object sender, EventArgs e)
        {
            var generator = new WordGenerator(grammar.ParsingTree);

            dgvChains.Rows.Clear();

            for (int i = 0; i < dgvGrammar.Rows.Count - 1; i++)
            {
                dgvChains.Rows.Add(generator.GetString());
            }
        }

        /// <summary>
        ///     Generates user-defined grammar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///     Checks whether the entered chain conforms to the specified <see cref="lab8.Grammar"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
