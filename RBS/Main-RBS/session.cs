using System;
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
	}


	public class loginReturnedData
	{
		public Boolean success { get; set; }
		public int userID { get; set; }
		public string whoknows { get; set; }
	}
}
