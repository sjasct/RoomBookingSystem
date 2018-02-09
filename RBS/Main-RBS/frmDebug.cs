using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Main_RBS
{
    public partial class frmDebug : Form
    {
        // creates instance of databasehelper
        private DatabaseHelper db;

        public frmDebug()
        {
            InitializeComponent();
        }

        // event method for when the login as admin button is clicked
        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            // get user details for admin
            user user = db.getUser(1);

            // sets session details as those for admin
            session.loggedIn = true;
            session.userID = user.id;
            session.username = user.username;
            session.name = new string[] { user.firstname, user.secondname };
            session.role = user.role;
            session.email = user.email;

            Debug.WriteLine(String.Format("Logged in as {0}", session.username));
        }

        // event method for when the test booking button is clicked
        private void btnTestBooking_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Inserting test booking..");

            // generate random dates, rooms and periods
            Random r = new Random();
            int dateThing = r.Next(1, 22);
            int roomID = r.Next(1, 8);
            int period = r.Next(1, 6);

            // sets date
            DateTime date = new DateTime(2018, 2, dateThing);

            // if booking does not already exist, insert the booking
            if (!db.checkBookingExists(date.ToString(), period, roomID))
            {
                db.insertBooking(roomID, date, period, session.userID, "Test Booking");
            }
        }

        // event method for when the delete all bookings button is clicked
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            // show confirmation dialog to user. continue if user clicked 'yes'
            if (MessageBox.Show("Are you sure you want to delete all bookings?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                // sends misc query to database
                db.miscAction("TRUNCATE TABLE tblBookings");
            }
        }

        // event method for when the login as teacher button is clicked
        private void btnLoginTeacher_Click(object sender, EventArgs e)
        {
            // get user details for teacher
            user user = db.getUser(3);

            // sets session details as those for teacher
            session.loggedIn = true;
            session.userID = user.id;
            session.username = user.username;
            session.name = new string[] { user.firstname, user.secondname };
            session.role = user.role;
            session.email = user.email;

            Debug.WriteLine(String.Format("Logged in as {0}", session.username));
        }

        // event method for when the login as student button is clicked
        private void btnLoginStudent_Click(object sender, EventArgs e)
        {
            // get user details for student
            user user = db.getUser(2);

            // sets session details as those for student
            session.loggedIn = true;
            session.userID = user.id;
            session.username = user.username;
            session.name = new string[] { user.firstname, user.secondname };
            session.role = user.role;
            session.email = user.email;

            Debug.WriteLine(String.Format("Logged in as {0}", session.username));
        }

        // when the form is loaded
        private void frmDebug_Load(object sender, EventArgs e)
        {
            // create new instance of the database helper
            db = new DatabaseHelper();
        }
    }
}