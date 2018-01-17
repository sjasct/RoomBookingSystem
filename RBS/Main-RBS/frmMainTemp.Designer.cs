namespace Main_RBS
{
	partial class frmMainTemp
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
			this.btnNewBook = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOwnBookings = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnHomeLogin = new System.Windows.Forms.Button();
			this.btnShowID = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.lblUserHeader = new System.Windows.Forms.Label();
			this.btnLogOut = new System.Windows.Forms.Button();
			this.btnTestBooking = new System.Windows.Forms.Button();
			this.listNewBookThingy = new System.Windows.Forms.ListView();
			this.clmRoomID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnDeleteAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnNewBook
			// 
			this.btnNewBook.Location = new System.Drawing.Point(12, 58);
			this.btnNewBook.Name = "btnNewBook";
			this.btnNewBook.Size = new System.Drawing.Size(149, 23);
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Temp Home Screen";
			// 
			// btnOwnBookings
			// 
			this.btnOwnBookings.Location = new System.Drawing.Point(12, 87);
			this.btnOwnBookings.Name = "btnOwnBookings";
			this.btnOwnBookings.Size = new System.Drawing.Size(149, 23);
			this.btnOwnBookings.TabIndex = 4;
			this.btnOwnBookings.Text = "Your Bookings";
			this.btnOwnBookings.UseVisualStyleBackColor = true;
			this.btnOwnBookings.Click += new System.EventHandler(this.btnOwnBookings_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 165);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "All Bookings";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// btnHomeLogin
			// 
			this.btnHomeLogin.Location = new System.Drawing.Point(167, 87);
			this.btnHomeLogin.Name = "btnHomeLogin";
			this.btnHomeLogin.Size = new System.Drawing.Size(149, 23);
			this.btnHomeLogin.TabIndex = 7;
			this.btnHomeLogin.Text = "Log In";
			this.btnHomeLogin.UseVisualStyleBackColor = true;
			this.btnHomeLogin.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnShowID
			// 
			this.btnShowID.Location = new System.Drawing.Point(167, 58);
			this.btnShowID.Name = "btnShowID";
			this.btnShowID.Size = new System.Drawing.Size(149, 23);
			this.btnShowID.TabIndex = 8;
			this.btnShowID.Text = "View Profile";
			this.btnShowID.UseVisualStyleBackColor = true;
			this.btnShowID.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(496, 9);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(101, 23);
			this.btnRefresh.TabIndex = 9;
			this.btnRefresh.Text = "Refresh Data";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
			this.btnLogOut.Location = new System.Drawing.Point(167, 116);
			this.btnLogOut.Name = "btnLogOut";
			this.btnLogOut.Size = new System.Drawing.Size(149, 23);
			this.btnLogOut.TabIndex = 11;
			this.btnLogOut.Text = "Log Out";
			this.btnLogOut.UseVisualStyleBackColor = true;
			this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
			// 
			// btnTestBooking
			// 
			this.btnTestBooking.Location = new System.Drawing.Point(12, 116);
			this.btnTestBooking.Name = "btnTestBooking";
			this.btnTestBooking.Size = new System.Drawing.Size(149, 23);
			this.btnTestBooking.TabIndex = 12;
			this.btnTestBooking.Text = "Insert test booking";
			this.btnTestBooking.UseVisualStyleBackColor = true;
			this.btnTestBooking.Click += new System.EventHandler(this.btnTestBooking_Click);
			// 
			// listNewBookThingy
			// 
			this.listNewBookThingy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRoomID,
            this.clmDate,
            this.clmPeriod,
            this.clmUser});
			this.listNewBookThingy.FullRowSelect = true;
			this.listNewBookThingy.HideSelection = false;
			this.listNewBookThingy.Location = new System.Drawing.Point(16, 181);
			this.listNewBookThingy.Name = "listNewBookThingy";
			this.listNewBookThingy.Size = new System.Drawing.Size(581, 187);
			this.listNewBookThingy.TabIndex = 13;
			this.listNewBookThingy.UseCompatibleStateImageBehavior = false;
			this.listNewBookThingy.View = System.Windows.Forms.View.Details;
			// 
			// clmRoomID
			// 
			this.clmRoomID.Text = "RoomID";
			// 
			// clmDate
			// 
			this.clmDate.Text = "Date";
			// 
			// clmPeriod
			// 
			this.clmPeriod.Text = "Period";
			// 
			// clmUser
			// 
			this.clmUser.Text = "UserID";
			// 
			// btnDeleteAll
			// 
			this.btnDeleteAll.Location = new System.Drawing.Point(448, 116);
			this.btnDeleteAll.Name = "btnDeleteAll";
			this.btnDeleteAll.Size = new System.Drawing.Size(149, 23);
			this.btnDeleteAll.TabIndex = 14;
			this.btnDeleteAll.Text = "Delete All Bookings";
			this.btnDeleteAll.UseVisualStyleBackColor = true;
			this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
			// 
			// frmMainTemp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 399);
			this.Controls.Add(this.btnDeleteAll);
			this.Controls.Add(this.listNewBookThingy);
			this.Controls.Add(this.btnTestBooking);
			this.Controls.Add(this.btnLogOut);
			this.Controls.Add(this.lblUserHeader);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnShowID);
			this.Controls.Add(this.btnHomeLogin);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnOwnBookings);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnNewBook);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmMainTemp";
			this.Text = "Home | Room Booking System";
			this.Activated += new System.EventHandler(this.frmMainTemp_Activated);
			this.Load += new System.EventHandler(this.frmMainTemp_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainTemp_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMainTemp_KeyPress);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnNewBook;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOwnBookings;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnHomeLogin;
		private System.Windows.Forms.Button btnShowID;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label lblUserHeader;
		private System.Windows.Forms.Button btnLogOut;
		private System.Windows.Forms.Button btnTestBooking;
		private System.Windows.Forms.ListView listNewBookThingy;
		private System.Windows.Forms.ColumnHeader clmRoomID;
		private System.Windows.Forms.ColumnHeader clmDate;
		private System.Windows.Forms.ColumnHeader clmPeriod;
		private System.Windows.Forms.ColumnHeader clmUser;
		private System.Windows.Forms.Button btnDeleteAll;
	}
}

