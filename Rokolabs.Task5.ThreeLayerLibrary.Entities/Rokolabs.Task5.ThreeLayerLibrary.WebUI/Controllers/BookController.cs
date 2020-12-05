using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Books;
using System;
using System.Web.Mvc;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBookLogic _bookLogic;
        private IAuthorLogic authorLogic = DependencyResolver.Current.GetService<IAuthorLogic>();
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public BookController(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }

        // GET: Book/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            try
            {
                return View(_mapper.Map<ReadBookVM>(_bookLogic.GetBookById(id)));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);

                return RedirectToAction("Index", "PrintEdition"); 
            }
        }

        // GET: Book/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookVM book)
        {
            try
            {
                _bookLogic.AddBook(_mapper.Map<Book>(book), book.IdAuthor);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Info("Something go wrong in Creating of Book page " + ex.Message);
                return View();
            }
        }

        // GET: Book/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            try
            {
                return View(_mapper.Map<EditBookVM>(_bookLogic.GetBookById(id)));
            }
            catch (Exception ex)
            {
                Logger.Info("Something goes wrong at Book Editing page " + ex.Message);
                return RedirectToAction("Index", "PrintEdition"); //TODO: To 404 or something
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBookVM book)
        {
            try
            {
                _bookLogic.EditBook(_mapper.Map<Book>(book), book.IdAuthor);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch
            {
                Logger.Info("Something goes wrong ");
                return RedirectToAction("Index", "PrintEdition");
            }
        }

        // GET: Book/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                return View(_mapper.Map<ReadBookVM>(_bookLogic.GetBookById(id)));
            }
            catch (Exception ex)
            {
                Logger.Error("Can't reach Delete page for Book: " + ex.Message);
                return RedirectToAction("Details", "Book", id);
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReadBookVM readBookVM)
        {
            try
            {
                _bookLogic.DeleteBookById(readBookVM.Id);
                return RedirectToAction("Index", "PrintEdition");
            }
            catch (Exception ex)
            {
                Logger.Error("Something goes wrong in Delete Book method" + ex.Message);
                return View();
            }
        }
    }
}