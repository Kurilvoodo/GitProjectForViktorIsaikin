using System;
using System.ComponentModel.DataAnnotations;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.NewspaperIssues
{
    public class CreateNewspaperIssueVM
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int? ReleaseNumber { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        [Required]
        public int NewspaperId { get; set; }
    }
}