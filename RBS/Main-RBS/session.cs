﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_RBS
{
	public static class session
	{
		static public Boolean loggedIn { get; set; }
		static public int userID { get; set; }
		static public string username { get; set; }
		static public string[] name { get; set; }
		static public string group { get; set; }
		static public string email { get; set; }
	}


	public class loginReturnedData
	{
		public Boolean success { get; set; }
		public int userID { get; set; }
		public string username { get; set; }
		public string[] name { get; set; }
		public string group { get; set; }
		public string email { get; set; }
	}
}
