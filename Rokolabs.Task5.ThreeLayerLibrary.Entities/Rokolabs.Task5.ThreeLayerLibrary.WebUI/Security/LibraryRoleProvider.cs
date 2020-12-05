using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Users;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Security
{
    public class LibraryRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public override bool IsUserInRole(string username, string roleName)
        {
            var _userLogic = DependencyResolver.Current.GetService<IUserLogic>();
            ReadUserVM readUserVM = _mapper.Map<ReadUserVM>(_userLogic.GetUserById(_userLogic.GetUserIdByUsername(username)));
            return readUserVM.Role == roleName;
        }

        public override string[] GetRolesForUser(string username)
        {
            var _userLogic = DependencyResolver.Current.GetService<IUserLogic>();

            ReadUserVM readUserVM = _mapper.Map<ReadUserVM>(_userLogic.GetUserById(_userLogic.GetUserIdByUsername(username)));
            readUserVM.Role = _userLogic.GetUserRole(readUserVM.Id);
            return new string[] { readUserVM.Role };
        }

        #region Not Implemented

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion Not Implemented
    }
}