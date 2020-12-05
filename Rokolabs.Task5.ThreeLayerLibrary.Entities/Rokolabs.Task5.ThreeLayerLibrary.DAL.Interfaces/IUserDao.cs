using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces
{
    public interface IUserDao
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