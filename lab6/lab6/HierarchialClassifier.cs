using Table = System.Collections.Generic.List<System.Collections.Generic.List<double>>;

namespace lab6
{
    /// <summary>
    ///     Creates a hierchial tree
    /// </summary>
    public sealed class HierarchialClassifier
    {
        /// <summary>
        ///     Randomizator
        /// </summary>
        private readonly Random Random = new();

        /// <summary>
        ///     Table of distances for tree creation n * n
        /// </summary>
        private readonly Table DistanceTable;

        /// <summary>
        ///     Initial table size
        /// </summary>
        private readonly int _tableSize;

        /// <summary>
        ///     Initializaes classifier with specified size and maximum value
        /// </summary>
        /// <param name="size">
        ///     Distance table initial size
        /// </param>
        /// <param name="maxVal">
        ///     Maximum value + 0.1 for random number generation
        /// </param>
        public HierarchialClassifier(int size, int maxVal)
        {
            _tableSize = size;
            DistanceTable = Create_DistanceTable(maxVal);
        }

        /// <summary>
        ///     Creates preset distance table:<br/>
        ///     Max:<br/>
        ///         { 0.0, 0.2, 2.0, 0.5 }<br/>
        ///         { 0.2, 0.0, 1.0, 1.7}<br/>
        ///         { 2.0, 1.0, 0.0, 0.4 }<br/>
        ///         { 0.5, 1.7, 0.4, 0.0 }<br/><br/>
        ///     Min:<br/>
        ///         { 0.0, 5.0, 0.5, 2.0 }<br/>
        ///         { 5.0, 0.0, 1.0, 0.6 }<br/>
        ///         { 0.5, 1.0, 0.0, 2.5 }<br/>
        ///         { 2.0, 0.6, 2.5, 0.0 }<br/><br/>
        /// </summary>
        /// <param name="isMax">
        ///     If <see langword="true"/> => Max, else => Min
        /// </param>
        public HierarchialClassifier(bool isMax = false)
        {
            _tableSize = 4;
            DistanceTable = Create_DistanceTable();
            if (isMax)
            {
                DistanceTable_ToMax();
            }

        }

        /// <summary>
        ///     Converts to Max table.<br/> 
        ///     See HierachialClassifier constructor: HierarchialClassifier(bool isMax)<br/>
        /// </summary>
        private void DistanceTable_ToMax()
        {
            for (int i = 0; i < DistanceTable.Count; i++)
            {
                for (int j = 0; j < DistanceTable[i].Count; j++)
                {
                    DistanceTable[i][j] = DistanceTable[i][j] == 0 ? 0 : Math.Round(1 / DistanceTable[i][j], 1);
                }
            }
        }

        /// <summary>
        ///     Counts tree<br/> 
        ///     List is leaves<br/> 
        ///     Last element is head<br/>
        /// </summary>
        /// <returns>
        ///     Tree
        /// </returns>
        public List<Node> Get_Tree()
        {
            var tree = new List<Node>();
            var inds = Create_IndList(_tableSize);
            int counter = _tableSize;

            while (DistanceTable.Count > 1)
            {
                var min = Get_MinDistIndexes();

                for (int j = 0; j < DistanceTable.Count; j++)
                {
                    DistanceTable[min.Row][j] = DistanceTable[min.Row][j] < DistanceTable[min.Column][j] ?
                        DistanceTable[min.Row][j] : DistanceTable[min.Column][j];
                }

                DistanceTable.Add(DistanceTable[min.Row]);
                DistanceTable.RemoveAt(min.Row);
                DistanceTable.RemoveAt(min.Column);
                for (int i = 0; i < DistanceTable.Count; i++)
                {
                    DistanceTable[i][min.Column] = DistanceTable[i][min.Column] < DistanceTable[i][min.Row] ?
                        DistanceTable[i][min.Column] : DistanceTable[i][min.Row];
                    DistanceTable[i].Add(DistanceTable[i][min.Column]);
                    DistanceTable[i].RemoveAt(min.Row);
                    DistanceTable[i].RemoveAt(min.Column);
                }

                Add_TreeNode(tree, min, inds, ref counter);

                counter -= 2;
            }

            return tree;
        }

