namespace Main_RBS
{
	partial class frmLogin
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblLoginHead = new System.Windows.Forms.Label();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.lblLoginUsername = new System.Windows.Forms.Label();
            this.lblLoginPass = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.lblLoginError = new System.Windows.Forms.Label();
            this.btnLoginEnter = new System.Windows.Forms.Button();
            this.btnLoginCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLoginHead
            // 
            this.lblLoginHead.AutoSize = true;
            this.lblLoginHead.Location = new System.Drawing.Point(13, 13);
            this.lblLoginHead.Name = "lblLoginHead";
            this.lblLoginHead.Size = new System.Drawing.Size(70, 13);
            this.lblLoginHead.TabIndex = 0;
            this.lblLoginHead.Text = "Please login..";
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.Location = new System.Drawing.Point(74, 56);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(198, 20);
            this.txtLoginUsername.TabIndex = 1;
            // 
            // lblLoginUsername
            // 
            this.lblLoginUsername.AutoSize = true;
            this.lblLoginUsername.Location = new System.Drawing.Point(13, 56);
            this.lblLoginUsername.Name = "lblLoginUsername";
            this.lblLoginUsername.Size = new System.Drawing.Size(55, 13);
            this.lblLoginUsername.TabIndex = 2;
            this.lblLoginUsername.Text = "Username";
            // 
            // lblLoginPass
            // 
            this.lblLoginPass.AutoSize = true;
            this.lblLoginPass.Location = new System.Drawing.Point(13, 81);
            this.lblLoginPass.Name = "lblLoginPass";
            this.lblLoginPass.Size = new System.Drawing.Size(53, 13);
            this.lblLoginPass.TabIndex = 3;
            this.lblLoginPass.Text = "Password";
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(74, 81);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(198, 20);
            this.txtLoginPassword.TabIndex = 4;
            // 
            // lblLoginError
            // 
            this.lblLoginError.AutoSize = true;
            this.lblLoginError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLoginError.Location = new System.Drawing.Point(16, 114);
            this.lblLoginError.Name = "lblLoginError";
            this.lblLoginError.Size = new System.Drawing.Size(213, 13);
            this.lblLoginError.TabIndex = 5;
            this.lblLoginError.Text = "The details you entered could not be found!";
            // 
            // btnLoginEnter
            // 
            this.btnLoginEnter.Location = new System.Drawing.Point(196, 145);
            this.btnLoginEnter.Name = "btnLoginEnter";
            this.btnLoginEnter.Size = new System.Drawing.Size(75, 23);
            this.btnLoginEnter.TabIndex = 6;
            this.btnLoginEnter.Text = "Login";
            this.btnLoginEnter.UseVisualStyleBackColor = true;
            this.btnLoginEnter.Click += new System.EventHandler(this.btnLoginEnter_Click);
            // 
            // btnLoginCancel
            // 
            this.btnLoginCancel.Location = new System.Drawing.Point(115, 145);
            this.btnLoginCancel.Name = "btnLoginCancel";
            this.btnLoginCancel.Size = new System.Drawing.Size(75, 23);
            this.btnLoginCancel.TabIndex = 7;
            this.btnLoginCancel.Text = "Cancel";
            this.btnLoginCancel.UseVisualStyleBackColor = true;
            this.btnLoginCancel.Click += new System.EventHandler(this.btnLoginCancel_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLoginEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 189);
            this.Controls.Add(this.btnLoginCancel);
            this.Controls.Add(this.btnLoginEnter);
            this.Controls.Add(this.lblLoginError);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.lblLoginPass);
            this.Controls.Add(this.lblLoginUsername);
            this.Controls.Add(this.txtLoginUsername);
            this.Controls.Add(this.lblLoginHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblLoginHead;
		private System.Windows.Forms.TextBox txtLoginUsername;
		private System.Windows.Forms.Label lblLoginUsername;
		private System.Windows.Forms.Label lblLoginPass;
		private System.Windows.Forms.TextBox txtLoginPassword;
		private System.Windows.Forms.Label lblLoginError;
		private System.Windows.Forms.Button btnLoginEnter;
		private System.Windows.Forms.Button btnLoginCancel;
	}
}