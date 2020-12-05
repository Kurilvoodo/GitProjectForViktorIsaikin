namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class PrintEdition
    {
        #region Fields and properties

        public int Id { get; set; }
        public int PublicationYear { get; set; }
        public string Title { get; set; }
        public string Annotation { get; set; }

        #endregion Fields and properties

        public override string ToString()
        {
            return base.ToString();
        }
    }
}