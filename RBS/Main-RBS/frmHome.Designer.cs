namespace Main_RBS
{
	partial class frmHome
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            WeekPlanner.DataColumns dataColumns1 = new WeekPlanner.DataColumns();
            this.btnNewBook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHomeLogin = new System.Windows.Forms.Button();
            this.btnShowID = new System.Windows.Forms.Button();
            this.lblUserHeader = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.listAllBookings = new System.Windows.Forms.ListView();
            this.clmRoomID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBookingMade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listOwnBookings = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listUsers = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.calAllBookings = new WeekPlanner.CalendarPlanner();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.calDTPick = new System.Windows.Forms.DateTimePicker();
            this.btnDayLeft = new System.Windows.Forms.Button();
            this.btnDayRight = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numRoomSelect = new System.Windows.Forms.NumericUpDown();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRoomSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewBook
            // 
            this.btnNewBook.Location = new System.Drawing.Point(12, 39);
            this.btnNewBook.Name = "btnNewBook";
            this.btnNewBook.Size = new System.Drawing.Size(114, 23);
            this.btnNewBook.TabIndex = 0;
            this.btnNewBook.Text = "New Booking";
            this.btnNewBook.UseVisualStyleBackColor = true;
            this.btnNewBook.Click += new System.EventHandler(this.btnNewBook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CompSci Project: Room Booking System";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "All Bookings";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnHomeLogin
            // 
            this.btnHomeLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHomeLogin.Location = new System.Drawing.Point(12, 97);
            this.btnHomeLogin.Name = "btnHomeLogin";
            this.btnHomeLogin.Size = new System.Drawing.Size(114, 23);
            this.btnHomeLogin.TabIndex = 7;
            this.btnHomeLogin.Text = "Log In";
            this.btnHomeLogin.UseVisualStyleBackColor = true;
            this.btnHomeLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowID
            // 
            this.btnShowID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowID.Location = new System.Drawing.Point(132, 97);
            this.btnShowID.Name = "btnShowID";
            this.btnShowID.Size = new System.Drawing.Size(114, 23);
            this.btnShowID.TabIndex = 8;
            this.btnShowID.Text = "View Profile";
            this.btnShowID.UseVisualStyleBackColor = true;
            this.btnShowID.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblUserHeader
            // 
            this.lblUserHeader.AutoSize = true;
            this.lblUserHeader.Location = new System.Drawing.Point(252, 9);
            this.lblUserHeader.Name = "lblUserHeader";
            this.lblUserHeader.Size = new System.Drawing.Size(76, 13);
            this.lblUserHeader.TabIndex = 10;
            this.lblUserHeader.Text = "Not logged in..";
            this.lblUserHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogOut.Location = new System.Drawing.Point(12, 68);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(114, 23);
            this.btnLogOut.TabIndex = 11;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // listAllBookings
            // 
            this.listAllBookings.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listAllBookings.AllowColumnReorder = true;
            this.listAllBookings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listAllBookings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRoomID,
            this.clmDate,
            this.clmPeriod,
            this.clmUser,
            this.clmBookingMade,
            this.clmId,
            this.clmNotes});
            this.listAllBookings.FullRowSelect = true;
            this.listAllBookings.GridLines = true;
            this.listAllBookings.HideSelection = false;
            this.listAllBookings.Location = new System.Drawing.Point(10, 28);
            this.listAllBookings.Name = "listAllBookings";
            this.listAllBookings.Size = new System.Drawing.Size(751, 187);
            this.listAllBookings.TabIndex = 13;
            this.listAllBookings.UseCompatibleStateImageBehavior = false;
            this.listAllBookings.View = System.Windows.Forms.View.Details;
            this.listAllBookings.ItemActivate += new System.EventHandler(this.listAllBookings_ItemActivate);
            this.listAllBookings.SelectedIndexChanged += new System.EventHandler(this.listAllBookings_SelectedIndexChanged);
            // 
            // clmRoomID
            // 
            this.clmRoomID.Text = "RoomID";
            // 
            // clmDate
            // 
            this.clmDate.Text = "Date";
            this.clmDate.Width = 120;
            // 
            // clmPeriod
            // 
            this.clmPeriod.Text = "Period";
            // 
            // clmUser
            // 
            this.clmUser.Text = "UserID";
            // 
            // clmBookingMade
            // 
            this.clmBookingMade.Text = "Time Made";
            this.clmBookingMade.Width = 180;
            // 
            // clmId
            // 
            this.clmId.Text = "ID";
            // 
            // clmNotes
            // 
            this.clmNotes.Text = "Notes";
            this.clmNotes.Width = 200;
            // 
            // listOwnBookings
            // 
            this.listOwnBookings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listOwnBookings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listOwnBookings.FullRowSelect = true;
            this.listOwnBookings.GridLines = true;
            this.listOwnBookings.HideSelection = false;
            this.listOwnBookings.Location = new System.Drawing.Point(7, 234);
            this.listOwnBookings.Name = "listOwnBookings";
            this.listOwnBookings.Size = new System.Drawing.Size(751, 187);
            this.listOwnBookings.TabIndex = 15;
            this.listOwnBookings.UseCompatibleStateImageBehavior = false;
            this.listOwnBookings.View = System.Windows.Forms.View.Details;
            this.listOwnBookings.ItemActivate += new System.EventHandler(this.listOwnBookings_ItemActivate);
            this.listOwnBookings.SelectedIndexChanged += new System.EventHandler(this.listOwnBookings_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RoomID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Period";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "UserID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time Made";
            this.columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Notes";
            this.columnHeader7.Width = 200;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Your Bookings";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-191, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Login as:";
            // 
            // listUsers
            // 
            this.listUsers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader8,
            this.columnHeader17});
            this.listUsers.FullRowSelect = true;
            this.listUsers.GridLines = true;
            this.listUsers.HideSelection = false;
            this.listUsers.Location = new System.Drawing.Point(20, 640);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(767, 140);
            this.listUsers.TabIndex = 23;
            this.listUsers.UseCompatibleStateImageBehavior = false;
            this.listUsers.View = System.Windows.Forms.View.Details;
            this.listUsers.ItemActivate += new System.EventHandler(this.listUsers_ItemActivate);
            this.listUsers.SelectedIndexChanged += new System.EventHandler(this.listUsers_SelectedIndexChanged);
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "User ID";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Username";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Name";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Role";
            this.columnHeader17.Width = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 624);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Users";
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditProfile.Location = new System.Drawing.Point(132, 68);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(114, 23);
            this.btnEditProfile.TabIndex = 25;
            this.btnEditProfile.Text = "Edit Profile";
            this.btnEditProfile.UseVisualStyleBackColor = true;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(132, 39);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(114, 23);
            this.btnNewUser.TabIndex = 26;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // calAllBookings
            // 
            this.calAllBookings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(98)))), ((int)(((byte)(128)))));
            this.calAllBookings.Columns = dataColumns1;
            this.calAllBookings.CurrentDate = new System.DateTime(2018, 2, 7, 14, 21, 33, 182);
            this.calAllBookings.DatesIntervalMode = WeekPlanner.WeekPlannerMode.Daily;
            this.calAllBookings.DayCount = 7;
            this.calAllBookings.GridBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(221)))), ((int)(((byte)(242)))));
            this.calAllBookings.GridCellHeight = 200;
            this.calAllBookings.GridTextFont = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.calAllBookings.HeaderBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.calAllBookings.HeaderColumnsFont = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.calAllBookings.HeaderDatesFont = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.calAllBookings.HeaderFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(192)))), ((int)(((byte)(234)))));
            this.calAllBookings.HeaderFillLeftMarginColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(221)))), ((int)(((byte)(252)))));
            this.calAllBookings.HeaderStyleMode = WeekPlanner.HeaderStyle.Aqua;
            this.calAllBookings.IsAllowedDraggingBetweenRows = true;
            this.calAllBookings.IsAllowedTreeViewDrawing = true;
            this.calAllBookings.ItemHeight = 20;
            this.calAllBookings.ItemTextFont = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.calAllBookings.LeftMargin = 250;
            this.calAllBookings.LeftMarginColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(231)))), ((int)(((byte)(245)))));
            this.calAllBookings.Location = new System.Drawing.Point(6, 33);
            this.calAllBookings.Name = "calAllBookings";
            this.calAllBookings.Size = new System.Drawing.Size(755, 394);
            this.calAllBookings.TabIndex = 27;
            this.calAllBookings.ItemClick += new WeekPlanner.CalendarPlanner.CalendarItemEventHandler(this.calAllBookings_ItemClick);
            this.calAllBookings.Load += new System.EventHandler(this.calAllBookings_Load);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 162);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 459);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listAllBookings);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.listOwnBookings);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "List View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.calDTPick);
            this.tabPage2.Controls.Add(this.btnDayLeft);
            this.tabPage2.Controls.Add(this.btnDayRight);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.numRoomSelect);
            this.tabPage2.Controls.Add(this.calAllBookings);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Calendar View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // calDTPick
            // 
            this.calDTPick.Location = new System.Drawing.Point(455, 4);
            this.calDTPick.Name = "calDTPick";
            this.calDTPick.Size = new System.Drawing.Size(200, 20);
            this.calDTPick.TabIndex = 32;
            this.calDTPick.ValueChanged += new System.EventHandler(this.calDTPick_ValueChanged);
            // 
            // btnDayLeft
            // 
            this.btnDayLeft.Location = new System.Drawing.Point(661, 4);
            this.btnDayLeft.Name = "btnDayLeft";
            this.btnDayLeft.Size = new System.Drawing.Size(47, 23);
            this.btnDayLeft.TabIndex = 31;
            this.btnDayLeft.Text = "<";
            this.btnDayLeft.UseVisualStyleBackColor = true;
            this.btnDayLeft.Click += new System.EventHandler(this.btnDayLeft_Click);
            // 
            // btnDayRight
            // 
            this.btnDayRight.Location = new System.Drawing.Point(714, 4);
            this.btnDayRight.Name = "btnDayRight";
            this.btnDayRight.Size = new System.Drawing.Size(47, 23);
            this.btnDayRight.TabIndex = 30;
            this.btnDayRight.Text = ">";
            this.btnDayRight.UseVisualStyleBackColor = true;
            this.btnDayRight.Click += new System.EventHandler(this.btnDayRight_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Select Room:";
            // 
            // numRoomSelect
            // 
            this.numRoomSelect.Location = new System.Drawing.Point(84, 6);
            this.numRoomSelect.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numRoomSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRoomSelect.Name = "numRoomSelect";
            this.numRoomSelect.Size = new System.Drawing.Size(53, 20);
            this.numRoomSelect.TabIndex = 28;
            this.numRoomSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRoomSelect.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(703, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 23);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 811);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblUserHeader);
            this.Controls.Add(this.btnShowID);
            this.Controls.Add(this.btnHomeLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewBook);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home | Room Booking System";
            this.Activated += new System.EventHandler(this.frmMainTemp_Activated);
            this.Load += new System.EventHandler(this.frmMainTemp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainTemp_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRoomSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnNewBook;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnHomeLogin;
		private System.Windows.Forms.Button btnShowID;
		private System.Windows.Forms.Label lblUserHeader;
		private System.Windows.Forms.Button btnLogOut;
		private System.Windows.Forms.ListView listAllBookings;
		private System.Windows.Forms.ColumnHeader clmRoomID;
		private System.Windows.Forms.ColumnHeader clmDate;
		private System.Windows.Forms.ColumnHeader clmPeriod;
		private System.Windows.Forms.ColumnHeader clmUser;
		private System.Windows.Forms.ListView listOwnBookings;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader clmBookingMade;
		private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader clmNotes;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView listUsers;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Button btnNewUser;
        private WeekPlanner.CalendarPlanner calAllBookings;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown numRoomSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDayLeft;
        private System.Windows.Forms.Button btnDayRight;
        private System.Windows.Forms.DateTimePicker calDTPick;
    }
}

