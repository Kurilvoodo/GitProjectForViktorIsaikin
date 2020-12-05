using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces
{
    public interface IPrintEditionDao
    {
        IEnumerable<PrintEdition> GetAllPrintEditions();

        IEnumerable<PrintEdition> GetAllPrintEditionsSortedByPublicationYear();

        IEnumerable<PrintEdition> GetAllPrintEditionsSortedByPublicationYearDescending();
        PageResult<PrintEdition> SortedPaging(PageOption pageOption, string partAuthorName, string sortString, string partTitle);
        IEnumerable<PrintEdition> DownloadTheCatalog();
    }
}