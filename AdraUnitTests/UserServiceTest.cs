using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using DataAccessLibrary.Repository.Interfaces;
using EntityClasses;
using DataAccessLibrary;
using BusinessLayer.Service;

namespace AdraUnitTests
{
    /// <summary>
    /// Summary description for UserServiceTest
    /// </summary>
    [TestFixture]
    public class UserServiceTest
    {
        [Test]
        public void AddUserTest_user_Already_Exists()
        {
            user userDAL = new user();
            userDAL.username = "poornima";
            userDAL.password = "reFOoYBePNnjblVxNVa3b9D/8K7ZPtrzuQGfv/yRV9Y=";
            userDAL.userType = 1;
            userDAL.fname = "janith";
            userDAL.lname = "karunarathne";
            userDAL.salt = "0VqK3vXCiXKyWt7y2HMmviGpz7Tt4z9jO3Fh9FCOimw=";

            User userBAL = new User();
            userBAL.username = "poornima";
            userBAL.password = "12345";
            userBAL.userType = 1;
            userBAL.fname = "poornima";
            userBAL.lname = "karunarathne";
            userBAL.salt = "";

            string expected = "This username is already in use. Please enter another username.";

            Mock<IUserRepo> mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(x => x.ViewUser(It.IsAny<string>())).Returns(userDAL);


            UserService userService = new UserService(mockUserRepo.Object);
            string actual = userService.AddUser(userBAL);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void AddUserTest_user_Not_Exists()
        {
            User userBAL = new User();
            userBAL.username = "poornima";
            userBAL.password = "reFOoYBePNnjblVxNVa3b9D/8K7ZPtrzuQGfv/yRV9Y=";
            userBAL.userType = 1;
            userBAL.fname = "janith";
            userBAL.lname = "karunarathne";
            userBAL.salt = "0VqK3vXCiXKyWt7y2HMmviGpz7Tt4z9jO3Fh9FCOimw=";



            string expected = "User Added succesfully";

            Mock<IUserRepo> mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(x => x.ViewUser(It.IsAny<string>())).Returns((user)null);
            mockUserRepo.Setup(x => x.AddUser(It.IsAny<user>())).Returns("User Added succesfully");

            UserService userService = new UserService(mockUserRepo.Object);
            string actual = userService.AddUser(userBAL);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void LoginTest_User_Not_Resgistered()
        {
            string username = "poornima";
            string password = "12345";
            int expected = 0;

            Mock<IUserRepo> mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(x => x.ViewUser(It.IsAny<string>())).Returns((user)null);

            UserService userService = new UserService(mockUserRepo.Object);
            int actual = userService.Login(username, password);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoginTest_User_Resgistered_Wrong_Password()
        {
            string username = "poornima";
            string password = "123456";

            user userDAL = new user();
            userDAL.username = "poornima";
            userDAL.password = "12345";
            userDAL.userType = 1;
            userDAL.fname = "poornima";
            userDAL.lname = "karunarathne";
            userDAL.salt = "";


            int expected = 0;


            Mock<IUserRepo> mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(x => x.ViewUser(It.IsAny<string>())).Returns(userDAL);

            UserService userService = new UserService(mockUserRepo.Object);
            int actual = userService.Login(username, password);

            Assert.AreEqual(expected, actual);
        }



        [Test]
        public void LoginTest_Correct_credentials()
        {
            string username = "poornima";
            string password = "12345";

            user userDAL = new user();
            userDAL.username = "poornima";
            userDAL.password = "nn4bIX3pXLOJYIXdN7GfV+dvz30yTI2CFiaNl0ZNSpQ=";
            userDAL.userType = 1;
            userDAL.fname = "janith";
            userDAL.lname = "karunarathne";
            userDAL.salt = "0VqK3vXCiXKyWt7y2HMmviGpz7Tt4z9jO3Fh9FCOimw=";

            int expected = 1;


            Mock<IUserRepo> mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(x => x.ViewUser(It.IsAny<string>())).Returns(userDAL);

            UserService userService = new UserService(mockUserRepo.Object);
            int actual = userService.Login(username, password);

            Assert.AreEqual(expected, actual);
        }
    }
}
