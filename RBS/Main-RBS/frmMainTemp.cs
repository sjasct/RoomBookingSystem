using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Main_RBS
{
	public partial class frmMainTemp : Form
	{

		DatabaseHelper db;

		private void frmMainTemp_Load(object sender, EventArgs e)
		{
			db = new DatabaseHelper();
			popAllBookings();
			miscClasses.userID = -1;
            tempVars.editBookingId = 0;
            refreshForm();
		}

		public frmMainTemp()
		{
			InitializeComponent();	
		}
		
		private void popAllBookings()
		{
			List<ListViewItem> items = db.popBookings();

			foreach(ListViewItem item in items)
			{
				listAllBookings.Items.Add(item);
			}
		}

		private void popOwnBookings()
		{
			if (miscClasses.loggedIn)
			{
				List<ListViewItem> items = db.popBookings(false);

				foreach (ListViewItem item in items)
				{
					listOwnBookings.Items.Add(item);
				}
			}	
		}

		private void button1_Click(object sender, EventArgs e)
		{
			frmLogin loginForm = new frmLogin();
			loginForm.ShowDialog();
		}

		private void btnOwnBookings_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Not implemented.");
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			try
			{
				string userdata = String.Format("Username: {0}\nName: {1} {2}\nGroup: {3}\nEmail: {4}\nID: {5}", miscClasses.username, miscClasses.name[0], miscClasses.name[1], miscClasses.group, miscClasses.email, miscClasses.userID);
				MessageBox.Show(userdata);
			}
			catch (System.NullReferenceException)
			{
				MessageBox.Show("You are not logged in!");
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			refreshForm();
		}

		private void refreshForm()
		{
			// Header
			string name;
			try
			{
				name = miscClasses.name[0];
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
			if (string.IsNullOrEmpty(miscClasses.group))
			{
				btnDeleteAll.Enabled = false;
				btnNewBook.Enabled = false;
				btnOwnBookings.Enabled = false;
				btnLogOut.Enabled = false;
				btnHomeLogin.Enabled = true;
				btnShowID.Enabled = false;
                btnTestBooking.Enabled = false;
			}
			else if (miscClasses.group == "Student")
			{
				btnDeleteAll.Enabled = false;
				btnShowID.Enabled = true;
				btnNewBook.Enabled = false;
				btnOwnBookings.Enabled = false;
				btnLogOut.Enabled = true;
				btnHomeLogin.Enabled = false;
                btnTestBooking.Enabled = true;
            }
			else if(miscClasses.group == "Teacher")
			{
				btnDeleteAll.Enabled = false;
				btnShowID.Enabled = true;
				btnNewBook.Enabled = true;
				btnOwnBookings.Enabled = true;
				btnLogOut.Enabled = true;
				btnHomeLogin.Enabled = false;
                btnTestBooking.Enabled = true;
            }
			else if (miscClasses.group == "Admin")
			{
				btnDeleteAll.Enabled = true;
				btnShowID.Enabled = true;
				btnNewBook.Enabled = true;
				btnOwnBookings.Enabled = true;
				btnLogOut.Enabled = true;
				btnHomeLogin.Enabled = false;
                btnTestBooking.Enabled = true;
            }

			foreach (ListViewItem item in listAllBookings.Items)
			{
				item.Remove();
			}
			foreach (ListViewItem item in listOwnBookings.Items)
			{
				item.Remove();
			}
			popAllBookings();
			popOwnBookings();
		}

		private void frmMainTemp_Activated(object sender, EventArgs e)
		{
			//refreshForm();
		}

		private void btnLogOut_Click(object sender, EventArgs e)
		{
			bool success = false;

			try
			{
				miscClasses.loggedIn = false;
				miscClasses.userID = -1;
				miscClasses.username = null;
				miscClasses.name = new string[] { "", "" };
				miscClasses.group = null;
				miscClasses.email = null;
				success = true;
			}
			catch
			{
				MessageBox.Show("Log out failed!");
			}

			if (success)
			{
				MessageBox.Show("Logged out!");
				refreshForm();
			}
		}

		private void btnTestBooking_Click(object sender, EventArgs e)
		{

			Random r = new Random();
			int dateThing = r.Next(1, 31);
			int roomID = r.Next(1, 5);
			int period = r.Next(1, 5);

			DateTime date = new DateTime(2018, 1, dateThing);

			db.insertBooking(roomID, date, period, miscClasses.userID, "wow");

			refreshForm();
		}

		private void frmMainTemp_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.F5)
			{
				MessageBox.Show("refreshing");
				refreshForm();
			}
		}

		private void btnNewBook_Click(object sender, EventArgs e)
		{
			new frmNewBook().Show();
		}

		private void btnDeleteAll_Click(object sender, EventArgs e)
		{
			db.miscAction("TRUNCATE TABLE tblBookings");
			refreshForm();
		}

        private void listAllBookings_ItemActivate(object sender, EventArgs e)
        {
            int editBookingId = Convert.ToInt32(listAllBookings.SelectedItems[0].SubItems[5].Text);
            tempVars.editBookingId = editBookingId;
            new frmNewBook().Show();
        }

        private void listAllBookings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
