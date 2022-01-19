
using Common;

namespace DAL
{
    public interface IUser
    {
        UserData getUserById(Guid id);
        void saveUser(UserData user);  

        void deleteUser(Guid id);
        void updateUser (UserData user);
    }
}

