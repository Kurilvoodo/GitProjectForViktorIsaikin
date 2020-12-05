using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System;
using System.Web.Mvc;
using Tools;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Controllers
{
    [AllowAnonymous]
    public class PrintEditionController : Controller
    {
        private IPrintEditionLogic _printEditionLogic;

        public PrintEditionController(IPrintEditionLogic printEditionLogic)
        {
            _printEditionLogic = printEditionLogic;
        }

        public ActionResult Index()
        {
            try
            {
                var _printEditionLogic = DependencyResolver.Current.GetService<IPrintEditionLogic>();
                return View(_printEditionLogic.GetAllPrintEditions());
            }
            catch (Exception ex)
            {
                Logger.Error("Somehting goes wrong with Index method of PrintEditionController: " + ex.Message);
                return RedirectToAction("Index", "PrintEdition");
            }
        }
        [HttpGet]
        public ActionResult SortedPaging(int pageNumber = 1, string partAuthorName = "", string sortString = "asc", string partTitle = "")
        {
            PageOption option = new PageOption()
            {
                Skip = 5 * (pageNumber - 1),
                Limit = 5
            };
            var printEditions = _printEditionLogic.SortedPaging(option, partAuthorName, sortString, partTitle);
            printEditions.PageSize = option.Limit;
            printEditions.PageNumber = pageNumber;
            return View(printEditions);
        }

        [AllowAnonymous]
        public FileResult DownloadTheCatalog()
        {
            var downloadStream =_printEditionLogic.DownloadTheCatalog(); // memoryStream
            return File(downloadStream, "application/xlsx", "Catalog.xlsx");
        }
        [ChildActionOnly]
        public ActionResult ShowLinksForAdmin()
        {
            return PartialView("~/Views/PartialViews/DisplayModelView/_DisplayLinksForAdmin.cshtml");
        }
    }
}