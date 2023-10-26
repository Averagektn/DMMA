namespace lab8
{
    public class Node
    {
        public char Symbol { get; private set; }
        private readonly List<Node> children;

        public Node(char symbol)
        {
            Symbol = symbol;
            children = new List<Node>();
        }

        public Node AddChild(Node child)
        {
            children.Add(child);
            
            return child;
        }

        public void RemoveChild(char symbol)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Symbol == symbol)
                {
                    children.RemoveAt(i);
                }
            }
        }

        public bool Contains(char symbol)
        {
            bool res = false;

            for (int i = 0; i < children.Count && !res; i++)
            {
                res = children[i].Symbol == symbol;
            }

            return res;
        }

        public Node GetChild(char symbol)
        {
            int i;
            bool res = false;

            for (i = 0; i < children.Count && !res; i++)
            {
                res = children[i].Symbol == symbol;
            }

            return children[i - 1];
        }

        public List<Node> GetChildren()
        {
            return children;
        }

        public void Merge(Node node)
        {
            var merging = node.GetChildren(); 
            for (int i = 0; i < merging.Count; i++)
            {
                if (Contains(merging[i].Symbol))
                {
                    GetChild(merging[i].Symbol).Merge(merging[i]);
                }
                else
                {
                    AddChild(merging[i]);
                }
            }
        }

    }

}
