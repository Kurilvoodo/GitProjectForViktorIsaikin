using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Newspapers
{
    public class ReadNewspaperVM : ReadBasePrintEditionVM
    {
        public string PlaceOfPublication { get; set; }
        public string PublishingHouse { get; set; }
        public string ISSN { get; set; }
    }
}