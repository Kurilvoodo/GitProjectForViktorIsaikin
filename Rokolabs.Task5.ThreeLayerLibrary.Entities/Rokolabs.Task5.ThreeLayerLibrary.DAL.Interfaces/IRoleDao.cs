using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces
{
    public interface IRoleDao
    {
        IEnumerable<Roles> GetAllRoles();

        string GetUserRoleById(int id);
    }
}