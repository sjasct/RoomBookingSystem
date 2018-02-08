using System;
using System.Drawing;

namespace WeekPlanner
{
    interface iWeekPlannerItem
    {
        Color BackColor { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Subject { get; set; }
        Rectangle Rectangle { get; set; }
        string Name { get; set; }
        int bookingid { get; set; }
        int userid { get; set; }
    }
}
