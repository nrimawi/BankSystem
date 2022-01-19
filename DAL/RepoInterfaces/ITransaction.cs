using Common;
namespace DAL
{
     interface ITransaction
    {
        TransactionData getTransactionById(Guid id);
        void saveTransaction(TransactionData transaction);
        void deleteTransaction(Guid id);

        void updateTransaction(TransactionData transactionData); 

   
    }
}
