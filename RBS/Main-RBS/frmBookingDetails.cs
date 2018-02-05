using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Main_RBS
{
    public partial class frmBookingDetails : Form
    {
        private booking book;

        private DatabaseHelper db;

        private int editID;

        private bool modeEdit;

        public frmBookingDetails()
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

            if (modeEdit)
            {
                db.updateBooking(editID, Convert.ToInt32(txtRoom.Value), date, Convert.ToInt32(txtPeriod.Value), session.userID, txtNotes.Text);
            }
            else
            {
                db.insertBooking(Convert.ToInt32(txtRoom.Value), date, Convert.ToInt32(txtPeriod.Value), session.userID, txtNotes.Text);
            }

            this.Close();
        }

        private void frmNewBook_Load(object sender, EventArgs e)
        {
            db = new DatabaseHelper();
            modeEdit = false;
            if (tempVars.editBookingId != -1)
            {
                this.Text = "Edit Booking";
                modeEdit = true;

                editID = tempVars.editBookingId;
                book = db.getBooking(tempVars.editBookingId);

                txtNotes.Text = book.notes;
                txtPeriod.Value = book.period;
                txtRoom.Value = book.roomID;
                dtDate.MinDate = DateTime.MinValue;
                dtDate.MaxDate = DateTime.MaxValue;
                dtDate.Value = book.date;
                tempVars.editBookingId = -1;
            }
            else
            {
                this.Text = "New Booking";
                modeEdit = false;
                btnDeleteBook.Enabled = false;
            }

            if (book.UserID == session.userID || session.role == "Admin")
            {
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
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                string cmd = String.Format("DELETE from tblBookings WHERE Id = {0}", book.id);

                Debug.WriteLine("Started delete process..");

                try
                {
                    db.miscAction(cmd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                this.Close();
            }
        }
    }
}