namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class LibraryError
    {
        #region Fields and properties

        public string Message { get; set; }
        public object ProblemField { get; set; }

        #endregion Fields and properties

        #region Overrided methods

        public override bool Equals(object obj)
        {
            if (obj is LibraryError error)
            {
                return (error.Message?.Equals(this.Message) ?? null == this.Message) &&
                    (error.ProblemField?.Equals(this.ProblemField) ?? null == this.ProblemField);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion Overrided methods
    }
}