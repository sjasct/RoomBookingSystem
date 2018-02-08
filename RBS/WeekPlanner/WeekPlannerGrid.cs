using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;


namespace WeekPlanner
{
    [DesignTimeVisibleAttribute(false)]
    public partial class WeekPlannerGrid : ScrollableControl, iWeekGrid
    {

        /// <summary>
        /// Possible states of the WeekPlanner
        /// </summary>
        public enum PlannerState
        {
            /// <summary>
            /// Nothing happening
            /// </summary>
            Idle,

            /// <summary>
            /// User is currently dragging an item among the view
            /// </summary>
            DraggingItem,

            /// <summary>
            /// User is editing an item's Text
            /// </summary>
            EditingItemText,

            /// <summary>
            /// User is currently resizing an item
            /// </summary>
            ResizingItem
        }

        public CalendarPlanner planner;

        #region " Internal Classes "

        /// <summary>
        /// Gets the TextBox of the edit mode
        /// </summary>
        internal CalendarTextBox TextBox
        {
            get { return _textBox; }
            set { _textBox = value; }
        }

        #endregion

        #region private fields

        private int outRow = -1;// row to detect when cursor leaves row in the left margin
        private DataColumns _columns;
        private int rowNumer = 0; // row to detect when it changes during dragging
        TimeSpan durationStart;
        TimeSpan durationEnd;
        DateTime moveDate;
        private PlannerState _state;
        private CalendarTextBox _textBox;
        private WeekPlannerItem _editModeItem;
        private WeekPlannerItem itemOnState;

        private const int smallWhiteRectWidth = 3;
        private const int shadowItemRect = 3;

        private int _dayCount = 1;

        private Font _gridFont;
        private Font _itemFont;
        private Point mouseClickPosition;
        private Point mouseClickScrollPosition;

        List<CoordRow> RowCoord = new List<CoordRow>();
        List<CoordColumn> ColumnCoord = new List<CoordColumn>();

        private WeekPlannerRowCollection listRows; // List of rows to add to the calendar
        private WeekPlannerItem _selectedItem;
        WeekPlannerItem outHittedItem = null; // to detect when mouse leaves the item

        private int _selectedRow = -1;
        private int _selectedColumn;
        private DateTime _selectedCellDate;

        private DateTime _currentDate;
        private Color _borderColor;
        private Color _leftMarginColor;
        private readonly Color smallRectColor = Color.White;
        private readonly Color selectedItemBorderColor = Color.DeepSkyBlue;
        private readonly Color itemBorderColor = Color.DarkBlue;

        private readonly Color shadowColor = Color.SlateGray;

        int VerticalStep;// step to draw according to vertcal coordinates
        private bool itemOnStateChanged;

        #endregion

        #region iWeek members


