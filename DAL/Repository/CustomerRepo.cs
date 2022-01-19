

using Common;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class CustomerRepo : ICustomer
    {
        public void deleteCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerData getCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void saveCustomer(CustomerData customer)
        {
            #region validation
            if (customer == null) { return; }
            #endregion

            #region get database connection and validation
            DataBaseConnection dataBaseConnection = DataBaseConnection.Instance;
            var connection = dataBaseConnection.connection;

            #endregion

            #region execute query
            using var query = new MySqlCommand();
            query.Connection = connection;
            string GUID = Guid.NewGuid().ToString();
            Console.WriteLine(GUID.Length);
            Console.WriteLine(customer.customerId);
            query.CommandText = $"INSERT INTO customer VALUES(@customerID,@customerName,@customerEmail,@customerAge,1)";
            query.Parameters.AddWithValue("@customerID", customer.customerId.ToString());
            query.Parameters.AddWithValue("@customerName", customer.customerName);
            query.Parameters.AddWithValue("@customerEmail", customer.customerEmail);
            query.Parameters.AddWithValue("@customerAge", customer.customerAge);
            query.ExecuteNonQuery();
            #endregion
        }

        public void updateCustomer(CustomerData customer)
        {
            throw new NotImplementedException();
        }
    }
}
