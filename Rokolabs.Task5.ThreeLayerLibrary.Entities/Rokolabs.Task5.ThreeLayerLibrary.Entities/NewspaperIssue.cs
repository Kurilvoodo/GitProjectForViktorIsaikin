using System;
using System.Text;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class NewspaperIssue
    {
        public int NumberOfPages { get; set; }
        public int? ReleaseNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Id { get; set; }
        public int NewspaperId { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (ReleaseNumber != null)
            {
                sb.Append(" ");
                sb.Append(ReleaseNumber);
            }
            sb.Append(" ");
            sb.Append(ReleaseDate);
            sb.Append(" ");
            return sb.ToString();
        }
    }
}