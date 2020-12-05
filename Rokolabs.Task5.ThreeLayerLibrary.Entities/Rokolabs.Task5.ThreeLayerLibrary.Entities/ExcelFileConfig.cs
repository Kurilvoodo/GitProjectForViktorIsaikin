using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class ExcelFileConfig
    {
        public MemoryStream memoryStream { get; set; }
        public SpreadsheetDocument exel { get; set; }
        public WorkbookPart workBookPart { get; set; }
        public WorksheetPart worksheetPart { get; set; }
        public Workbook workBook { get; set; }
        public FileVersion fileVersion { get; set; }
        public Worksheet workSheet { get; set; }
        public SheetData sheetData { get; set; }

        public ExcelFileConfig()
        {
            memoryStream = new MemoryStream();
            exel = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook);
            workBookPart = exel.AddWorkbookPart();
            worksheetPart = workBookPart.AddNewPart<WorksheetPart>();
            workBook = new Workbook();
            fileVersion = new FileVersion();
            fileVersion.ApplicationName = "Microsoft Office Excel";
            workSheet = new Worksheet();
            sheetData = new SheetData();
        }

        public MemoryStream FinishSheetGenerating(string sheetName)
        {
            workSheet.Append(sheetData);
            worksheetPart.Worksheet = workSheet;
            worksheetPart.Worksheet.Save();
            Sheets sheets = new Sheets();
            Sheet sheet = new Sheet();
            sheet.Name = sheetName;
            sheet.SheetId = 1;
            sheet.Id = workBookPart.GetIdOfPart(worksheetPart);
            sheets.Append(sheet);
            workBook.Append(fileVersion);
            workBook.Append(sheets);

            exel.WorkbookPart.Workbook = workBook;
            exel.WorkbookPart.Workbook.Save();
            exel.Close();
            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}