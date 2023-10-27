using System.Diagnostics.Metrics;
using System.Text;

namespace lab8
{
    public sealed class WordGenerator
    {
        private Node parsingTree;
        private readonly Random random = new();

        public WordGenerator(List<string> words)
        {
            parsingTree = Get_Tree(words);

        }

        public string GetString()
        {
            var head = parsingTree;
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

            return symbols.Count == 0 ? null :symbols[letterIndex].Symbol;
        }


        private Node Get_Tree(List<string> words)
        {
            parsingTree = new Node('\0');
            var head = parsingTree;

            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (parsingTree.Contains(words[i][j]))
                    {
                        parsingTree = parsingTree.GetChild(words[i][j]);
                    }
                    else
                    {
                        parsingTree = parsingTree.AddChild(new Node(words[i][j]));
                    }
                }
                parsingTree = head;
            }

            parsingTree = head;
            Merge(parsingTree);

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
