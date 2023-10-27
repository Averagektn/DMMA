namespace lab8
{
    public class Grammar
    {
        public Node ParsingTree { get; protected set; }

        protected readonly Random random = new();

        public Grammar(List<string> words)
        {
            ParsingTree = Get_Tree(words);
        }

        public Grammar(Node tree)
        {
            ParsingTree = tree;
        }

        private Node Get_Tree(List<string> words)
        {
            Node? ParsingTree = new('\0');
            var head = ParsingTree;

            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < words[i].Length && ParsingTree is not null; j++)
                {
                    if (ParsingTree.Contains(words[i][j]))
                    {
                        ParsingTree = ParsingTree.GetChild(words[i][j]);
                    }
                    else
                    {
                        ParsingTree = ParsingTree.AddChild(new Node(words[i][j]));
                    }
                }
                ParsingTree = head;
            }

            ParsingTree = head;
            Merge(ParsingTree);

            return head;
        }

        private void Merge(Node head)
        {
            var roots = head.GetChildren();
            var newRoot = new Node('\0');

            if (roots.Count == 0)
            {
                return;
            }

            for (int i = 0; i < roots.Count; i++)
            {
                for (int j = i + 1; j < roots.Count; j++)
                {
                    if (roots[i].Symbol == roots[j].Symbol)
                    {
                        roots[j].Merge(roots[i]);
                        roots[i].Merge(roots[j]);
                    }
                }
            }

            for (int i = 0; i < roots.Count; i++)
            {
                newRoot.AddChildren(roots[i].GetChildren());
            }

            Merge(newRoot);
        }

    }

}
