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

			db.insertBooking(Convert.ToInt32(txtRoom.Value), date, Convert.ToInt32(txtPeriod.Value), session.userID, txtNotes.Text);

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
                txtPeriod.Value = book.period;
                txtRoom.Value = book.roomID;
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

            if(book.UserID == session.userID || session.role == "Admin"){
                btnDeleteBook.Enabled = true;
            }
            else
            {
                btnDeleteBook.Enabled = false;
            }
            

        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dtDate.Text);

            db.updateBooking(editID, Convert.ToInt32(txtRoom.Value), date, Convert.ToInt32(txtPeriod.Value), session.userID, txtNotes.Text);

            this.Close();
        }

        private void txtPeriod_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            string cmd = String.Format("DELETE from tblBookings WHERE Id = {0}", book.id);

            //MessageBox.Show(cmd);

            try
            {
                db.miscAction(cmd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            



            this.Close();
        }
    }
}
