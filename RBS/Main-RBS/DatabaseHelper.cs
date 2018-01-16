using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Main_RBS
{
	public class DatabaseHelper
	{

		public string test = "idk";

		string connectionString;

		SqlConnection connection;

		public string getCString()
		{
			connectionString = ConfigurationManager.ConnectionStrings["Main_RBS.Properties.Settings.dbConnectionString"].ConnectionString;
			return connectionString;
		}

		public DataTable popBookings()
		{

			using (connection = new SqlConnection(getCString()))
			{

				SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblBookings", connection);

				DataTable bookTable = new DataTable();
				adapter.Fill(bookTable);

				return bookTable;

			}

		}

		// not void for now
		public void checkLoginDetails(string username, string pass)
		{

			// SELECT * FROM tblUsers WHERE username = "{username}" AND pass = "{pass}"
			using (connection = new SqlConnection(getCString()))
			{

				SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblBookings", connection);

				DataTable bookTable = new DataTable();
				adapter.Fill(bookTable);

				//return bookTable;

			}

		}

	}
}
