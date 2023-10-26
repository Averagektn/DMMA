using System.Reflection.Metadata.Ecma335;

namespace lab8
{
    public sealed class WordGenerator
    {
        private Node parsingTree;

        public WordGenerator(List<string> words) 
        {
            parsingTree = Get_Tree(words);
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
            head = Merge();

            return head;
        }

        private Node Merge()
        {
            var a = parsingTree.GetChildren()[0].GetChildren()[0];
            var b = parsingTree.GetChildren()[1].GetChildren()[0];

            a.Merge(b);
            b.Merge(a);

            return a;
        }

    }

}
