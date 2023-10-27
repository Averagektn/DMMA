using System.Text;

namespace lab8
{
    /// <summary>
    ///     Generates words based on given grammar
    /// </summary>
    public class WordGenerator : Grammar
    {
        /// <summary>
        ///     Randomizer
        /// </summary>
        protected readonly Random random = new();

        /// <summary>
        ///     Word generator
        /// </summary>
        /// <param name="words">
        ///     Grammar chains
        /// </param>
        public WordGenerator(List<string> words) : base(words) { }

        /// <summary>
        ///     Word generator
        /// </summary>
        /// <param name="tree">
        ///     Parsing tree
        /// </param>
        public WordGenerator(Node tree) : base(tree) { }

        /// <summary>
        ///     Genetares random chain of letters based on <see cref="Grammar.ParsingTree"/>
        /// </summary>
        /// <returns>
        ///     String as symbol chain
        /// </returns>
        public string GetString()
        {
            var head = ParsingTree;
            var children = head.GetChildren();
            var chain = new StringBuilder();

            for (char? letter = GetRandomSymbol(children); letter is not null; letter = GetRandomSymbol(children))
            {
                chain.Append(letter);
                head = head?.GetChild((char)letter);
                children = head?.GetChildren();

                if (children is null)
                {
                    break;
                }
            }

            return chain.ToString();
        }

        /// <summary>
        ///     Randomizes next symbol
        /// </summary>
        /// <param name="symbols">
        ///     Symbols to choose from
        /// </param>
        /// <returns>
        ///     Next random symbol
        /// </returns>
        private char? GetRandomSymbol(List<Node> symbols)
        {
            int letterIndex = random.Next(symbols.Count);

            return symbols.Count == 0 ? null : symbols[letterIndex].Symbol;
        }

    }

}
