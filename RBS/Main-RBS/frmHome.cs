﻿using System;
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

            db = new clDB();

            calAllBookings.ItemDatesChanged += CalAllBookings_ItemDatesChanged;
            calAllBookings.ItemTextFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Pixel);
            calAllBookings.HeaderColumnsFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            calAllBookings.GridTextFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            calAllBookings.HeaderDatesFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            calAllBookings.Columns.Add("clmPeriod", "Period", 100);
            calAllBookings.CurrentDate = DateTime.Now.Date;

            calDTPick.MinDate = Convert.ToDateTime("02/01/1970");

            Debug.WriteLine("Loading main form..");

            session.loggedIn = false;
            session.role = user.roles.None;
            session.userID = -1;

            tempVars.editBookingId = -1;

            btnRefresh.Image = null;
            btnRefresh.Text = "Refresh";

            refreshForm();

        }

        
        public void rePopCalndar(int roomID)
        {
            DateTime earlyDate = Convert.ToDateTime("01/01/1970");

            calAllBookings.Calendar.Rows.Clear();
            

            for (int n = 1; n < 6; n++)
            {
                // empty
                WeekPlannerItemCollection ic = new WeekPlannerItemCollection();
                WeekPlannerItem i = new WeekPlannerItem();
                i.StartDate = earlyDate;
                i.EndDate = earlyDate;
                i.Subject = "test";
                i.BackColor = System.Drawing.Color.YellowGreen;
                i.bookingid = -2;
                i.userid = -2;
                ic.Add(i);

                List<booking> bookinglist = db.populateCalendar(roomID, n);

                foreach (booking bk in bookinglist)
                {
                    WeekPlannerItem item = new WeekPlannerItem();
                    item.StartDate = bk.date;
                    item.EndDate = bk.date;
                    item.BackColor = System.Drawing.Color.Red;
                    item.bookingid = bk.id;
                    item.userid = bk.UserID;
                    item.Subject = db.getUsername(item.userid);
                    ic.Add(item);
                }

                DataColumns cr = new DataColumns(calAllBookings.Calendar);
                cr["clmPeriod"].Data.Add(String.Format("Period {0}", n.ToString()));
                calAllBookings.Rows.Add(cr, ic);
            }
        }

        private void CalAllBookings_ItemDatesChanged(object sender, WeekPlannerItemEventArgs e)
        {
            refreshForm();
        }

        public frmHome()
        {
            InitializeComponent();
        }

        private void popAllBookings()
        {
            Debug.WriteLine("Populating all bookings list..");
            List<ListViewItem> items = db.popBookings();

            foreach (ListViewItem item in items)
            {
                listAllBookings.Items.Add(item);
            }
        }

        private void popOwnBookings()
        {
            Debug.WriteLine("Populating own bookings list..");
            if (session.loggedIn)
            {
                List<ListViewItem> items = db.popBookings(false);

                foreach (ListViewItem item in items)
                {
                    listOwnBookings.Items.Add(item);
                }
            }
        }

        private void popUsers()
        {
            Debug.WriteLine("Populating users list..");

            List<ListViewItem> items = db.popUsers();

            foreach (ListViewItem item in items)
            {
                listUsers.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Opening login form..");
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string userdata = String.Format("Username: {0}\nName: {1} {2}\nrole: {3}\n\nID: {4}", session.username, session.name[0], session.name[1], session.role, session.userID);
                MessageBox.Show(userdata);
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("You are not logged in!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        public void refreshForm()
        {
            Stopwatch refreshTime = new Stopwatch();
            refreshTime.Start();
            rePopCalndar(Convert.ToInt32(numRoomSelect.Value));
            Debug.WriteLine("Refreshing form..");
            // Header
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

            // buttons
            if (session.loggedIn == false || session.role == user.roles.None)
            {
                btnNewBook.Enabled = false;
                btnLogOut.Enabled = false;
                btnHomeLogin.Enabled = true;
                btnShowID.Enabled = false;
                btnNewUser.Enabled = false;
                btnEditProfile.Enabled = false;
            }
            else if (session.role == user.roles.Student)
            {
                btnShowID.Enabled = true;
                btnNewBook.Enabled = false;
                btnLogOut.Enabled = true;
                btnHomeLogin.Enabled = false;
                btnNewUser.Enabled = false;
                btnEditProfile.Enabled = true;
            }
            else if (session.role == user.roles.Teacher)
            {
                btnShowID.Enabled = true;
                btnNewBook.Enabled = true;
                btnLogOut.Enabled = true;
                btnHomeLogin.Enabled = false;
                btnNewUser.Enabled = false;
                btnEditProfile.Enabled = true;
            }
            else if (session.role == user.roles.Admin)
            {
                btnShowID.Enabled = true;
                btnNewBook.Enabled = true;
                btnLogOut.Enabled = true;
                btnHomeLogin.Enabled = false;
                btnNewUser.Enabled = true;
                btnEditProfile.Enabled = true;
            }

            foreach (ListViewItem item in listAllBookings.Items)
            {
                item.Remove();
            }
            foreach (ListViewItem item in listOwnBookings.Items)
            {
                item.Remove();
            }
            foreach (ListViewItem item in listUsers.Items)
            {
                item.Remove();
            }
            popAllBookings();
            popOwnBookings();
            popUsers();
            refreshTime.Stop();
            Debug.WriteLine(String.Format("Took {0} milliseconds to refresh", refreshTime.ElapsedMilliseconds.ToString()));
        }

        private void frmMainTemp_Activated(object sender, EventArgs e)
        {
            //refreshForm();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Logging user out..");
            bool success = false;

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
            catch
            {
                MessageBox.Show("Log out failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (success)
            {
                MessageBox.Show("You have successfully been logged out!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshForm();
            }
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

            refreshForm();
        }

        private void frmMainTemp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Debug.WriteLine("Detected F5 key");
                refreshForm();
            }
            if (e.KeyCode == Keys.F12)
            {
                new frmDebug().ShowDialog();
            }
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

        private void btnNewBook_Click(object sender, EventArgs e)
        {
            new frmBookingDetails().ShowDialog();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all bookings?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                db.miscAction("TRUNCATE TABLE tblBookings");
                refreshForm();
            }
        }

        private void listAllBookings_ItemActivate(object sender, EventArgs e)
        {
            int editBookingId = Convert.ToInt32(listAllBookings.SelectedItems[0].SubItems[5].Text);
            string editUserId = listAllBookings.SelectedItems[0].SubItems[3].Text;
            tempVars.editBookingId = editBookingId;

            if (editUserId == session.username || session.role == user.roles.Admin)
            {
                tempVars.bookingMode = tempVars.modes.Edit;
            }
            else
            {
                tempVars.bookingMode = tempVars.modes.View;
            }

            new frmBookingDetails().ShowDialog();
        }

        private void listAllBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void loginAsUser(user u)
        {
            session.loggedIn = true;
            session.userID = u.id;
            session.username = u.username;
            session.name = new string[] { u.firstname, u.secondname };
            session.role = u.role;
            session.email = u.email;
            refreshForm();

            Debug.WriteLine(String.Format("Logged in as {0}", session.username));
        }

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

        private void listOwnBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listUsers_ItemActivate(object sender, EventArgs e)
        {
            int editUserId = Convert.ToInt32(listUsers.SelectedItems[0].SubItems[0].Text);

            tempVars.editUserId = editUserId;

            if (session.userID == editUserId || session.role == user.roles.Admin)
            {
                tempVars.userMode = tempVars.modes.Edit;
            }
            else
            {
                tempVars.userMode = tempVars.modes.View;
            }

            new frmEditUser().ShowDialog();

        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            tempVars.editUserId = session.userID;
            new frmEditUser().ShowDialog();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            tempVars.editUserId = -1;
            new frmEditUser().ShowDialog();
        }

        private void listOwnBookings_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                int editBookingId = Convert.ToInt32(listOwnBookings.SelectedItems[0].SubItems[5].Text);
                string editUserId = listOwnBookings.SelectedItems[0].SubItems[3].Text;
                tempVars.editBookingId = editBookingId;

                if (editUserId == session.username || session.role == user.roles.Admin)
                {
                    tempVars.bookingMode = tempVars.modes.Edit;
                }
                else
                {
                    tempVars.bookingMode = tempVars.modes.View;
                }

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

        private void calAllBookings_ItemClick(object sender, WeekPlannerItemEventArgs e)
        {
            //int editBookingId = Convert.ToInt32(listOwnBookings.SelectedItems[0].SubItems[5].Text);
            int editBookingId = e.Item.bookingid;
            //string editUserId = listOwnBookings.SelectedItems[0].SubItems[3].Text;
            string editUserId = db.getUsername(e.Item.userid);
            tempVars.editBookingId = editBookingId;

            if (editUserId == session.username || session.role == user.roles.Admin)
            {
                tempVars.bookingMode = tempVars.modes.Edit;
            }
            else
            {
                tempVars.bookingMode = tempVars.modes.View;
            }

            new frmBookingDetails().ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            rePopCalndar(Convert.ToInt32(numRoomSelect.Value));
        }

        private void btnDayRight_Click(object sender, EventArgs e)
        {
            calAllBookings.CurrentDate = calAllBookings.CurrentDate.AddDays(1);
        }

        private void btnDayLeft_Click(object sender, EventArgs e)
        {
            calAllBookings.CurrentDate = calAllBookings.CurrentDate.AddDays(-1);
        }

        private void calDTPick_ValueChanged(object sender, EventArgs e)
        {
            calAllBookings.CurrentDate = calDTPick.Value;
        }

        private void numRoomSelect_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}