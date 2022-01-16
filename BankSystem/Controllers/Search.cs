using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Controllers
{
    public class Search
    {
        /// <summary>
        /// This function used to search for the a role object using its ID
        /// </summary>
        /// <param name="roles">roles data list to search in</param>
        /// <param name="roleId">The id of the object we want to return</param>
        /// <returns>role object on success and null on failure </returns>
        public static Role getLoggedInUserRole(List<Role> roles, int roleId)
        {
            #region inputValidation
            if (roleId == null && roles==null) return null;
            #endregion

            #region search
            var role = roles.Where((role) => role.RoleId == roleId).FirstOrDefault();
            return role;
            #endregion 
        }

        /// <summary>
        /// This function used to search for the an accounts  using its IBAN
        /// </summary>
        /// <param name="accounts">accounts data list to search in</param>
        /// <param name="IBAN">The id of the object we want to return</param>
        /// <returns>account object on success and null on failure </returns>

        public static Account getAccount(List<Account> accounts,Guid IBAN)
        {
            #region inputValidation
            if (accounts == null && IBAN == null) return null;
            #endregion
            
            #region search
            var account = accounts.Where((account) => account.accountIBAN == IBAN).FirstOrDefault();
            if (account == null) return  null ;
            return account;
            #endregion

        }

        /// <summary>
        /// This function used to search for a customer using its ID
        /// </summary>
        /// <param name=customers">customers data list to search in</param>
        /// <param name="customerID">The id of the object we want to return</param>
        /// <returns>cusomer object on success and null on failure </returns>

        public static Customer getCustomer(List<Customer> customers, Guid customerID)
        {
            #region inputValidation
            if(customerID == null && customers==null) return null;
            #endregion

            #region search
            var customer = customers.Where((customer) =>  customer.customerId == customerID).FirstOrDefault();
            return customer;
            #endregion
        }

    }
}
