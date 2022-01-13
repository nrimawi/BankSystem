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
       
        /// <summary>
        /// This function used to find the user which has a username and password from the users list
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="username">string that carries the username of the user</param>
        /// <param name="password">string that carries the password of the user</param>
        /// <returns>USER FOUND: return user
        ///          USER NOT FOUND or Input/s is/are null :return null </returns>
        public static User userLoginAuthentication(List<User> users,string username,string password) 
        {
            #region inputValidation
            if (username == null || password == null && users != null) { return null; }
            #endregion

            #region searchQuery
            var user = users.Where((user) => user.userName==username && user.userPassword==password).FirstOrDefault();
          
            return user;
            #endregion

        }



    }
}
