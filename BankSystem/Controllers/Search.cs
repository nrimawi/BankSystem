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

        public static Role GetLoggedInUserRole(List<Role> roles, User user)
        {
            var query = roles.Where((role) => role.RoleId == user.roleID).FirstOrDefault();
            return query;
        }

        public static Account GetAccount(List<Account> accounts,Guid IBAN)
        {
            var query = accounts.Where((account) => account.accountIBAN == IBAN).FirstOrDefault();
            return query;

        }

        public static Customer GetCustomer(List<Customer> customers, Guid customerID)
        {

            var query = customers.Where((customer) =>  customer.customerId == customerID).FirstOrDefault();
            return query;
        }

    }
}
