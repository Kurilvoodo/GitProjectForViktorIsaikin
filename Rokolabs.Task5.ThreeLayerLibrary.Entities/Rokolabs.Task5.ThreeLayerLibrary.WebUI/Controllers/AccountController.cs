using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Login;
using System;
using System.Web.Mvc;
using System.Web.Security;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserLogic _userLogic;
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public AccountController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: AccountControlller
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SignInLoginVM signInLoginVM)
        {
            if (ModelState.IsValid)
            {
                HashedLoginVM hashedLoginVM = new HashedLoginVM()
                {
                    Username = signInLoginVM.Username,
                    Password = Utils.HashUtils.ComputeHash(signInLoginVM.Password)
                };
                if (_userLogic.Login(_mapper.Map<User>(hashedLoginVM)))
                {
                    FormsAuthentication.SetAuthCookie(signInLoginVM.Username, true);

                    return RedirectToAction("Index", "PrintEdition");
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CreateLoginVM createLoginVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HashedLoginVM hashedLoginVM= new HashedLoginVM()
                    {
                        Username = createLoginVM.Username,
                        Password = Utils.HashUtils.ComputeHash(createLoginVM.Password)
                    };
                    
                    _userLogic.AddUser(_mapper.Map<User>(hashedLoginVM));
                    return RedirectToAction("Login", "Account");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "PrintEdition");
        }

        [AllowAnonymous]
        public ActionResult AccesIsDenied()
        {
            Logger.Info($"{User.Identity.Name} try to get acces to non-permissioend functional");
            return View();
        }

        [Authorize(Roles = "CommonUser")]
        public ActionResult SwitchAccount()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}