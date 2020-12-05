using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rokolabs.Task5.ThreeLayerLibrary.BLL
{
    public class PrintEditionLogic : IPrintEditionLogic
    {
        private IPrintEditionDao _printEditionDao;
        private IAuthorDao _authorDao;

        public PrintEditionLogic(IPrintEditionDao printEditionDao, IAuthorDao authorDao)
        {
            _printEditionDao = printEditionDao;
            _authorDao = authorDao;
        }

        public MemoryStream DownloadTheCatalog()
        {
            List<PrintEdition> printEditions = _printEditionDao.DownloadTheCatalog().ToList();
            ExcelFileConfig exelFile = new ExcelFileConfig();
            for (int i = 0; i < printEditions.Count - 1; i++)
            {
                exelFile.sheetData.Append(RowParserer(printEditions[i], i));
            }
            return exelFile.FinishSheetGenerating("First Sheet of the Catalog");
        }

        private Row RowParserer(PrintEdition item, int index)
        {
            Row row = new Row() { RowIndex = (UInt32Value)(uint)index + 1 };
            if (item is Book)
            {
                Book bookItem = (Book)item;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (var author in _authorDao.GetAuthorByBookId(item.Id))
                {
                    string authorName = author.FirstName[0] + ". ";
                    sb.Append(authorName);
                    sb.Append(" ");
                    sb.Append(@author.LastName);
                    sb.Append(" ");
                }
                sb.Append(item.Title);
                sb.Append(" ");
                sb.Append(item.PublicationYear);
                sb.Append(" ");
                CellInclude(row, sb.ToString());
                CellInclude(row, bookItem.ISBN);
                CellInclude(row, bookItem.NumberOfPages.ToString());
            }
            if (item is Newspaper)
            {
                Newspaper newspaperItem = (Newspaper)item;
                CellInclude(row, newspaperItem.Title + " " + newspaperItem.currentNewspaperIssue.ToString());
                CellInclude(row, newspaperItem.ISSN);
                CellInclude(row, newspaperItem.currentNewspaperIssue.NumberOfPages.ToString());
            }
            if (item is Patent)
            {
                Patent patentItem = (Patent)item;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(patentItem.Title);
                sb.Append(" ");
                sb.Append("from (");
                sb.Append(patentItem.PublicationYear);
                sb.Append(") ");
                CellInclude(row, sb.ToString());
                CellInclude(row, patentItem.RegistrationNumber.ToString());
                CellInclude(row, patentItem.NumberOfPages.ToString());
            }
            return row;
        }

        private void CellInclude(Row r, string item)
        {
            Cell cell = new Cell();
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue(item);
            r.Append(cell);
        }

        public IEnumerable<PrintEdition> GetAllPrintEditions()
        {
            return _printEditionDao.GetAllPrintEditions();
        }

        public IEnumerable<PrintEdition> GetAllPrintEditionsSortedByPublicationYear()
        {
            return _printEditionDao.GetAllPrintEditionsSortedByPublicationYear();
        }

        public IEnumerable<PrintEdition> GetAllPrintEditionsSortedByPublicationYearDescending()
        {
            return _printEditionDao.GetAllPrintEditionsSortedByPublicationYearDescending();
        }

        public PageResult<PrintEdition> SortedPaging(PageOption pageOption, string partAuthorName, string sortString, string partTitle)
        {
            return _printEditionDao.SortedPaging(pageOption, partAuthorName, sortString, partTitle);
        }
    }
}