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
			MessageBox.Show(session.userID.ToString());
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			refreshForm();
		}

		private void refreshForm()
		{
			// header
			string name = db.getNameFromId(session.userID)[0];
			//MessageBox.Show(name);
			if (string.IsNullOrEmpty(name) || name == "")
			{
				lblUserHeader.Text = "Not logged in..";
			}
			lblUserHeader.Text = String.Format("Welcome {0}!", name);


		}

		private void frmMainTemp_Activated(object sender, EventArgs e)
		{
			refreshForm();
		}
	}
}
