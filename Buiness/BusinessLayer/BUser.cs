

using Common;
using DAL;

namespace Business
{
    class BUser : IUser
    {
        public void deleteUser(Guid id)
        {
            UserRepo transRepo = new UserRepo();
            transRepo.deleteUser(id);
        }

        public UserData getUserById(Guid id)
        {
            UserRepo transRepo = new UserRepo();
            return transRepo.getUserById(id);
        }

        public void saveUser(UserData User)
        {
            UserRepo transRepo = new UserRepo();
            transRepo.saveUser(User);
        }

        public void updateUser(UserData UserData)
        {
            UserRepo transRepo = new UserRepo();
            transRepo.updateUser(UserData);
        }
    }
}
