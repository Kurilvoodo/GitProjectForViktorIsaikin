using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.NewspaperIssues;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Controllers
{
    public class NewspaperIssueController : Controller
    {
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();
        private INewspaperIssueLogic _newspaperIssueLogic;

        public NewspaperIssueController(INewspaperIssueLogic newspaperIssueLogic)
        {
            _newspaperIssueLogic = newspaperIssueLogic;
        }

        [AllowAnonymous]
        public ActionResult IssuesOfNewspaper(int newspaperId)
        {
            try
            {
                return View("~/Views/NewspaperIssue/IssuesOfNewspaper.cshtml",
           _mapper.Map<IEnumerable<ReadNewspaperIssueVM>>(_newspaperIssueLogic.GetAllNewspaperIssuesByNewspaperId(newspaperId)));
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at IssueOfNewspaper method for Newspaper Issue Controller: " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // GET: NewspaperIssue/Details/5

        public ActionResult Details(int issueId)
        {
            try
            {
                return View(_mapper.Map<ReadNewspaperIssueVM>(_newspaperIssueLogic.GetNewspaperIssueById(issueId)));
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at Details method for Newspaper Issue Controller: " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // GET: NewspaperIssue/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewspaperIssue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateNewspaperIssueVM newspaperIssue)
        {
            try
            {
                _newspaperIssueLogic.AddNewspaperIssue(_mapper.Map<NewspaperIssue>(newspaperIssue), newspaperIssue.NewspaperId);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at Create method in Newspaper Issue Controller: " + ex.Message);
                return View();
            }
        }

        // GET: NewspaperIssue/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            try
            {
                return View(_mapper.Map<EditNewspaperIssueVM>(_newspaperIssueLogic.GetNewspaperIssueById(id)));
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at Edit method at NewspaperIssue Controller: " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // POST: NewspaperIssue/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditNewspaperIssueVM editNewspaperIssueVM)
        {
            try
            {
                
                _newspaperIssueLogic.EditNewspaperIssue(_mapper.Map<NewspaperIssue>(editNewspaperIssueVM));
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at Edit Method at newspaperIssue Controller: " + ex.Message);
                return View();
            }
        }

        // GET: NewspaperIssue/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                return View(_mapper.Map<ReadNewspaperIssueVM>(_newspaperIssueLogic.GetNewspaperIssueById(id)));
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong with Delete method at Newspaper issue Controller: " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // POST: NewspaperIssue/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(ReadNewspaperIssueVM readNewspaperIssueVM)
        {
            try
            {
                _newspaperIssueLogic.DeleteNewspaperIssue(readNewspaperIssueVM.Id);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong with Delete Method at Newspaper Issue Controller: " + ex.Message);
                return View();
            }
        }
    }
}