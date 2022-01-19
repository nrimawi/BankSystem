

using Common;
using DAL;

namespace Business
{
    class BRole : IRole
    {
        public void deleteRole(Guid id)
        {
            RoleRepo roleRepo = new RoleRepo();
            roleRepo.deleteRole(id);
        }

        public RoleData getRoleById(Guid id)
        {
            RoleRepo roleRepo = new RoleRepo();
            return roleRepo.getRoleById(id);

        }

        public void saveRole(RoleData role)
        {
            RoleRepo roleRepo = new RoleRepo();
            roleRepo.saveRole(role);
        }

        public void updateRole(RoleData role)
        {
            RoleRepo roleRepo = new RoleRepo();
            roleRepo.updateRole(role);

        }
    }
}
