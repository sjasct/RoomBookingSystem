namespace Main_RBS
{
	partial class frmBookingDetails
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
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnNewBook = new System.Windows.Forms.Button();
            this.txtRoom = new System.Windows.Forms.NumericUpDown();
            this.txtPeriod = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnBookExist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(52, 15);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(266, 20);
            this.dtDate.TabIndex = 0;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Room";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Period";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.AllowDrop = true;
            this.txtNotes.Location = new System.Drawing.Point(52, 91);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(266, 92);
            this.txtNotes.TabIndex = 3;
            // 
            // btnNewBook
            // 
            this.btnNewBook.Location = new System.Drawing.Point(243, 202);
            this.btnNewBook.Name = "btnNewBook";
            this.btnNewBook.Size = new System.Drawing.Size(75, 23);
            this.btnNewBook.TabIndex = 4;
            this.btnNewBook.Text = "Submit";
            this.btnNewBook.UseVisualStyleBackColor = true;
            this.btnNewBook.Click += new System.EventHandler(this.btnNewBook_Click);
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(53, 41);
            this.txtRoom.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.txtRoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(38, 20);
            this.txtRoom.TabIndex = 1;
            this.txtRoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(54, 67);
            this.txtPeriod.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(38, 20);
            this.txtPeriod.TabIndex = 2;
            this.txtPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPeriod.ValueChanged += new System.EventHandler(this.txtPeriod_ValueChanged);
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(162, 202);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBook.TabIndex = 5;
            this.btnDeleteBook.Text = "Delete";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // btnBookExist
            // 
            this.btnBookExist.Location = new System.Drawing.Point(15, 202);
            this.btnBookExist.Name = "btnBookExist";
            this.btnBookExist.Size = new System.Drawing.Size(112, 23);
            this.btnBookExist.TabIndex = 6;
            this.btnBookExist.Text = "Check Availability";
            this.btnBookExist.UseVisualStyleBackColor = true;
            this.btnBookExist.Click += new System.EventHandler(this.btnBookExist_Click);
            // 
            // frmBookingDetails
            // 
            this.AcceptButton = this.btnNewBook;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 238);
            this.Controls.Add(this.btnBookExist);
            this.Controls.Add(this.btnDeleteBook);
            this.Controls.Add(this.txtPeriod);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.btnNewBook);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBookingDetails";
            this.Text = "x Booking";
            this.Load += new System.EventHandler(this.frmNewBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.Button btnNewBook;
        private System.Windows.Forms.NumericUpDown txtRoom;
        private System.Windows.Forms.NumericUpDown txtPeriod;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnBookExist;
    }
}