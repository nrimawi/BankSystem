

using Common;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class TransactionRepo : ITransaction
    {
        public void deleteTransaction(Guid id)
        {
            throw new NotImplementedException();
        }

        public TransactionData getTransactionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void saveTransaction(TransactionData transaction)
        {
            throw new NotImplementedException();

        }

        public void updateTransaction(TransactionData  transaction)
        {
            throw new NotImplementedException();
        }
    }
}
