using System;

namespace WeekPlanner
{
    /// <summary>
    /// Stores column number with it coordinates
    /// </summary>
    internal class CoordColumn
    {
        public CoordColumn(int column, int firstCoord, int secondCoord, DateTime dateValue)
        {
            Column = column;
            FirstCoord = firstCoord;
            SecondCoord = secondCoord;
            DateValue = dateValue;
        }

        public int Column { get; set; }
        public int FirstCoord { get; set; }
        public int SecondCoord { get; set; }
        public DateTime DateValue { get; set; }
    }

    /// <summary>
    /// Stores row number with it coordinates
    /// </summary>
    internal class CoordRow
    {
        public CoordRow(int row, int firstCoord, int secondCoord)
        {
            RowIndex = row;
            FirstCoord = firstCoord;
            SecondCoord = secondCoord;
        }

        public int RowIndex { get; set; }
        public int FirstCoord { get; set; }
        public int SecondCoord { get; set; }
    }
}
