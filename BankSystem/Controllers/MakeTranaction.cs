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

        public static void withdraw(Account account, double amount)
        {
            //validatition 
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");


            if (account.accountBalance - amount < 0)
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");

            //create transation
            Transaction _withdraw = new Transaction(-amount, DateTime.Now);
            account.transactionslist.Add(_withdraw);
            account.accountBalance += -amount;
            Console.WriteLine($"Successfully withdraw {-_withdraw.trasnationAmount} Nis, and your new balance become {account.accountBalance} Nis");

        }

        public static void deposit(Account account, double amount)
        {

            //validatition 
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of desposte must be positive");


            //create transation
            Transaction deposite = new Transaction(amount, DateTime.Now);
            account.transactionslist.Add(deposite);
            account.accountBalance += amount;
            Console.WriteLine($"Successfully deposited {deposite.trasnationAmount} Nis, and your new balance become {account.accountBalance} Nis");


        }
    }
}
