using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WeekPlanner
{
    public partial class CalendarPlanner : UserControl, iWeekPlanner
    {
        #region iWeek members

        /// <summary>
        /// Possible modes to show dates intervals
        /// </summary>
        [Description("Possible modes to show dates intervals")]
        [Browsable(true), Category("CalendarPlanner")]
        public WeekPlannerMode DatesIntervalMode
        {
            get { return weekHeader.DatesIntervalMode; }
            set
            {
                 weekHeader.DatesIntervalMode = value;
            }
        }

        /// <summary>
        /// Possible modes to fill background header
        /// </summary>
        [Description("Possible modes to fill background header")]
        [Browsable(true), Category("CalendarPlanner")]
        public HeaderStyle HeaderStyleMode
        {
            get { return weekHeader.HeaderStyleMode; }
            set
            {
                weekHeader.HeaderStyleMode = value;
            }
        }

        public WeekPlannerGrid Calendar
        {
            get
            {
                return weekPlannerGrid;
            }
        }

        /// <summary>
        /// Date of the calendar planner
        /// </summary>
        [Description("Date of the calendar planner")]
        [Browsable(true), Category("CalendarPlanner")]
        public DateTime CurrentDate
        {
            get
            {
                return weekHeader.CurrentDate;
            }
            set
            {
                weekPlannerGrid.CurrentDate = weekHeader.CurrentDate = value;
            }
        }

        /// <summary>
        /// Grid's border color
        /// </summary>
        [Description("Grid's border color")]
        [Browsable(true), Category("CalendarPlanner")]
        public Color BorderColor
        {
            get
            {
                return weekHeader.BorderColor = weekPlannerGrid.BorderColor;
            }
            set
            {
                weekPlannerGrid.BorderColor = weekHeader.BorderColor = value;
            }
        }

        /// <summary>
        /// Margin of the left column
        /// </summary>
        [Description("Margin of the left column")]
        [Browsable(true), Category("CalendarPlanner")]
        public int LeftMargin
        {
            get { return weekPlannerGrid.LeftMargin; }
            set { weekPlannerGrid.LeftMargin = weekHeader.LeftMargin = value; }
        }

        /// <summary>
        /// Day count to show by calendar
        /// </summary>
        [Description("Day count to show by calendar")]
        [Browsable(true), Category("CalendarPlanner")]
        public int DayCount
        {
            get { return weekPlannerGrid.DayCount; }
            set { weekPlannerGrid.DayCount = weekHeader.DayCount = value; }
        }

        /// <summary>
        /// Columns in the left margin column
        /// </summary>
        [Description("Columns in the left margin column")]
        [Browsable(true), Category("CalendarPlanner")]
        public DataColumns Columns
        {
            get { return weekPlannerGrid.Columns = weekHeader.Columns; }
            set
            {
                weekPlannerGrid.Columns = weekHeader.Columns = value;
            }
        }

        #endregion

        #region iWeekPlanner members

        /// <summary>
        /// Enables/Disables item's drag/drop between rows
        /// </summary>
        [Description("Allows/Disallows item's drag/drop between rows")]
        [Browsable(true), Category("CalendarPlanner")]
        public bool IsAllowedDraggingBetweenRows
        {
            get
            {
                return weekPlannerGrid.IsAllowedDraggingBetweenRows;
            }
            set
            {
                weekPlannerGrid.IsAllowedDraggingBetweenRows = value;
            }
        }


        /// <summary>
        /// Enables/Disables tree view lines drawing
        /// </summary>
        [Description("Enables/Disables tree view lines drawing")]
        [Browsable(true), Category("CalendarPlanner")]
        public bool IsAllowedTreeViewDrawing
        {
            get
            {
                return weekPlannerGrid.IsAllowedTreeViewDrawing;
            }
            set
            {
                weekPlannerGrid.IsAllowedTreeViewDrawing = value;
            }
        }

        /// <summary>
        /// Background color of the calendar planner
        /// </summary>
        [Description("Background color of the calendar planner")]
        [Browsable(true), Category("CalendarPlanner")]
        public Color GridBackgroundColor
        {
            get
            {
                return weekPlannerGrid.GridBackgroundColor;
            }
            set
            {
                weekPlannerGrid.GridBackgroundColor = value;
            }
        }

        /// <summary>
        /// Background color of the header
        /// </summary>
        [Description("Background color of the header")]
        [Browsable(true), Category("CalendarPlanner")]
        public Color HeaderBackgroundColor
        {
            get
            {
                return weekHeader.HeaderBackgroundColor;
            }
            set
            {
                weekHeader.HeaderBackgroundColor = value;
            }
        }

        /// <summary>
        /// Background color of the header's title
        /// </summary>
        [Description("Background color of the header's title")]
        [Browsable(true), Category("CalendarPlanner")]
        public Color HeaderFillColor
        {
            get
            {
                return weekHeader.HeaderFillColor;
            }
            set
            {
                weekHeader.HeaderFillColor = value;
            }
        }

        /// <summary>
        /// Background color of the header's left margin title
        /// </summary>
        [Description("Background color of the header's left margin title")]
        [Browsable(true), Category("CalendarPlanner")]
        public Color HeaderFillLeftMarginColor
        {
            get
            {
                return weekHeader.HeaderFillLeftMarginColor;
            }
            set
            {
                weekHeader.HeaderFillLeftMarginColor = value;
            }
        }

        /// <summary>
        /// Left margin's background color
        /// </summary>
        [Description("Left margin's background color")]
        [Browsable(true), Category("CalendarPlanner")]
        public Color LeftMarginColor
        {
            get
            {
                return weekPlannerGrid.LeftMarginColor;
            }
            set
            {
                weekPlannerGrid.LeftMarginColor = value;
            }
        }

        /// <summary>
        /// Height of the each cell
        /// </summary>
        [Description("Height of the each cell")]
        [Browsable(true), Category("CalendarPlanner")]
        public int GridCellHeight
        {
            get
            {
                return weekPlannerGrid.GridCellHeight;
            }
            set
            {
                weekPlannerGrid.GridCellHeight = value;
            }
        }


        /// <summary>
        /// Height of the each item
        /// </summary>
        [Description("Height of the each item")]
        [Browsable(true), Category("CalendarPlanner")]
        public int ItemHeight
        {
            get
            {
                return weekPlannerGrid.ItemHeight;
            }
            set
            {
                weekPlannerGrid.ItemHeight = value;
                weekPlannerGrid.Invalidate();
            }
        }

        /// <summary>
        /// Font for the text left margin column
        /// </summary>
        [Description("Font for the text left margin column")]
        [Browsable(true), Category("CalendarPlanner")]
        public Font GridTextFont
        {
            get
            {
                return weekPlannerGrid.GridTextFont;
            }
            set
            {
                weekPlannerGrid.GridTextFont = value;
            }
        }

        /// <summary>
        /// Font of the each item
        /// </summary>
        [Description("Font of the each item")]
        [Browsable(true), Category("CalendarPlanner")]
        public Font ItemTextFont
        {
            get
            {
                return weekPlannerGrid.ItemTextFont;
            }
            set
            {
                weekPlannerGrid.ItemTextFont = value;
            }
        }
        /// <summary>
        /// Font of the planner's header
        /// </summary>
        [Description("Font of the planner's columns header")]
        [Browsable(true), Category("CalendarPlanner")]
        public Font HeaderColumnsFont
        {
            get
            {
                return weekHeader.HeaderColumnsFont;
            }
            set
            {
                weekHeader.HeaderColumnsFont = value;
            }
        }


        /// <summary>
        /// Font of the planner's header
        /// </summary>
        [Description("Font of the planner's dates header")]
        [Browsable(true), Category("CalendarPlanner")]
        public Font HeaderDatesFont
        {
            get
            {
                return weekHeader.HeaderDatesFont;
            }
            set
            {
                weekHeader.HeaderDatesFont = value;
            }
        }

        /// <summary>
        /// Index of selected row
        /// </summary>
        [Description("Index of selected row")]
        [Browsable(true), Category("CalendarPlanner")]
        public int SelectedRowIndex
        {
            get
            {
                return weekPlannerGrid.SelectedRowIndex;
            }
        }

        /// <summary>
        /// Index of selected column
        /// </summary>
        [Description("Index of selected column")]
        [Browsable(true), Category("CalendarPlanner")]
        public int SelectedColumn
        {
            get
            {
                return weekPlannerGrid.SelectedColumn;
            }
        }

        /// <summary>
        /// Selected column's date
        /// </summary>
        [Description("Selected column's date")]
        public DateTime SelectedCellDate
        {
            get
            {
                return weekPlannerGrid.SelectedCellDate;
            }
        }

        /// <summary>
        /// Gets the item being edited (if any)
        /// </summary>
        [Description("Gets the item being edited (if any)")]
        public WeekPlannerItem EditModeItem
        {
            get
            {
                return weekPlannerGrid.EditModeItem;
            }
        }

        /// <summary>
        /// Gets the item being selected (if any)
        /// </summary>
        [Description("Gets the item being selected (if any)")]
        public WeekPlannerItem SelectedItem
        {
            get
            {
                return weekPlannerGrid.SelectedItem;
            }
        }

        /// <summary>
        /// Gets the count of rows
        /// </summary>
        [Description("Gets the count of rows")]
        public int RowCount
        {
            get
            {
                return weekPlannerGrid.RowCount;
            }
        }

        /// <summary>
        /// Gets the list of rows with items
        /// </summary>
        [Description("Gets the list of rows with items")]
        public WeekPlannerRowCollection Rows
        {
            get
            {
                return weekPlannerGrid.Rows;
            }
        }

        /// <summary>
        /// Gets the location of the auto-scroll position
        /// </summary>
        [Description("Gets the location of the auto-scroll position")]
        public Point WeekPlannerScrollPosition
        {
            get
            {
                return weekPlannerGrid.WeekPlannerScrollPosition;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Delegate that supports item-related events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CalendarItemEventHandler(object sender, WeekPlannerItemEventArgs e);

        /// <summary>
        /// Delegate that supports left column row-related events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CalendarRowLeftColumnEventHandler(object sender, RowClickEventArgs e, int rowNumber);

        /// <summary>
        /// Delegate that supports row-related events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CalendarRowEventHandler(object sender, RowEventArgs e);

        /// <summary>
        /// Occurs when an item is double-clicked
        /// </summary>
        [Description("Occurs when an item is double-clicked")]
        public event CalendarItemEventHandler ItemDoubleClick;

        /// <summary>
        /// Occurs when an item is clicked
        /// </summary>
        [Description("Occurs when an item is clicked")]
        public event CalendarItemEventHandler ItemClick;


        /// <summary>
        /// Occurs when an row is double-clicked
        /// </summary>
        [Description("Occurs when an row is double-clicked")]
        public event CalendarRowEventHandler RowDoubleClick;

        /// <summary>
        /// Occurs when an row is clicked
        /// </summary>
        [Description("Occurs when an row is clicked")]
        public event CalendarRowEventHandler RowClick;

        /// <summary>
        /// Occurs when an item date range has changed
        /// </summary>
        [Description("Occurs when an item date range has changed")]
        public event CalendarItemEventHandler ItemDatesChanged;

        /// <summary>
        /// Occurs when an row left margin is clicked
        /// </summary>
        [Description("Occurs when an row left margin is clicked")]
        public event CalendarRowLeftColumnEventHandler RowLeftColumnClick;
        /// <summary>
        /// Occurs when an item text is edited
        /// </summary>
        [Description("Occurs when an item text is edited")]
        public event CalendarItemEventHandler ItemTextEdited;


        /// <summary>
        /// Occurs when the mouse is moved over an item
        /// </summary>
        [Description("Occurs when the mouse is moved over an item")]
        public event CalendarItemEventHandler ItemMouseHover;

        /// <summary>
        /// Occurs when the mouse leaves the visible part of the item
        /// </summary>
        [Description("Occurs when the mouse leaves the visible part of the item")]
        public event CalendarItemEventHandler ItemMouseLeave;


        #endregion

        public CalendarPlanner()
        {
            InitializeComponent();
            DatesIntervalMode = WeekPlannerMode.Daily;
            weekPlannerGrid.planner = this;
            IsAllowedDraggingBetweenRows = true;
            IsAllowedTreeViewDrawing = true;
            BorderColor = WeekPlannerColorTable.BorderColor;
            GridCellHeight = 200;
            LeftMargin = 250;
            CurrentDate = DateTime.Now;
            GridBackgroundColor = WeekPlannerColorTable.GridBackgroundColor;
            HeaderBackgroundColor = WeekPlannerColorTable.HeaderBackgroundColor;
            HeaderFillColor = WeekPlannerColorTable.HeaderFillColor;
            HeaderFillLeftMarginColor = WeekPlannerColorTable.HeaderFillLeftMarginColor;
            LeftMarginColor = WeekPlannerColorTable.LeftMarginColor;
            DayCount = 7;
            ItemHeight = 20;
        }

        #region Methods

        /// <summary>
        /// Activates the edit mode on the specified item
        /// </summary>
        /// <param name="item"></param>
        public void ActivateEditMode(WeekPlannerItem item)
        {
            weekPlannerGrid.ActivateEditMode(item);
        }
        
        #endregion

        #region Overrided Events and Raisers

        /// <summary>
        /// Occurs when an item is double-clicked
        /// </summary>
        [Description("Occurs when an item is double-clicked")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnItemDoubleClick(WeekPlannerItemEventArgs e)
        {
            if (ItemDoubleClick != null)
            {
                ItemDoubleClick(this, e);
            }
        }

        /// <summary>
        /// Occurs when an row left margin is clicked
        /// </summary>
        [Description("Occurs when an row left margin  is clicked")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnRowLeftColumnClick(RowClickEventArgs e, int rowNumber)
        {
            if (RowLeftColumnClick != null)
            {
                RowLeftColumnClick(this, e, rowNumber);
            }
        }

        /// <summary>
        /// Occurs when an item is clicked
        /// </summary>
        [Description("Occurs when an item is clicked")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnItemClick(WeekPlannerItemEventArgs e)
        {
            if (ItemClick != null)
            {
                ItemClick(this, e);
            }
        }


        /// <summary>
        /// Occurs when an row is double-clicked
        /// </summary>
        [Description("Occurs when an row is double-clicked")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnRowDoubleClick(RowEventArgs e)
        {
            if (RowDoubleClick != null)
            {
                RowDoubleClick(this, e);
            }
        }


        /// <summary>
        /// Occurs when an row is clicked
        /// </summary>
        [Description("Occurs when an row is clicked")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnRowClick(RowEventArgs e)
        {
            if (RowClick != null)
            {
                RowClick(this, e);
            }
        }



        /// <summary>
        /// Occurs when an item date range has changed
        /// </summary>
        [Description("Occurs when an item date range has changed")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnItemDatesChanged(WeekPlannerItemEventArgs e)
        {
            if (ItemDatesChanged != null)
            {
                ItemDatesChanged(this, e);
            }
        }


        /// <summary>
        /// Occurs when an item text is edited
        /// </summary>
        [Description("Occurs when an item text is edited")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnItemTextEdited(WeekPlannerItemEventArgs e)
        {
            if (ItemTextEdited != null)
            {
                ItemTextEdited(this, e);
            }
        }


        /// <summary>
        /// Occurs when the mouse is moved over an item
        /// </summary>
        [Description("Occurs when the mouse is moved over an item")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnItemMouseHover(WeekPlannerItemEventArgs e)
        {
            if (ItemMouseHover != null)
            {
                ItemMouseHover(this, e);
            }
        }


        /// <summary>
        /// Occurs when the mouse leaves the visible part of the item
        /// </summary>
        [Description("Occurs when the mouse leaves the visible part of the item")]
        [Browsable(true), Category("CalendarPlanner")]
        public void OnItemMouseLeave(WeekPlannerItemEventArgs e)
        {
            if (ItemMouseLeave != null)
            {
                ItemMouseLeave(this, e);
            }
        }

        #endregion

    }
}
