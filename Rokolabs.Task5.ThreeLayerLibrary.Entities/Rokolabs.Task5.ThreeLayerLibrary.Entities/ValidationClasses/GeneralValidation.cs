using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities.ValidationClasses
{
    public class GeneralValidation
    {
        private bool _placeOfPublicationIsValid;
        private bool _PublishingHouseIsValid;
        private bool _numberOfPagesIsValid;
        private bool _titleIsValid;
        private bool _annotationIsValid;
        private bool _publicationYearIsValid;
        private string _placeOfPublication;
        private string _publishingHouse;
        private string _title;
        private string _annotation;
        private int _publicationYear;

        public List<String> generalValidationExceptions = new List<string>();

        public bool PlaceOfPublicationIsValid { get => _placeOfPublicationIsValid; set => _placeOfPublicationIsValid = value; }
        public bool PublishingHouseIsValid { get => _PublishingHouseIsValid; set => _PublishingHouseIsValid = value; }
        public bool NumberOfPagesIsValid { get => _numberOfPagesIsValid; set => _numberOfPagesIsValid = value; }
        public bool TitleIsValid { get => _titleIsValid; set => _titleIsValid = value; }
        public bool AnnotationIsValid { get => _annotationIsValid; set => _annotationIsValid = value; }
        public bool PublicationYearIsValid { get => _publicationYearIsValid; set => _publicationYearIsValid = value; }
        public string PlaceOfPublication { get => _placeOfPublication; }
        public string PublishingHouse { get => _publishingHouse; }
        public string Title { get => _title; }
        public string Annotation { get => _annotation; }
        public int PublicationYear { get => _publicationYear; }

        public GeneralValidation(string placeOfPublication,
                                string publishingHouse,
                                string title,
                                string annotation,
                                int publicationYear)
        {
            _placeOfPublication = placeOfPublication;
            _publishingHouse = publishingHouse;
            _title = title;
            _annotation = annotation;
            _publicationYear = publicationYear;
        }

        public GeneralValidation(int numberOfPages,
                                string title,
                                string annotation,
                                int publicationYear)
        {
            _title = title;
            _annotation = annotation;
            _publicationYear = publicationYear;
        }

        public void ExecuteValidation()
        {
            PlaceOfPublicationIsValid = PlaceOfPublicationValidation();
            PublishingHouseIsValid = PublishingHouseValidation();
            TitleIsValid = TitleValidation();
            AnnotationIsValid = AnnotationValidation();
            PublicationYearIsValid = PublicationYearValidation();
        }

        public void ExecutePatentGeneralValidation()
        {
            TitleIsValid = TitleValidation();
            AnnotationIsValid = AnnotationValidation();
            PublicationYearIsValid = PublicationYearValidation();
        }

        private bool PublicationYearValidation()
        {
            bool result = true;
            if (_publicationYear < 1400)
            {
                result = false;
                generalValidationExceptions.Add("Publication year must be more than 1400");
            }
            else if (_publicationYear > DateTime.Now.Year)
            {
                result = false;
                generalValidationExceptions.Add("Publication year must  be less or equal to current year");
            }
            return result;
        }

        private bool AnnotationValidation()
        {
            bool result = true;
            if (_annotation.Length > 2000)
            {
                result = false;
                generalValidationExceptions.Add("Annotation length cannot be more than 2000 symbols");
            }
            return result;
        }

        private bool TitleValidation()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(_title))
            {
                result = false;
                generalValidationExceptions.Add("Title cannot be empty");
            }
            else if (_title.Length > 300)
            {
                result = false;
                generalValidationExceptions.Add("Title length cannot be more than 300 symbols");
            }
            return result;
        }

        private bool PublishingHouseValidation()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(_publishingHouse))
            {
                result = false;
                generalValidationExceptions.Add("Publishing house cannot be empty");
            }
            else if (_publishingHouse.Length > 300)
            {
                result = false;
                generalValidationExceptions.Add("Publishing house name cannot be more than 300 symbols");
            }
            return result;
        }

        private bool PlaceOfPublicationValidation()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(_placeOfPublication))
            {
                result = false;
                generalValidationExceptions.Add("Place of publication cannot be empty");
            }
            else if (_placeOfPublication.Length > 200)
            {
                result = false;
                generalValidationExceptions.Add("Place of publication cannot be more than 200 symbols");
            }
            else
            {
                var engPattern = @"(^[A-Z][a-z]*((-[A-Z][a-z]*)?|(-[a-z]+-[A-Z][a-z]*)?|( ([A-Z]|[a-z])[a-z]*)*)$)";
                var rusPattern = @"(^[А-ЯЁ][а-яё]*((-[А-ЯЁ][а-яё]*)?|(-[а-яё]+-[А-ЯЁ][а-яё]*)?|( ([А-ЯЁ]|[а-яё])[а-яё]*)*)$)";

                if (!Regex.IsMatch(_placeOfPublication, engPattern) && !Regex.IsMatch(_placeOfPublication, rusPattern))
                {
                    result = false;
                    generalValidationExceptions.Add("Place of publication must be started with uppercase symbol and it can contains hyphen(double-hyphen) and white-spaces. If it contains hyphen, next symbol must be uppercase, if this double-hyphen then symbol after second hyphen must be uppercase. You can use only russian or english letters");
                }
            }
            return result;
        }

        public GeneralValidation()
        {
        }

        public bool PlaceOfPublicationValidation(string placeOfPublication)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(placeOfPublication))
            {
                result = false;
                generalValidationExceptions.Add("Place of publication cannot be empty");
            }
            else if (placeOfPublication.Length > 200)
            {
                result = false;
                generalValidationExceptions.Add("Place of publication cannot be more than 200 symbols");
            }
            else
            {
                var engPattern = @"(^[A-Z][a-z]*((-[A-Z][a-z]*)?|(-[a-z]+-[A-Z][a-z]*)?|( ([A-Z]|[a-z])[a-z]*)*)$)";
                var rusPattern = @"(^[А-ЯЁ][а-яё]*((-[А-ЯЁ][а-яё]*)?|(-[а-яё]+-[А-ЯЁ][а-яё]*)?|( ([А-ЯЁ]|[а-яё])[а-яё]*)*)$)";

                if (!Regex.IsMatch(placeOfPublication, engPattern) && !Regex.IsMatch(placeOfPublication, rusPattern))
                {
                    result = false;
                    generalValidationExceptions.Add("Place of publication must be started with uppercase symbol and it can contains hyphen(double-hyphen) and white-spaces. If it contains hyphen, next symbol must be uppercase, if this double-hyphen then symbol after second hyphen must be uppercase. You can use only russian or english letters");
                }
            }
            return result;
        }

        public bool PublishingHouseValidation(string publishingHouse)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(publishingHouse))
            {
                result = false;
                generalValidationExceptions.Add("Publishing house cannot be empty");
            }
            else if (publishingHouse.Length > 300)
            {
                result = false;
                generalValidationExceptions.Add("Publishing house name cannot be more than 300 symbols");
            }
            return result;
        }

        public bool NumberOfPageValidation(int numberOfPages)
        {
            bool result = true;
            if (numberOfPages <= 0)
            {
                result = false;
                generalValidationExceptions.Add("Number of pages cannot be lesser or equal to  0");
            }
            return result;
        }

        public bool TitleValidation(string title)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(title))
            {
                result = false;
                generalValidationExceptions.Add("Title cannot be empty");
            }
            else if (title.Length > 300)
            {
                result = false;
                generalValidationExceptions.Add("Title length cannot be more than 300 symbols");
            }
            return result;
        }

        public bool AnnotationValidation(string annotation)
        {
            bool result = true;
            if (annotation.Length > 2000)
            {
                result = false;
                generalValidationExceptions.Add("Annotation length cannot be more than 2000 symbols");
            }
            return result;
        }

        public bool PublicationYearValidation(int publicationYear)
        {
            bool result = true;
            if (publicationYear < 1400)
            {
                result = false;
                generalValidationExceptions.Add("Publication year must be more than 1400");
            }
            else if (publicationYear > DateTime.Now.Year)
            {
                result = false;
                generalValidationExceptions.Add("Publication year must  be less or equal to current year");
            }
            return result;
        }
    }
}