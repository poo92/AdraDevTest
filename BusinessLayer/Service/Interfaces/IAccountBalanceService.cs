using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service.Interfaces
{
    interface IAccountBalanceService
    {
        // upload balance
        string UploadBalance(int year, int month, float rnd, float canteen, float ceoCar, float marketing, float parking);
        // View balance of a month
        string ViewBalance(int year, int month);
        // view balances of a time period
        string[] ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth);
    }
}
