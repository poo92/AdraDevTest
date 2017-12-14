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
        private Dbcontext DbContext;
        public UserRepo()
        {
            DbContext = new Dbcontext();
        }

        // add user method
        public string AddUser(user user)
        {
            // add new user to the db
            DbContext.users.Add(user);
            int result = DbContext.SaveChanges();

            if (result != 0)
            {
                return "User Added succesfully";
            }
            else
            {
                return "An error occured.Please try again";
            }
        }

        // method to get user by username
        public user ViewUser(string username)
        {
            user user = DbContext.users.Where(o => o.username == username).FirstOrDefault();
            return user;
        }


    }
}
