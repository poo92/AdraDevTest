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
        string UploadBalance(int year, int month, float rnd, float canteen, float ceoCar, float marketing, float parking);
        string ViewBalance(int year, int month);
        string[] ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth);
    }
}
