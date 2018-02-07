using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WeekPlanner
{
    /// <summary>
    /// Columns with header and data
    /// </summary>
    public class DataValue
    {
        public DataValue(string name,string text, int width, ValueColorCollection data)
        {
            this.name = name;
            this.data = data;
            this.width = width;
            this.text = text;
        }

        /// <summary>
        /// Name of column
        /// </summary>
        public string Name
        {
            get
            {
                return (name);
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Text for header of column
        /// </summary>
        public string Text
        {
            get
            {
                return (text);
            }
            set
            {
                text = value;
            }
        }

        /// <summary>
        /// Width of column
        /// </summary>
        public int Width
        {
            get
            {
                return (width);
            }
            set
            {
                width = value;
            }
        }

        /// <summary>
        /// List of Data for column
        /// </summary>
        public ValueColorCollection Data
        {
            get
            {
                return (data);
            }
            set
            {
                data = value;
            }
        }
        string name;
        string text;
        int width;
        ValueColorCollection data;
    }



    /// <summary>
    /// Data for columns
    /// </summary>
    public class ValueColor
    {
        string text;
        Color datacolor;

        public ValueColor(string name, Color color)
        {
            this.text = name;
            this.datacolor = color;
        }

        public string Text
        {
            get
            {
                return (text);
            }
            set
            {
                text = value;
            }
        }


        public Color DataColor
        {
            get
            {
                return (datacolor);
            }
            set
            {
                datacolor = value;
            }
        }

        
    }




    /// <summary>
    /// List of Data for columns
    /// </summary>
    public class ValueColorCollection : List<ValueColor>
    {
        public WeekPlannerGrid Calendar
        {
            get { return _calendar; }
        }

        private readonly WeekPlannerGrid _calendar;


        internal ValueColorCollection(WeekPlannerGrid c)
        {
            _calendar = c;
        }

        public void Add(string text, Color color)
        {
            ValueColor item = new ValueColor(text, color);
            Add(item);
            if (Calendar != null) Calendar.Invalidate();
        }

        public void Add(string text)
        {
            
            ValueColor item = new ValueColor(text,Color.Black);
            base.Add(item);
            if (Calendar != null) Calendar.Invalidate();
        }

        public new void Clear()
        {
            base.Clear();
            if (Calendar != null) Calendar.Invalidate();
        }
    }




    /// <summary>
    /// Data columns with named indexes
    /// </summary>
    public class DataColumns
    {

        public WeekPlannerGrid Calendar
        {
            get { return _calendar; }
        }

        private readonly WeekPlannerGrid _calendar;

        public DataColumns(WeekPlannerGrid c)
        {
            _calendar = c;

            row = new ArrayList();

            if (Calendar != null && Calendar.Columns!=null)
            {
                for (int index = 0; index < Calendar.Columns.row.Count; index++)
                {
                    DataValue dataValue = (DataValue)Calendar.Columns.row[index];
                    Add(dataValue.Name, dataValue.Text, dataValue.Width);
                    // Calendar = Calendar;
                }
            }
        }

        public DataColumns()
        {
            row = new ArrayList();

        }

        public void Add(string ColumnName,string Text, int width)
        {
            var listValue = new ValueColorCollection(Calendar);

            row.Add(new DataValue(ColumnName, Text, width, listValue));
        }

        /// <summary>
        /// Clears all data in columns
        /// </summary>
        public void Clear()
        {
            foreach (DataValue dataValue in row.Cast<DataValue>())
            {
                dataValue.Data.Clear();
            }
        }

        ///// <summary>
        ///// Copies columns header
        ///// </summary>
        //public void CloneHeader(DataColumns dataCol)
        //{
        //    for (int index = 0; index < row.Count; index++)
        //    {
        //        DataValue dataValue = (DataValue)row[index];
        //        dataCol.Add(dataValue.Name, dataValue.Text, dataValue.Width);
        //        dataCol.Calendar = Calendar;
        //    }
        //}

        public int Count
        {
            get
            {
                return row.Count;
            }
        }

        public DataValue this[int column]
        {
            get
            {
                 return ((DataValue)row[column]);
            }
            set
            {
                row[column] = value;
            }
        }

        int FindColumn(string name)
        {
            for (int index = 0; index < row.Count; index++)
            {
                DataValue dataValue = (DataValue)row[index];
                if (dataValue.Name == name)
                    return (index);
            }
            return (-1);
        }

        public DataValue this[string name]
        {
            get
            {
                return this[FindColumn(name)];
            }
            set
            {
                this[FindColumn(name)] = value;
            }
        }
        ArrayList row;
    }
}
