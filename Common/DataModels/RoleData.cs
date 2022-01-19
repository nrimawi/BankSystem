

namespace Common
{
    public class RoleData
    {
        #region fields
        public Guid roleId { get; }
        public string roleName { get; set; }

        public bool active;

        #endregion

        #region constructor

        public RoleData(Guid roleId, string roleName)
        {
            this.roleId = roleId;
            this.roleName = roleName;
        }

        public RoleData()
        {
        }
        #endregion

    }
}
