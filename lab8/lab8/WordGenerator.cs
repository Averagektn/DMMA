using System.Text;

namespace lab8
{
    public class WordGenerator : Grammar
    {
        public WordGenerator(List<string> words) : base(words) { }
        public WordGenerator(Node tree) : base(tree) { }

        public string GetString()
        {
            var head = ParsingTree;
            var children = head.GetChildren();
            var chain = new StringBuilder();

            for (char? letter = GetRandomSymbol(children); letter is not null; letter = GetRandomSymbol(children))
            {
                chain.Append(letter);
                head = head.GetChild((char)letter);
                children = head.GetChildren();
            }

            return chain.ToString();
        }

        private char? GetRandomSymbol(List<Node> symbols)
        {
            int letterIndex = random.Next(symbols.Count);

            return symbols.Count == 0 ? null : symbols[letterIndex].Symbol;
        }

    }

}
