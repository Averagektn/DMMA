namespace lab8
{
    /// <summary>
    ///     Tree root with multiple children
    /// </summary>
    public class Node
    {
        /// <summary>
        ///     Value
        /// </summary>
        public char Symbol { get; private set; }

        /// <summary>
        ///     Children
        /// </summary>
        private readonly List<Node> children;

        /// <summary>
        ///     Creates tree node with specified value and no children
        /// </summary>
        /// <param name="symbol">
        ///     Symbol of the alphabet, value of the root
        /// </param>
        public Node(char symbol)
        {
            Symbol = symbol;
            children = new List<Node>();
        }

        /// <summary>
        ///     Adds new element to children
        /// </summary>
        /// <param name="child">
        ///     Child of the root
        /// </param>
        /// <returns>
        ///     Child of the root
        /// </returns>
        public Node AddChild(Node child)
        {
            children.Add(child);
            
            return child;
        }

        /// <summary>
        ///     Adds multiple nodes to children
        /// </summary>
        /// <param name="children">
        ///     List of children
        /// </param>
        public void AddChildren(List<Node> children)
        {
            this.children.AddRange(children);
        }

        /// <summary>
        ///     Deletes all children with specified symbol
        /// </summary>
        /// <param name="symbol">
        ///     Value of child to delete
        /// </param>
        public void RemoveChild(char symbol)
        {
            children.RemoveAll(child => child.Symbol == symbol);
        }

        /// <summary>
        ///     Checks for the presence of the specified character among the root child values
        /// </summary>
        /// <param name="symbol">
        ///     Character to search
        /// </param>
        /// <returns>
        ///     An indication of the presence of a given character among children
        /// </returns>
        public bool Contains(char symbol)
        {
            return children.Any(child => child.Symbol == symbol);
        }

        /// <summary>
        ///     Getting a child with a given value
        /// </summary>
        /// <param name="symbol">
        ///     Character to search
        /// </param>
        /// <returns>
        ///     A child with the given value, if it exists, otherwise <see langword="null"/>
        /// </returns>
        public Node? GetChild(char symbol)
        {
            return children.FirstOrDefault(child => child.Symbol == symbol);
        }

        /// <summary>
        ///     Getting all children of the root
        /// </summary>
        /// <returns>
        ///     List of all children
        /// </returns>
        public List<Node> GetChildren()
        {
            return children;
        }

        /// <summary>
        ///     Merges specified root with the current root
        /// </summary>
        /// <param name="node">
        ///     Root to merge with
        /// </param>
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
