using System;
using System.Drawing;

namespace WeekPlanner
{
    /// <summary>
    /// Item to add to row
    /// </summary>
    public class WeekPlannerItem : iWeekPlannerItem
    {
        private int _layer;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _subject;
        private Rectangle _rectangle;
        private bool _isResizingStartDate;
        private bool _isResizingEndDate;
        private Color _backColor;
        private WeekPlannerGrid _calendar;
        private string _backData;

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

        public WeekPlannerItem()
        {
            _backColor = WeekPlannerColorTable.ItemBackgroundColor;
        }

        public WeekPlannerItem(WeekPlannerGrid c)
        {
            _calendar = c;
            _backColor = WeekPlannerColorTable.ItemBackgroundColor;
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                if (_calendar != null)
                {
                    _calendar.ResetLayers();
                    _calendar.Invalidate();
                }
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                if (_calendar != null)
                {
                    _calendar.ResetLayers();
                    _calendar.Invalidate();
                }
            }
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                if (_calendar != null)
                {
                    _calendar.ResetLayers();
                    _calendar.Invalidate();
                }
            }
        }

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        public string backData
        {
            get;
            set;
        }

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        internal int Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }

        public Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                if (_calendar != null)
                {
                    //_calendar.ResetLayers();
                    _calendar.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating if item is being resized by the <see cref="StartDate"/>
        /// </summary>
        internal bool IsResizingStartDate
        {
            get { return _isResizingStartDate; }
        }

        /// <summary>
        /// Gets a value indicating if item is being resized by the <see cref="EndDate"/>
        /// </summary>
        internal bool IsResizingEndDate
        {
            get { return _isResizingEndDate; }
        }


        /// <summary>
        /// Gets a value indicating if the specified point is in a resize zone of <see cref="EndDate"/>
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal bool ResizeEndDateZone(Point p)
        {
            int margin = 4;
            return EndDate.Date <= _calendar.CurrentDate.AddDays(_calendar.DayCount - 1) && Rectangle.FromLTRB(_rectangle.Right - margin, _rectangle.Top, _rectangle.Right, _rectangle.Bottom).Contains(p);

        }


        /// <summary>
        /// Gets a value indicating if the specified point is in a resize zone of <see cref="StartDate"/>
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal bool ResizeStartDateZone(Point p)
        {
            int margin = 4;
            return StartDate.Date >= _calendar.CurrentDate && Rectangle.FromLTRB(_rectangle.Left, _rectangle.Top, _rectangle.Left + margin, _rectangle.Bottom).Contains(p);

        }

        /// <summary>
        /// Sets the value of the <see cref="IsResizingStartDate"/> property
        /// </summary>
        /// <param name="resizing"></param>
        internal void SetIsResizingStartDate(bool resizing)
        {
            _isResizingStartDate = resizing;
        }

        /// <summary>
        /// Sets the value of the <see cref="IsResizingEndDate"/> property
        /// </summary>
        /// <param name="resizing"></param>
        internal void SetIsResizingEndDate(bool resizing)
        {
            _isResizingEndDate = resizing;
        }

    }
}
