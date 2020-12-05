using System.ComponentModel.DataAnnotations;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions
{
    public class CreateBasePrintEditionVM
    {
        [Required]
        public int PublicationYear { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Annotation { get; set; }
    }
}