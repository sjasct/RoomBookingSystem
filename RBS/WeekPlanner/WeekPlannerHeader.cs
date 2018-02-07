using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace WeekPlanner
{
    [DesignTimeVisibleAttribute(false)]
    public partial class WeekPlannerHeader : Control, iWeekHeader
    {
        private Font _headerColumnsFont;
        private Font _headerDatesFont;
        private DateTime _currentDate;
        private Color _borderColor;
        private Color _headerFillColor;
        private Color _headerFillLeftMarginColor;
        private int _leftMargin;
        private int _dayCount = 1;
        private DataColumns _columns;
        private WeekPlannerMode _datesIntervalMode;
        private HeaderStyle _headerStyleMode;

        #region iWeek members

        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public int DayCount
        {
            get
            {
                return _dayCount;
            }
            set
            {
                _dayCount = value;
                Invalidate();
            }
        }

        public int LeftMargin
        {
            get
            {
                return _leftMargin;
            }
            set
            {
                _leftMargin = value;
                Invalidate();
            }
        }

        public DataColumns Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
                Invalidate();
            }
        }

        #endregion

        #region iWeekHeader members

        public Font HeaderColumnsFont
        {
            get { return _headerColumnsFont; }
            set
            {
                _headerColumnsFont = value;
                Invalidate();
            }
        }

        public Font HeaderDatesFont
        {
            get { return _headerDatesFont; }
            set
            {
                _headerDatesFont = value;
                Invalidate();
            }
        }


        public Color HeaderFillColor
        {
            get { return _headerFillColor; }
            set
            {
                _headerFillColor = value;
                Invalidate();
            }
        }

        public Color HeaderFillLeftMarginColor
        {
            get { return _headerFillLeftMarginColor; }
            set
            {
                _headerFillLeftMarginColor = value;
                Invalidate();
            }
        }

        public Color HeaderBackgroundColor
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        public HeaderStyle HeaderStyleMode
        {
            get { return _headerStyleMode; }
            set
            {
                _headerStyleMode = value;
                Invalidate();
            }
        }

        public WeekPlannerMode DatesIntervalMode
        {
            get { return _datesIntervalMode; }
            set
            {
                _datesIntervalMode = value;
                Invalidate();
            }
        }

        #endregion

        public WeekPlannerHeader()
        {
            _columns = new DataColumns();
            _headerColumnsFont = new Font("Times New Roman", 8F, FontStyle.Bold);
            _headerDatesFont = new Font("Times New Roman", 8F, FontStyle.Bold);


            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        private void DrawHeader(Graphics graphics)
        {
            int step = (Width - _leftMargin) / _dayCount;

            int oldXCoord = _leftMargin;
            int XCoord = _leftMargin;

            DateTime dt = CurrentDate;

            int week = GetWeekNumber(_currentDate);
            int weekNew = GetWeekNumber(_currentDate);


            int modeFirstCoord = _leftMargin;
            int modeSecondCoord = _leftMargin;

            //Draws header fill rect
            var Rect = new Rectangle(_leftMargin, Height / 2, Width - _leftMargin, Height / 2);
            
            if (HeaderStyleMode == HeaderStyle.Aqua)
            {
                using (LinearGradientBrush gradientBrush = WeekPlannerColorTable.HeaderGradientBackBrush(Rect, _headerFillColor))
                {
                    graphics.FillRectangle(gradientBrush, Rect);
                }
            }
            else
            {
                using (var gradientBrush = new SolidBrush(_headerFillColor))
                {
                    graphics.FillRectangle(gradientBrush, Rect);
                }
            }
            


            //Draws header border rect
            using (Pen pen = new Pen(BorderColor))
            {
                graphics.DrawLine(pen, new Point(0, Height / 2), new Point(Width, Height / 2));
                graphics.DrawLine(pen, new Point(0, Height - 1), new Point(Width, Height - 1));
            }

            for (int i = 0; i < _dayCount; i++)
            {
                //Draws Week Days and Dates
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    string _date;
                    var sf = new StringFormat();
                    var rect = new Rectangle();

                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    //Draws vertical lines
                    Point p1 = new Point(XCoord, Height / 2);
                    Point p2 = new Point(XCoord, Height - 2);
                    using (Pen pen = new Pen(BorderColor))
                    {
                        if (i == 0) p1 = new Point(XCoord, 0);
                        graphics.DrawLine(pen, p1, p2);
                    }

                    if (i == 0)
                    {
                        _date = dt.AddDays(i).Day + " " + dt.AddDays(i).ToString("MMM");
                    }
                    else
                    {
                        _date = dt.AddDays(i).Day.ToString();
                    }

                    if (DatesIntervalMode == WeekPlannerMode.Daily)
                    {
                        //Draws day of week
                        graphics.DrawString(dt.AddDays(i).DayOfWeek.ToString().Substring(0, 3), _headerDatesFont, brush, XCoord, 2);

                        //Draws daily mode vertical lines
                        p1 = new Point(XCoord, 1);
                        p2 = new Point(XCoord, Height - 2);
                        using (Pen pen = new Pen(BorderColor))
                        {
                            graphics.DrawLine(pen, p1, p2);
                        }
                    }

                    //Draws week numbes
                    if (DatesIntervalMode == WeekPlannerMode.Weekly)
                    {
                        weekNew = GetWeekNumber(dt.AddDays(i));

                        if (week != weekNew)
                        {
                            modeSecondCoord = XCoord;
                            rect = new Rectangle(modeFirstCoord, 0, modeSecondCoord - modeFirstCoord, Height / 2);

                            //Draws weekly mode vertical lines
                            graphics.DrawString("Week:" + week, _headerDatesFont, brush, rect, sf);
                            using (Pen pen = new Pen(BorderColor))
                            {
                                graphics.DrawLine(pen, modeSecondCoord, 0, modeSecondCoord, Height / 2);
                            }
                            week = weekNew;
                            modeFirstCoord = XCoord;
                        }

                        if (i == _dayCount - 1)
                        {
                            modeSecondCoord = Width;
                            rect = new Rectangle(modeFirstCoord, 0, modeSecondCoord - modeFirstCoord, Height / 2);

                            graphics.DrawString("Week:" + week, _headerDatesFont, brush, rect, sf);
                        }
                    }


                    oldXCoord = XCoord;
                    XCoord += step;

                    //Draws dates
                    rect = new Rectangle(oldXCoord, Height / 2, XCoord - oldXCoord, Height / 2);
                    graphics.DrawString(_date, _headerDatesFont, brush, rect, sf);

                }

            }
        }

        void DrawLeftMargin(Graphics graphics)
        {
            var XCoord = 0;

            //Draws header fill rect
            var rect = new Rectangle(0, Height / 2, _leftMargin, Height / 2);

            if (HeaderStyleMode == HeaderStyle.Aqua)
            {
                using (LinearGradientBrush gradientBrush = WeekPlannerColorTable.HeaderGradientBackBrush(rect,_headerFillLeftMarginColor))
                    {
                        graphics.FillRectangle(gradientBrush, rect);
                    }
            }
            else
            {
                using (var gradientBrush = new SolidBrush(_headerFillLeftMarginColor))
                    {
                        graphics.FillRectangle(gradientBrush, rect);
                    }
            }



            for (int i = 0; i < _columns.Count; i++)
           {
                int rectWidth = _columns[i].Width;
                if (i == Columns.Count-1) rectWidth = LeftMargin - XCoord;
                Rectangle Rect = new Rectangle(XCoord, Height / 2, rectWidth, Height / 2);

                //Draws item text
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString(Columns[i].Text, _headerColumnsFont, brush, Rect, sf);
                }

                //Draws vertical lines
                XCoord += Columns[i].Width;
                Point p1 = new Point(XCoord, Height / 2);
                Point p2 = new Point(XCoord, Height - 2);
                using (Pen pen = new Pen(BorderColor))
                {
                    if (i < Columns.Count - 1)
                   graphics.DrawLine(pen, p1, p2);
                }
           }

        }

        static int GetWeekNumber(DateTime dtDate)
        {
            CultureInfo ciGetNumber = CultureInfo.CurrentCulture;
            int returnNumber = ciGetNumber.Calendar.GetWeekOfYear(dtDate, CalendarWeekRule.FirstFourDayWeek,
                                                                  DayOfWeek.Monday);
            return returnNumber;
        }

        #region "Drawing Methods"

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Height > 1)
            {
                
                if (Columns != null) DrawLeftMargin(e.Graphics);
                DrawHeader(e.Graphics);
            }
            base.OnPaint(e);
        }

        #endregion
    }
}
