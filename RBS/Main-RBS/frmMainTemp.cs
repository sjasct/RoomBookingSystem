using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Main_RBS
{
	public partial class frmMainTemp : Form
	{

		string connectionString;

		SqlConnection connection; 

		public frmMainTemp()
		{
			InitializeComponent();

			connectionString = ConfigurationManager.ConnectionStrings["Main_RBS.Properties.Settings.dbConnectionString"].ConnectionString;
		}

		private void frmMainTemp_Load(object sender, EventArgs e)
		{
			popBookings();
		}

		private void popBookings()
		{
			using (connection = new SqlConnection(connectionString))
			using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblBookings", connection))
			{

				DataTable bookTable = new DataTable();
				adapter.Fill(bookTable);

				lstBookings.DisplayMember = "Date";
				lstBookings.ValueMember = "Id";
				lstBookings.DataSource = bookTable;

			}

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
