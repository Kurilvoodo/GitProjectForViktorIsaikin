using System;
using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class Patent : PrintEdition
    {
        #region Fields and properties;

        public ISet<int> AuthorsId { get; set; }

        public string Country { get; set; }
        public int RegistrationNumber { get; set; }
        public DateTime? DateOfApplication { get; set; }
        public DateTime PublicationDate { get; set; }
        public int IdAuthor { get; set; }
        public int NumberOfPages { get; set; }

        #endregion Fields and properties;

        public override bool Equals(object obj)
        {
            if (obj is Patent patent)
            {
                return this.RegistrationNumber == patent.RegistrationNumber && this.Country == patent.Country;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Title:{Title} Publication Year: {PublicationYear} Number of pages: {NumberOfPages} " + Environment.NewLine +
                $"Publication Date: {PublicationDate} " + $"Date Of Application: {DateOfApplication} ";
        }
    }
}