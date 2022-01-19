using Common;
using MySql.Data.MySqlClient;

namespace DAL
{
   public class AccountRepo : IAccount
    {
        public void deleteAccount(AccountData account)
        {
            throw new NotImplementedException();
        }

        public AccountData getAccountById()
        {
            throw new NotImplementedException();
        }

        public void updateAccount(AccountData account)
        {
            throw new NotImplementedException();
        }

        public void saveAccount(AccountData account)
        {
            #region validation
            if (account == null) { return; }
            #endregion

            #region get database connection and validation
            DataBaseConnection dataBaseConnection = DataBaseConnection.Instance;
            var connection = dataBaseConnection.connection;

            #endregion


            using var query = new MySqlCommand();
            query.Connection = connection;
            string GUID = Guid.NewGuid().ToString();
            query.CommandText = $"INSERT INTO account VALUES(@accountIBAN,@accountType,@accountBalance,1)";
            query.Parameters.AddWithValue("@accountIBAN", account.accountIBAN.ToString());
            query.Parameters.AddWithValue("@accountType", account.accountType);
            query.Parameters.AddWithValue("@accountBalance", account.accountBalance);
            query.ExecuteNonQuery();
        }


    }
}
