using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Main_RBS
{
    public partial class frmEditUser : Form
    {

        // setting the variables at class level so that they can be accessed in any method
        private clDB db;
        private int userID;
        private user user;
        private bool newUserMode;
        private clHelper helper;

        public frmEditUser()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        // method called when the form is loaded
        private void frmEditUser_Load(object sender, EventArgs e)
        {
            // if the form has been opened in view mode
            if(tempVars.userMode == tempVars.modes.View)
            {
                // foreach control, disable it if it's a textbox or button
                foreach(Control c in this.Controls)
                {
                    if(c is TextBox || c is Button)
                    {
                        c.Enabled = false;
                    }
                }
            }

            // disable delete button by default
            btnDeleteUser.Enabled = false;


            // adding roles to the role dropdown list
            bxRoleList.Items.Add("Admin");
            bxRoleList.Items.Add("Teacher");
            bxRoleList.Items.Add("Student");

            // setting the dropdown type
            bxRoleList.DropDownStyle = ComboBoxStyle.DropDownList;

            // enable the role selection if the user is an admin
            if (session.role != user.roles.Admin)
            {
                bxRoleList.Enabled = false;
            }
            else
            {
                bxRoleList.Enabled = true;
                // since the user is an admin, enable the delete button
                if (session.userID != tempVars.editUserId)
                {
                    btnDeleteUser.Enabled = true;
                }
            }
            
            // create new object of helper class
            helper = new clHelper();
            // create new object of database class
            db = new clDB();

            // if the form is loaded to edit a user
            if (tempVars.editUserId != -1)
            {

                // set the form title
                this.Text = "Edit user";

                // define that a new user is not being created
                newUserMode = false;

                // set the local variable userID
                userID = tempVars.editUserId;

                // get the user details from the database
                user = db.getUser(userID);

                // reset the Id stored in tempvars back to default
                tempVars.editUserId = 0;

                // fill the controls with the user details
                txtName1.Text = user.firstname;
                txtName2.Text = user.secondname;
                switch(user.role){
                    case(user.roles.Admin):
                        bxRoleList.Text = "Admin";
                        break;
                    case (user.roles.Teacher):
                        bxRoleList.Text = "Teacher";
                        break;
                    case (user.roles.Student):
                        bxRoleList.Text = "Student";
                        break;
                    default:
                        bxRoleList.Text = "Student";
                        break;
                }
                txtUsername.Text = user.username;
            }
            // if the form is loaded to create a new user
            else
            {
                // set the title of the form
                this.Text = "New User";

                // set the mode to new user
                newUserMode = true;

                // disable and hide the delete button
                btnDeleteUser.Enabled = false;
                btnDeleteUser.Visible = false;

                // enable selection of role
                bxRoleList.Enabled = true;
            }
        }

        // when the submit button is clicked
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            // default the password given to null
            string givenPassword = null;

            // CHECK: password match
            if (!String.IsNullOrEmpty(txtPass1.Text))
            {
                // if both passwords are tge sane
                if (txtPass1.Text == txtPass2.Text)
                {
                    // the given password is that has been entered into txtPass1
                    givenPassword = txtPass1.Text;
                }
                // else throw error message, abandon checks and force password reattempt
                else
                {
                    MessageBox.Show("The two passwords you entered don't match!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // CHECK: username already exists
            if (db.checkUsernameExists(txtUsername.Text, userID))
            {
                // throw error message to user
                MessageBox.Show("That username is taken!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHECK: username alphanumeric
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            // if the username does not meet the regex requirements: throw error message
            if (!alphanumeric.IsMatch(txtUsername.Text))
            {
                MessageBox.Show("The username should only contain alphanumeric characters! (A-Z, a-z and 0-9)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHECK: username length is less than or = 15
            if (txtUsername.Text.Length > 15)
            {
                MessageBox.Show("The username should be 15 characters or less!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if form is set to new user mode
            if (newUserMode)
            {
                try
                {

                    // set SQL command to INSERT
                    string cmd = String.Format("INSERT INTO tblUsers (FirstName, SecondName, Password, Role, Username) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", txtName1.Text, txtName2.Text, txtPass1.Text, bxRoleList.Text, txtUsername.Text);
                    
                    // send the command to the Database server
                    db.miscAction(cmd);

                    // refresh the home form to accomodate for new data
                    helper.refreshHomeForm();

                    // close this form
                    this.Close();
                }
                // if error in the sending of the SQL command: throw to user
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // if form is in edit mode
            else
            {
                // if no new password is given, set the given password to their current password
                if (String.IsNullOrEmpty(givenPassword))
                {
                    givenPassword = user.password;
                }

                try
                {
                    // call updateuser method and pass through all user details
                    db.updateUser(userID, txtName1.Text, txtName2.Text, givenPassword, bxRoleList.Text, txtUsername.Text);

                    // if the user being edited is the current logged in user
                    if (session.userID == userID)
                    {
                        // change their name shown at top to updated name
                        session.name = new string[] { txtName1.Text, txtName2.Text };
                    }
                    // refresh the home form to show new details
                    helper.refreshHomeForm();
                    
                    // close the form
                    this.Close();
                }
                // if an error occurs, throw to user
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        // when the delete button has been pressed
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

            // create delete SQL command
            string cmd = String.Format("DELETE from tblUsers WHERE Id = {0}", userID);

            // send command to the database
            db.miscAction(cmd);

            // refresh the home form with updated data
            helper.refreshHomeForm();

            // close form
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void bxRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}