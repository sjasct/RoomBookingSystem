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
			this.lstBookings = new System.Windows.Forms.ListBox();
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
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(299, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "All Bookings";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// lstBookings
			// 
			this.lstBookings.FormattingEnabled = true;
			this.lstBookings.Location = new System.Drawing.Point(302, 29);
			this.lstBookings.Name = "lstBookings";
			this.lstBookings.Size = new System.Drawing.Size(272, 108);
			this.lstBookings.TabIndex = 6;
			this.lstBookings.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// frmMainTemp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 324);
			this.Controls.Add(this.lstBookings);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnOwnBookings);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnNewBook);
			this.Name = "frmMainTemp";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.frmMainTemp_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnNewBook;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOwnBookings;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lstBookings;
	}
}

