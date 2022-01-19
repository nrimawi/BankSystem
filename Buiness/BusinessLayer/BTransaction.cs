

using Common;
using DAL;

namespace Business
{
    class BTransaction : ITransaction
    {
        public void deleteTransaction(Guid id)
        {
            TransactionRepo transRepo = new TransactionRepo();
            transRepo.deleteTransaction(id);
        }

        public TransactionData getTransactionById(Guid id)
        {
            TransactionRepo transRepo = new TransactionRepo();
            return transRepo.getTransactionById(id);
        }

        public void saveTransaction(TransactionData transaction)
        {
            TransactionRepo transRepo = new TransactionRepo();
            transRepo.saveTransaction(transaction);
        }

        public void updateTransaction(TransactionData transactionData)
        {
            TransactionRepo transRepo = new TransactionRepo();
            transRepo.updateTransaction(transactionData);
        }
    }
}
