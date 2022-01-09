using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Controllers
{
    public class AdminTransaction
    {

    
        public static Account CreateBankAccount(string type, Guid customerId)
        {
            Account account = new Account(true,Guid.NewGuid(),type,0,customerId,new List<Transaction>());

            return account;

        }

        public static Customer CreateCustomer(string name, string email, int age)
        {
            Customer customer = new Customer(true,Guid.NewGuid(),name, email, age,new List<Guid>());

            return customer;

        }

     
    }
}
