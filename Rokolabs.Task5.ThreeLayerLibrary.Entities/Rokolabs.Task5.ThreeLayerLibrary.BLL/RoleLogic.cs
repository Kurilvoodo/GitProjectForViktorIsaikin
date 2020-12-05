using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL
{
    public class RoleLogic : IRoleLogic
    {
        private IRoleDao _roleDao;

        public RoleLogic(IRoleDao roleDao)
        {
            _roleDao = roleDao;
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            return _roleDao.GetAllRoles();
        }

        public string GetUserRoleById(int id)
        {
            return _roleDao.GetUserRoleById(id);
        }
    }
}