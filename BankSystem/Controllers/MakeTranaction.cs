using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Controllers
{


    public class  MakeTransaction
    {
        /// <summary>
        /// This Function is used to make a withdraw transaction for a specific account with a targeted amount
        /// </summary>
        /// <param name="account">the Targeted account</param>
        /// <param name="amount">The Targeted amount(number)</param>
        /// <returns>
        /// 1 ON Success 
        /// 0 on failure of type wrong input
        /// -1 on failure of type can't fund the required amount
        /// </returns>
        public static int withdraw(Account account, double amount)
        {

            #region validation
            if (amount != null && amount <= 0)
                return 0;


            if (account.accountBalance - amount < 0)
                return -1;
            #endregion

            #region Create Transaction
            Transaction _withdraw = new Transaction(-amount, DateTime.Now);
            account.transactionslist.Add(_withdraw);
            account.accountBalance += -amount;
            //Console.WriteLine($"Successfully withdraw {-_withdraw.trasnationAmount} Nis, and your new balance become {account.accountBalance} Nis");
            return 1;

            #endregion

        }

        /// <summary>
        /// This Function is used to make a deposite transaction for a specific account with a targeted amount
        /// </summary>
        /// <param name="account">the Targeted account</param>
        /// <param name="amount">The Targeted amount</param>
        /// <returns>
        /// 1 ON Success 
        /// 0 on failure of type wrong input
        /// </returns>
        public static int deposit(Account account, double amount)
        {
            #region validation
            if (amount != null && amount <= 0)
                return 0;
            #endregion

            #region Create Transation
            Transaction deposite = new Transaction(amount, DateTime.Now);
            account.transactionslist.Add(deposite);
            account.accountBalance += amount;
            return 1;
            #endregion

        }
    }
}
