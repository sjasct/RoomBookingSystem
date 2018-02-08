﻿using System;
using System.Windows.Forms;

namespace Main_RBS
{
    public partial class frmEditUser : Form
    {
        private DatabaseHelper db;
        private int userID;
        private user user;
        private bool newUserMode;

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
            btnDeleteUser.Enabled = false;

            if (session.role != "Admin")
            {
                txtRole.ReadOnly = true;
            }
            else
            {
                txtRole.ReadOnly = false;
                if (session.userID != tempVars.editUserId)
                {
                    btnDeleteUser.Enabled = true;
                }
            }

            db = new DatabaseHelper();
            if (tempVars.editUserId != -1)
            {
                newUserMode = false;
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
                newUserMode = true;
                btnDeleteUser.Enabled = false;
                txtRole.ReadOnly = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string givenPassword;
            bool passsuccess = false;
            bool namesuccess = false;

            if (!String.IsNullOrEmpty(txtPass1.Text))
            {
                if (txtPass1.Text == txtPass2.Text)
                {
                    givenPassword = txtPass1.Text;
                    passsuccess = true;
                }
                else
                {
                    MessageBox.Show("The two passwords you entered don't match!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                passsuccess = true;
            }

            if (!db.checkUsernameExists(txtUsername.Text, userID))
            {
                //MessageBox.Show("Success");
                namesuccess = true;
            }
            else
            {
                //MessageBox.Show("Fail");
            }

            if (passsuccess && namesuccess)
            {
                if (newUserMode)
                {
                    try
                    {
                        string cmd = String.Format("INSERT INTO tblUsers (FirstName, SecondName, Password, Email, Role, Username) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", txtName1.Text, txtName2.Text, txtPass1.Text, txtEmail.Text, txtRole.Text, txtUsername.Text);
                        //MessageBox.Show(cmd);
                        db.miscAction(cmd);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    givenPassword = user.password;
                    try
                    {
                        db.updateUser(userID, txtName1.Text, txtName2.Text, givenPassword, txtEmail.Text, txtRole.Text, txtUsername.Text);
                        if (session.userID == userID)
                        {
                            session.name = new string[] { txtName1.Text, txtName2.Text };
                            session.email = txtEmail.Text;
                        }
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

            this.Close();
        }
    }
}