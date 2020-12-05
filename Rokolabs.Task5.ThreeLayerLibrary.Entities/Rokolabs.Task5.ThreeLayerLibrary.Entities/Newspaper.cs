using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class Newspaper : PrintEdition
    {
        #region Fields and properties

        public List<NewspaperIssue> NewspaperIssues = new List<NewspaperIssue>();
        public NewspaperIssue currentNewspaperIssue { get; set; }
        public string PlaceOfPublication { get; set; }
        public string PublishingHouse { get; set; }
        public string ISSN { get; set; }

        #endregion Fields and properties

        #region Bases Overrides

        public override bool Equals(object obj)
        {
            if (obj is Newspaper newspaper)
            {
                if (!string.IsNullOrWhiteSpace(this.ISSN) && !string.IsNullOrWhiteSpace(newspaper.ISSN))
                {
                    return this.ISSN == newspaper.ISSN;
                }
                return this.Title == newspaper.Title && this.PublishingHouse == newspaper.PublishingHouse && this.PublicationYear == newspaper.PublicationYear;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ToString(int i) 
        {
            return $"{Title} " + NewspaperIssues[i].ToString();
        }

        #endregion Bases Overrides
    }
}