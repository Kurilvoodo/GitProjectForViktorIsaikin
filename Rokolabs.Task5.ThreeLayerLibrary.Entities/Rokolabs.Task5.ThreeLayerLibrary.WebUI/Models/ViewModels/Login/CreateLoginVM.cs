using System.ComponentModel.DataAnnotations;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Login
{
    public class CreateLoginVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(3)]
        [MaxLength(50)]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(3)]
        [MaxLength(50)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}