using System;
using System.Drawing;

namespace WeekPlanner
{
    interface iWeek
    {
        int DayCount { get; set; }
        DateTime CurrentDate { get; set; }
        int LeftMargin { get; set; }
        Color BorderColor { get; set; }
        DataColumns Columns { get; set; }
    }

    interface iWeekHeader : iWeek
    {
        Font HeaderColumnsFont { get; set; }
        Font HeaderDatesFont { get; set; }
        Color HeaderBackgroundColor { get; set; }
        Color HeaderFillColor { get; set; }
        Color HeaderFillLeftMarginColor { get; set; }
        WeekPlannerMode DatesIntervalMode { get; set; }
        HeaderStyle HeaderStyleMode { get; set; }
    }

    interface iWeekGrid : iWeek
    {
        int RowCount { get; }
        int GridCellHeight { get; set; }
        int ItemHeight { get; set; }
        Font GridTextFont { get; set; }
        Font ItemTextFont { get; set; }
        Color GridBackgroundColor { get; set; }
        Color LeftMarginColor { get; set; }
        int SelectedRowIndex { get; }
        int SelectedColumn { get; }
        bool IsAllowedDraggingBetweenRows { get; set; }
        bool IsAllowedTreeViewDrawing { get; set; }
        DateTime SelectedCellDate { get; }
        WeekPlannerItem EditModeItem { get; }
        WeekPlannerItem SelectedItem { get; }
        WeekPlannerRowCollection Rows { get; }
        Point WeekPlannerScrollPosition { get; }
        void ActivateEditMode(WeekPlannerItem item);

    }

    interface iWeekPlanner : iWeekHeader, iWeekGrid
    {
        void OnItemDoubleClick(WeekPlannerItemEventArgs e);
        void OnItemClick(WeekPlannerItemEventArgs e);
        void OnItemDatesChanged(WeekPlannerItemEventArgs e);
        void OnItemTextEdited(WeekPlannerItemEventArgs e);
        void OnItemMouseHover(WeekPlannerItemEventArgs e);
        void OnItemMouseLeave(WeekPlannerItemEventArgs e);
        void OnRowClick(RowEventArgs e);
        void OnRowDoubleClick(RowEventArgs e);
        void OnRowLeftColumnClick(RowClickEventArgs e, int rowNumber);

    }
}
