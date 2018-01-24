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
            db = new DatabaseHelper();
            if (tempVars.editUserId != 0)
            {

                userID = tempVars.editUserId;
                user = db.getUser(userID);

                tempVars.editUserId = 0;

                txtName1.Text = user.firstname;
                txtName2.Text = user.secondname;
                txtEmail.Text = user.email;
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
                    MessageBox.Show("things don't match melonhead");
                }
            }
            else
            {
                success = true;
            }

            if (success)
            {
                MessageBox.Show("kjfhbkjbfhn");
                try
                {
                    db.updateUser(userID, txtName1.Text, txtName2.Text, givenPassword, txtEmail.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }
    }
}
