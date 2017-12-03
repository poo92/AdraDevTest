using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository.Interfaces
{
    interface IAccountBalanceRepo
    {
        // upload account balance
        string UploadBalance(int year, int month, float rnd, float canteen, float ceoCar, float marketing, float parking);

        // view balance of an account
        AccountBalance ViewBalance(int year, int month);

        // view balances of a time period
        List<AccountBalance> ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth);
    }
}
