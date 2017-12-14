//using System;
//using BusinessLayer.Service;
//using DataAccessLibrary.Repository.Interfaces;
//using Moq;
//using EntityClasses;
//using DataAccessLibrary.Repository;
//using DataAccessLibrary;
//using NUnit.Framework;

//namespace AdraUnitTests
//{
//    [TestFixture]
//    public class AccountBalanceServiceTest
//    {
//        //[TestMethod]
//        //public void UploadBalance()
//        //{
//        //    accountbalance accountBalanceDAL = new accountbalance();
//        //    accountBalanceDAL.year = 2016;
//        //    accountBalanceDAL.month = 1;
//        //    accountBalanceDAL.rnd = 10000.00;
//        //    accountBalanceDAL.canteen = 150000.25;
//        //    accountBalanceDAL.ceocar = 2500.36;
//        //    accountBalanceDAL.marketing = 69354.25;
//        //    accountBalanceDAL.parking = 25369.25;

//        //    AccountBalance accountBalanceBAL = new AccountBalance();
//        //    accountBalanceBAL.year = 2016;
//        //    accountBalanceBAL.month = 1;
//        //    accountBalanceBAL.rnd = 10000.00;
//        //    accountBalanceBAL.canteen = 150000.25;
//        //    accountBalanceBAL.ceocar = 2500.36;
//        //    accountBalanceBAL.marketing = 69354.25;
//        //    accountBalanceBAL.parking = 25369.25;

//        //    Mock<IAccountBalanceRepo> mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
//        //    mockAccountBalanceRepo.Setup(x => x.UploadBalance(It.IsAny<accountbalance>())).Returns("uploaded succesfully");
//        //    mockAccountBalanceRepo.Setup(x => x.ViewBalance(It.IsAny<int>(), It.IsAny<int>())).Returns(accountBalanceDAL);
//        //    AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);
//        //    string status = accountBalanceService.UploadBalance(accountBalanceBAL);
//        //    string expected = "Balances of this month already exsists in the database";
//        //    Assert.AreEqual(status, expected);

//        //}

//        [Test]
//        public void ViewBalance()
//        {
//            accountbalance accountBalanceDAL = new accountbalance();
//            accountBalanceDAL.year = 2016;
//            accountBalanceDAL.month = 1;
//            accountBalanceDAL.rnd = 10000.00;
//            accountBalanceDAL.canteen = 150000.25;
//            accountBalanceDAL.ceocar = 2500.36;
//            accountBalanceDAL.marketing = 69354.25;
//            accountBalanceDAL.parking = 25369.25;

//            AccountBalance accountBalanceBAL = new AccountBalance();
//            accountBalanceBAL.year = 2016;
//            accountBalanceBAL.month = 1;
//            accountBalanceBAL.rnd = 10000.00;
//            accountBalanceBAL.canteen = 150000.25;
//            accountBalanceBAL.ceocar = 2500.36;
//            accountBalanceBAL.marketing = 69354.25;
//            accountBalanceBAL.parking = 25369.25;

//            var mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
//            mockAccountBalanceRepo.Setup(x => x.ViewBalance(It.IsAny<int>(), It.IsAny<int>())).Returns(accountBalanceDAL);
//            AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);
//            AccountBalance accountBalanceresult = accountBalanceService.ViewBalance(2016,1);
//            Assert.AreEqual(accountBalanceresult, accountBalanceBAL);

//        }


//        [Test]
//        public void strconcat()
//        {
            
//                var mockAccountBalanceRepo = new Mock<IAccountBalanceRepo>();
//                AccountBalanceService accountBalanceService = new AccountBalanceService(mockAccountBalanceRepo.Object);
//                string result = accountBalanceService.strconcat("karu");
//                Assert.AreEqual("poohkaru", result);
        
//        }
//    }
//    }
