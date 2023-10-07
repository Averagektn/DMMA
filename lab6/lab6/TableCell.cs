namespace lab6
{
    /// <summary>
    ///     Represents a cell of a table with 2 indexes and value
    /// </summary>
    public struct TableCell
    {
        /// <summary>
        ///     First index
        /// </summary>
        public int Row;

        /// <summary>
        ///     Second index
        /// </summary>
        public int Column;

        /// <summary>
        ///     Payload
        /// </summary>
        public double Value;

        /// <summary>
        ///     Creates table cell
        /// </summary>
        /// <param name="row">
        ///     Row index
        /// </param>
        /// <param name="column">
        ///     Column index
        /// </param>
        /// <param name="value">
        ///     Payload
        /// </param>
        public TableCell(int row, int column, double value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

    }

}
