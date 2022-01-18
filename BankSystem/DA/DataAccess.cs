using BankSystem.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace BankSystem.DA
{
    public class DataAccess
    {



        
        public static void saveCustomer(Customer customer)
        {
            #region validation
            if (customer == null) { return; }
            #endregion

            #region get database connection and validation
            DataBaseConnection  dataBaseConnection= DataBaseConnection.Instance;
            var connection = dataBaseConnection.connection;
            try { connection.Open(); }
            catch (MySqlException ex) { throw ex; }
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

        public static void saveAccount(Account account)
        {
            #region validation
            if (account == null) { return; }
            #endregion

            #region get database connection and validation
            DataBaseConnection dataBaseConnection = DataBaseConnection.Instance;
            var connection = dataBaseConnection.connection;
            try { connection.Open(); }
            catch (MySqlException ex) { throw ex; }
            #endregion


            using var query = new MySqlCommand();
            query.Connection = connection;
            string GUID = Guid.NewGuid().ToString();
            query.CommandText = $"INSERT INTO customer VALUES(@accountIBAN,@accountType,@accountBalance,1)";
            query.Parameters.AddWithValue("@accountIBAN", account.accountIBAN.ToString());
            query.Parameters.AddWithValue("@accountType", account.accountType);
            query.Parameters.AddWithValue("@accountBalance", account.accountBalance);
            query.ExecuteNonQuery();

        }
     
        public static void saveAccounts(List<Account> accounts)
        {

            #region validation
            if (accounts == null) { return; }
            #endregion

            #region saveToFile
            try
            {
                File.WriteAllText(@"Accounts.json", JsonConvert.SerializeObject(accounts));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        /// <summary>
        ///This function used to retrive customers data from a jason  "Customers" located at the default directory  by deserialzie the  jason object
        /// </summary>
        /// <returns>
        /// IF FILE WAS FOUND AND IT COUNTAINS DATA : return var of Customer list
        /// IF FILE WAS NOT FOUND OR HAS NO DATA: return an empty list of customer
        /// </returns>

        public static List<Customer> getAllCustomers()
        {
            #region retrive and validation data
            try
            {
                string json = File.ReadAllText(@"Customers.json");
                if (json != "")
                {
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
                    return customers;
                }
                return new List<Customer>();
            }

            catch { return new List<Customer>(); }
            #endregion
        }


        /// <summary>
        ///This function used to retrive accounts data from a jason  "Accounts" located at the default directory by deserialzie the jsom object
        /// </summary>
        /// <returns>
        /// IF FILE WAS FOUND AND IT COUNTAINS DATA : return var of accounts list
        /// IF FILE WAS NOT FOUND OR HAS NO DATA: return an empty list of accounts
        /// </returns>
        public static List<Account> getAllAccounts()
        {
            #region retrive and validation data

            try
            {
                string json = File.ReadAllText(@"Accounts.json");
                if (json != null && json != "")
                {

                    var accounts = JsonConvert.DeserializeObject<List<Account>>(json);
                    return accounts;
                }

                else return new List<Account>();
            }
            catch
            {
                return new List<Account>();
            }
            #endregion
        }

    }
}
