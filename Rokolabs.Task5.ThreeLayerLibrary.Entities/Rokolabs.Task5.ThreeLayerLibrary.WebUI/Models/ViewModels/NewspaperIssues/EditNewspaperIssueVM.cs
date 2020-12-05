using System;
using System.ComponentModel.DataAnnotations;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.NewspaperIssues
{
    public class EditNewspaperIssueVM
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int? ReleaseNumber { get; set; }

        public int NumberOfPages { get; set; }

        public int NewspaperId { get; set; }
    }
}