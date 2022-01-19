using Common;
namespace DAL
{
    public interface IRole
    {
        RoleData getRoleById(Guid id);
        void saveRole(RoleData role);
        void deleteRole(Guid id);

        void updateRole(RoleData role); 

   
    }
}
