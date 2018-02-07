using System.ComponentModel;
using System.Windows.Forms;

namespace WeekPlanner
{
    [DesignTimeVisible(false)]
    public class CalendarTextBox : TextBox
    {
        #region Fields
        private WeekPlannerGrid _calendar;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new <see cref="CalendarTextBox"/> for the specified <see cref="Calendar"/>
        /// </summary>
        /// <param name="calendar">Calendar where this control lives</param>
        public CalendarTextBox(WeekPlannerGrid calendar)
        {
            _calendar = calendar;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the calendar where this control lives
        /// </summary>
        public WeekPlannerGrid Calendar
        {
            get { return _calendar; }
        }


        #endregion

    }
}
