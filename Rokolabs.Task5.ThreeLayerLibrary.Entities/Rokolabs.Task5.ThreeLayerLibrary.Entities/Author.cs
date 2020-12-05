namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class Author
    {
        #region Fields and propeties

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion Fields and propeties

        #region Bases Overrides

        public override bool Equals(object obj)
        {
            if (obj is Author author)
            {
                if (Id != default)
                {
                    return this.Id == author.Id && this.FirstName == author.FirstName && this.LastName == author.LastName;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        #endregion Bases Overrides
    }
}