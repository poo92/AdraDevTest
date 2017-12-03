using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    public class User
    {
        public int uID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int userType { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }

    }
}
