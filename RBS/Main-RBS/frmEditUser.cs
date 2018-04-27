using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Main_RBS
{
    public partial class frmEditUser : Form
    {
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

        private void frmEditUser_Load(object sender, EventArgs e)
        {

            if(tempVars.userMode == tempVars.modes.View)
            {
                foreach(Control c in this.Controls)
                {
                    if(c is TextBox || c is Button)
                    {
                        c.Enabled = false;
                    }
                }
            }

            btnDeleteUser.Enabled = false;

            bxRoleList.Items.Add("Admin");
            bxRoleList.Items.Add("Teacher");
            bxRoleList.Items.Add("Student");
            bxRoleList.DropDownStyle = ComboBoxStyle.DropDownList;

            if (session.role != user.roles.Admin)
            {
                bxRoleList.Enabled = false;
            }
            else
            {
                bxRoleList.Enabled = true;
                if (session.userID != tempVars.editUserId)
                {
                    btnDeleteUser.Enabled = true;
                }
            }

            helper = new clHelper();
            db = new clDB();
            if (tempVars.editUserId != -1)
            {
                this.Text = "Edit user";
                newUserMode = false;
                userID = tempVars.editUserId;
                user = db.getUser(userID);

                tempVars.editUserId = 0;

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
            else
            {
                this.Text = "New User";
                newUserMode = true;
                btnDeleteUser.Enabled = false;
                btnDeleteUser.Visible = false;
                bxRoleList.Enabled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string givenPassword = null;

            // CHECK: password match
            if (!String.IsNullOrEmpty(txtPass1.Text))
            {
                if (txtPass1.Text == txtPass2.Text)
                {
                    givenPassword = txtPass1.Text;
                }
                else
                {
                    MessageBox.Show("The two passwords you entered don't match!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // CHECK: username already exists
            if (db.checkUsernameExists(txtUsername.Text, userID))
            {
                MessageBox.Show("That username is taken!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHECK: username alphanumeric
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            if (!alphanumeric.IsMatch(txtUsername.Text))
            {
                MessageBox.Show("The username should only contain alphanumeric characters! (A-Z, a-z and 0-9)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHECK: username length
            if (txtUsername.Text.Length > 15)
            {
                MessageBox.Show("The username should be 15 characters or less!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newUserMode)
            {
                try
                {
                    string cmd = String.Format("INSERT INTO tblUsers (FirstName, SecondName, Password, Role, Username) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", txtName1.Text, txtName2.Text, txtPass1.Text, bxRoleList.Text, txtUsername.Text);
                    //MessageBox.Show(cmd);
                    db.miscAction(cmd);

                    helper.refreshHomeForm();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(givenPassword))
                {
                    givenPassword = user.password;
                }

                try
                {
                    db.updateUser(userID, txtName1.Text, txtName2.Text, givenPassword, bxRoleList.Text, txtUsername.Text);
                    if (session.userID == userID)
                    {
                        session.name = new string[] { txtName1.Text, txtName2.Text };
                    }

                    helper.refreshHomeForm();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string cmd = String.Format("DELETE from tblUsers WHERE Id = {0}", userID);

            db.miscAction(cmd);

            helper.refreshHomeForm();

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