using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities.ValidationClasses
{
    public class NewspaperValidation
    {
        #region Fields and properties

        private bool _iSSNIsValid;
        private string _iSSN;

        public GeneralValidation NewspaperGeneralValidation;
        public List<string> newspaperValidationExceptions = new List<string>();

        public bool ISSNIsValid { get => _iSSNIsValid; set => _iSSNIsValid = value; }
        public string ISSN { get => _iSSN; }

        #endregion Fields and properties

        public NewspaperValidation(Newspaper newspaper)
        {
            NewspaperGeneralValidation = new GeneralValidation(newspaper.PlaceOfPublication,
                                                            newspaper.PublishingHouse,
                                                            newspaper.Title,
                                                            newspaper.Annotation,
                                                            newspaper.PublicationYear);
            _iSSN = newspaper.ISSN;
        }

        public void ExeciteValidation()
        {
            NewspaperGeneralValidation.ExecuteValidation();
            ISSNIsValid = ISSNValidation();
        }

        public bool ISSNValidation()
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(ISSN))
            {
                var regex = new Regex(@"^ISSN [0-9]{4}-[0-9]{4}$");
                if (!regex.IsMatch(ISSN))
                {
                    result = false;
                    newspaperValidationExceptions.Add("Invalid format of ISSN (FORMAT: XXXX-XXXX, where X is digit)");
                }
            }
            return result;
        }

        public bool ISSNValidation(string iSSN)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(iSSN))
            {
                var regex = new Regex(@"^ISSN [0-9]{4}-[0-9]{4}$");
                if (!regex.IsMatch(iSSN))
                {
                    result = false;
                    newspaperValidationExceptions.Add("Invalid format of ISSN (FORMAT: XXXX-XXXX, where X is digit)");
                }
            }
            return result;
        }
    }
}