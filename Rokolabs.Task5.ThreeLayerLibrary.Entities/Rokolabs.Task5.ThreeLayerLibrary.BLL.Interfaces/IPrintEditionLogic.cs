using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.IO;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces
{
    public interface IPrintEditionLogic
    {
        IEnumerable<PrintEdition> GetAllPrintEditions();

        IEnumerable<PrintEdition> GetAllPrintEditionsSortedByPublicationYear();

        IEnumerable<PrintEdition> GetAllPrintEditionsSortedByPublicationYearDescending();
        PageResult<PrintEdition> SortedPaging(PageOption pageOption, string partAuthorName, string sortString, string partTitle);

        MemoryStream DownloadTheCatalog();
    }
}