using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Books
{
    public class ReadBookVM : ReadBasePrintEditionVM
    {
        public string PlaceOfPublication { get; set; }

        public string PublishingHouse { get; set; }
        public int IdAuthor { get; set; }

        public string ISBN { get; set; }

        public int NumberOfPages { get; set; }
        public HashSet<int> AuthorsId { get; set; } = new HashSet<int>();
    }
}