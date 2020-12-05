using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities.ValidationClasses
{
    public class PatentValidation
    {
        #region Fields and properties

        private bool _countryIsValid;
        private bool _registrationNumberIsValid;
        private bool _dateOfApplicationIsValid;
        private bool _publicationDateIsValid;
        private string _country;
        private int _registrationNumber;
        private DateTime? _dateOfApplication;
        private DateTime? _publicationDate;
        public GeneralValidation GeneralValidation { get; set; }
        public List<string> patentValidationExceptions = new List<string>();

        public bool CountryIsValid { get => _countryIsValid; set => _countryIsValid = value; }
        public bool RegistrationNumberIsValid { get => _registrationNumberIsValid; set => _registrationNumberIsValid = value; }
        public bool DateOfApplicationIsValid { get => _dateOfApplicationIsValid; set => _dateOfApplicationIsValid = value; }
        public bool PublicationDateIsValid { get => _publicationDateIsValid; set => _publicationDateIsValid = value; }

        #endregion Fields and properties

        public PatentValidation(Patent patent)
        {
            GeneralValidation = new GeneralValidation(patent.NumberOfPages,
                                                        patent.Title,
                                                        patent.Annotation,
                                                        patent.PublicationYear);

            _country = patent.Country;
            _registrationNumber = patent.RegistrationNumber;
            _dateOfApplication = patent.DateOfApplication;
            _publicationDate = patent.PublicationDate;
        }

        public void ExecutePatentValidation()
        {
            GeneralValidation.ExecutePatentGeneralValidation();
            CountryIsValid = CountryValidation();
            RegistrationNumberIsValid = RegistrationNumberValidation();
            DateOfApplicationIsValid = DateOfApplicationValidation();
            PublicationDateIsValid = PublicationDateValidation();
        }

        public bool CountryValidation()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(_country))
            {
                result = false;
                patentValidationExceptions.Add("Country can't be empty");
            }
            else if (_country.Length > 200)
            {
                result = false;
                patentValidationExceptions.Add("Country length cannot be more than 200 symbols");
            }
            else
            {
                var engPattern = @"(^[A-Z][a-z]*((-[A-Z][a-z]*)?|(-[a-z]*-[A-Z][a-z]*)?|( ([A-Z]|[a-z])[a-z]*)*)$)";
                var rusPattern = @"(^[А-ЯЁ][а-яё]*((-[А-ЯЁ][а-яё]*)?|(-[а-яё]*-[А-ЯЁ][а-яё]*)?|( ([А-ЯЁ]|[а-яё])[а-яё]*)*)$|(^[A-Z]*$)|(^[А-ЯЁ]*$))";

                if (!Regex.IsMatch(_country, engPattern) && !Regex.IsMatch(_country, rusPattern))
                {
                    result = false;
                    patentValidationExceptions.Add("Country must be started with uppercase symbol and it can contains hyphen(double-hyphen) and white-spaces. If it contains hyphen, next symbol must be uppercase, if this double-hyphen then symbol after second hyphen must be uppercase. You can use only russian or english letters. Or country must be abbreviation");
                }
            }
            return result;
        }

        public bool CountryValidation(string country)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(country))
            {
                result = false;
                patentValidationExceptions.Add("Country can't be empty");
            }
            else if (country.Length > 200)
            {
                result = false;
                patentValidationExceptions.Add("Country length cannot be more than 200 symbols");
            }
            else
            {
                var engPattern = @"(^[A-Z][a-z]*((-[A-Z][a-z]*)?|(-[a-z]*-[A-Z][a-z]*)?|( ([A-Z]|[a-z])[a-z]*)*)$)";
                var rusPattern = @"(^[А-ЯЁ][а-яё]*((-[А-ЯЁ][а-яё]*)?|(-[а-яё]*-[А-ЯЁ][а-яё]*)?|( ([А-ЯЁ]|[а-яё])[а-яё]*)*)$|(^[A-Z]*$)|(^[А-ЯЁ]*$))";

                if (!Regex.IsMatch(country, engPattern) && !Regex.IsMatch(country, rusPattern))
                {
                    result = false;
                    patentValidationExceptions.Add("Country must be started with uppercase symbol and it can contains hyphen(double-hyphen) and white-spaces. If it contains hyphen, next symbol must be uppercase, if this double-hyphen then symbol after second hyphen must be uppercase. You can use only russian or english letters. Or country must be abbreviation");
                }
            }
            return result;
        }

        public bool RegistrationNumberValidation()
        {
            bool result = true;
            if (_registrationNumber <= 0)
            {
                result = false;
                patentValidationExceptions.Add("Registration number cannot be lesser or equal to 0");
            }
            else if (_registrationNumber.ToString().Length > 9)
            {
                result = false;
                patentValidationExceptions.Add("Registration number must be less or equal to 9 symbols");
            }
            return result;
        }

        public bool RegistrationNumberValidation(int registrationNumber)
        {
            bool result = true;
            if (registrationNumber <= 0)
            {
                result = false;
                patentValidationExceptions.Add("Registration number cannot be lesser or equal to 0");
            }
            else if (registrationNumber.ToString().Length > 9)
            {
                result = false;
                patentValidationExceptions.Add("Registration number must be less or equal to 9 symbols");
            }
            return result;
        }

        public bool DateOfApplicationValidation()
        {
            bool result = true;
            if (_dateOfApplication != null)
            {
                if (_dateOfApplication.Value.Year < 1474 || _dateOfApplication.Value > DateTime.Now)
                {
                    result = false;
                    patentValidationExceptions.Add("Date of application must be more than 1474 year and less or equal than current date");
                }
            }
            return result;
        }

        public bool DateOfApplicationValidation(DateTime? dateOfApplication)
        {
            bool result = true;
            if (dateOfApplication != null)
            {
                if (dateOfApplication.Value.Year < 1474 || dateOfApplication.Value > DateTime.Now)
                {
                    result = false;
                    patentValidationExceptions.Add("Date of application must be more than 1474 year and less or equal than current date");
                }
            }
            return result;
        }

        public bool PublicationDateValidation()
        {
            bool result = true;
            if (_dateOfApplication != null)
            {
                if (_publicationDate < _dateOfApplication)
                {
                    result = false;
                    patentValidationExceptions.Add("Publication date cannot be less than the date of application");
                }
            }
            if (_publicationDate.Value.Year < 1474 || _publicationDate > DateTime.Now)
            {
                result = false;
                patentValidationExceptions.Add("Publication year connt be less than 1474 and more than current date");
            }
            return result;
        }

        public bool PublicationDateValidation(DateTime? publicationDate, DateTime? dateOfApplication)
        {
            bool result = true;
            if (dateOfApplication != null)
            {
                if (publicationDate < dateOfApplication)
                {
                    result = false;
                    patentValidationExceptions.Add("Publication date cannot be less than the date of application");
                }
            }
            if (publicationDate.Value.Year < 1474 || publicationDate > DateTime.Now)
            {
                result = false;
                patentValidationExceptions.Add("Publication year connt be less than 1474 and more than current date");
            }
            return result;
        }
    }
}