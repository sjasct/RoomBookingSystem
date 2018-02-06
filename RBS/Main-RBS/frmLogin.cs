using System;
using System.Windows.Forms;

namespace Main_RBS
{
    public partial class frmLogin : Form
    {
        private DatabaseHelper db;

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
                session.role = loginData.role;
                session.email = loginData.email;
                session.loggedIn = true;

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