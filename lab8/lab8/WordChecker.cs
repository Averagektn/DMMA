namespace lab8
{
    public class WordChecker : Grammar
    {
        public WordChecker(List<string> words) : base(words) { }
        public WordChecker(Node tree) : base(tree) { }

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
