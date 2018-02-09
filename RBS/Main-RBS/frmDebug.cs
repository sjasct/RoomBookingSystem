using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Main_RBS
{
    public partial class frmDebug : Form
    {

        DatabaseHelper db;

        public frmDebug()
        {
            InitializeComponent();
        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            user user = db.getUser(1);

            session.loggedIn = true;
            session.userID = user.id;
            session.username = user.username;
            session.name = new string[] { user.firstname, user.secondname };
            session.role = user.role;
            session.email = user.email;

            Debug.WriteLine(String.Format("Logged in as {0}", session.username));
        }

        private void btnTestBooking_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Inserting test booking..");

            Random r = new Random();
            int dateThing = r.Next(1, 22);
            int roomID = r.Next(1, 8);
            int period = r.Next(1, 6);

            DateTime date = new DateTime(2018, 2, dateThing);

            if (!db.checkBookingExists(date.ToString(), period, roomID))
            {
                db.insertBooking(roomID, date, period, session.userID, "Test Booking");
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all bookings?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                db.miscAction("TRUNCATE TABLE tblBookings");
            }
        }

        private void btnLoginTeacher_Click(object sender, EventArgs e)
        {
            user user = db.getUser(3);

            session.loggedIn = true;
            session.userID = user.id;
            session.username = user.username;
            session.name = new string[] { user.firstname, user.secondname };
            session.role = user.role;
            session.email = user.email;

            Debug.WriteLine(String.Format("Logged in as {0}", session.username));
        }

        private void btnLoginStudent_Click(object sender, EventArgs e)
        {
            user user = db.getUser(2);

            session.loggedIn = true;
            session.userID = user.id;
            session.username = user.username;
            session.name = new string[] { user.firstname, user.secondname };
            session.role = user.role;
            session.email = user.email;

            Debug.WriteLine(String.Format("Logged in as {0}", session.username));
        }

        private void frmDebug_Load(object sender, EventArgs e)
        {
            db = new DatabaseHelper();
        }
    }
}
