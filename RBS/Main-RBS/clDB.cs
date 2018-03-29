using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Main_RBS
{
    public class clDB
    {
        private string connectionString;

        private SqlConnection connection;

        // method to return the connection string
        public string getCString()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Main_RBS.Properties.Settings.dbConnectionString"].ConnectionString;
            return connectionString;
        }

        // method for populating the bookings table
        // var all: if all bookings want to be collected
        public List<ListViewItem> popBookings(bool all = true)
        {
            // new instances of connection, listItems and query for use within the method
            SqlConnection connection;
            List<ListViewItem> listItems = new List<ListViewItem>();
            string query;

            // checks if someone is not logged in or if all = true (default as true)
            if (session.userID < 0 || all)
            {
                // selects all entries from the bookings table
                query = "SELECT b.* FROM tblBookings b ";
            }
            else
            {
                // selects only the bookings for the logged in user
                query = String.Format("SELECT * FROM tblBookings WHERE UserID = {0} ORDER BY TimeBooked DESC", session.userID);
            }

            Debug.WriteLine(String.Format("Sending SQL command: {0}", query));

            try
            {
                // opens a connection to the database using the connection string
                using (connection = new SqlConnection(getCString()))
                {
                    // sets up data adapters for reading data from the returned result
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    DataTable dt = new DataTable();

                    try
                    {
                        // takes the data from the adapter and puts it into the datatable
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                    // for each entry in the data table, add to the item list
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        // converts the date from datetime to a string
                        string convertedDT = Convert.ToDateTime(dr["Date"].ToString()).ToShortDateString();

                        string[] list = new string[] { dr["RoomID"].ToString(), convertedDT, dr["Period"].ToString(), getUsername(Convert.ToInt32(dr["UserID"])), dr["TimeBooked"].ToString(), dr["Id"].ToString(), dr["Notes"].ToString() };

                        // creates a new ListViewItem using the list array
                        ListViewItem li = new ListViewItem(list);

                        // adds the list item to the list<>
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

        // method for populating the calendar view
        // var roomid: get the bookings for the specific room required
        // var period: get the bookings with the period
        public List<booking> populateCalendar(int roomID, int period)
        {
            // new instances of connection, listItems and query for use within the method

            SqlConnection connection;
            List<booking> listItems = new List<booking>();
            string query;

            // gets the date, id and userid values from the bookings table that match the roomID and period

            query = String.Format("SELECT Date, Id, UserID FROM tblBookings WHERE RoomID = {0} AND Period = {1}", roomID.ToString(), period.ToString());

            Debug.WriteLine(String.Format("Sending SQL command: {0}", query));

            try
            {
                // opens a new connection to the database
                using (connection = new SqlConnection(getCString()))
                {
                    // sets up data adapters for reading data from the returned result
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();

                    try
                    {
                        // fills the datatable with the data from the adaoter
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                    // for each row in the results
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // create a new booking object and set the returned values
                        DataRow dr = dt.Rows[i];

                        booking bk = new Main_RBS.booking();
                        bk.date = Convert.ToDateTime(dr["Date"].ToString());
                        bk.id = Convert.ToInt32(dr["Id"]);
                        bk.UserID = Convert.ToInt32(dr["UserID"]);

                        // add to the booking list
                        listItems.Add(bk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // return list items
            return listItems;
        }

        // method for populating the users table
        public List<ListViewItem> popUsers()
        {
            // new instances of connection, listItems and query for use within the method
            SqlConnection connection;
            List<ListViewItem> listItems = new List<ListViewItem>();
            string query = "SELECT * FROM tblUsers";

            Debug.WriteLine(String.Format("Sending SQL command: {0}", query));

            try
            {
                // opens up a new connection to the database
                using (connection = new SqlConnection(getCString()))
                {
                    // gets the data returned and adds it to a datatable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // for each returned result
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // add the data to a list
                        DataRow dr = dt.Rows[i];

                        string formattedName = String.Format("{0} {1}", dr["FirstName"], dr["SecondName"]);

                        string[] list = new string[] { dr["Id"].ToString(), dr["Username"].ToString(), formattedName, dr["Role"].ToString() };

                        // turn into a listview
                        ListViewItem li = new ListViewItem(list);

                        // add to a list
                        listItems.Add(li);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // return list items
            return listItems;
        }

        // method for checking login details
        // var username: the username required to check
        // var pass: the password required to check
        public loginReturnedData checkLoginDetails(string username, string pass)
        {
            // creates new instance of the login returned data
            loginReturnedData returnedData = new loginReturnedData();

            // opens new connection to the database
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                // get all info from users table that have the username and password given
                string command = String.Format("SELECT * FROM tblUsers WHERE Username = '{0}' AND Password = '{1}'", username, pass);
                Debug.WriteLine(String.Format("Sending SQL command: {0}", command));

                // execute the command and get the data back
                SqlCommand logincommand = new SqlCommand(command, connection);
                SqlDataReader reader = logincommand.ExecuteReader();

                // if data exists
                if (reader.Read())
                {
                    // sets the returned data to the user info
                    returnedData.success = true;
                    returnedData.userID = reader.GetInt32(0);
                    returnedData.username = reader.GetString(1);
                    returnedData.name = new string[] { reader.GetString(2), reader.GetString(3) };
                    switch (reader.GetString(5))
                    {
                        case "Admin":
                            returnedData.role = user.roles.Admin;
                            break;
                        case "Teacher":
                            returnedData.role = user.roles.Teacher;
                            break;
                        case "Student":
                            returnedData.role = user.roles.Student;
                            break;
                        default:
                            returnedData.role = user.roles.Student;
                            break;
                    }
                }
            }

            // retuens the returned data
            return returnedData;
        }

        // method for checking if a username already exists
        // var username: username to check
        // var editid: to check if the name being checked is the current edited user's current name
        public bool checkUsernameExists(string username, int editId)
        {
            // defaults 'exists' to false
            bool exists = false;

            // opens connection to the database
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                // get the id from table users that have fields matching the username
                string command = String.Format("SELECT Id FROM tblUsers WHERE Username = '{0}'", username);
                Debug.WriteLine(String.Format("Sending SQL command: {0}", command));

                // executes the command
                SqlCommand logincommand = new SqlCommand(command, connection);

                // creates instance of recievedId for future reference
                int recievedId;

                // if username trying to change to is the user's current username
                try
                {
                    // tries to see if any data has been returned
                    recievedId = (int)logincommand.ExecuteScalar();
                }
                catch
                {
                    // no username found
                    return false;
                }

                if (recievedId == editId)
                {
                    // username is the same
                    return false;
                }

                // if username exists
                try
                {
                    exists = (int)logincommand.ExecuteScalar() > 0;
                }
                catch (NullReferenceException)
                {
                    exists = false;
                }

                return exists;
            }
        }

        // method for retrieving a username
        // var userid: used to retrieve the username
        public string getUsername(int userid)
        {
            // opens a new connection to the database
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                // select the username from the users table for entries that match the userif
                string command = String.Format("SELECT Username FROM tblUsers WHERE Id = {0}", userid.ToString());
                Debug.WriteLine(String.Format("Sending SQL command: {0}", command));

                // executes the command
                SqlCommand logincommand = new SqlCommand(command, connection);

                // reads the username, assigns it to the name variable and returnes it
                string name = (string)logincommand.ExecuteScalar();
                return name;
            }
        }

        // method for checking if a booking already exists
        public bool checkBookingExists(string date, int period, int room, int editId = -1)
        {
            try
            {
                // defaults exists to false
                bool exists = false;

                // opens connection to the database
                using (connection = new SqlConnection(getCString()))
                {
                    connection.Open();

                    // select the id that matches the criteria
                    string command = String.Format("SELECT Id FROM tblBookings WHERE Date = CONVERT(date, '{0}', 103) AND Period = {1} AND RoomID = {2}", date, period, room);
                    Debug.WriteLine(String.Format("Sending SQL command: {0}", command));

                    // executes the command
                    SqlCommand logincommand = new SqlCommand(command, connection);

                    // sets the var 'recievedId' for future use
                    int recievedId;

                    try
                    {
                        recievedId = (int)logincommand.ExecuteScalar();
                        // booking has been founed
                    }
                    catch
                    {
                        // no booking found
                        return false;
                    }

                    // if booking trying to change to is the user's current booking
                    if (editId != -1 && recievedId == editId)
                    {
                        return false;
                    }

                    // if username exists
                    try
                    {
                        exists = (int)logincommand.ExecuteScalar() > 0;
                        Debug.WriteLine(exists.ToString());
                    }
                    catch (NullReferenceException)
                    {
                        exists = false;
                    }

                    return exists;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // method for retrieving booking details
        public booking getBooking(int id)
        {
            // creates new instance of booking
            booking booking = new booking();

            // opens connection to the database
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                // select all entries where the ID is as specified
                string command = String.Format("SELECT * FROM tblBookings WHERE Id = {0}", id.ToString());
                Debug.WriteLine(String.Format("Sending SQL command: {0}", command));

                // executes the command
                SqlCommand logincommand = new SqlCommand(command, connection);

                // gets the returned data
                SqlDataReader reader = logincommand.ExecuteReader();

                // if data exists
                if (reader.Read())
                {
                    // sets booking data
                    booking.id = reader.GetInt32(0);
                    booking.date = reader.GetDateTime(2);
                    booking.UserID = reader.GetInt32(4);
                    booking.period = reader.GetInt32(3);
                    booking.notes = reader.GetString(5);
                    booking.roomID = reader.GetInt32(1);
                }
            }

            // returns booking
            return booking;
        }

        // method for retrieving user details
        public user getUser(int id)
        {
            // creates new instance of a user object
            user user = new user();

            // opens connection to the database
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                // get all users with the id specified
                string command = String.Format("SELECT * FROM tblUsers WHERE Id = {0}", id.ToString());
                Debug.WriteLine(String.Format("Sending SQL command: {0}", command));

                // sends the command
                SqlCommand logincommand = new SqlCommand(command, connection);

                // gets the returned data
                SqlDataReader reader = logincommand.ExecuteReader();

                // if data exists
                if (reader.Read())
                {
                    // sets the user data
                    user.id = reader.GetInt32(0);
                    user.username = reader.GetString(1);
                    user.firstname = reader.GetString(2);
                    user.secondname = reader.GetString(3);
                    user.password = reader.GetString(4);

                    switch (reader.GetString(5))
                    {
                        case "Admin":
                            user.role = user.roles.Admin;
                            break;
                        case "Teacher":
                            user.role = user.roles.Teacher;
                            break;
                        case "Student":
                            user.role = user.roles.Student;
                            break;
                        default:
                            user.role = user.roles.Student;
                            break;
                    }
                }
            }

            // returns user data
            return user;
        }

        // method for inserting a booking into a table
        public void insertBooking(int roomID, DateTime date, int period, int userID, string notes)
        {
            // gets current date/time
            DateTime dt = new DateTime();
            dt = DateTime.Now;

            // turns the date given to the method into a string in the form of `DD/MM/YYYY`
            string newdt = date.ToShortDateString();

            // opens connection to the databse
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                // insert the following values into the table
                string command = String.Format("INSERT INTO tblBookings (RoomID, Date, Period, UserID, Notes, TimeBooked) VALUES ({0}, CONVERT(date, '{1}', 103), {2}, {3}, '{4}', CONVERT(datetime, '{5}', 103))", roomID.ToString(), date, period, userID.ToString(), notes, dt.ToString());
                Debug.WriteLine(String.Format("Sending SQL command: {0}", command));
                SqlCommand logincommand = new SqlCommand(command, connection);

                try
                {
                    // executes the command
                    logincommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // method for updating booking details
        public void updateBooking(int bookID, int roomID, DateTime date, int period, int userID, string notes)
        {
            // opens connection to the database
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                // update the booking table with these values
                string command = String.Format("UPDATE tblBookings SET RoomID = {0}, Date = CONVERT(date, '{1}', 103), Period = {2}, UserID = {3}, Notes = '{4}' WHERE Id = {5}", roomID.ToString(), date, period, userID.ToString(), notes, bookID.ToString());
                Debug.WriteLine(String.Format("Sending SQL command: {0}", command));
                SqlCommand logincommand = new SqlCommand(command, connection);
                try
                {
                    // executes the command
                    logincommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // method for updating user details
        public void updateUser(int id, string firstname, string secondname, string password, string role, string username)
        {
            // opens connection to the database
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                // update the users table with the following values
                string command = String.Format("UPDATE tblUsers SET FirstName = '{0}', SecondName = '{1}', Password = '{2}', Role='{3}', Username = '{4}'  WHERE Id = {5}", firstname, secondname, password, role, username, id.ToString());
                Debug.WriteLine(String.Format("Sending SQL command: {0}", command));
                SqlCommand logincommand = new SqlCommand(command, connection);
                try
                {
                    // executes the command
                    logincommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // method for executing misc queries/commands to the database608-
        public void miscAction(string query)
        {
            Debug.WriteLine(String.Format("Sending SQL command: {0}", query));

            // opens connection to the database
            using (connection = new SqlConnection(getCString()))
            {
                connection.Open();

                string command = query;

                SqlCommand logincommand = new SqlCommand(command, connection);
                try
                {
                    // executes the command
                    logincommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occured. \nDetails: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}