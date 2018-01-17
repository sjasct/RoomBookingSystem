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
	public partial class frmNewBook : Form
	{
		public frmNewBook()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnNewBook_Click(object sender, EventArgs e)
		{
			DatabaseHelper db = new DatabaseHelper();

			DateTime date = Convert.ToDateTime(dtDate.Text);

			MessageBox.Show(date.Day.ToString());

			db.insertBooking(Convert.ToInt32(txtRoom.Text), date, Convert.ToInt32(txtPeriod.Text), session.userID, txtNotes.Text);

		}
	}
}
