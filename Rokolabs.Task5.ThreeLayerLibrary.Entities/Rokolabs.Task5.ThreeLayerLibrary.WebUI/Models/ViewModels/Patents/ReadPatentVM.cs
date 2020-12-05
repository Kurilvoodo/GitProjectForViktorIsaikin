using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions;
using System;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Patents
{
    public class ReadPatentVM : ReadBasePrintEditionVM
    {
        public string Country { get; set; }

        public int RegistrationNumber { get; set; }

        public DateTime? DateOfApplication { get; set; }

        public int NumberOfPages { get; set; }

        public DateTime PublicationDate { get; set; }

        public int IdAuthor { get; set; }
        public HashSet<int> AuthorsId { get; set; } = new HashSet<int>();
    }
}