using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddUser(User user)
        {
            return _userDao.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userDao.DeleteUser(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDao.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public int GetUserIdByUsername(string username)
        {
            return _userDao.GetUserIdByUsername(username);
        }

        public string GetUserRole(int id)
        {
            return _userDao.GetUserRole(id);
        }

        public void GiveRoleToUser(int userId, int WebsiteRoleId)
        {
            _userDao.GiveRoleToUser(userId, WebsiteRoleId);
        }

        public bool Login(User user)
        {
            return _userDao.Login(user);
        }
    }
}