using Table = System.Collections.Generic.List<System.Collections.Generic.List<double>>;

namespace lab6
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class HierarchialClassifier
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Random Random = new();

        /// <summary>
        /// 
        /// </summary>
        private readonly Table DistanceTable;

        /// <summary>
        /// 
        /// </summary>
        private readonly int _tableSize;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">
        /// 
        /// </param>
        /// <param name="maxVal">
        /// 
        /// </param>
        public HierarchialClassifier(int size, int maxVal)
        {
            _tableSize = size;
            DistanceTable = Create_DistanceTable(maxVal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isMax">
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <returns>
        /// 
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
        /// 
        /// </summary>
        /// <param name="tree">
        /// 
        /// </param>
        /// <param name="cell">
        /// 
        /// </param>
        /// <param name="inds">
        /// 
        /// </param>
        /// <param name="counter">
        /// 
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
        /// 
        /// </summary>
        /// <param name="size">
        /// 
        /// </param>
        /// <returns>
        /// 
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
        /// 
        /// </summary>
        /// <returns>
        /// 
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
                int tmp = minRow;
                minRow = minCol;
                minCol = tmp;
            }

            return new TableCell(minRow, minCol, minHeight);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
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
        /// 
        /// </summary>
        /// <param name="maximum">
        /// 
        /// </param>
        /// <returns>
        /// 
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
