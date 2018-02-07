namespace WeekPlanner
{
    partial class CalendarPlanner
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.weekHeader = new WeekPlanner.WeekPlannerHeader();
            this.weekPlannerGrid = new WeekPlanner.WeekPlannerGrid();
            this.SuspendLayout();
            // 
            // weekHeader
            // 
            this.weekHeader.BackColor = System.Drawing.SystemColors.Control;
            this.weekHeader.BorderColor = System.Drawing.Color.Empty;
            this.weekHeader.CurrentDate = new System.DateTime(((long)(0)));
            this.weekHeader.DayCount = 1;
            this.weekHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.weekHeader.HeaderBackgroundColor = System.Drawing.SystemColors.Control;
            this.weekHeader.HeaderFillColor = System.Drawing.Color.Empty;

            this.weekHeader.LeftMargin = 0;
            this.weekHeader.Location = new System.Drawing.Point(0, 0);
            this.weekHeader.Name = "weekHeader";
            this.weekHeader.Size = new System.Drawing.Size(666, 46);
            this.weekHeader.TabIndex = 0;
            this.weekHeader.Text = "weekPlannerHeader1";
            // 
            // weekPlannerGrid
            // 
            this.weekPlannerGrid.AutoScroll = true;
            this.weekPlannerGrid.AutoScrollMinSize = new System.Drawing.Size(100, 0);
            this.weekPlannerGrid.BackColor = System.Drawing.SystemColors.Control;
            this.weekPlannerGrid.BorderColor = System.Drawing.Color.Empty;
            this.weekPlannerGrid.CurrentDate = new System.DateTime(((long)(0)));
            this.weekPlannerGrid.DayCount = 1;
            this.weekPlannerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weekPlannerGrid.GridBackgroundColor = System.Drawing.SystemColors.Control;
            this.weekPlannerGrid.GridCellHeight = 0;
            this.weekPlannerGrid.GridTextFont = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.weekPlannerGrid.ItemHeight = 0;
            this.weekPlannerGrid.ItemTextFont = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.weekPlannerGrid.LeftMargin = 0;
            this.weekPlannerGrid.Location = new System.Drawing.Point(0, 46);
            this.weekPlannerGrid.Name = "weekPlannerGrid";
            this.weekPlannerGrid.Size = new System.Drawing.Size(666, 300);
            this.weekPlannerGrid.TabIndex = 1;
            this.weekPlannerGrid.Text = "weekPlannerGrid1";
            // 
            // CalendarPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.weekPlannerGrid);
            this.Controls.Add(this.weekHeader);
            this.Name = "CalendarPlanner";
            this.Size = new System.Drawing.Size(666, 346);
            this.ResumeLayout(false);

        }

        #endregion

        private WeekPlannerHeader weekHeader;
        private WeekPlannerGrid weekPlannerGrid;
    }
}
