using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service.Interfaces;
using DataAccessLibrary.Repository;

namespace BusinessLayer.Service
{
    public class UserService :IUserService
    {
        // create userRepo object
        private UserRepo _UserRepo;
        public UserService()
        {
            _UserRepo = new UserRepo(); // Initialize userRepo object
        }

        // Login method
        public string LoginUser(string username, string password)
        {
            string loginStatus = _UserRepo.LoginUser(username, password);
            if (loginStatus == "Login Complete")
            {
                Console.WriteLine(loginStatus);
            }

            return loginStatus;
        }

       

    }
}
