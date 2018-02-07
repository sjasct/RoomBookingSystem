using System.Drawing;

namespace WeekPlanner
{
    interface iWeekPlannerRow
    {
        string Name { get; set; }
        int LayerCount { get; set; }
        DataColumns Columns { get; set; }
        Color BackColor { get; set; }
        WeekPlannerItemCollection Items { get; set; }
        string AncestorName { get; set; }
        bool IsVisible { get; set; }
        bool IsExpanded { get; set; }
        bool IsCollapsible { get; set; }
    }
}
