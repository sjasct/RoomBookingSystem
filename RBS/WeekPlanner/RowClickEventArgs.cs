using System;
using System.Windows.Forms;

namespace WeekPlanner
{
    public class RowClickEventArgs : EventArgs
    {
        #region Ctor

        /// <summary>
        /// Creates a new <see cref="WeekPlannerRow"/>
        /// </summary>
        /// <param name="row">Related row</param>
        /// <param name="button">Mouse Button Pressed</param>
        public RowClickEventArgs(WeekPlannerRow row, MouseButtons button)
        {
            _row = row;
            _button = button;
        }

        #endregion

        #region Props

        private WeekPlannerRow _row;
        private MouseButtons _button;
        /// <summary>
        /// Gets the <see cref="WeekPlannerRow"/> related to the event
        /// </summary>
        public WeekPlannerRow Row
        {
            get { return _row; }
        }


        public MouseButtons MouseButton
        {
            get { return _button; }
        }


        #endregion
    }
}
