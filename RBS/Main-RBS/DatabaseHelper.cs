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

		string connectionString;

		SqlConnection connection;

		public string getCString()
		{
			connectionString = ConfigurationManager.ConnectionStrings["Main_RBS.Properties.Settings.dbConnectionString"].ConnectionString;
			return connectionString;
		}

		public List<ListViewItem> popBookings(bool all = true)
		{
			SqlConnection connection;

			List<ListViewItem> listItems = new List<ListViewItem>();

			string query;

			if (session.userID < 0 || all)
			{
				query = "SELECT * FROM tblBookings";
			}
			else
			{
				query = String.Format("SELECT * FROM tblBookings WHERE UserID = {0} ORDER BY TimeBooked DESC", session.userID);
			}

			try
			{
				using (connection = new SqlConnection(getCString()))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

					DataTable dt = new DataTable();

					adapter.Fill(dt);

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						DataRow dr = dt.Rows[i];

						string[] list = new string[] { dr["RoomID"].ToString(), dr["Date"].ToString(), dr["Period"].ToString(), dr["UserID"].ToString(), dr["TimeBooked"].ToString() };

						ListViewItem li = new ListViewItem(list);

						listItems.Add(li);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

			return listItems;
		}

		public loginReturnedData checkLoginDetails(string username, string pass)
		{

			loginReturnedData returnedData = new loginReturnedData();

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

		public booking getBooking(int id)
		{

			booking booking = new booking();

			using (connection = new SqlConnection(getCString()))
			{
				connection.Open();

				string command = String.Format("SELECT * FROM tblBookings WHERE Id = {0}", id.ToString());

				SqlCommand logincommand = new SqlCommand(command, connection);
				SqlDataReader reader = logincommand.ExecuteReader();

				if (reader.Read())
				{
					booking.id = reader.GetInt32(0);
					booking.date = reader.GetDateTime(2);
					booking.UserID = reader.GetInt32(4);
					booking.period = reader.GetInt32(3);
					booking.notes = reader.GetString(5);
					booking.roomID = reader.GetInt32(1);
				}
			}

			return booking;
		}

		public void insertBooking(int roomID, DateTime date, int period, int userID, string notes)
		{
			DateTime dt = new DateTime();
			dt = DateTime.Now;

			string newdt = date.ToShortDateString();

			using (connection = new SqlConnection(getCString()))
			{
				connection.Open();

				string command = String.Format("INSERT INTO tblBookings (RoomID, Date, Period, UserID, Notes, TimeBooked) VALUES ({0}, CONVERT(date, '{1}', 103), {2}, {3}, '{4}', CONVERT(datetime, '{5}', 103))", roomID.ToString(), date, period, userID.ToString(), notes, dt.ToString()); 
				
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

		public void miscAction(string query)
		{
			using (connection = new SqlConnection(getCString()))
			{
				connection.Open();

				string command = query;

				SqlCommand logincommand = new SqlCommand(command, connection);
				try
				{
					logincommand.ExecuteNonQuery();
				}
				catch (Exception ex)
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
