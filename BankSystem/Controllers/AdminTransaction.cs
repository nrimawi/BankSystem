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

        /// <summary>
        /// This function is used to create a bank account 
        /// </summary>
        /// <param name="type">string that specify the type of account </param>
        /// <param name="customerId">global unique identifer which carries the customer id </param>
        /// <returns>account object with the required data if any input data is null return null</returns>
        public static Account CreateBankAccount(string type, Guid customerId)
        {
            #region data validation
            if (type == null || customerId == null)
            {
                throw new ArgumentNullException();
            }
                #endregion

            #region create Account
            try
            {
                Account account = new Account(true, Guid.NewGuid(), type, 0, customerId, new List<Transaction>());

                return account;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            #endregion

        }




        /// <summary>
        /// This function is used to create a bank account 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="age"></param>
        /// <returns>customer object with the required data if any input data is null return null </returns>
        public static Customer CreateCustomer(string name, string email, int age)
        {
            #region data validation
          
            #endregion

            #region createCustomer
            try
            {
                Customer customer = new Customer(true, Guid.NewGuid(), name, email, age, new List<Guid>());

                return customer;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

                return null;
            }
            #endregion
        }
        
        
        
       


    }
}
