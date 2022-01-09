using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Controllers
{

    public class Authentication
    {
       

        public static User UserLoginAuthentication(List<User> users,string username,string password) 
        {

            var  query = users.Where((user) => user.userName==username && user.userPassword==password).FirstOrDefault();
           
                return query;

        }


      
    }
}
