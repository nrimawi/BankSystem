

namespace BankSystem.Models
{
    public class Role
    {
        #region fields
        public int roleId { get; }
        public string roleName { get; set; }

        public bool active;

        private static int id;

        #endregion

        #region constructor
        public Role(string name)
        {
            this.active = true;
            this.roleName = name;
            this.roleId = id++;

        }

        public Role()
        {
        }
        #endregion

    }
}