        public Point WeekPlannerScrollPosition
        {
            get
            {
                return AutoScrollPosition;
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

        public DateTime CurrentDate
        {
            get
            {
                return _currentDate.Date;
            }
            set
            {
                _currentDate = value;

                if (listRows != null)
                {
                    ResetLayers();
                }
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


        public int LeftMargin
        {
            get;
            set;
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

        #region iWeekGrid members


        public WeekPlannerRowCollection Rows
        {
            get
            {
                return listRows;
            }
        }

        public int GridCellHeight
        {
            get;
            set;
        }

        public int ItemHeight
        {
            get;
            set;
        }

        public bool IsAllowedDraggingBetweenRows
        {
            get;
            set;
        }

        public bool IsAllowedTreeViewDrawing
        {
            get;
            set;
        }


        public Font ItemTextFont
        {
            get { return _itemFont; }
            set
            {
                _itemFont = value;
                Invalidate();
            }
        }


        public Font GridTextFont
        {
            get { return _gridFont; }
            set
            {
                _gridFont = value;
                Invalidate();
            }
        }

        public Color GridBackgroundColor
        {
            get { return BackColor; }
            set { BackColor = value; }
        }
        public Color LeftMarginColor
        {
            get { return _leftMarginColor; }
            set
            {
                _leftMarginColor = value;
                Invalidate();
            }
        }

        public int SelectedRowIndex
        {
            get
            {
                return _selectedRow;
            }

            internal set
            {
                _selectedRow = value;
            }
        }

        public int SelectedColumn
        {
            get
            {
                return _selectedColumn;
            }
        }

        public DateTime SelectedCellDate
        {
            get
            {
                return _selectedCellDate;
            }
        }

        /// <summary>
        /// Gets the item being edited (if any)
        /// </summary>
        public WeekPlannerItem EditModeItem
        {
            get
            {
                return _editModeItem;
            }
        }

        /// <summary>
        /// Gets the  selected item
        /// </summary>
        public WeekPlannerItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
        }

        /// <summary>
        /// Gets the  row count
        /// </summary>
        public int RowCount
        {
            get
            {
                return listRows.Count;
            }
        }

        /// <summary>
        /// Gets or sets the state of the calendar
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PlannerState State
        {
            get { return _state; }
        }

        #endregion

        /// <summary>
        /// Row height before it was increased
        /// </summary>
        internal int OldCellHeight
        {
            get;
            set;
        }

        public WeekPlannerGrid()
        {
            listRows = new WeekPlannerRowCollection(this);
            _columns = new DataColumns(this);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            _itemFont = _gridFont = new Font("Times New Roman", 8F, FontStyle.Bold);

            AutoScroll = true;

            AutoScrollMinSize = new Size(10, GridCellHeight); // drawing for an area of 100 x GridCellHeight
        }

        #region "Drawing Methods"

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Point pt = AutoScrollPosition;
            e.Graphics.TranslateTransform(pt.X, pt.Y);

            VerticalStep = (Width - LeftMargin) / _dayCount;

            if (listRows != null && listRows.Count > 0)
            {
                ResetLayers();
                DistributeRows();
                DrawGrid(e.Graphics);

            }
            base.OnPaint(e);

        }

        /// <summary>
        /// Draws text in the left margin cell
        /// </summary>
        private void DrawValueText(Graphics graphics, int rowNumber, int yTextLocation, int yLine)
        {
            var XCoord = 0;
            var sizeEllipse = 20;
            var data = listRows.ElementAt(rowNumber);

            for (int i = 0; i < data.Columns.Count; i++)
            {
                //Draws text
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                // Gets y coord according to row 
                var yy = RowCoord.Where(d => d.RowIndex == rowNumber).Single();

                // Gets y coord according to row 
                var yCoord = RowCoord.Where(d => d.RowIndex == rowNumber).Single();
                var cellHeight = yCoord.SecondCoord - yCoord.FirstCoord;
                int height = data.Columns[i].Data.Count * GridTextFont.Height;
                int y = (cellHeight - height) / 2 + yTextLocation;


                foreach (var item in data.Columns[i].Data)
                {
                    int rectWidth = _columns[i].Width;
                    if (i == data.Columns.Count - 1) rectWidth = LeftMargin - XCoord;

                    Rectangle textRect = new Rectangle(XCoord, y, rectWidth, y + GridTextFont.Height);

                    using (Brush brush = new SolidBrush(item.DataColor))
                    {
                        graphics.DrawString(item.Text, GridTextFont, brush, textRect, sf);
                    }
                    y += GridTextFont.Height;
                }

                XCoord += _columns[i].Width;

                //Draws vertical lines
                Point p1 = new Point(XCoord, yTextLocation);
                Point p2 = new Point(XCoord, yLine);
                Point p3 = new Point(XCoord + smallWhiteRectWidth, yTextLocation);
                Point p4 = new Point(XCoord + smallWhiteRectWidth, yLine);

                using (Pen pen = new Pen(Color.Black))
                {
                    if (i < data.Columns.Count - 1)
                    {
                        graphics.DrawLine(pen, p1, p2);
                        graphics.DrawLine(pen, p3, p4);

                        //Draws vertical white rectangles
                        using (var backBrush = new SolidBrush(smallRectColor))
                            graphics.FillRectangle(backBrush, XCoord, yTextLocation, smallWhiteRectWidth, yLine - yTextLocation);
                    }
                }

                // Draws dotted lines like in tree view
                if (i == 0 && IsAllowedTreeViewDrawing)
                {
                    var xLine = 0;
                    Pen linePen = new Pen(Color.Black, 2);
                    for (int l = 1; l <= data.Level + 1; l++)
                    {
                        var index = listRows.IndexOf(data);
                        xLine = l * sizeEllipse;
                        linePen.DashStyle = DashStyle.Dot;


                        if (index == 0)
                        {
                            graphics.DrawLine(linePen, xLine, cellHeight / 2 + yTextLocation, xLine,
                                              yLine);
                        }
                        else if (index == listRows.Count - 1)
                        {
                            graphics.DrawLine(linePen, xLine, yTextLocation, xLine,
                                              cellHeight / 2 + yTextLocation);
                        }
                        else
                        {
                            var nextRow = listRows.ElementAt(index + 1);
                            if (nextRow.Level < data.Level && l == data.Level + 1 && !data.IsCollapsible)
                            {
                                graphics.DrawLine(linePen, xLine, yTextLocation, xLine,
                                                  cellHeight / 2 + yTextLocation);
                            }
                            else
                            {
                                graphics.DrawLine(linePen, xLine, yTextLocation, xLine,
                                                  yLine);
                            }
                        }


                    }

                    graphics.DrawLine(linePen, xLine, cellHeight / 2 + yTextLocation, xLine + sizeEllipse,
                                      cellHeight / 2 + yTextLocation);
                }


                if (data.IsCollapsible)
                {

                    //Draws plus/minus
                    if (i == 0)
                    {

                        var xEllipse = (data.Level * 20) + 10;
                        int yEllipse = cellHeight / 2 + yTextLocation - sizeEllipse / 2;
                        using (Pen pen = new Pen(Color.DarkBlue))
                        {
                            graphics.DrawEllipse(pen, xEllipse, yEllipse, sizeEllipse, sizeEllipse);
                        }

                        var r = new Rectangle(xEllipse, yEllipse, sizeEllipse, sizeEllipse);
                        var brush = new SolidBrush(Color.White);
                        graphics.FillEllipse(brush, r);


                        Pen myPen;
                        myPen = new Pen(Color.Black, 2);

                        //Draws up arrow
                        if (data.IsExpanded)
                        {
                            graphics.DrawLine(myPen, xEllipse + 5, yEllipse + sizeEllipse / 2,
                                              xEllipse + sizeEllipse - 10,
                                              yEllipse + 5);

                            graphics.DrawLine(myPen, xEllipse + sizeEllipse - 10,
                                              yEllipse + 5, xEllipse + sizeEllipse - 5,
                                              yEllipse + sizeEllipse / 2);
                        }
                        //Draws down arrow
                        else
                        {
                            graphics.DrawLine(myPen, xEllipse + 5, yEllipse + sizeEllipse / 2,
                                              xEllipse + sizeEllipse / 2,
                                              yEllipse + sizeEllipse - 5);
                            graphics.DrawLine(myPen, xEllipse + sizeEllipse - 5, yEllipse + sizeEllipse / 2,
                                              xEllipse + sizeEllipse / 2,
                                              yEllipse + sizeEllipse - 5);
                        }
                    }

                    if (i == data.Columns.Count - 1)
                    {
                        //Draws shadow rect of the left margin column
                        using (var backBrush = new SolidBrush(shadowColor))
                        {
                            graphics.FillRectangle(backBrush, LeftMargin, yTextLocation, smallWhiteRectWidth,
                                                   yLine - yTextLocation);
                        }
                    }

                    //Draws shadow rect of the left margin column
                    using (var backBrush = new SolidBrush(shadowColor))
                    {
                        graphics.FillRectangle(backBrush, 0, yy.SecondCoord, LeftMargin, shadowItemRect);
                    }
                }
            }
        }

        /// <summary>
        /// Draws horizontal net lines and text in the left margin cell
        /// </summary>
        /// <returns>Are intersected items at the layer.</returns>
        private int DrawHorizLines(Graphics graphics, int xCoord)
        {
            int yCoord = 0;
            Rectangle colRect;
            Rectangle rowRect;

            for (int i = 0; i < listRows.Count; i++)
            {
                var row = listRows.ElementAt(i);
                if (row.IsVisible)
                {
                    var OldYCoord = yCoord;
                    var elementHeight = ItemHeight + shadowItemRect;
                    var height = elementHeight*row.LayerCount + 2*elementHeight;
                    //var height = 0;

                    if (height < GridCellHeight) height = GridCellHeight;
                    yCoord += height;
                    colRect = new Rectangle(0, OldYCoord, LeftMargin, height);
                    rowRect = new Rectangle(0, OldYCoord + 1, this.Width, height - 2);


                    //using (var backBrush = new SolidBrush(_leftMarginColor))
                    //    graphics.FillRectangle(backBrush, colRect);

                    ////Draws background color of the row
                    var backColor = listRows.ElementAt(i).BackColor;
                    var marginBackColor = listRows.ElementAt(i).LeftMarginBackColor;
                    //if (backColor != BackColor)
                    //{
                    //    using (var backBrush = new SolidBrush(backColor))
                    //        graphics.FillRectangle(backBrush, rowRect);
                    //}

                    int sHeight = 3;

                    ////////////////////////////////////////////////////////////////////////
                    //Draws background color of the row
                    using (var backBrush = new SolidBrush(backColor))
                        graphics.FillRectangle(backBrush, new Rectangle(LeftMargin, OldYCoord + 1, this.Width, height - 2));

                    //Draws background color of the left margin row
                    var leftMarginRect = new Rectangle(0, OldYCoord + sHeight, LeftMargin, height - sHeight);
                    using (var backBrush = new SolidBrush(marginBackColor))
                        graphics.FillRectangle(backBrush, leftMarginRect);
                    /////////////////////////////////////////////////////////////////////

                    //Horizontal Lines
                    Point p1 = new Point(xCoord, yCoord);
                    Point p2 = new Point(Width, yCoord);
                    using (Pen pen = new Pen(_borderColor))
                    {
                        graphics.DrawLine(pen, p1, p2);
                    }



                    //Adds number of level with coordinates to list
                    RowCoord.Add(new CoordRow(i, OldYCoord, yCoord));

                    //Draws text in value cells
                    DrawValueText(graphics, i, OldYCoord, yCoord);
                }
            }

            return yCoord;
        }

        /// <summary>
        /// Distribute Items by row Layers strarting from provided layer
        /// </summary>
        /// <param name="row">Current row</param>
        /// <param name="layerNumber">Layer below which distribute Items</param>
        /// <returns>Are there intersected items at the layer.</returns>
        bool DistributeLayers(WeekPlannerRow row, int layerNumber)
        {
            bool isIntersection = false;
            //Selects all items at the row by layer number
            //var listLayer = row.Items.Where(l => l.Layer == layerNumber &&
            //    Helper.isDatesIntersect(CurrentDate.Date, CurrentDate.Date.AddDays(DayCount), l.StartDate.Date, l.EndDate.Date) ||
             //   Helper.isDatesIntersect(l.StartDate.Date, l.EndDate.Date, CurrentDate.Date, CurrentDate.Date.AddDays(DayCount))).ToList();
            var listLayer = row.Items.Where(l => l.Layer == layerNumber).ToList();

            foreach (var item in listLayer)
            {
                //if item is already distributed at the layer
                if (item.Layer == layerNumber)
                {
                    // Looks for the items which intersect with the provided item
                    var intersectItems = IntersectedItems(item, listLayer);
                    if (intersectItems.Count() > 0)
                    {
                        isIntersection = true;
                        // Intescted items increase layer number
                        foreach (var i in intersectItems)
                        {
                            i.Layer++;
                        }
                    }
                }

            }

            return isIntersection;
        }

        /// <summary>
        /// Looks for the items which intersect with the provided item
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <param name="items">List of items in which checks intersection</param>
        /// <returns>Collection of inersected items.</returns>
        public IEnumerable<WeekPlannerItem> IntersectedItems(WeekPlannerItem item, List<WeekPlannerItem> items)
        {
            foreach (var i in items)
            {
                if (item == i) continue;
                var isIntersect = isDatesIntersect(item.StartDate.Date, item.EndDate.Date, i.StartDate.Date, i.EndDate.Date);
                var isIntersect2 = isDatesIntersect(i.StartDate.Date, i.EndDate.Date, item.StartDate.Date, item.EndDate.Date);

                if ((isIntersect || isIntersect2) && item.Layer == i.Layer)
                {
                    yield return i;
                }
            }
        }

        /// <summary> 
        /// Checks does date range intersect with another date range
        /// </summary> 
        static bool isDatesIntersect(DateTime d1_Start, DateTime d1_End, DateTime d2_Start, DateTime d2_End)
        {
            return (d2_Start <= d1_End && d2_Start >= d1_Start || d2_End >= d1_Start && d2_End <= d1_End);
        }

        /// <summary>
        /// perform items layout by layers at the provided row
        /// </summary>
        /// <returns>Count of layers at the row</returns>
        private int PerformItemsLayout(WeekPlannerRow row)
        {
            var count = 0;
            for (int i = 0; i <= count; i++)
            {
                //if found intersected items at the layer increase layer count
                if (DistributeLayers(row, i)) count++;
            }
            row.LayerCount = count;
            return count;
        }

        /// <summary>
        /// perform items layout by layers at the all rows
        /// </summary>
        private void DistributeRows()
        {
            foreach (var row in listRows)
            {
                PerformItemsLayout(row);
            }

        }

        /// <summary>
        /// Draws calendar item according to dates
        /// </summary>
        private void DrawItems(Graphics graphics)
        {

            foreach (var row in listRows)
            {
                if (row.IsVisible)
                {
                    foreach (var item in row.Items)
                    {
                        var isSelected = item == _selectedItem;
                        var level = listRows.IndexOf(row);


                        DateTime dStart = item.StartDate.Date;
                        DateTime dEnd = item.EndDate.Date;

                        // Looks for the left x coord according to date
                        var x1 = ColumnCoord.Where(d => d.DateValue.Date == dStart).SingleOrDefault();
                        // Gets y coord according to row 
                        var yCoord = RowCoord.Where(d => d.RowIndex == level).SingleOrDefault();
                        // Looks for the right x coord according to date
                        var x2 = ColumnCoord.Where(d => d.DateValue.Date == dEnd).SingleOrDefault();

                        int y = yCoord.FirstCoord + item.Layer*(ItemHeight + shadowItemRect);

                        int width;
                        Rectangle rect;
                        // if Start Date and End Date in the week interval
                        if (dStart >= CurrentDate && dEnd <= CurrentDate.AddDays(_dayCount - 1))
                        {
                            width = x2.SecondCoord - x1.FirstCoord - 2*smallWhiteRectWidth;

                            if (item.Rectangle.Width == 0 && item.Rectangle.Height == 0)
                            {
                                rect = new Rectangle(x1.FirstCoord + smallWhiteRectWidth, y, width, ItemHeight);
                                item.Rectangle = rect;
                            }
                            else
                            {
                                rect = item.Rectangle;
                            }

                            DrawItemRect(graphics, item.Subject, rect.X, rect.Y, rect.Width, rect.Height, true, true,
                                         item.BackColor, isSelected);
                        }

                        // if End Date is not in the week interval
                        if (dStart >= CurrentDate && dEnd > CurrentDate.AddDays(_dayCount - 1) && x1 != null)
                        {
                            width = Width - x1.FirstCoord;
                            if (item.Rectangle.Width == 0 && item.Rectangle.Height == 0)
                            {
                                rect = new Rectangle(x1.FirstCoord + smallWhiteRectWidth, y, width, ItemHeight);
                                item.Rectangle = rect;
                            }
                            else
                            {
                                rect = item.Rectangle;
                            }


                            DrawItemRect(graphics, item.Subject, rect.X, rect.Y, rect.Width, rect.Height, true, false,
                                         item.BackColor, isSelected);
                        }

                        // if Start Date is not in the week interval
                        if (dStart < CurrentDate && dEnd <= CurrentDate.AddDays(_dayCount - 1) && x2 != null)
                        {
                            width = x2.SecondCoord - LeftMargin - smallWhiteRectWidth;
                            if (item.Rectangle.Width == 0 && item.Rectangle.Height == 0)
                            {
                                rect = new Rectangle(LeftMargin, y, width, ItemHeight);
                                item.Rectangle = rect;
                            }
                            else
                            {
                                rect = item.Rectangle;
                            }

                            DrawItemRect(graphics, item.Subject, rect.X, rect.Y, rect.Width, rect.Height, false, true,
                                         item.BackColor, isSelected);
                        }

                        // if Start Date is not in the week interval
                        if (dStart < CurrentDate && dEnd > CurrentDate.AddDays(_dayCount - 1))
                        {
                            width = Width - LeftMargin;
                            if (item.Rectangle.Width == 0 && item.Rectangle.Height == 0)
                            {
                                rect = new Rectangle(LeftMargin, y, width, ItemHeight);
                                item.Rectangle = rect;
                            }
                            else
                            {
                                rect = item.Rectangle;
                            }

                            DrawItemRect(graphics, item.Subject, rect.X, rect.Y, rect.Width, rect.Height, false, true,
                                         item.BackColor, isSelected);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Draws calendar single item rectangle and text
        /// </summary>
        private void DrawItemRect(Graphics graphics, string text,
            int x, int y, int width, int height,
            bool isDrawLeftBorder,
            bool isDrawRightBorder,
            Color backColor,
            bool isSelected)
        {
            Rectangle Rect = new Rectangle(x, y, width, height);

            //Draws shadow rect
            using (SolidBrush backBrush = new SolidBrush(Color.SlateGray))
                graphics.FillRectangle(backBrush, Rect.X + shadowItemRect, Rect.Y, Rect.Width, Rect.Height + shadowItemRect);

            //draws item rect
            if (width > 0 && height > 0)
            {
                using (LinearGradientBrush gradientBrush = WeekPlannerColorTable.ItemGradientBackBrush(Rect, backColor))
                {
                    graphics.FillRectangle(gradientBrush, Rect);
                }
            }

            // Draws border
            Point p1 = new Point(x, y);
            Point p2 = new Point(x + width, y);
            Point p3 = new Point(x + width, y + height);
            Point p4 = new Point(x, y + height);

            Pen pen = new Pen(itemBorderColor);
            if (isSelected)
                pen = new Pen(selectedItemBorderColor, 3);

            using (pen)
            {
                graphics.DrawLine(pen, p1, p2);
                if (isDrawRightBorder) graphics.DrawLine(pen, p2, p3);
                graphics.DrawLine(pen, p3, p4);
                if (isDrawLeftBorder) graphics.DrawLine(pen, p4, p1);
            }


            //Draws item text
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                graphics.DrawString(text, ItemTextFont, brush, Rect, sf);
            }
        }

        /// <summary>
        /// Draws vertical net lines
        /// </summary>
        private void DrawVertLines(Graphics graphics, int xCoord, int yCoord)
        {
            int lineWidth = 1;
            for (int i = 0; i < _dayCount; i++)
            {
                var OldXCoord = xCoord - lineWidth;
                //Vertical lines coordinates
                Point p1 = new Point(xCoord, 1);
                Point p2 = new Point(xCoord, yCoord);

                Point p3 = new Point(xCoord + smallWhiteRectWidth, 1);
                Point p4 = new Point(xCoord + smallWhiteRectWidth, yCoord);

                using (Pen pen = new Pen(Color.Black, lineWidth))
                {
                    //Draws vertical lines
                    graphics.DrawLine(pen, p1, p2);
                    graphics.DrawLine(pen, p3, p4);

                    //Draws vertical white rectangles
                    using (var backBrush = new SolidBrush(smallRectColor))
                        graphics.FillRectangle(backBrush, xCoord, 1, smallWhiteRectWidth, yCoord);
                }
                if (i == _dayCount - 1 && VerticalScroll.Visible)
                    xCoord += VerticalStep - SystemInformation.VerticalScrollBarWidth;
                else
                    xCoord += VerticalStep;

                //Adds number of column with coordinates to list
                ColumnCoord.Add(new CoordColumn(i, OldXCoord, xCoord, CurrentDate.AddDays(i)));

            }
        }

        /// <summary>
        /// Draws overall net
        /// </summary>
        private void DrawGrid(Graphics graphics)
        {
            RowCoord.Clear();
            ColumnCoord.Clear();

            int YCoord = DrawHorizLines(graphics, 0);
            DrawVertLines(graphics, LeftMargin, YCoord);
            DrawSelectedCell(graphics);
            DrawItems(graphics);

            AutoScrollMinSize = new Size(100, YCoord);

        }


        /// <summary>
        /// Draws background rectangle in the selected net cell
        /// </summary>
        private void DrawSelectedCell(Graphics graphics)
        {
            var x = ColumnCoord.Where(d => d.DateValue.Date == _selectedCellDate).SingleOrDefault();
            var y = RowCoord.Where(d => d.RowIndex == _selectedRow).SingleOrDefault();

            if (x != null && y != null && _selectedItem == null && _selectedRow != -1)
            {
                var selectedCellRect = new Rectangle(x.FirstCoord, y.FirstCoord, x.SecondCoord - x.FirstCoord, y.SecondCoord - y.FirstCoord);
                using (var backBrush = new SolidBrush(Color.WhiteSmoke))
                    graphics.FillRectangle(backBrush, selectedCellRect);
            }
        }

        #endregion


        /// <summary>
        /// Searches for the item by it coords
        /// </summary>
        /// <param name="p">X,Y coords</param>
        /// <param name="items">list of items in which searches item</param>
        /// <returns></returns>
        public WeekPlannerItem GetItemAt(Point p, List<WeekPlannerItem> items)
        {
            return items.FirstOrDefault(item => item.Rectangle.Contains(p));
        }

        /// <summary>
        /// Invalidates the area of the specified item
        /// </summary>
        /// <param name="item"></param>
        public void Invalidate(WeekPlannerItem item)
        {
            Rectangle r = item.Rectangle;
            Invalidate(r);
        }

        /// <summary>
        /// Handles the LostFocus event of the TextBox that edit items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            FinalizeEditMode();
        }


        /// <summary>
        /// Finalizes editing
        /// </summary>
        public void FinalizeEditMode()
        {
            if (EditModeItem == null) return;

            WeekPlannerItem itemBuffer = _editModeItem;
            _editModeItem = null;

            itemBuffer.Subject = TextBox.Text.Trim();

            if (TextBox != null)
            {
                TextBox.Visible = false;
                Controls.Remove(TextBox);
                TextBox.Dispose();
            }

            if (_editModeItem != null)
                Invalidate();

            planner.OnItemTextEdited(new WeekPlannerItemEventArgs(itemBuffer));

            _textBox = null;

            if (State == PlannerState.EditingItemText)
            {
                SetState(PlannerState.Idle);
            }
        }

        /// <summary>
        /// Activates the edit mode on the specified item
        /// </summary>
        /// <param name="item"></param>
        public void ActivateEditMode(WeekPlannerItem item)
        {

            _editModeItem = item;
            TextBox = new CalendarTextBox(this);
            TextBox.KeyDown += TextBox_KeyDown;
            TextBox.LostFocus += TextBox_LostFocus;
            TextBox.Font = ItemTextFont;
            Rectangle r = item.Rectangle;
            r.Location = r.Location + new Size(AutoScrollPosition);

            r.Inflate(-2, -2);
            TextBox.Bounds = r;
            TextBox.BorderStyle = BorderStyle.None;
            TextBox.Text = item.Subject;
            TextBox.Multiline = true;

            Controls.Add(TextBox);
            TextBox.Visible = true;
            TextBox.Focus();
            TextBox.SelectionStart = TextBox.Text.Length;

            SetState(PlannerState.EditingItemText);
        }

        /// <summary>
        /// Handles the Keydown event of the TextBox that edit items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FinalizeEditMode();
            }
        }

        /// <summary>
        /// Sets the value of the property
        /// </summary>
        /// <param name="state">Current state of the calendar</param>
        private void SetState(PlannerState state)
        {
            _state = state;
        }

        #region Override Methods


        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseClickPosition = new Point(e.X, e.Y);
            mouseClickScrollPosition = mouseClickPosition - new Size(AutoScrollPosition);

            if (!Focused)
            {
                Focus();
            }

            var row = RowCoord.Where(d => (isNumberInRange(mouseClickScrollPosition.Y, d.FirstCoord, d.SecondCoord))).SingleOrDefault();
            _selectedRow = row != null ? row.RowIndex : -1;

            var column =
                ColumnCoord.Where(d => (isNumberInRange(mouseClickScrollPosition.X, d.FirstCoord, d.SecondCoord))).SingleOrDefault();


            if (column != null)
            {
                _selectedColumn = column.Column;
                _selectedCellDate = CurrentDate.AddDays(SelectedColumn);
            }

            if (listRows.Count > 0 && _selectedRow != -1)
            {
                var plannerRow = listRows.ElementAt(_selectedRow);
                _selectedItem = GetItemAt(mouseClickScrollPosition, plannerRow.Items);
            }

            switch (State)
            {
                case PlannerState.Idle:
                    if (_selectedItem != null)
                    {
                        itemOnState = _selectedItem;
                        itemOnStateChanged = false;

                        durationStart = itemOnState.StartDate.Date.Subtract(column.DateValue.Date);
                        durationEnd = itemOnState.EndDate.Date.Subtract(column.DateValue.Date);
                        if (itemOnState.ResizeStartDateZone(mouseClickScrollPosition))
                        {
                            SetState(PlannerState.ResizingItem);
                            itemOnState.SetIsResizingStartDate(true);
                        }
                        else if (itemOnState.ResizeEndDateZone(mouseClickScrollPosition))
                        {
                            SetState(PlannerState.ResizingItem);
                            itemOnState.SetIsResizingEndDate(true);
                        }
                        else
                        {
                            rowNumer = _selectedRow;
                            SetState(PlannerState.DraggingItem);
                        }
                    }
                    break;
                case PlannerState.DraggingItem:
                    break;
                case PlannerState.ResizingItem:
                    break;
                case PlannerState.EditingItemText:
                    break;
            }

            
            if (row != null && column != null && listRows.Count > 0)
            {
                var rowClicked = listRows.ElementAt(_selectedRow);
                planner.OnRowClick(new RowEventArgs(rowClicked));
                Invalidate();
            }

            if (mouseClickScrollPosition.X < LeftMargin)
            {
                try
                {
                    var rowClicked = listRows.ElementAt(_selectedRow);
                    if (e.Button == MouseButtons.Left) rowClicked.IsExpanded = !rowClicked.IsExpanded;
                    planner.OnRowLeftColumnClick(new RowClickEventArgs(rowClicked, e.Button), listRows.IndexOf(rowClicked));
                    rowClicked.LeftMarginBackColor = rowClicked.LeftMarginOldBackColor;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Debug.WriteLine("It happened");
                }
            }

            base.OnMouseDown(e);
        }



        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //Cursor = Cursors.Hand;
            var mouseMovePosition = new Point(e.X, e.Y);
            var mouseMoveScrollPosition = mouseMovePosition - new Size(AutoScrollPosition);

            var row = RowCoord.Where(d => (isNumberInRange(mouseMoveScrollPosition.Y, d.FirstCoord, d.SecondCoord))).SingleOrDefault();
            var moveRow = row != null ? row.RowIndex : -1;

            var column =
                ColumnCoord.Where(d => (isNumberInRange(mouseMoveScrollPosition.X, d.FirstCoord, d.SecondCoord))).SingleOrDefault();

            WeekPlannerItem hittedItem = null;

            if (listRows.Count > 0 && moveRow != -1 && listRows.Count > moveRow)
            {
                var plannerRow = listRows.ElementAt(moveRow);

                if (plannerRow.LeftMarginBackColor != Color.White)
                    plannerRow.LeftMarginOldBackColor = plannerRow.LeftMarginBackColor;

                hittedItem = GetItemAt(mouseMoveScrollPosition, plannerRow.Items);
                if (outHittedItem != hittedItem && hittedItem != null)
                {
                    outHittedItem = hittedItem;
                }

                
                //to detect cursor movement above left margin column
                if (mouseMoveScrollPosition.X < LeftMargin)
                {
                    //to detect cursor movement during changing rows
                    if (outRow != moveRow)
                    {
                        plannerRow.LeftMarginBackColor = Color.White;
                        //sets row color when cursor moves above the row
                        if (plannerRow.IsCollapsible)
                        {
                            //plannerRow.LeftMarginBackColor = Color.White;
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                        }

                        //finds row which has left cursor and sets back color
                        if (outRow != -1)
                        {
                            var oRow = listRows.ElementAt(outRow);
                            oRow.LeftMarginBackColor = oRow.LeftMarginOldBackColor;
                            if (oRow.IsCollapsible)
                            {
                                //oRow.LeftMarginBackColor = oRow.LeftMarginOldBackColor;
                            }
                        }

                        outRow = moveRow;
                    }
                }

                                //to detect when cursor leaves left margin column
                else
                {
                    if (plannerRow.IsCollapsible)
                    {
                        //plannerRow.LeftMarginBackColor = plannerRow.LeftMarginOldBackColor;

                    }
                    plannerRow.LeftMarginBackColor = plannerRow.LeftMarginOldBackColor;
                    outRow = -1;

                }


            }


            // to detect cursor movement below left margin column
            if (moveRow == -1 && outRow != -1)
            {
                var r = listRows.ElementAt(outRow);
                if (r.IsCollapsible)
                {
                    outRow = -1;
                    //r.LeftMarginBackColor = r.LeftMarginOldBackColor;
                    Cursor = Cursors.Default;
                }
                r.LeftMarginBackColor = r.LeftMarginOldBackColor;
            }


            switch (State)
            {
                case PlannerState.Idle:
                    Cursor should = Cursors.Default;

                    if (hittedItem != null)
                    {
                        if ((hittedItem.ResizeEndDateZone(mouseMoveScrollPosition) || hittedItem.ResizeStartDateZone(mouseMoveScrollPosition)))
                        {
                            should = Cursors.SizeWE;
                        }

                        planner.OnItemMouseHover(new WeekPlannerItemEventArgs(hittedItem));

                    }
                    if (!Cursor.Equals(should) && mouseMoveScrollPosition.X > LeftMargin) Cursor = should;

                    if (hittedItem == null && outHittedItem != null)
                    {
                        planner.OnItemMouseLeave(new WeekPlannerItemEventArgs(outHittedItem));
                        outHittedItem = null;
                    }

                    break;
                case PlannerState.DraggingItem:

                    if (column != null)
                    {
                        moveDate = column.DateValue;
                    }

                    itemOnState.StartDate = moveDate.AddDays(durationStart.Days);
                    itemOnState.EndDate = moveDate.AddDays(durationEnd.Days);

                    if (rowNumer != moveRow && moveRow != -1 && IsAllowedDraggingBetweenRows)
                    {
                        try
                        {
                            var oldRowNumber = rowNumer;
                            rowNumer = moveRow;

                            var newRow = Rows.ElementAt(rowNumer);
                            var oldRow = Rows.ElementAt(oldRowNumber);

                            var newItem = new WeekPlannerItem(this);
                            newItem = itemOnState;


                            var addedItem = newRow.Items.Add(newItem);
                            oldRow.Items.Remove(itemOnState);
                            _selectedItem = addedItem;
                            itemOnState = addedItem;
                        }
                        catch (Exception)
                        {
                            Debug.WriteLine("it did it again");
                        }
                    }
                    itemOnStateChanged = true;
                    break;
                case PlannerState.ResizingItem:
                    if (column != null)
                    {
                        moveDate = column.DateValue;
                    }

                    if (itemOnState.IsResizingStartDate && moveDate <= itemOnState.EndDate.Date)
                    {
                        itemOnState.StartDate = moveDate.AddDays(durationStart.Days);
                    }
                    else if (itemOnState.IsResizingEndDate && moveDate >= itemOnState.StartDate.Date)
                    {
                        itemOnState.EndDate = moveDate.AddDays(durationEnd.Days);
                    }
                    itemOnStateChanged = true;
                    break;
                case PlannerState.EditingItemText:
                    break;
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (_selectedItem != null)
            {
                planner.OnItemDoubleClick(new WeekPlannerItemEventArgs(_selectedItem));
            }

            if (mouseClickPosition.X > LeftMargin && _selectedItem == null && _selectedRow != -1)
            {
                var row = listRows.ElementAt(_selectedRow);
                planner.OnRowDoubleClick(new RowEventArgs(row));
            }

            base.OnDoubleClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (itemOnState != null)
            {
                itemOnState.SetIsResizingEndDate(false);
                itemOnState.SetIsResizingStartDate(false);
                planner.OnItemClick(new WeekPlannerItemEventArgs(itemOnState));
                if (itemOnStateChanged)
                    planner.OnItemDatesChanged(new WeekPlannerItemEventArgs(itemOnState));
                itemOnState = null;
            }

            SetState(PlannerState.Idle);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Delete)
            {
                var row = Rows.ElementAt(_selectedRow);
                row.Items.Remove(_selectedItem);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (listRows.Count > 0)
            {
                //finds top row on the screen and sets it's left margin color
                var position = new Point(0, 1);
                var scrollPosition = position - new Size(AutoScrollPosition);
                var row = RowCoord.Where(d => (isNumberInRange(scrollPosition.Y, d.FirstCoord, d.SecondCoord))).SingleOrDefault();

                if (row != null)
                {
                    var plannerRow = listRows.ElementAt(row.RowIndex);
                    if (plannerRow.IsCollapsible) plannerRow.LeftMarginBackColor = LeftMarginColor;
                    outRow = -1;
                }

            }
        }

        #endregion

        /// <summary> 
        /// Checks does int number intersect with numbers range
        /// </summary> 
        static bool isNumberInRange(int number, int first, int second)
        {
            return number > first && number < second;
        }

        /// <summary>
        /// Restes all items layers and coords to 0
        /// </summary>
        public void ResetLayers()
        {
            foreach (var item in listRows.Where(row => row.Items != null).SelectMany(row => row.Items))
            {
                item.Rectangle = new Rectangle(0, 0, 0, 0);
                item.Layer = 0;
            }
        }

        #region Public Methods




        #endregion

    }
}
