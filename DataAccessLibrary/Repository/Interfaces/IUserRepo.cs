using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repository.Interfaces
{
   public interface IUserRepo
    {
        string LoginUser(string username, string HashPassword);
        
    }
}
