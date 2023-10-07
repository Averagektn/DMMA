namespace lab6
{
    /// <summary>
    /// 
    /// </summary>
    public struct TableCell
    {
        /// <summary>
        /// 
        /// </summary>
        public int Row;

        /// <summary>
        /// 
        /// </summary>
        public int Column;

        /// <summary>
        /// 
        /// </summary>
        public double Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">
        /// 
        /// </param>
        /// <param name="column">
        /// 
        /// </param>
        /// <param name="value">
        /// 
        /// </param>
        public TableCell(int row, int column, double value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

    }

}
