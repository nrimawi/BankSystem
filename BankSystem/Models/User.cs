

namespace BankSystem.Models
{
    public class User
    {

        #region fields
        public bool active { get; set; }
        public Guid userId { get; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userEmail { get; set; }
        public int userAge { get; set; }

        public int roleID;
        #endregion

        #region constructor
        public User(string name, string email, int age, int role, string pass)
        {
            this.userId = Guid.NewGuid();
            this.userAge = age;
            this.userEmail = email;
            this.userName = name;
            this.active = true;
            this.roleID = role;
            this.userPassword = pass;

        }
        #endregion

    }
}
