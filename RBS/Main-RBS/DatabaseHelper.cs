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
		public loginReturnedData checkLoginDetails(string username, string pass)
		{

			loginReturnedData returnedData = new loginReturnedData();

			// SELECT * FROM tblUsers WHERE username = "{username}" AND pass = "{pass}"
			using (connection = new SqlConnection(getCString()))
			{

				connection.Open();

				string command = String.Format("SELECT Id FROM tblUsers WHERE Username = '{0}' AND Password = '{1}'", username, pass);

				SqlCommand logincommand = new SqlCommand(command, connection);
				SqlDataReader reader = logincommand.ExecuteReader();

				if (reader.Read())
				{
					returnedData.success = true;
					//returnedData.userID = Int32.Parse(reader.GetString(0));
					returnedData.userID = reader.GetInt32(0);
				}



			}

			return returnedData;

		}



	}
}
