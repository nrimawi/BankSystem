using BankSystem.Models;
using Newtonsoft.Json;

namespace BankSystem.DA
{
    public class DataBaseConnections
    {

        /// <summary>
        /// This function used to save the customers data to a jason named Customers located at the default directory by serializing the data
        /// </summary>
        /// <param name="customers">customers data list </param>
        public static void saveCustomers(List<Customer> customers)
        {
            #region validation
            if (customers == null) { return; }
            #endregion

            #region saveToFile
            try
            {
                File.WriteAllText(@"Customers.json", JsonConvert.SerializeObject(customers));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        /// <summary>
        /// This function used to save the accounts data to a jason "Accounts" located at the default directory  by serializing the data
        /// </summary>
        /// <param name="accounts">accounts data list </param>
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
