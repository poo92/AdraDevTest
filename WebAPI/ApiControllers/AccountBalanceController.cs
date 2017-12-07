using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Service;
using Newtonsoft.Json.Linq;     // json.NET
using EntityClasses;
using WebAPI.ApiModels;

namespace WebAPI.ApiControllers
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
            return _AccountBalanceService.UploadBalance(accountBalance);

        }


        [Route("api/AccountBalance/ViewBalance")]               // method to View  account balance of a month
        [HttpPost]
        public AccountBalance ViewBalance(UserRequest userRequest)
        {
            
            int year = userRequest.year;
            int month = userRequest.month;
            return _AccountBalanceService.ViewBalance(year, month);


        }


        [Route("api/AccountBalance/ViewBalanceChart")]
        [HttpPost]
        public List<AccountBalance> ViewBalanceChart(UserRequest userRequest)      // method to View  account balance of a time period
        {
            
            int startYear = userRequest.startYear;
            int startMonth = userRequest.startMonth;
            int endYear = userRequest.endYear;
            int endMonth = userRequest.endMonth;

            return _AccountBalanceService.ViewBalanceChart(startYear, startMonth, endYear, endMonth);


        }

    }
}
