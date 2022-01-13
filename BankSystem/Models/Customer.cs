

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

        public List<Guid> accountList;
       
        #endregion


        #region constructor
        public Customer(bool active, Guid customerId, string customerName, string customerEmail, int customerAge, List<Guid> accountList)
        {
            this.active = active;
            this.customerId = customerId;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.customerAge = customerAge;
            this.accountList = accountList;
        }

        #endregion



    }
}
