

namespace BankSystem.Models
{
    public class Role
    {
        #region fields
        public Guid roleId { get; }
        public string roleName { get; set; }

        public bool active;

        #endregion

        #region constructor

        public Role(Guid roleId, string roleName)
        {
            this.roleId = roleId;
            this.roleName = roleName;
        }

        public Role()
        {
        }
        #endregion

    }
}
