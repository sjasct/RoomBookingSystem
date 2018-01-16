using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

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

		public loginReturnedData checkLoginDetails(string username, string pass)
		{

			loginReturnedData returnedData = new loginReturnedData();

			// SELECT * FROM tblUsers WHERE username = "{username}" AND pass = "{pass}"
			using (connection = new SqlConnection(getCString()))
			{

				connection.Open();

				string command = String.Format("SELECT * FROM tblUsers WHERE Username = '{0}' AND Password = '{1}'", username, pass);

				SqlCommand logincommand = new SqlCommand(command, connection);
				SqlDataReader reader = logincommand.ExecuteReader();

				if (reader.Read())
				{
					returnedData.success = true;
					returnedData.userID = reader.GetInt32(0);
					returnedData.username = reader.GetString(1);
					returnedData.name = new string[] { reader.GetString(2), reader.GetString(3) };
					returnedData.group = reader.GetString(5);
					returnedData.email = reader.GetString(6);

				}

			}

			return returnedData;

		}

		public void insertBooking(int roomID, string date, int period, int userID, string notes)
		{

			//string newdt = date.ToShortDateString();

			using (connection = new SqlConnection(getCString()))
			{

				/*
				 * this doesn't work
				 * at all.
				 * 
				 * no errors. just no 
				 * data is actually 
				 * inserted into the table.
				 * 
				 * why? f*** knows.
				 * 
				 */

				connection.Open();

				string command = String.Format("INSERT INTO tblBookings (RoomID, Date, PeriodBegin, PeriodEnd, UserID, Notes) VALUES ({0}, CONVERT(date, '{1}', 103), {2}, {2}, {3}, '{4}')", roomID.ToString(), date, period, userID.ToString(), notes); 
				
				SqlCommand logincommand = new SqlCommand(command, connection);

				try
				{
					logincommand.ExecuteNonQuery();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
				finally
				{
					connection.Close();
				}

				

			}
		}

	}
}
