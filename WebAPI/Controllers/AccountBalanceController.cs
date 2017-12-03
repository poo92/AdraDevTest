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
    public class AccountBalanceController : ApiController
    {
        private AccountBalanceService _AccountBalanceService;

        public AccountBalanceController()
        {
            _AccountBalanceService = new AccountBalanceService();
        }

        [Route("api/AccountBalance/UploadBalance")]
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


        [Route("api/AccountBalance/ViewBalance")]
        [HttpPost]
        public string ViewBalance(AccountBalance accountBalance)
        {
            int year = accountBalance.year;
            int month = accountBalance.month;

            return _AccountBalanceService.ViewBalance(year, month);


        }


        [Route("api/AccountBalance/ViewBalanceChart")]
        [HttpPost]
        public string[] ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth)
        {
            return _AccountBalanceService.ViewBalanceChart(startYear, startMonth, endYear, endMonth);


        }

    }
}
