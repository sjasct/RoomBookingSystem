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

		booking book;

		DatabaseHelper db;

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

			DateTime date = Convert.ToDateTime(dtDate.Text);

			db.insertBooking(Convert.ToInt32(txtRoom.Text), date, Convert.ToInt32(txtPeriod.Text), session.userID, txtNotes.Text);

			this.Close();
		}

		private void btnEditSubmit_Click(object sender, EventArgs e)
		{
			book = db.getBooking(Convert.ToInt32(txtEditID.Text));

			txtNotes.Text = book.notes;
			txtPeriod.Text = book.period.ToString();
			txtRoom.Text = book.roomID.ToString();
			dtDate.MinDate = DateTime.MinValue;
			dtDate.MaxDate = DateTime.MaxValue;
			MessageBox.Show(String.Format("{0}\n{1}\n{2}", DateTime.MinValue.ToString(), DateTime.MaxValue.ToString(), dtDate.MaxDate.ToString()));
			dtDate.Value = book.date;
		}

		private void frmNewBook_Load(object sender, EventArgs e)
		{
			db = new DatabaseHelper();
		}
	}
}
