namespace Main_RBS
{
    partial class frmDebug
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoginAdmin = new System.Windows.Forms.Button();
            this.btnLoginTeacher = new System.Windows.Forms.Button();
            this.btnLoginStudent = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnTestBooking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login as:";
            // 
            // btnLoginAdmin
            // 
            this.btnLoginAdmin.Location = new System.Drawing.Point(16, 39);
            this.btnLoginAdmin.Name = "btnLoginAdmin";
            this.btnLoginAdmin.Size = new System.Drawing.Size(157, 23);
            this.btnLoginAdmin.TabIndex = 1;
            this.btnLoginAdmin.Text = "Admin (scottsj03)";
            this.btnLoginAdmin.UseVisualStyleBackColor = true;
            this.btnLoginAdmin.Click += new System.EventHandler(this.btnLoginAdmin_Click);
            // 
            // btnLoginTeacher
            // 
            this.btnLoginTeacher.Location = new System.Drawing.Point(16, 69);
            this.btnLoginTeacher.Name = "btnLoginTeacher";
            this.btnLoginTeacher.Size = new System.Drawing.Size(157, 23);
            this.btnLoginTeacher.TabIndex = 2;
            this.btnLoginTeacher.Text = "Teacher (hoodj03)";
            this.btnLoginTeacher.UseVisualStyleBackColor = true;
            this.btnLoginTeacher.Click += new System.EventHandler(this.btnLoginTeacher_Click);
            // 
            // btnLoginStudent
            // 
            this.btnLoginStudent.Location = new System.Drawing.Point(16, 98);
            this.btnLoginStudent.Name = "btnLoginStudent";
            this.btnLoginStudent.Size = new System.Drawing.Size(157, 23);
            this.btnLoginStudent.TabIndex = 3;
            this.btnLoginStudent.Text = "Student (brantodb01)";
            this.btnLoginStudent.UseVisualStyleBackColor = true;
            this.btnLoginStudent.Click += new System.EventHandler(this.btnLoginStudent_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Admin Actions";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(204, 39);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(153, 23);
            this.btnDeleteAll.TabIndex = 5;
            this.btnDeleteAll.Text = "Delete all bookings";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnTestBooking
            // 
            this.btnTestBooking.Location = new System.Drawing.Point(204, 69);
            this.btnTestBooking.Name = "btnTestBooking";
            this.btnTestBooking.Size = new System.Drawing.Size(153, 23);
            this.btnTestBooking.TabIndex = 6;
            this.btnTestBooking.Text = "Insert Test Booking";
            this.btnTestBooking.UseVisualStyleBackColor = true;
            this.btnTestBooking.Click += new System.EventHandler(this.btnTestBooking_Click);
            // 
            // frmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 169);
            this.Controls.Add(this.btnTestBooking);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoginStudent);
            this.Controls.Add(this.btnLoginTeacher);
            this.Controls.Add(this.btnLoginAdmin);
            this.Controls.Add(this.label1);
            this.Name = "frmDebug";
            this.Text = "frmDebug";
            this.Load += new System.EventHandler(this.frmDebug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoginAdmin;
        private System.Windows.Forms.Button btnLoginTeacher;
        private System.Windows.Forms.Button btnLoginStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnTestBooking;
    }
}