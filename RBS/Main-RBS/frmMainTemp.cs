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

		//string connectionString;

		//SqlConnection connection; 

		DatabaseHelper db;

		public frmMainTemp()
		{
			InitializeComponent();

			
		}

		private void frmMainTemp_Load(object sender, EventArgs e)
		{

			db = new DatabaseHelper();
			popBookings();
		}

		private void popBookings()
		{

			DataTable dt = null;
			try
			{
				dt = db.popBookings();
			}
			catch
			{
				MessageBox.Show("oops");
			}
			finally
			{
				//MessageBox.Show(adapter.ToString());
			}

			

			lstBookings.DisplayMember = "Date";
			lstBookings.ValueMember = "Id";
			lstBookings.DataSource = dt;


		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			frmLogin loginForm = new frmLogin();
			loginForm.ShowDialog();
		}

		private void btnOwnBookings_Click(object sender, EventArgs e)
		{
			DatabaseHelper db = new DatabaseHelper();
			MessageBox.Show(db.test);

			
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			
			

			try
			{
				string userdata = String.Format("Username:{0}\nName: {1} {2}\nGroup: {3}\nEmail: {4}\nID: {5}", session.username, session.name[0], session.name[1], session.group, session.email, session.userID);
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
			if (string.IsNullOrEmpty(session.group))
			{
				btnNewBook.Enabled = false;
				btnOwnBookings.Enabled = false;
				btnLogOut.Enabled = false;
				btnHomeLogin.Enabled = true;
			}
			else if (session.group == "Student")
			{


				btnNewBook.Enabled = false;
				btnOwnBookings.Enabled = false;
				btnLogOut.Enabled = true;
				btnHomeLogin.Enabled = false;
			}
			else if(session.group == "Teacher" || session.group == "Admin")
			{


				btnNewBook.Enabled = true;
				btnOwnBookings.Enabled = true;
				btnLogOut.Enabled = true;
				btnHomeLogin.Enabled = false;
			}
			else
			{
			}

			db.popBookings();

		}

		private void frmMainTemp_Activated(object sender, EventArgs e)
		{
			refreshForm();
		}

		private void btnLogOut_Click(object sender, EventArgs e)
		{
			bool success = false;

			try
			{
				session.loggedIn = false;
				session.userID = -1;
				session.username = null;
				session.name = new string[] { "", "" };
				session.group = null;
				session.email = null;
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

			DateTime date = new DateTime(2018, 1, 16);

			string niceFormat = date.ToString("yyyyMMdd");

			
			

			MessageBox.Show(niceFormat);

			db.insertBooking(2, niceFormat, 5, 1, "wow");

			//refreshForm();
		}

		private void frmMainTemp_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.F5)
			{
				MessageBox.Show("refreshing");
				refreshForm();
			}
		}

		private void frmMainTemp_KeyPress(object sender, KeyPressEventArgs e)
		{
			MessageBox.Show(e.KeyChar.ToString());
			if (e.KeyChar == (char)Keys.F5)
			{
				MessageBox.Show("refreshing..");
				refreshForm();
			}
		}
	}
}
