using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Service;
using WebAPI.Models;            // AccountBalance class 
using Newtonsoft.Json.Linq;     // json.NET

namespace WebAPI.Controllers
{
    public class AccountBalanceController : ApiController
    {
        private AccountBalanceService _AccountBalanceService; // create object of AccountBalanceService in BL

        public AccountBalanceController()
        {
            _AccountBalanceService = new AccountBalanceService();   // initialization 
        }

        [Route("api/AccountBalance/UploadBalance")]                 // method to upload the account balances
        [HttpPost]
        public string UploadBalance(AccountBalance accountBalance)
        {
            int year = accountBalance.year;
            int month = accountBalance.month;
            float rnd = accountBalance.rnd;
            float canteen = accountBalance.canteen;
            float ceoCar = accountBalance.ceoCar;
            float marketing = accountBalance.marketing;
            float parking = accountBalance.parking;

            return _AccountBalanceService.UploadBalance(year, month, rnd, canteen, ceoCar, marketing, parking);


        }


        [Route("api/AccountBalance/ViewBalance")]               // method to View  account balance of a month
        [HttpPost]
        public string ViewBalance(JObject jsonData)
        {
            dynamic json = jsonData;
            int year = json.year;
            int month = json.month;
            return _AccountBalanceService.ViewBalance(year, month);


        }


        [Route("api/AccountBalance/ViewBalanceChart")]
        [HttpPost]
        public string[] ViewBalanceChart(JObject jsonData)      // method to View  account balance of a time period
        {
            dynamic json = jsonData;
            int startYear = json.startYear;
            int startMonth = json.startMonth;
            int endYear = json.endYear;
            int endMonth = json.endMonth;

            return _AccountBalanceService.ViewBalanceChart(startYear, startMonth, endYear, endMonth);


        }

    }
}
