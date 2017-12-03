using DataAccessLibrary.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class UserRepo : IUserRepo
    {

        // Login method
        public string LoginUser(string username, string HashPassword)
        {
            return "Login Complete";
            //string hashedPassword = DbContext.Users.Where(o => o.UserName == username).Select(o => o.Password).FirstOrDefault().ToString();
            //if (hashedPassword == HashPassword)
            // {
            //  return "Login Complete";
            //}
            //return "Login Fail";
        }

    }
}
