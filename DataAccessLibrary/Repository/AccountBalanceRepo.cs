using DataAccessLibrary.Model;
using DataAccessLibrary.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class AccountBalanceRepo : IAccountBalanceRepo
    {
        public string UploadBalance(int year, int month, float rnd, float canteen, float ceoCar, float marketing, float parking)
        {
            return "uploaded successfully";
        }

        public AccountBalance ViewBalance(int year, int month)
        {
            AccountBalance accountBalance = new AccountBalance();
            accountBalance.year = 2016;
            accountBalance.month = 1;
            accountBalance.rnd = 5.63f;
            accountBalance.canteen = 50000f;
            accountBalance.ceoCar = 10000f;
            accountBalance.marketing = -600f;
            accountBalance.parking = 2000f;
            return accountBalance;


        }

        public List<AccountBalance> ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth)
        {
            List<AccountBalance> resultList = new List<AccountBalance>();

            AccountBalance accountBalance1 = new AccountBalance();
            accountBalance1.year = 2016;
            accountBalance1.month = 1;
            accountBalance1.rnd = 5.63f;
            accountBalance1.canteen = 50000f;
            accountBalance1.ceoCar = 10000f;
            accountBalance1.marketing = -600f;
            accountBalance1.parking = 2000f;


            AccountBalance accountBalance2 = new AccountBalance();
            accountBalance2.year = 2016;
            accountBalance2.month = 2;
            accountBalance2.rnd = 450.2f;
            accountBalance2.canteen = 630.5f;
            accountBalance2.ceoCar = 2077f;
            accountBalance2.marketing = 38.5f;
            accountBalance2.parking = -2000f;


            AccountBalance accountBalance3 = new AccountBalance();
            accountBalance3.year = 2016;
            accountBalance3.month = 3;
            accountBalance3.rnd = 4000f;
            accountBalance3.canteen = 6000f;
            accountBalance3.ceoCar = 4500.50f;
            accountBalance3.marketing = 3596.54f;
            accountBalance3.parking = 75625.36f;


            resultList.Add(accountBalance1);
            resultList.Add(accountBalance2);
            resultList.Add(accountBalance3);



            return resultList;
        }

    }

}

