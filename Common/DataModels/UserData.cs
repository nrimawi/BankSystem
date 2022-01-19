

namespace Common
{
    public class UserData
    {

        #region fields
        public bool active { get; set; }
        public Guid userId { get; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userEmail { get; set; }
        public int userAge { get; set; }
        public int salary { get; set; }
        public int roleID;

        #endregion

        #region constructor

        public UserData(Guid userId, string userName, string userPassword, string userEmail, int userAge, int salary, int roleID)
        {
            this.userId = userId;
            this.userName = userName;
            this.userPassword = userPassword;
            this.userEmail = userEmail;
            this.userAge = userAge;
            this.salary = salary;
            this.roleID = roleID;
        }

        public UserData()
        {
        }

        #endregion

    }
}
