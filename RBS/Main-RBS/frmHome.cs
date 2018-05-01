using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using WeekPlanner;

namespace Main_RBS
{
    public partial class frmHome : Form
    {
        private clDB db;

        private void frmMainTemp_Load(object sender, EventArgs e)
        {

            // cre
            db = new clDB();

            // create new event handler for when the dates have been changed
            calAllBookings.ItemDatesChanged += CalAllBookings_ItemDatesChanged;

            // set the fonts
            calAllBookings.ItemTextFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Pixel);
            calAllBookings.HeaderColumnsFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            calAllBookings.GridTextFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            calAllBookings.HeaderDatesFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Pixel);

            // add a column to display periods
            calAllBookings.Columns.Add("clmPeriod", "Period", 100);

            // sets the calview date to today
            calAllBookings.CurrentDate = DateTime.Now.Date;

            // sets the datetime picker to only go back to 2nd Jan 1970
            calDTPick.MinDate = Convert.ToDateTime("02/01/1970");

            Debug.WriteLine("Loading main form..");

            // set session as not logged in
            session.loggedIn = false;
            session.role = user.roles.None;
            session.userID = -1;

            tempVars.editBookingId = -1;
            
            // refresh the form
            refreshForm();

        }

        
        public void rePopCalndar(int roomID)
        {

            // gets the date of 1st Jan 1970 as datetime format
            DateTime earlyDate = Convert.ToDateTime("01/01/1970");

            // clear all rows upon refresh
            calAllBookings.Calendar.Rows.Clear();

            // create an entry in calview on 1st Jan 1970 5 times for each 5 periods
            // this is done to ensure that all 5 period rows are shown at all points
            // (rows must have at least 1 item to show)
            for (int n = 1; n < 6; n++)
            {
                // empty
                WeekPlannerItemCollection ic = new WeekPlannerItemCollection();
                WeekPlannerItem i = new WeekPlannerItem();
                i.StartDate = earlyDate;
                i.EndDate = earlyDate;
                i.Subject = "-";
                i.BackColor = System.Drawing.Color.YellowGreen;
                i.bookingid = -2;
                i.userid = -2;
                ic.Add(i);

                // return the bookings from the database into a List with the booking class
                List<booking> bookinglist = db.populateCalendar(roomID, n);

                // for each booking, add it to the calview
                foreach (booking bk in bookinglist)
                {
                    // create new weekplanneritem object
                    WeekPlannerItem item = new WeekPlannerItem();
                    // set the dates
                    item.StartDate = bk.date;
                    item.EndDate = bk.date;

                    // set the ids
                    item.bookingid = bk.id;
                    item.userid = bk.UserID;

                    // set the subject as the user's username
                    item.Subject = db.getUsername(item.userid);

                    // if the booking user's ID is the current user
                    if (bk.UserID == session.userID)
                    {
                        // set colour of item to red
                        item.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        // set colour of item to cadetblue
                        item.BackColor = System.Drawing.Color.CadetBlue;
                    }
                    // add the items to the calview
                    ic.Add(item);
                }

                // add columns to the calview
                DataColumns cr = new DataColumns(calAllBookings.Calendar);
                cr["clmPeriod"].Data.Add(String.Format("Period {0}", n.ToString()));
                calAllBookings.Rows.Add(cr, ic);
            }
        }

        // when the calview dates have been changed
        private void CalAllBookings_ItemDatesChanged(object sender, WeekPlannerItemEventArgs e)
        {
            // refresh the form
            refreshForm();
        }

        public frmHome()
        {
            InitializeComponent();
        }

        // populate the all bookings listview control
        private void popAllBookings()
        {
            Debug.WriteLine("Populating all bookings list..");

            // create new list and get returned bookings from database
            List<ListViewItem> items = db.popBookings();

            // foreach item, add to control
            foreach (ListViewItem item in items)
            {
                listAllBookings.Items.Add(item);
            }
        }

        // populate the own bookings listview control
        private void popOwnBookings()
        {
            Debug.WriteLine("Populating own bookings list..");

            // if user is logged in
            if (session.loggedIn)
            {

                // create new list and get returned bookings from database
                List<ListViewItem> items = db.popBookings(false);

                // foreach item, add to control
                foreach (ListViewItem item in items)
                {
                    listOwnBookings.Items.Add(item);
                }
            }
        }

        // populate users listview control
        private void popUsers()
        {
            Debug.WriteLine("Populating users list..");

            // create new list and get returned users from database
            List<ListViewItem> items = db.popUsers();

            // foreach item, add to control
            foreach (ListViewItem item in items)
            {
                listUsers.Items.Add(item);
            }
        }

        // when login button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Opening login form..");

            // create new object of login form, open the form
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
        }

        // when "view profile" button is clicked"
        private void button1_Click_1(object sender, EventArgs e)
        {
            // try to show message box with user details
            try
            {
                string userdata = String.Format("Username: {0}\nName: {1} {2}\nrole: {3}\n\nID: {4}", session.username, session.name[0], session.name[1], session.role, session.userID);
                MessageBox.Show(userdata);
            }
            // throw error when user is not logged in
            catch (System.NullReferenceException)
            {
                MessageBox.Show("You are not logged in!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // when refresh button is clicked
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // refresh the form
            refreshForm();
        }

        // refresh the form with new data
        public void refreshForm()
        {
            // start stopwatch - for diagnostics only
            Stopwatch refreshTime = new Stopwatch();
            refreshTime.Start();

            // populate the calview with the selected room
            rePopCalndar(Convert.ToInt32(numRoomSelect.Value));
            Debug.WriteLine("Refreshing form..");

            // set the header (Welcome X!..) text
            string name;
            try
            {
                name = session.name[0];
            }
            catch
            {
                name = "";
            }
            if (string.IsNullOrEmpty(name) || name == "")
            {
                lblUserHeader.Text = "Not logged in..";
            }
            else
            {
                lblUserHeader.Text = String.Format("Welcome {0}!", name);
            }

            // if user is not logged in / has no role
            if (session.loggedIn == false || session.role == user.roles.None)
            {
                // set user's permissions based on role
                btnNewBook.Enabled = false;
                btnLogOut.Enabled = false;
                btnHomeLogin.Enabled = true;
                btnShowID.Enabled = false;
                btnNewUser.Enabled = false;
                btnEditProfile.Enabled = false;
            }
            // if user is student
            else if (session.role == user.roles.Student)
            {
                // set user's permissions based on role
                btnShowID.Enabled = true;
                btnNewBook.Enabled = false;
                btnLogOut.Enabled = true;
                btnHomeLogin.Enabled = false;
                btnNewUser.Enabled = false;
                btnEditProfile.Enabled = true;
            }
            // if user is teacher
            else if (session.role == user.roles.Teacher)
            {
                // set user's permissions based on role
                btnShowID.Enabled = true;
                btnNewBook.Enabled = true;
                btnLogOut.Enabled = true;
                btnHomeLogin.Enabled = false;
                btnNewUser.Enabled = false;
                btnEditProfile.Enabled = true;
            }
            // if user is Admin
            else if (session.role == user.roles.Admin)
            {
                // set user's permissions based on role
                btnShowID.Enabled = true;
                btnNewBook.Enabled = true;
                btnLogOut.Enabled = true;
                btnHomeLogin.Enabled = false;
                btnNewUser.Enabled = true;
                btnEditProfile.Enabled = true;
            }

            // wipe items in all bookings list
            foreach (ListViewItem item in listAllBookings.Items)
            {
                item.Remove();
            }

            // wipe items in own bookings list
            foreach (ListViewItem item in listOwnBookings.Items)
            {
                item.Remove();
            }

            // wipe items in user list
            foreach (ListViewItem item in listUsers.Items)
            {
                item.Remove();
            }

            // populate listview controls for all bookings, own bookings and users
            popAllBookings();
            popOwnBookings();
            popUsers();

            // stop stopwatch, show time to debug
            refreshTime.Stop();
            Debug.WriteLine(String.Format("Took {0} milliseconds to refresh", refreshTime.ElapsedMilliseconds.ToString()));
        }

        private void frmMainTemp_Activated(object sender, EventArgs e)
        {
            //refreshForm();
        }


        // when log out button is clicked
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Logging user out..");

            // default success to false
            bool success = false;

            // attempt to reset session values
            try
            {
                session.loggedIn = false;
                session.userID = -1;
                session.username = null;
                session.name = new string[] { "", "" };
                session.role = user.roles.None;
                session.email = null;
                success = true;
            }
            // if fails, show message
            catch
            {
                MessageBox.Show("Log out failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // if success, show success message and refresh form
            if (success)
            {
                MessageBox.Show("You have successfully been logged out!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshForm();
            }
        }

        // when test booking button is clicked
        private void btnTestBooking_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Inserting test booking..");
            
            // generate random values
            Random r = new Random();
            int dateThing = r.Next(1, 22);
            int roomID = r.Next(1, 8);
            int period = r.Next(1, 6);

            // convert random date into datetime format
            DateTime date = new DateTime(2018, 2, dateThing);

            // if booking doesn't already exist, insert into table
            if (!db.checkBookingExists(date.ToString(), period, roomID))
            {
                db.insertBooking(roomID, date, period, session.userID, "Test Booking");
            }

            // refresh the form
            refreshForm();
        }

        // when a key is pressed when the form is in focus
        private void frmMainTemp_KeyDown(object sender, KeyEventArgs e)
        {
            // if the key is F5
            if (e.KeyCode == Keys.F5)
            {
                Debug.WriteLine("Detected F5 key");
                // refresh the form
                refreshForm();
            }
            // if key is F12
            if (e.KeyCode == Keys.F12)
            {
                // show debug form
                new frmDebug().ShowDialog();
            }

            // quick logins. when numpad 1-3 entered, login as set user
            if (e.KeyCode == Keys.NumPad1)
            {
                loginAsUser(db.getUser(1));
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                loginAsUser(db.getUser(3));
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                loginAsUser(db.getUser(2));
            }

        }

        // when new booking button is clicked
        private void btnNewBook_Click(object sender, EventArgs e)
        {
            // show new booking form
            new frmBookingDetails().ShowDialog();
        }

        // when delete all bookings button is clicked
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            // show confirmation message - if answer is yes
            if (MessageBox.Show("Are you sure you want to delete all bookings?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                // delete all bookings
                db.miscAction("TRUNCATE TABLE tblBookings");

                // refresh the form
                refreshForm();
            }
        }

        // when an item in listallbookings has been clicked
        private void listAllBookings_ItemActivate(object sender, EventArgs e)
        {

            // get the selected values
            int editBookingId = Convert.ToInt32(listAllBookings.SelectedItems[0].SubItems[5].Text);
            string editUserId = listAllBookings.SelectedItems[0].SubItems[3].Text;

            // set the tempvar to the retrieved booking ID
            tempVars.editBookingId = editBookingId;

            // if user is booker or user is admin
            if (editUserId == session.username || session.role == user.roles.Admin)
            {
                // set mode to edit
                tempVars.bookingMode = tempVars.modes.Edit;
            }
            // if not
            else
            {
                // set mode to view
                tempVars.bookingMode = tempVars.modes.View;
            }

            // open booking form
            new frmBookingDetails().ShowDialog();
        }

        private void listAllBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // method to login as user
        private void loginAsUser(user u)
        {
            // set all session values to retirieved user
            session.loggedIn = true;
            session.userID = u.id;
            session.username = u.username;
            session.name = new string[] { u.firstname, u.secondname };
            session.role = u.role;
            session.email = u.email;
            refreshForm();

            Debug.WriteLine(String.Format("Logged in as {0}", session.username));
        }

        // START: Login as user buttons
        private void btnLoginSelf_Click(object sender, EventArgs e)
        {
            loginAsUser(db.getUser(1));
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            loginAsUser(db.getUser(8));
        }

        private void btnLoginBranton_Click(object sender, EventArgs e)
        {
            loginAsUser(db.getUser(2));
        }

        private void btnLoginHood_Click(object sender, EventArgs e)
        {
            loginAsUser(db.getUser(3));
        }
        // END: Login as user buttons

        private void listOwnBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // when item clicked on users list
        private void listUsers_ItemActivate(object sender, EventArgs e)
        {
            // get the selected user's ID
            int editUserId = Convert.ToInt32(listUsers.SelectedItems[0].SubItems[0].Text);

            // set the tempvar user ID to selected user ID
            tempVars.editUserId = editUserId;

            // if user trying to edit own or user is admin
            if (session.userID == editUserId || session.role == user.roles.Admin)
            {
                // set mode to edit
                tempVars.userMode = tempVars.modes.Edit;
            }
            // if not
            else
            {
                // set mode to view
                tempVars.userMode = tempVars.modes.View;
            }

            // show edit user form
            new frmEditUser().ShowDialog();

        }

        // when edit profile button has been clicked
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            // set edit user ID to current user ID
            tempVars.editUserId = session.userID;

            // open edit user form
            new frmEditUser().ShowDialog();
        }

        // when new user button has been clicked
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            // set edit mode to new user
            tempVars.editUserId = -1;

            // open new user form
            new frmEditUser().ShowDialog();
        }

        // when item in own bookings list has been created
        private void listOwnBookings_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                // get selected values
                int editBookingId = Convert.ToInt32(listOwnBookings.SelectedItems[0].SubItems[5].Text);
                string editUserId = listOwnBookings.SelectedItems[0].SubItems[3].Text;

                // set tempvars booking id
                tempVars.editBookingId = editBookingId;

                // if booker is current user or user is admin
                if (editUserId == session.username || session.role == user.roles.Admin)
                {
                    // set mode to edit
                    tempVars.bookingMode = tempVars.modes.Edit;
                }
                // if not
                else
                {
                    // set mode to view
                    tempVars.bookingMode = tempVars.modes.View;
                }

                // open edit booking form
                new frmBookingDetails().ShowDialog();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void calAllBookings_Load(object sender, EventArgs e)
        {
        }

        // when item in calview is clicked
        private void calAllBookings_ItemClick(object sender, WeekPlannerItemEventArgs e)
        {
            // get the selected booking & user id
            int editBookingId = e.Item.bookingid;
            string editUserId = db.getUsername(e.Item.userid);

            // set booking id tempvar
            tempVars.editBookingId = editBookingId;

            // if user is booker or user is admin
            if (editUserId == session.username || session.role == user.roles.Admin)
            {
                // set mode to edit
                tempVars.bookingMode = tempVars.modes.Edit;
            }

            // if not
            else
            {
                // set mode to view
                tempVars.bookingMode = tempVars.modes.View;
            }


            // open edit booking form
            new frmBookingDetails().ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        // when room select has been changed
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // repopulate calview with room bookings
            rePopCalndar(Convert.ToInt32(numRoomSelect.Value));
        }

        // when +1 day has been clicked on calview
        private void btnDayRight_Click(object sender, EventArgs e)
        {
            // add a day to current date for calview
            calAllBookings.CurrentDate = calAllBookings.CurrentDate.AddDays(1);
        }

        // when -1day has been clicked on calview
        private void btnDayLeft_Click(object sender, EventArgs e)
        {
            // remove a day from current date for calview
            calAllBookings.CurrentDate = calAllBookings.CurrentDate.AddDays(-1);
        }

        // when the date selector date has changed
        private void calDTPick_ValueChanged(object sender, EventArgs e)
        {

            // change the current date on calview to that date
            calAllBookings.CurrentDate = calDTPick.Value;
        }

        private void numRoomSelect_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}