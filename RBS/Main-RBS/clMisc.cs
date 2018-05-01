using System;

namespace Main_RBS
{
    // global class that holds the current user session
    public static class session
    {

        static public Boolean loggedIn { get; set; }
        static public int userID { get; set; }
        static public string username { get; set; }
        static public string[] name { get; set; }
        public static user.roles role { get; set; }
        static public string email { get; set; }
    }

    // global class that stores data that needs to be transfered between forms
    public static class tempVars
    {
        static public int editBookingId { get; set; }
        static public int editUserId { get; set; }
        static public modes userMode { get; set; }
        static public modes bookingMode { get; set; }

        // different modes that forms can be opened in, used for the userMode and bookingMode vars above
        public enum modes
        {
            Edit,
            View
        }
    }

    // class structure that can hold login data
    public class loginReturnedData
    {
        public Boolean success { get; set; }
        public int userID { get; set; }
        public string username { get; set; }
        public string[] name { get; set; }
        public user.roles role { get; set; }
        public string email { get; set; }
    }

    // class structure that can hold booking data
    public class booking
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public DateTime date { get; set; }
        public int period { get; set; }
        public string notes { get; set; }
        public int roomID { get; set; }
    }

    // class structure that can hold user data
    public class user
    {

        // roles that users are able to have
        public enum roles
        {
            Admin,
            Teacher,
            Student,
            None
        }

        public int id { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string secondname { get; set; }
        public roles role { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}