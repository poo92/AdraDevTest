using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Service;
using EntityClasses;


namespace WebAPI.ApiControllers
{
    public class UserController : ApiController
    {
        private UserService _UserService;   // create BL object
        public UserController()
        {
            _UserService = new UserService();   // initialize BL object
        }

        [Route("api/User/Login")]
        [HttpPost]
        public int Login(User user)
        {
            string username = user.username;
            string password = user.password;

            return _UserService.Login(username, password);

          
        }

        [Route("api/User/AddUser")]
        [HttpPost]
        public string AddUser(User user)
        {
            User userBAL = new User();
            userBAL.username = user.username;
            userBAL.password = user.password;
            userBAL.userType = user.userType;
            userBAL.fname = user.fname;
            userBAL.lname = user.lname;



            return _UserService.AddUser(userBAL);


        }
    }
}
