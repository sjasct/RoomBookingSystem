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
    public partial class frmEditUser : Form
    {

        DatabaseHelper db;
        int userID;
        user user;

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

            if (session.role != "Admin")
            {
                txtRole.ReadOnly = true;
            }
            else
            {
                txtRole.ReadOnly = false;
            }

            db = new DatabaseHelper();
            if (tempVars.editUserId != 0)
            {

                userID = tempVars.editUserId;
                user = db.getUser(userID);

                tempVars.editUserId = 0;

                txtName1.Text = user.firstname;
                txtName2.Text = user.secondname;
                txtEmail.Text = user.email;
                txtRole.Text = user.role;
                txtUsername.Text = user.username;
            }
            else
            {
                
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            

            string givenPassword = user.password;
            bool success = false;

            if(!String.IsNullOrEmpty(txtPass1.Text))
            {
               if(txtPass1.Text == txtPass2.Text)
                {
                    givenPassword = txtPass1.Text;
                    success = true;
                }
                else
                {
                    MessageBox.Show("The two passwords you mentioned don't match");
                }
            }
            else
            {
                success = true;
            }

            if (success)
            {
                try
                {
                    db.updateUser(userID, txtName1.Text, txtName2.Text, givenPassword, txtEmail.Text, txtRole.Text, txtUsername.Text);
                    if(session.userID == userID)
                    {
                        session.name = new string[] { txtName1.Text, txtName2.Text };
                        session.email = txtEmail.Text;
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }
    }
}
