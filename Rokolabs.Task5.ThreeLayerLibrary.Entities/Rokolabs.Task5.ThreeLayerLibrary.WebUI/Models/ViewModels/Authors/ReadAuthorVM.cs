namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Authors
{
    public class ReadAuthorVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}