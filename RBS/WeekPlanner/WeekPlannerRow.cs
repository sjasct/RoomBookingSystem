using System.Drawing;

namespace WeekPlanner
{
    /// <summary>
    /// Row to add to calendar
    /// </summary>
    public class WeekPlannerRow : iWeekPlannerRow
    {
        private WeekPlannerGrid _calendar;
        private WeekPlannerItemCollection _items;
        private DataColumns _columns;
        private Color _backColor;
        private bool _isCollapsible;
        private Color _leftMarginOldBackColor;
        private Color _leftMarginBackColor;
        private bool _isVisible = true;

        internal WeekPlannerGrid Calendar
        {
            set
            {
                _calendar = value;
            }
            get
            {
                return _calendar;
            }
        }

        public WeekPlannerRow()
        {
            if(_calendar!=null)
            _backColor = _calendar.BackColor;
            _leftMarginBackColor = WeekPlannerColorTable.LeftMarginColor;
        }

        public WeekPlannerRow(WeekPlannerGrid c)
        {
            _calendar = c;
            _backColor = _calendar.BackColor;
            _leftMarginBackColor = WeekPlannerColorTable.LeftMarginColor;
        }

        /// <summary>
        /// Name of the row
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the ancestor row
        /// </summary>
        public string AncestorName
        {
            get;
            set;
        }

        public bool IsExpanded { set; get; }

        /// <summary>
        /// Count of layers at row
        /// </summary>
        public int LayerCount
        {
            get;
            set;
        }

        /// <summary>
        /// Columns with data at row
        /// </summary>
        public DataColumns Columns
        {
            set
            {
                _columns = value;
            }
            get
            {
                return _columns;
            }
        }

        /// <summary>
        /// Level of the row
        /// </summary>
        public int Level
        {
            get;
            set;
        }

        /// <summary>
        /// Color of row
        /// </summary>
        public Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                if (_calendar != null)
                {
                    _calendar.Invalidate();
                }
            }
        }

        /// <summary>
        /// Color of the left margin row
        /// </summary>
        public Color LeftMarginBackColor
        {
            get { return _leftMarginBackColor; }
            set
            {
                _leftMarginBackColor = value;
                if (_calendar != null)
                {
                    _calendar.Invalidate();
                }
            }
        }

        /// <summary>
        /// Is it visible row 
        /// </summary>
        public bool IsVisible
        {
            set
            {
                _isVisible = value;
                if (_calendar != null)
                {
                    _calendar.Invalidate();
                }
            }
            get
            {
                return _isVisible;
            }
        }


        /// <summary>
        /// Is it clickable row for collapsing
        /// </summary>
        public bool IsCollapsible
        {
            set
            {
                _isCollapsible = value;
                if (_calendar != null)
                {
                    _calendar.Invalidate();
                }
            }
            get
            {
                return _isCollapsible;
            }
        }


        /// <summary>
        /// Old Color of the left margin row
        /// </summary>
        public Color LeftMarginOldBackColor
        {
            get { return _leftMarginOldBackColor; }
            set
            {
                _leftMarginOldBackColor = value;
                if (_calendar != null)
                {
                    _calendar.Invalidate();
                }
            }

        }

        /// <summary>
        /// List of items at row
        /// </summary>
        public WeekPlannerItemCollection Items
        {
            set
            {
                _items = value;
                if (_calendar != null)
                {
                    _items.Calendar = _calendar;
                }
            }
            get
            {
                return _items;
            }
        }

    }
}
