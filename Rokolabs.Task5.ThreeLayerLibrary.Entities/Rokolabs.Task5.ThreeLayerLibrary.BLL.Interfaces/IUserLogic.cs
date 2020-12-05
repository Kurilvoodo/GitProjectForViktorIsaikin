using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces
{
    public interface IUserLogic
    {
        IEnumerable<User> GetAllUsers();

        int AddUser(User user);

        void DeleteUser(int userId);

        void GiveRoleToUser(int userId, int WebsiteRoleId);

        bool Login(User user);

        int GetUserIdByUsername(string username);

        User GetUserById(int id);

        string GetUserRole(int id);
    }
}