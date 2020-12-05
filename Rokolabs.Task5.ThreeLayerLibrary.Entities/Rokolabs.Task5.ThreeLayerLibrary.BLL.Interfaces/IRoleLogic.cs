using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces
{
    public interface IRoleLogic
    {
        IEnumerable<Roles> GetAllRoles();

        string GetUserRoleById(int id);
    }
}