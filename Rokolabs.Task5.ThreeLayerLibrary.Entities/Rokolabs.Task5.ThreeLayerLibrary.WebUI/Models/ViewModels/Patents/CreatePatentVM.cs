using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Patents
{
    public class CreatePatentVM : CreateBasePrintEditionVM
    {
        [Required]
        [MaxLength(200)]
        public string Country { get; set; }

        [Required]
        public int RegistrationNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfApplication { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Required]
        public int IdAuthor { get; set; }
    }
}