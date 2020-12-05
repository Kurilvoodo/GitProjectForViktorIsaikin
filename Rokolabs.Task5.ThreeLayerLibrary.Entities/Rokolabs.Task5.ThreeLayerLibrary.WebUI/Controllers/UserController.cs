using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private IUserLogic _userLogic;
        private IRoleLogic _roleLogic = DependencyResolver.Current.GetService<IRoleLogic>();
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: User

        public ActionResult Index()
        {
            try
            {
                return View(_mapper.Map<IEnumerable<ReadUserVM>>(_userLogic.GetAllUsers()));
            }
            catch (Exception ex)
            {
                Logger.Error("Somehting goes wrong with Index method of UserController:  " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        [AllowAnonymous]
        public int GetUserIdByUsername(string username)
        {
            return _userLogic.GetUserIdByUsername(username);
        }

        [AllowAnonymous]
        public ReadUserVM GetUserById(int id)
        {
            return _mapper.Map<ReadUserVM>(_userLogic.GetUserById(id));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            if (User.Identity.Name == GetUserById(id).Username)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                EditUserVM editUserVM = _mapper.Map<EditUserVM>(_userLogic.GetUserById(id));
                editUserVM.Role = _roleLogic.GetUserRoleById(id);
                return View(editUserVM);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserVM editUserVM)
        {
            try
            {
                _userLogic.GiveRoleToUser(editUserVM.Id, editUserVM.RoleId);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult ShowDropdownMultiSelect()
        {
            
            ViewBag.RoleId = new MultiSelectList(_roleLogic.GetAllRoles(), "Id", "RoleName");
            return PartialView("~/Views/PartialViews/DisplayModelView/_DisplayRolesDropDownMultiSelect.cshtml");
        }
    }
}