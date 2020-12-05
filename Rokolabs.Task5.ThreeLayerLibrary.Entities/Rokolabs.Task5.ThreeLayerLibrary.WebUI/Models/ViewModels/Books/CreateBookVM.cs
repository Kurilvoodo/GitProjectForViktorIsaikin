using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions;
using System.ComponentModel.DataAnnotations;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Books
{
    public class CreateBookVM : CreateBasePrintEditionVM
    {
        [Required]
        [MaxLength(200)]
        public string PlaceOfPublication { get; set; }

        [Required]
        [MaxLength(300)]
        public string PublishingHouse { get; set; }

        public int IdAuthor { get; set; }

        [MaxLength(18)]
        [MinLength(18)]
        public string ISBN { get; set; }

        [Required]
        public int NumberOfPages { get; set; }
    }
}