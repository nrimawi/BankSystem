

using Common;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserRepo : IUser
    {
        public void deleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

  
        public UserData getUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void saveUser(UserData user)
        {
            throw new NotImplementedException();

        }

        public void updateUser(UserData  user)
        {
            throw new NotImplementedException();
        }
    }
}
