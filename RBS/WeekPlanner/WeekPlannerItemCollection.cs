using System;
using System.Collections.Generic;
using System.Drawing;


namespace WeekPlanner
{
    /// <summary>
    /// List of items to add to row
    /// </summary>
    /// 
    public class WeekPlannerItemCollection:List<WeekPlannerItem>
    {
        private WeekPlannerGrid _calendar;
        public WeekPlannerGrid Calendar
        {
            set { _calendar = value; }
            get { return _calendar; }
        }

        /// <summary>
        /// List of items to add to row
        /// </summary>
        /// 
        public WeekPlannerItemCollection()
        {

        }

        internal WeekPlannerItemCollection(WeekPlannerGrid c)
        {
            _calendar = c;
        }


        public WeekPlannerItem Add(DateTime d1, DateTime d2, string subject)
        {
            var item = new WeekPlannerItem(_calendar);
            item.StartDate = d1;
            item.EndDate = d2;
            item.Subject = subject;

            Add(item);
            return item;
        }


        public WeekPlannerItem Add(DateTime d1, DateTime d2, string subject, Color backColor)
        {
            var item = Add(d1, d2, subject);
            item.BackColor = backColor;
            return item;
        }

        public new WeekPlannerItem Add(WeekPlannerItem item)
        {
            base.Add(item);
            if (_calendar != null)
            {
                item.Calendar = _calendar;
                _calendar.ResetLayers();
                _calendar.Invalidate();
            }
            return item;
        }

        public new void Remove(WeekPlannerItem item)
        {
            base.Remove(item);
            if (_calendar != null)
            {
                item.Calendar = _calendar;
                _calendar.ResetLayers();
                _calendar.Invalidate();
            }

        }

        public new void Clear()
        {
            base.Clear();
            if (_calendar != null)
            {
                _calendar.ResetLayers();
                _calendar.Invalidate();
            }

        }


    }
}
