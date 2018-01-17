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
	public partial class frmLogin : Form
	{

		DatabaseHelper db;

		public frmLogin()
		{
			InitializeComponent();
		}

		private void btnLoginCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnLoginEnter_Click(object sender, EventArgs e)
		{
			
			string username = txtLoginUsername.Text;
			string password = txtLoginPassword.Text;

			loginReturnedData loginData = db.checkLoginDetails(username, password);

			if (loginData.success)
			{
				session.userID = loginData.userID;
				session.username = loginData.username;
				session.name = loginData.name;
				session.group = loginData.group;
				session.email = loginData.email;
				
				this.Close();
			}
			else
			{
				lblLoginError.Text = "login failed";
				txtLoginPassword.Text = String.Empty;
			}
		}

		private void frmLogin_Load(object sender, EventArgs e)
		{
			db = new DatabaseHelper();
			lblLoginError.Text = String.Empty;
		}
	}
}
