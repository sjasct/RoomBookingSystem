using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Main_RBS
{
    public partial class frmBookingDetails : Form
    {
        // sets the global vars for this class
        private booking book;

        private clDB db;
        private int editID;
        private bool modeEdit;
        private clHelper help;

        public frmBookingDetails()
        {
            InitializeComponent();
        }

        // event method for when the submit button is clicked
        private void btnNewBook_Click(object sender, EventArgs e)
        {
            // converts the date in the dtTime control to text
            DateTime date = Convert.ToDateTime(dtDate.Text);

            // if the booking is not already taken
            if (!db.checkBookingExists(dtDate.Text, Convert.ToInt32(txtPeriod.Value), Convert.ToInt32(txtRoom.Value), editID))
            {
                // if in edit mode
                if (modeEdit)
                {
                    // update the booking
                    db.updateBooking(editID, Convert.ToInt32(txtRoom.Value), date, Convert.ToInt32(txtPeriod.Value), session.userID, txtNotes.Text);
                    help.refreshHomeForm();
                }
                else
                {
                    // insert the booking
                    db.insertBooking(Convert.ToInt32(txtRoom.Value), date, Convert.ToInt32(txtPeriod.Value), session.userID, txtNotes.Text);
                    help.refreshHomeForm();
                }

                // close the form
                this.Close();
            }
            else
            {
                // show error message
                MessageBox.Show("That slot is taken!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // event method for when the form is loaded
        private void frmNewBook_Load(object sender, EventArgs e)
        {
            // creates new instance of the databasehelper object
            db = new clDB();
            help = new clHelper();

            // defaults edit mode to false
            modeEdit = false;

            // if a booking id has been set
            if (tempVars.editBookingId != -1)
            {
                // set all vars to edit mode
                this.Text = "Edit Booking";
                modeEdit = true;
                editID = tempVars.editBookingId;

                // gets booking details
                book = db.getBooking(tempVars.editBookingId);

                // fills out the form elements with the existing details
                txtNotes.Text = book.notes;
                txtPeriod.Value = book.period;
                txtRoom.Value = book.roomID;
                dtDate.MinDate = DateTime.MinValue;
                dtDate.MaxDate = DateTime.MaxValue;
                dtDate.Value = book.date;

                // resets the booking id
                tempVars.editBookingId = -1;
            }
            else
            {
                // sets all vars to new book mode
                this.Text = "New Booking";
                modeEdit = false;
                btnDeleteBook.Enabled = false;
                btnDeleteBook.Visible = false;
            }

            // if user has permission to edit booking (either booked themselves or they're an admin

            if (book != null && (book.UserID == session.userID || session.role == user.roles.Admin))
            {
                // enable ability to delete booking
                btnDeleteBook.Enabled = true;
            }
            else
            {
                btnDeleteBook.Enabled = false;
            }
        }

        // event method for when the delete booking button has been clicked
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            // show confirmation message - if answered yes, continue
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                // delete the booking with id of x from tblBookings
                string cmd = String.Format("DELETE from tblBookings WHERE Id = {0}", book.id);

                Debug.WriteLine("Started delete process..");

                try
                {
                    // execute command with the miscAction method
                    db.miscAction(cmd);
                    help.refreshHomeForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                // closes the form
                this.Close();
            }
        }

        // event method for checking if a booking slot is taken
        private void btnBookExist_Click(object sender, EventArgs e)
        {
            // if the booking slot is taken
            if (db.checkBookingExists(dtDate.Text, Convert.ToInt32(txtPeriod.Value), Convert.ToInt32(txtRoom.Value), editID))
            {
                MessageBox.Show("That slot is taken!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // if not
            else
            {
                MessageBox.Show("That slot is available!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}