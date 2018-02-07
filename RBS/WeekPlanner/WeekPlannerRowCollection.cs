using System;
using System.Collections.Generic;
using System.Linq;

namespace WeekPlanner
{
    /// <summary>
    /// List of rows to add to the calendar
    /// </summary>
    public class WeekPlannerRowCollection : List<WeekPlannerRow>
    {
        public WeekPlannerGrid Calendar
        {
            get { return _calendar; }
        }

        private readonly WeekPlannerGrid _calendar;

        internal WeekPlannerRowCollection(WeekPlannerGrid c)
        {
            _calendar = c;
        }

        public WeekPlannerRow Add(WeekPlannerRow row)
        {
            row.Calendar = _calendar;

            if (row.Items == null)
            {
                row.Items = new WeekPlannerItemCollection(_calendar);
            }
            else
            {
                row.Items.Calendar = _calendar;

                foreach (var item in row.Items)
                {
                    item.Calendar = _calendar;
                }
            }

            base.Add(row);
            _calendar.Invalidate();
            return row;
        }

        public new WeekPlannerRow Insert(int index, WeekPlannerRow row)
        {

            RowAdd(row);
            base.Insert(index, row);
            _calendar.Invalidate();
            return row;
        }

        public WeekPlannerRow Insert(int index, DataColumns ColumnRows, WeekPlannerItemCollection PlannerItem)
        {
            var row = RowAdd(ColumnRows, PlannerItem);

            base.Insert(index, row);
            _calendar.Invalidate();

            return row;
        }

        private void RowAdd(WeekPlannerRow row)
        {
            row.Calendar = _calendar;


            if (row.Items == null)
            {
                row.Items = new WeekPlannerItemCollection(_calendar);
            }
            else
            {
                row.Items.Calendar = _calendar;

                foreach (var item in row.Items)
                {
                    item.Calendar = _calendar;
                }
            }

        }

        private WeekPlannerRow RowAdd(DataColumns ColumnRows, WeekPlannerItemCollection PlannerItem)
        {
            var row = new WeekPlannerRow(_calendar);

            if (PlannerItem == null)
                PlannerItem = new WeekPlannerItemCollection(_calendar);

            foreach (var item in PlannerItem)
            {
                item.Calendar = _calendar;
            }

            row.Items = PlannerItem;
            row.Columns = ColumnRows;

            return row;
        }

        public WeekPlannerRow Add(DataColumns ColumnRows, WeekPlannerItemCollection PlannerItem)
        {

            var row = new WeekPlannerRow(_calendar);

            if (PlannerItem == null)
                PlannerItem = new WeekPlannerItemCollection(_calendar);

            foreach (var item in PlannerItem)
            {
                item.Calendar = _calendar;
            }

            row.Items = PlannerItem;
            row.Columns = ColumnRows;

            base.Add(row);
            _calendar.Invalidate();
            return row;
        }

        public new void Remove(WeekPlannerRow row)
        {
            base.Remove(row);
            ClearRowIndex();
            _calendar.Invalidate();
        }

        public new void Remove(int rowIndex)
        {
            var row = this.ElementAt(rowIndex);
            _calendar.ResetLayers();

            base.Remove(row);
            ClearRowIndex();
            _calendar.Invalidate();
        }

        public new void Clear()
        {
            base.Clear();
            _calendar.GridCellHeight = _calendar.OldCellHeight;
            ClearRowIndex();
            _calendar.Invalidate();
        }

        private void ClearRowIndex()
        {
            if (_calendar.SelectedRowIndex >= Count) _calendar.SelectedRowIndex = -1;
        }

    }
}