        /// <summary>
        ///     Adds new node to tree list
        /// </summary>
        /// <param name="tree">
        ///     Tree to add to
        /// </param>
        /// <param name="cell">
        ///     Payload
        /// </param>
        /// <param name="inds">
        ///     Idexes for payload correction
        /// </param>
        /// <param name="counter">
        ///     Defines adding algorithm
        /// </param>
        private static void Add_TreeNode(List<Node> tree, TableCell cell, List<int> inds, ref int counter)
        {
            if (cell.Column >= counter || cell.Row >= counter)
            {
                if (cell.Column >= counter && cell.Row >= counter)
                {
                    tree.Add(new(tree[cell.Column], tree[cell.Row], cell.Value));
                }
                else
                {
                    cell.Row = inds[cell.Column];
                    cell.Column = -1;
                    tree.Add(new(cell, tree[^1]));
                    counter++;
                }
            }
            else
            {
                int tmp = cell.Row;
                cell.Row = inds[tmp];
                inds.RemoveAt(tmp);

                tmp = cell.Column;
                cell.Column = inds[tmp];
                inds.RemoveAt(tmp);

                tree.Add(new(cell));
            }
        }

        /// <summary>
        ///     Index list is list where indexes are equal to values
        /// </summary>
        /// <param name="size">
        ///     List size
        /// </param>
        /// <returns>
        ///     New index list
        /// </returns>
        private static List<int> Create_IndList(int size)
        {
            var res = new List<int>();

            for (int i = 0; i < size; i++)
            {
                res.Add(i);
            }

            return res;
        }

        /// <summary>
        ///     Counts elements of <see cref="DistanceTable"/> with least distance between
        /// </summary>
        /// <returns>
        ///     New element of the tree
        /// </returns>
        private TableCell Get_MinDistIndexes()
        {
            int minRow = 0;
            int minCol = 0;
            double minHeight = double.MaxValue;

            for (int i = 0; i < DistanceTable.Count; i++)
            {
                for (int j = 0; j < DistanceTable[i].Count; j++)
                {
                    if (DistanceTable[i][j] <= minHeight && DistanceTable[i][j] != 0 && i != j)
                    {
                        minRow = i;
                        minCol = j;
                        minHeight = DistanceTable[i][j];
                    }
                }
            }

            if (minRow < minCol)
            {
                (minCol, minRow) = (minRow, minCol);
            }

            return new TableCell(minRow, minCol, minHeight);
        }

        /// <summary>
        ///     Initializes <see cref="DistanceTable"/> for empty constructor
        /// </summary>
        /// <returns>
        ///     New <see cref="DistanceTable"/>
        /// </returns>
        private static Table Create_DistanceTable() =>
            new()
            {
                new() { 0, 5, 0.5, 2 },
                new() { 5, 0, 1, 0.6 },
                new() { 0.5, 1, 0, 2.5},
                new() { 2, 0.6, 2.5, 0}
            };


        /// <summary>
        ///     Initializes <see cref="DistanceTable"/> with random calues
        /// </summary>
        /// <param name="maximum">
        ///     Maximal: maximum + 0.1
        /// </param>
        /// <returns>
        ///     New <see cref="DistanceTable"/>
        /// </returns>
        private Table Create_DistanceTable(int maximum)
        {
            var table = new Table() { new() };

            for (int i = 1; i < _tableSize; i++)
            {
                table.Add(new());
                for (int j = 0; j < i; j++)
                {
                    table[i].Add(Math.Round(Random.NextDouble() * maximum + 0.1, 1));
                }
            }

            for (int i = 0; i < _tableSize; i++)
            {
                table[i].Add(0);
                for (int j = i + 1; j < _tableSize; j++)
                {
                    table[i].Add(table[j][i]);
                }
            }

            return table;
        }

    }

}
