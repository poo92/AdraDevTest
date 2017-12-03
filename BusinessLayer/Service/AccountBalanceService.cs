using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service.Interfaces;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Model;

namespace BusinessLayer.Service
{
    public class AccountBalanceService : IAccountBalanceService
    {
        private AccountBalanceRepo _AccountBalanceRepo;

        public AccountBalanceService()
        {
            _AccountBalanceRepo = new AccountBalanceRepo();
        }
        public string UploadBalance(int year, int month, float rnd, float canteen, float ceoCar, float marketing, float parking)
        {
            string uploadStatus = _AccountBalanceRepo.UploadBalance(year, month, rnd, canteen, ceoCar, marketing, parking);

            return uploadStatus;

        }


        public string ViewBalance(int year, int month)
        {
            AccountBalance accountBalance = _AccountBalanceRepo.ViewBalance(year, month);


            string result = accountBalance.year.ToString() + accountBalance.month.ToString() + accountBalance.rnd.ToString() + accountBalance.canteen.ToString() + accountBalance.ceoCar.ToString() + accountBalance.marketing.ToString() + accountBalance.parking.ToString();
            return result;
        }

        public string[] ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth)
        {
            List<AccountBalance> resultList = new List<AccountBalance>();
            resultList = _AccountBalanceRepo.ViewBalanceChart(startYear, startMonth, endYear, endMonth);

            string[] resultArray = new string[resultList.Count];

            int i = 0;
            foreach (AccountBalance accountBalance in resultList)
            {
                string result = accountBalance.year.ToString() + accountBalance.month.ToString() + accountBalance.rnd.ToString() + accountBalance.canteen.ToString() + accountBalance.ceoCar.ToString() + accountBalance.marketing.ToString() + accountBalance.parking.ToString();
                resultArray[i] = result;
                i = i + 1;
            }

            return resultArray;
        }




    }
}
