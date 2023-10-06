namespace lab6
{
    public struct TableCell
    {
        public int Row;
        public int Column;
        public double Value;

        public TableCell(int row, int column, double value)
        {
            Row = row;
            Column = column;
            Value = value;
        }
    }
}
