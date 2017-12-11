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
using System.IO;
using System.Net.Http;
using System.Web.Http;

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
        //public List<string[]> UploadBalance(UserRequest userRequest)
        public string UploadBalance(UserRequest userRequest)
        {
            string[] months = { "January","February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string result = "";

            string fileContent = userRequest.fileContent;
            int year = userRequest.year;

            char delimiterNewLine = '\n';
            char delimiterTab = '\t';
            string[] lineSeperated = fileContent.Split(delimiterNewLine); // seperate line by line
            List<string[]> tabSeperated = new List<string[]>();
            double[] balances = new double[5];



            for (int i = 0; i < 6; i++)
            {
                string[] splitted = lineSeperated[i].Split(delimiterTab);  // seperate by tab 
                tabSeperated.Add(splitted);
            }
            
            string[] tabSeperatedArrayForMonth = tabSeperated[0];
            string month = tabSeperatedArrayForMonth[tabSeperatedArrayForMonth.Length - 1].Replace("\r", "");
            int monthIndex = 0;

            for (int i = 0; i < 12; i++)
            {                
            if (months[i].Equals(month))
                {
                    monthIndex = i + 1;
                }
            }


            if (monthIndex == 0)
            {
                result = "The month in the file is incorrect.Please check again";
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    string[] tabSeperatedArray = tabSeperated[i];
                    string balance = tabSeperatedArray[tabSeperatedArray.Length - 1].Replace(",", ""); // replace commas
                    double balanceDouble;
                    try
                    {
                        balanceDouble = Convert.ToDouble(balance);      // convert to double values
                        balances[i - 1] = balanceDouble;
                    }
                    catch (FormatException)
                    {
                        result = "Balance amounts are incorrect.Please check again.";
                    }
                    catch (OverflowException)
                    {
                        result = "Balance amounts are incorrect.Please check again.";
                    }
                }

                AccountBalance accountBalance = new AccountBalance();
                accountBalance.year = year;
                accountBalance.month = monthIndex;
                accountBalance.rnd = balances[0];
                accountBalance.canteen = balances[1];
                accountBalance.ceocar = balances[2];
                accountBalance.marketing = balances[3];
                accountBalance.parking = balances[4];
                accountBalance.uid = 1;


                result = _AccountBalanceService.UploadBalance(accountBalance);
            }
            return  result;

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

        [Route("api/AccountBalance/ViewCurrentBalance")]
        [HttpPost]
        public double ViewCurrentBalance(UserRequest userRequest)      // method to View  account balance of a time period
        {
            string accountType = userRequest.accountType;

            return _AccountBalanceService.ViewCurrentBalance(accountType);
        }

    }
}
