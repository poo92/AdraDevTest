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
        string UploadBalance(int year, int month, float rnd, float canteen, float ceoCar, float marketing, float parking);

        AccountBalance ViewBalance(int year, int month);

        List<AccountBalance> ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth);
    }
}
