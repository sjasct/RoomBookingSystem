using System;

namespace WeekPlanner
{
    public class WeekPlannerItemEventArgs
        : EventArgs
    {
        #region Ctor

        /// <summary>
        /// Creates a new <see cref="WeekPlannerItem"/>
        /// </summary>
        /// <param name="item">Related Item</param>
        public WeekPlannerItemEventArgs(WeekPlannerItem item)
        {
            _item = item;
        }

        #endregion

        #region Props

        private WeekPlannerItem _item;

        /// <summary>
        /// Gets the <see cref="WeekPlannerItem"/> related to the event
        /// </summary>
        public WeekPlannerItem Item
        {
            get
            {
                return _item;
            }
        }


        #endregion
    }
}
