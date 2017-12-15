//using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
//using Moq;
//using DataAccessLibrary.Repository.Interfaces;
//using EntityClasses;

//namespace AdraUnitTests
//{
//    /// <summary>
//    /// Summary description for UserServiceTest
//    /// </summary>
//    [TestFixture]
//    public class UserServiceTest
//    {
//        [Test]
//        public void AddUserTest_user_Already_Exists()
//        {
//            User userBAL = new User();
//            userBAL.username = "Poornima";
//            userBAL.password = userDAL.password;
//            userBAL.userType = userDAL.userType;
//            userBAL.fname = userDAL.fname;
//            userBAL.lname = userDAL.lname;
//            userBAL.salt = userDAL.salt;


//            Mock<IUserRepo> mockuserRepo = new Mock<IUserRepo>();
//            mockuserRepo.Setup(x => x.ViewUser(It.IsAny<string>()).Returns(accountBalanceDAL);

//        }
//    }
//}
