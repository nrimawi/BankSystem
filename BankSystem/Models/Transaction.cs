
namespace BankSystem.Models
{
    public class Transaction
    {
        #region feilds

        public bool active { get; set; }
        public Guid trasnactionID { get; set; }
        public DateTime transactionDate { get; set; }
        public double trasnationAmount { get; set; }

        #endregion

        #region constructors
        public Transaction() { }
        public Transaction(double ammount,DateTime date)
        {
            this.transactionDate = date;
            this.trasnationAmount = ammount;
            this.active = true;

        }
        #endregion
    }
}
