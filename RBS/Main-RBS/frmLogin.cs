using System;
using System.Windows.Forms;

namespace Main_RBS
{
    public partial class frmLogin : Form
    {
        // creates global db variable
        private DatabaseHelper db;

        public frmLogin()
        {
            InitializeComponent();
        }

        // event method for when the cancel button is clicked
        private void btnLoginCancel_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        // event method for when the submit button is clicked
        private void btnLoginEnter_Click(object sender, EventArgs e)
        {
            // gets the data from the form
            string username = txtLoginUsername.Text;
            string password = txtLoginPassword.Text;

            // attempts to query the database to check details - returns data
            loginReturnedData loginData = db.checkLoginDetails(username, password);

            // if login successful
            if (loginData.success)
            {
                // set session details to user details
                session.userID = loginData.userID;
                session.username = loginData.username;
                session.name = loginData.name;
                session.role = loginData.role;
                session.email = loginData.email;
                session.loggedIn = true;

                // close form
                this.Close();
            }
            else
            {
                // sets error message
                lblLoginError.Text = "Login failed!";

                // empties the password field
                txtLoginPassword.Text = String.Empty;
            }
        }

        // on form load
        private void frmLogin_Load(object sender, EventArgs e)
        {
            // creates instance of databasehelper on db
            db = new DatabaseHelper();

            // empties error message label
            lblLoginError.Text = String.Empty;
        }
    }
}