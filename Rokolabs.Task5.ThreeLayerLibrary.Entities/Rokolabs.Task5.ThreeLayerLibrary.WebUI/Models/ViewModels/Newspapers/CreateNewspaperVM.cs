using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions;
using System.ComponentModel.DataAnnotations;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Newspapers
{
    public class CreateNewspaperVM : CreateBasePrintEditionVM
    {
        [Required]
        [MaxLength(200)]
        public string PlaceOfPublication { get; set; }

        [Required]
        [MaxLength(300)]
        public string PublishingHouse { get; set; }

        [MaxLength(14)]
        [MinLength(14)]
        public string ISSN { get; set; }
    }
}