
using Common;

namespace DAL
{
    public interface IAccount
    {
        AccountData getAccountById();
        void saveAccount(AccountData account);  

        void deleteAccount(AccountData account);
        void updateAccount (AccountData account);
    }
}
