using DataAccessLibrary.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository
{
    public class AccountBalanceRepo : IAccountBalanceRepo
    {
        private Dbcontext DbContext;
        public AccountBalanceRepo()
        {
            DbContext = new Dbcontext();
        }



        // upload account balance 
        public string UploadBalance(accountbalance accountBalance)
        {
            DbContext.accountbalances.Add(accountBalance);
            int result = DbContext.SaveChanges();

            if (result != 0)
            {
                return "uploaded succesfully";
            }
            else
            {
                return "An error occured";
            }

        }

        // view balance of an account 
        public accountbalance ViewBalance(int year, int month)
        {
            accountbalance accountBalanceresult = DbContext.accountbalances.Where(o => o.year == year && o.month == month).FirstOrDefault();
            return accountBalanceresult;
        }

        // view balances of a time period
        public List<accountbalance> ViewBalanceChart(int startYear, int startMonth, int endYear, int endMonth)
        {
            List<accountbalance> resultList = DbContext.accountbalances.Where(o => o.year >= startYear && o.month >= startMonth && o.year <= endYear && o.month <= endMonth).ToList<accountbalance>();
            return resultList;
        }


        public accountbalance ViewCurrentBalance()
        {
            accountbalance maximum = DbContext.accountbalances.OrderByDescending(o => o.year).ThenByDescending(o => o.month).FirstOrDefault();
            return maximum;


        }



    }
}

