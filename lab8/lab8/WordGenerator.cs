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
            // a - a - b - c
            //           - a
            // c - a - b - d
            // b - c - d - a

            var head = parsingTree;
            var children = parsingTree.GetChildren();

            for (int i = 0; i < children.Count; i++)
            {
                // children = a b c
                // child = a -> a
                // secondChild = c -> a
                var child = children[i].GetChildren();
                for (int j = 0; j < child.Count; j++)
                {
                    for (int k = 1; k < children.Count; k++)
                    {
                        var secondChild = children[(i + k) % children.Count].GetChildren();
                        for (int n = 0; n < secondChild.Count; n++)
                        {
                            if (secondChild[n].Symbol == child[j].Symbol)
                            {
                                children[(i + k) % children.Count].RemoveChild(secondChild[n].Symbol);
                                children[(i + k) % children.Count].AddChild(child[j]);
                                for (int f = 0; f < secondChild[n].GetChildren().Count; f++)
                                {
                                    child[j].AddChild(secondChild[n].GetChildren()[f]);
                                }
                                //children[(i + k) % children.Count].RemoveChild(child[j].Symbol);
                                //secondChild[n].RemoveChild(child[j].Symbol);
                                secondChild[n].AddChild(child[j]);
                            }
                        }
                    }
                }
            }

            return head;
        }

    }

}
