﻿using EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service.Interfaces
{
    public interface IUserService
    {
        int Login(string username, string password);

        string AddUser(User user);
        User ViewUser(string username);
        string DeleteUser(User user);

        string[] GetAllUsers();
        
    }
}
