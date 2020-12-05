using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Books
{
    public class EditBookVM : EditBasePrintEditionVM
    {
        public string PlaceOfPublication { get; set; }

        public string PublishingHouse { get; set; }
        public int IdAuthor { get; set; }

        public string ISBN { get; set; }

        public int NumberOfPages { get; set; }
        public List<int> AuthorsId { get; set; } = new List<int>();
    }
}