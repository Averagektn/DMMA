namespace lab8
{
    /// <summary>
    ///     Checks if the selected chain obeys the given grammar
    /// </summary>
    public class WordChecker : Grammar
    {
        /// <summary>
        ///     Word checker
        /// </summary>
        /// <param name="words">
        ///     Letter chains
        /// </param>
        public WordChecker(List<string> words) : base(words) { }

        /// <summary>
        ///     Word checker
        /// </summary>
        /// <param name="tree">
        ///     Parsing tree
        /// </param>
        public WordChecker(Node tree) : base(tree) { }

        /// <summary>
        ///     Checks if the selected chain obeys the given grammar
        /// </summary>
        /// <param name="chain">
        ///     Chain to check
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if obeys, otherwise <see langword="false"/>
        /// </returns>
        public bool Contains(string chain)
        {
            bool contains = true;
            var head = ParsingTree;

            for (int i = 0; i < chain.Length && contains && head is not null; i++)
            {
                if (head.Contains(chain[i]))
                {
                    head = head.GetChild(chain[i]);
                }
                else
                {
                    contains = false;
                }
            }

            return contains;
        }

    }

}
