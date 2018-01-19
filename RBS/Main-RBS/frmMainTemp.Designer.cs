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
            this.listAllBookings = new System.Windows.Forms.ListView();
            this.clmRoomID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBookingMade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listOwnBookings = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoginSelf = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnLoginBranton = new System.Windows.Forms.Button();
            this.btnLoginHood = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewBook
            // 
            this.btnNewBook.Location = new System.Drawing.Point(12, 58);
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
            this.btnOwnBookings.Size = new System.Drawing.Size(114, 23);
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
            // 
            // btnHomeLogin
            // 
            this.btnHomeLogin.Location = new System.Drawing.Point(483, 68);
            this.btnHomeLogin.Name = "btnHomeLogin";
            this.btnHomeLogin.Size = new System.Drawing.Size(114, 23);
            this.btnHomeLogin.TabIndex = 7;
            this.btnHomeLogin.Text = "Log In";
            this.btnHomeLogin.UseVisualStyleBackColor = true;
            this.btnHomeLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowID
            // 
            this.btnShowID.Location = new System.Drawing.Point(321, 152);
            this.btnShowID.Name = "btnShowID";
            this.btnShowID.Size = new System.Drawing.Size(114, 23);
            this.btnShowID.TabIndex = 8;
            this.btnShowID.Text = "View Profile";
            this.btnShowID.UseVisualStyleBackColor = true;
            this.btnShowID.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(522, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
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
            this.btnLogOut.Location = new System.Drawing.Point(483, 39);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(114, 23);
            this.btnLogOut.TabIndex = 11;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnTestBooking
            // 
            this.btnTestBooking.Location = new System.Drawing.Point(12, 116);
            this.btnTestBooking.Name = "btnTestBooking";
            this.btnTestBooking.Size = new System.Drawing.Size(114, 23);
            this.btnTestBooking.TabIndex = 12;
            this.btnTestBooking.Text = "Insert test booking";
            this.btnTestBooking.UseVisualStyleBackColor = true;
            this.btnTestBooking.Click += new System.EventHandler(this.btnTestBooking_Click);
            // 
            // listAllBookings
            // 
            this.listAllBookings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRoomID,
            this.clmDate,
            this.clmPeriod,
            this.clmUser,
            this.clmBookingMade,
            this.clmId});
            this.listAllBookings.FullRowSelect = true;
            this.listAllBookings.HideSelection = false;
            this.listAllBookings.Location = new System.Drawing.Point(16, 181);
            this.listAllBookings.Name = "listAllBookings";
            this.listAllBookings.Size = new System.Drawing.Size(581, 187);
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
            // 
            // clmId
            // 
            this.clmId.Text = "ID";
            // 
            // listOwnBookings
            // 
            this.listOwnBookings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listOwnBookings.FullRowSelect = true;
            this.listOwnBookings.HideSelection = false;
            this.listOwnBookings.Location = new System.Drawing.Point(16, 396);
            this.listOwnBookings.Name = "listOwnBookings";
            this.listOwnBookings.Size = new System.Drawing.Size(581, 187);
            this.listOwnBookings.TabIndex = 15;
            this.listOwnBookings.UseCompatibleStateImageBehavior = false;
            this.listOwnBookings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "RoomID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
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
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Your Bookings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Login as:";
            // 
            // btnLoginSelf
            // 
            this.btnLoginSelf.Location = new System.Drawing.Point(441, 123);
            this.btnLoginSelf.Name = "btnLoginSelf";
            this.btnLoginSelf.Size = new System.Drawing.Size(75, 23);
            this.btnLoginSelf.TabIndex = 18;
            this.btnLoginSelf.Text = "scottsj03";
            this.btnLoginSelf.UseVisualStyleBackColor = true;
            this.btnLoginSelf.Click += new System.EventHandler(this.btnLoginSelf_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(441, 152);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(75, 23);
            this.btnAdmin.TabIndex = 19;
            this.btnAdmin.Text = "sysadmin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnLoginBranton
            // 
            this.btnLoginBranton.Location = new System.Drawing.Point(522, 123);
            this.btnLoginBranton.Name = "btnLoginBranton";
            this.btnLoginBranton.Size = new System.Drawing.Size(75, 23);
            this.btnLoginBranton.TabIndex = 20;
            this.btnLoginBranton.Text = "brantodb01";
            this.btnLoginBranton.UseVisualStyleBackColor = true;
            this.btnLoginBranton.Click += new System.EventHandler(this.btnLoginBranton_Click);
            // 
            // btnLoginHood
            // 
            this.btnLoginHood.Location = new System.Drawing.Point(522, 152);
            this.btnLoginHood.Name = "btnLoginHood";
            this.btnLoginHood.Size = new System.Drawing.Size(75, 23);
            this.btnLoginHood.TabIndex = 21;
            this.btnLoginHood.Text = "hoodj03";
            this.btnLoginHood.UseVisualStyleBackColor = true;
            this.btnLoginHood.Click += new System.EventHandler(this.btnLoginHood_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(132, 58);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(114, 23);
            this.btnDeleteAll.TabIndex = 22;
            this.btnDeleteAll.Text = "Delete All Bookings";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // frmMainTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 607);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnLoginHood);
            this.Controls.Add(this.btnLoginBranton);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnLoginSelf);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listOwnBookings);
            this.Controls.Add(this.listAllBookings);
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
        private System.Windows.Forms.Button btnLoginSelf;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnLoginBranton;
        private System.Windows.Forms.Button btnLoginHood;
        private System.Windows.Forms.Button btnDeleteAll;
    }
}

