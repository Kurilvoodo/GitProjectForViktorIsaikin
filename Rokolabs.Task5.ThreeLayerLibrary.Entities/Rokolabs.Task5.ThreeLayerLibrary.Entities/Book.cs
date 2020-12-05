using System;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class Book : PrintEdition
    {
        #region Fields and properties

        public List<int> AuthorsId { get; set; }

        public string PlaceOfPublication { get; set; }
        public string PublishingHouse { get; set; }
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }

        #endregion Fields and properties

        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                if (!string.IsNullOrWhiteSpace(this.ISBN) && !string.IsNullOrWhiteSpace(book.ISBN))
                {
                    return book.ISBN == this.ISBN;
                }
                return this.AuthorsId.Equals(book.AuthorsId) && this.Title == book.Title && this.PublicationYear == book.PublicationYear;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Title:{Title} Publication Year: {PublicationYear} Number of pages:{NumberOfPages} " + Environment.NewLine +
                $"Place of publication: {PlaceOfPublication} Publishing House:{PublishingHouse}" + Environment.NewLine +
                $"{ISBN}";
        }
    }
}