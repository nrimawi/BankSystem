

namespace BankSystem.Models
{

    public class Account
    {
        #region fields
        public bool active { get; set; }
        public Guid accountIBAN { get; set; }
        public string accountType { get; set; }
        public double accountBalance { get; set; }
        public Guid accountOwnerId { get; }

        public List<Transaction> transactionslist = new List<Transaction>();
        #endregion

        #region constructor

        public Account(bool active, Guid accountIBAN, string accountType, double accountBalance, Guid accountOwnerId, List<Transaction> transactionslist)
        {
            this.active = active;
            this.accountIBAN = accountIBAN;
            this.accountType = accountType;
            this.accountBalance = accountBalance;
            this.accountOwnerId = accountOwnerId;
            this.transactionslist = transactionslist;
        }
        #endregion 
    }
}
