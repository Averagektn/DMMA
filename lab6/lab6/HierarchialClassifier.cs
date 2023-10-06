using Table = System.Collections.Generic.List<System.Collections.Generic.List<double>>;

namespace lab6
{
    public sealed class HierarchialClassifier
    {

        private readonly Random Random = new();

        private Table DistanceTable;

        private int _tableSize;

        public HierarchialClassifier(int size, int maxVal)
        {
            _tableSize = size;
            //DistanceTable = Create_DistanceTable(maxVal);
            DistanceTable = Create_DistanceTable();
        }

        public List<Node> Get_Tree()
        {
            var tree = new List<Node>();
            var elementInds = new List<int>();
            int counter = _tableSize;
            var inds = new List<int>();

            for (int i = 0; i < DistanceTable.Count; i++)
            {
                inds.Add(i);
            }

            for (int i = 0; i < _tableSize; i++)
            {
                elementInds.Add(i);
            }

            while(DistanceTable.Count > 1)
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
                    DistanceTable[i].RemoveAt(min.Row);
                }

                if (min.Column > counter || min.Row > counter)
                {
                    if (min.Column > counter && min.Row > counter)
                    {
                        tree.Add(new(tree[min.Column], tree[min.Row], min.Value));
                    }
                    else
                    {
                        min.Row = inds[min.Column];
                        int tmp = min.Column;
                        min.Column = -1;
                        tree.Add(new(min, tree[tmp]));
                    }
                }
                else
                {
                    int tmp = min.Row;
                    min.Row = inds[tmp];
                    inds.RemoveAt(tmp);

                    tmp = min.Column;
                    min.Column = inds[tmp];
                    inds.RemoveAt(tmp);

                    tree.Add(new(min));
                }

                counter -= 2;
            }

            return tree;
        }

        private TableCell Get_MinDistIndexes(Table DistanceTable)
        {
            int minRow = 0;
            int minCol = 0;
            double minHeight = double.MaxValue;

            for (int i = 0; i < DistanceTable.Count; i++)
            {
                for (int j = 0; j < DistanceTable[i].Count; j++)
                {
                    if (DistanceTable[i][j] < minHeight && DistanceTable[i][j] != 0)
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

        private Table Create_DistanceTable() =>
            new() 
            { 
                new() { 0, 5, 0.5, 2 }, 
                new() { 5, 0, 1, 0.6 },
                new() { 0.5, 1, 0, 2.5},
                new() { 2, 0.6, 2.5, 0}
            };
        

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
