namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class SelectListSerialization
    {
        public int id { get; set; }
        public string text { get; set; }

        public SelectListSerialization() : base()
        {
        }

        public SelectListSerialization(int id, string searchText)
        {
            this.id = id;
            text = searchText;
        }
    }
}