

namespace BankSystem.Models
{
    public class Role
    {
        #region fields
        public int RoleId { get; }
        public string RoleName { get; set; }

        public bool active;

        private static int id;

        #endregion

        #region constructor
        public Role(string name)
        {
            this.active = true;
            this.RoleName = name;
            this.RoleId = id++;

        }

        public Role()
        {
        }
        #endregion

    }
}
