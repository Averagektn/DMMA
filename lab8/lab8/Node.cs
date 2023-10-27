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

        public void AddChildren(List<Node> children)
        {
            this.children.AddRange(children);
        }


        public void RemoveChild(char symbol)
        {
            children.RemoveAll(child => child.Symbol == symbol);
        }


        public bool Contains(char symbol)
        {
            return children.Any(child => child.Symbol == symbol);
        }


        public Node? GetChild(char symbol)
        {
            return children.FirstOrDefault(child => child.Symbol == symbol);
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
                    GetChild(merging[i].Symbol)?.Merge(merging[i]);
                }
                else
                {
                    AddChild(merging[i]);
                }
            }
        }

    }

}
