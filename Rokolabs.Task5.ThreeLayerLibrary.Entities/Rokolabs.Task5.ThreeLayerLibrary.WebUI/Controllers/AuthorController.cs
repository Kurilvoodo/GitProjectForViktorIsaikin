using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Authors;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorLogic _authorLogic;

        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public AuthorController(IAuthorLogic authorLogic)
        {
            _authorLogic = authorLogic;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateAuthorVM author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authorLogic.AddAuthor(_mapper.Map<Author>(author));
                    return ShowDropdownMultiSelect();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
            else
            {
                Logger.Info("Model State is not Valid for Author Creation.");
            }
            return View(author);
        }

        [ChildActionOnly]
        public ActionResult ShowDropdownMultiSelect()
        {
            ViewBag.IdAuthor = new MultiSelectList(_mapper.Map<IEnumerable<ReadAuthorVM>>(_authorLogic.GetAllAuthors()), "Id", "FullName");
            return PartialView("~/Views/PartialViews/DisplayModelView/_DisplayAuthorsDropdownMultiSelect.cshtml");
        }

        [HttpPost]
        public JsonResult GetAuthorsForSelecList(string searchText)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            return Json(_authorLogic.GetAuthorsBySearchTextForList(searchText));
        }

        [ChildActionOnly]
        public ActionResult ShowAjaxFormCreateAuthor()
        {
            return PartialView("~/Views/PartialViews/DisplayModelView/_DisplayAjaxCreateAuthor.cshtml");
        }
    }
}