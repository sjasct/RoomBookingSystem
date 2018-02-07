using System;

namespace WeekPlanner
{
    public class RowEventArgs : EventArgs
    {
        #region Ctor

        /// <summary>
        /// Creates a new <see cref="WeekPlannerRow"/>
        /// </summary>
        /// <param name="row">Related row</param>
        public RowEventArgs(WeekPlannerRow row)
        {
            _row = row;
        }

        #endregion

        #region Props

        private WeekPlannerRow _row;

        /// <summary>
        /// Gets the <see cref="WeekPlannerRow"/> related to the event
        /// </summary>
        public WeekPlannerRow Row
        {
            get { return _row; }
        }


        #endregion
    }
}
