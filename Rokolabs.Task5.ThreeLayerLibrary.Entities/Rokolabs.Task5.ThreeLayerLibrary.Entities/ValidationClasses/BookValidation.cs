using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities.ValidationClasses
{
    public class BookValidation
    {
        #region Fields and properties

        private bool _iSBNIsValid;
        private Book _book;
        public GeneralValidation BookGeneralValidation { get; set; }

        public bool ISBNIsValid { get => _iSBNIsValid; set => _iSBNIsValid = value; }

        public List<string> bookValidationExceptions = new List<string>();

        #endregion Fields and properties

        public BookValidation(Book book)
        {
            _book = book;
            BookGeneralValidation = new GeneralValidation(book.PlaceOfPublication,
                                                            book.PublishingHouse,
                                                            book.Title,
                                                            book.Annotation,
                                                            book.PublicationYear);
        }

        public void ExecuteBookValidation()
        {
            BookGeneralValidation.ExecuteValidation();
            ISBNIsValid = ISBNValidation();
        }

        public bool ISBNValidation()
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(_book.ISBN))
            {
                if (_book.ISBN.Length != 18)
                {
                    result = false;
                    bookValidationExceptions.Add("ISBN Must be equal to 19 symbols (ISBN prefix, 10 digit and 4 hyphen)");
                }
                else
                {
                    var regex = new Regex(@"^ISBN ([0-7]|([8][0-9])|([9][0-4])|([9][5-8][0-9])|([9][9][0-3])|([9]{2}[4-8][0-9])|([9]{3}[0-9][0-9]))-([0-9]{1,7})-([0-9]{1,7})-([0-9]|X)$");
                    if (!regex.IsMatch(_book.ISBN))
                    {
                        result = false;
                        bookValidationExceptions.Add("Incerroct ISBN");
                    }
                }
            }
            return result;
        }

        public bool ISBNValidation(string iSBN)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(iSBN))
            {
                if (iSBN.Length != 18)
                {
                    result = false;
                    bookValidationExceptions.Add("ISBN Must be equal to 19 symbols (ISBN prefix, 10 digit and 4 hyphen)");
                }
                else
                {
                    var regex = new Regex(@"^ISBN ([0-7]|([8][0-9])|([9][0-4])|([9][5-8][0-9])|([9][9][0-3])|([9]{2}[4-8][0-9])|([9]{3}[0-9][0-9]))-([0-9]{1,7})-([0-9]{1,7})-([0-9]|X)$");
                    if (!regex.IsMatch(iSBN))
                    {
                        result = false;
                        bookValidationExceptions.Add("Incerroct ISBN");
                    }
                }
            }
            return result;
        }
    }
}