using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Newspapers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Controllers
{
    public class NewspaperController : Controller
    {
        private INewspaperLogic _newspaperLogic;
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public NewspaperController(INewspaperLogic newspaperLogic)
        {
            _newspaperLogic = newspaperLogic;
        }

        [ChildActionOnly]
        public ActionResult ShowDropdownMultiSelect()
        {
            try
            {
                ViewBag.NewspaperId = new MultiSelectList(_mapper.Map<IEnumerable<ReadNewspaperVM>>(_newspaperLogic.GetAllNewspapers()), "Id", "Title");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return PartialView("~/Views/PartialViews/DisplayModelView/_DisplayNewspaperDropdownMultiSelect.cshtml");
        }

        // GET: Newspaper/Details/5
        public ActionResult Details(int id)
        {
            ReadNewspaperVM readNewspaperVM = null;
            try
            {
                readNewspaperVM = _mapper.Map<ReadNewspaperVM>(_newspaperLogic.GetNewspaperById(id));
                return View(readNewspaperVM);
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at Details method for Newspaper " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // GET: Newspaper/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Newspaper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateNewspaperVM newspaper)
        {
            try
            {
                _newspaperLogic.AddNewspaper(_mapper.Map<Newspaper>(newspaper));
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong with Creation Method in NewspaperController: " + ex.Message);
                return View();
            }
        }

        // GET: Newspaper/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ReadNewspaperVM readNewspaperVM = null;
            try
            {
                readNewspaperVM = _mapper.Map<ReadNewspaperVM>(_newspaperLogic.GetNewspaperById(id));
                return View(readNewspaperVM);
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at Edit method of NewspaperController: " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // POST: Newspaper/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditNewspaperVM newspaper)
        {
            try
            {
                _newspaperLogic.EditNewspaper(_mapper.Map<Newspaper>(newspaper));
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong with Editing at NewspaperController: " + ex.Message);
                return View();
            }
        }

        // GET: Newspaper/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ReadNewspaperVM readNewspaperVM = null;
            try
            {
                readNewspaperVM = _mapper.Map<ReadNewspaperVM>(_newspaperLogic.GetNewspaperById(id));
                return View(readNewspaperVM);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return View("Index", "PrintEdition");
            }
        }

        // POST: Newspaper/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReadNewspaperVM readNewspaperVM)
        {
            try
            {
                _newspaperLogic.DeleteNewspaperById(readNewspaperVM.Id);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at Delet method at NewsppaerController " + ex.Message);
                return View();
            }
        }
    }
}