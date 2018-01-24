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

                        string convertedDT = Convert.ToDateTime(dr["Date"].ToString()).ToShortDateString();

                        string[] list = new string[] { dr["RoomID"].ToString(), convertedDT, dr["Period"].ToString(), dr["UserID"].ToString(), dr["TimeBooked"].ToString(), dr["Id"].ToString(), dr["Notes"].ToString() };

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

        public List<ListViewItem> popUsers(bool all = true)
        {
            SqlConnection connection;

            List<ListViewItem> listItems = new List<ListViewItem>();

            string query = "SELECT * FROM tblUsers";

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

                        string formattedName = String.Format("{0} {1}", dr["FirstName"], dr["SecondName"]);

                        string[] list = new string[] { dr["Id"].ToString(), dr["Username"].ToString(), formattedName, dr["Role"].ToString(), dr["Email"].ToString() };

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
					returnedData.role = reader.GetString(5);
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

        public user getUser(int id)
        {

            user user = new user();

            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                string command = String.Format("SELECT * FROM tblUsers WHERE Id = {0}", id.ToString());

                SqlCommand logincommand = new SqlCommand(command, connection);
                SqlDataReader reader = logincommand.ExecuteReader();

                if (reader.Read())
                { 

                    user.id = reader.GetInt32(0);
                    user.username = reader.GetString(1);
                    user.firstname = reader.GetString(2);
                    user.secondname = reader.GetString(3);
                    user.password = reader.GetString(4);
                    user.role = reader.GetString(5);
                    user.email = reader.GetString(6);
                }
            }

            return user;
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

        public void updateBooking(int bookID, int roomID, DateTime date, int period, int userID, string notes)
        {

            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                string command = String.Format("UPDATE tblBookings SET RoomID = {0}, Date = CONVERT(date, '{1}', 103), Period = {2}, UserID = {3}, Notes = '{4}' WHERE Id = {5}", roomID.ToString(), date, period, userID.ToString(), notes, bookID.ToString());
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

        public void updateUser(int id, string firstname, string secondname, string password, string email, string role, string username)
        {

            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                string command = String.Format("UPDATE tblUsers SET FirstName = '{0}', SecondName = '{1}', Password = '{2}', Role='{4}', Email = '{3}', Username = '{6}'  WHERE Id = {5}", firstname, secondname, password, email, role, id.ToString(), username);
                MessageBox.Show(command);
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
