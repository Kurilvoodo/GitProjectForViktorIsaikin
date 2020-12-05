using System.ComponentModel.DataAnnotations;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Login
{
    public class SignInLoginVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}