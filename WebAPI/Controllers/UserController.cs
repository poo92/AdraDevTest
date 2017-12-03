using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Service;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private UserService _UserService;   // create BL object
        public UserController()
        {
            _UserService = new UserService();   // initialize BL object
        }

        [Route("api/UserLogin/Login")]
        [HttpPost]
        public string Login(User user)
        {
            string username = user.username;
            string password = user.password;
            return _UserService.LoginUser(username, password);
        }
    }
}
