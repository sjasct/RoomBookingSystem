using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_RBS
{
	public partial class frmNewBook : Form
	{

		booking book;

		DatabaseHelper db;

        int editID;

		public frmNewBook()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnNewBook_Click(object sender, EventArgs e)
		{

			DateTime date = Convert.ToDateTime(dtDate.Text);

			db.insertBooking(Convert.ToInt32(txtRoom.Text), date, Convert.ToInt32(txtPeriod.Text), miscClasses.userID, txtNotes.Text);

			this.Close();
		}

		private void frmNewBook_Load(object sender, EventArgs e)
		{
			db = new DatabaseHelper();
            if(tempVars.editBookingId != 0)
            {
                btnUpdate.Enabled = true;
                btnNewBook.Enabled = false;
                editID = tempVars.editBookingId;
                book = db.getBooking(tempVars.editBookingId);

                txtNotes.Text = book.notes;
                txtPeriod.Text = book.period.ToString();
                txtRoom.Text = book.roomID.ToString();
                dtDate.MinDate = DateTime.MinValue;
                dtDate.MaxDate = DateTime.MaxValue;
                dtDate.Value = book.date;
                tempVars.editBookingId = 0;
            }
            else
            {
                btnNewBook.Enabled = true;
                btnUpdate.Enabled = false;
            }
            

        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dtDate.Text);

            db.updateBooking(editID, Convert.ToInt32(txtRoom.Text), date, Convert.ToInt32(txtPeriod.Text), miscClasses.userID, txtNotes.Text);

            this.Close();
        }
    }
}
