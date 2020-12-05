using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Patents;
using System;
using System.Web.Mvc;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Controllers
{
    public class PatentController : Controller
    {
        // GET: Patent
        private IPatentLogic _patentLogic;

        private IAuthorLogic authorLogic = DependencyResolver.Current.GetService<IAuthorLogic>();
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public PatentController(IPatentLogic patentLogic)
        {
            _patentLogic = patentLogic;
        }

        // GET: Patent/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            try
            {
                return View(_mapper.Map<ReadPatentVM>(_patentLogic.GetPatentById(id)));
            }
            catch (Exception ex)
            {
                Logger.Error("Somehting goes wrong at Details  GET Method at Patent Controller: " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // GET: Patent/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreatePatentVM patent)
        {
            try
            {
                _patentLogic.AddPatent(_mapper.Map<Patent>(patent), patent.IdAuthor);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong at Create POST method at Patent Controller: " + ex.Message);
                return View();
            }
        }

        // GET: Patent/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Authors = authorLogic.GetAuthorsByIdForListForPatent(id);
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong with ViewBag.Authors and it's logic at GET Edit method at PatentController:  " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
            try
            {
                return View(_mapper.Map<EditPatentVM>(_patentLogic.GetPatentById(id)));
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong with Edit GETMethod at PatentController: " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // POST: Patent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditPatentVM editPatentVM)
        {
            try
            {
                _patentLogic.EditPatent(_mapper.Map<Patent>(editPatentVM), editPatentVM.IdAuthor);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong with POST Edit method at PatentController: " + ex.Message);
                return View();
            }
        }

        // GET: Patent/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                return View(_mapper.Map<ReadPatentVM>(_patentLogic.GetPatentById(id)));
            }
            catch (Exception ex)
            {
                Logger.Error("Somehtong goes wrong with GET Delete method at PatentController: " + ex.Message);
                return RedirectToAction("Index", "PrintEdtion");
            }
        }

        // POST: Patent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(ReadPatentVM readPatentVM)
        {
            try
            {
                _patentLogic.DeletePatentById(readPatentVM.Id);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Somehting goes wrong with POST Delete Method at PatentController: " + ex.Message);
                return View();
            }
        }
    }
}