

namespace BankSystem.Models
{
    public class Customer
    {

        #region fields
        public bool active { get; set; }
        public Guid customerId { get; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public int customerAge { get; set; }

       
        #endregion


        #region constructor
        public Customer( Guid customerId, string customerName, string customerEmail, int customerAge)
        {
            this.customerId = customerId;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.customerAge = customerAge;
        }

        #endregion



    }
}
