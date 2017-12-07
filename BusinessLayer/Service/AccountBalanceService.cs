using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service.Interfaces;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Repository.Interfaces;
using DataAccessLibrary;
using EntityClasses;

namespace BusinessLayer.Service
{
    public class AccountBalanceService : IAccountBalanceService
    {
        private IAccountBalanceRepo _AccountBalanceRepo;         // instance of a AccountBalanceRepo class on DAL

        public AccountBalanceService()
        {
            _AccountBalanceRepo = new AccountBalanceRepo();     // initialization
        }

        // upload balance
        public string UploadBalance(AccountBalance accountBalance)
        {
            accountbalance accountBalanceDAL = new accountbalance();
            accountBalanceDAL.year = accountBalance.year;
            accountBalanceDAL.month = accountBalance.month;
            accountBalanceDAL.rnd = accountBalance.rnd;
            accountBalanceDAL.canteen = accountBalance.canteen;
            accountBalanceDAL.ceocar = accountBalance.ceocar;
            accountBalanceDAL.marketing = accountBalance.marketing;
            accountBalanceDAL.parking = accountBalance.parking;
            accountBalanceDAL.uid = accountBalance.uid;

            string uploadStatus = _AccountBalanceRepo.UploadBalance(accountBalanceDAL);
            return uploadStatus;

        }

        // View balance of a month
        public AccountBalance ViewBalance(int year, int month)
        {
            accountbalance accountBalance = _AccountBalanceRepo.ViewBalance(year,month);
            AccountBalance accountBalanceResult = new AccountBalance();

            accountBalanceResult.year = accountBalance.year;
            accountBalanceResult.month = accountBalance.month;
            accountBalanceResult.rnd = (double)accountBalance.rnd;
            accountBalanceResult.canteen = (double)accountBalance.canteen;
            accountBalanceResult.ceocar = (double)accountBalance.ceocar;
            accountBalanceResult.marketing = (double)accountBalance.marketing;
            accountBalanceResult.parking = (double)accountBalance.parking;
            accountBalanceResult.uid = (int)accountBalance.uid;

            //            string result = accountBalanceresult.year.ToString() + accountBalanceresult.month.ToString() + accountBalanceresult.rnd.ToString() + accountBalanceresult.canteen.ToString() + accountBalanceresult.ceocar.ToString() + accountBalanceresult.marketing.ToString() + accountBalanceresult.parking.ToString();
            return accountBalanceResult;
        }

        // view balances of a time period
        public List<AccountBalance> ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth)
        {
            List<accountbalance> resultList = _AccountBalanceRepo.ViewBalanceChart(startYear, startMonth, endYear, endMonth);    // reuslt from the DB

            List<AccountBalance> result = new List<AccountBalance>();    // final result

            
            foreach (accountbalance accountBalance in resultList)
            {
                AccountBalance accountBalaceBAL = new AccountBalance();
                accountBalaceBAL.year = accountBalance.year;
                accountBalaceBAL.month = accountBalance.month;
                accountBalaceBAL.rnd = (double)accountBalance.rnd;
                accountBalaceBAL.canteen = (double)accountBalance.canteen;
                accountBalaceBAL.ceocar = (double)accountBalance.ceocar;
                accountBalaceBAL.marketing = (double)accountBalance.marketing;
                accountBalaceBAL.parking = (double)accountBalance.parking;
                accountBalaceBAL.uid = (int)accountBalance.uid;

                //               string accountBalaceBAL = accountBalance.year.ToString() + accountBalance.month.ToString() + accountBalance.rnd.ToString() + accountBalance.canteen.ToString() + accountBalance.ceocar.ToString() + accountBalance.marketing.ToString() + accountBalance.parking.ToString();
                result.Add(accountBalaceBAL);               
            }

            return result;
        }




    }
}
