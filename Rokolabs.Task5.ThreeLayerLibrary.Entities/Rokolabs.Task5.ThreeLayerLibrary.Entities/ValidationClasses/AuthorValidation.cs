using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities.ValidationClasses
{
    public class AuthorValidation
    {
        #region Fields and properties

        private Author _author;

        public List<string> exceptionList = new List<string>();
        public bool FirstNameIsValid { get; set; }
        public bool LastNameIsValid { get; set; }

        #endregion Fields and properties

        public AuthorValidation(Author author)
        {
            _author = author;
        }

        public AuthorValidation()
        {
        }

        public bool AuthorFirstNameValidation()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(_author.FirstName))
            {
                result = false;
                exceptionList.Add($"The author first name cannot be empty");
            }
            else if (_author.FirstName.Length > 50)
            {
                result = false;
                exceptionList.Add($"FirstName Can't be more than 50 symbols. Name was {_author.FirstName} - {_author.FirstName.Length}");
            }
            else
            {
                var engPattern = @"(^[A-Z][a-z]*$)|(^[A-Z][a-z]*-[A-Z][a-z]*$)";
                var rusPattern = @"(^[А-ЯЁ][а-яё]*$)|(^[А-ЯЁ][а-яё]*-[А-ЯЁ][а-яё]*$)";
                if (!Regex.IsMatch(_author.FirstName, rusPattern) && !Regex.IsMatch(_author.FirstName, engPattern))
                {
                    exceptionList.Add("The author first name must start with a uppercase symbol and it can contain a hyphen followed by a uppercase symbol " + Environment.NewLine
                        + "(Example: First-Name, Firstname), and contain only latin or russian letters"
                        + $" The First Name was: {_author.FirstName}");
                }
            }
            return result;
        }

        public bool AuthorFirstNameValidation(string firstName)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(firstName))
            {
                result = false;
                exceptionList.Add($"The author first name cannot be empty");
            }
            else if (firstName.Length > 50)
            {
                result = false;
                exceptionList.Add($"FirstName Can't be more than 50 symbols. Name was {firstName} - {firstName.Length}");
            }
            else
            {
                var engPattern = @"(^[A-Z][a-z]*$)|(^[A-Z][a-z]*-[A-Z][a-z]*$)";
                var rusPattern = @"(^[А-ЯЁ][а-яё]*$)|(^[А-ЯЁ][а-яё]*-[А-ЯЁ][а-яё]*$)";
                if (!Regex.IsMatch(firstName, rusPattern) && !Regex.IsMatch(firstName, engPattern))
                {
                    exceptionList.Add("The author first name must start with a uppercase symbol and it can contain a hyphen followed by a uppercase symbol " + Environment.NewLine
                        + "(Example: First-Name, Firstname), and contain only latin or russian letters"
                        + $" The First Name was: {firstName}");
                }
            }
            return result;
        }

        public bool AuthorLastNameValidation()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(_author.LastName))
            {
                result = false;
                exceptionList.Add("The author last name cannot be empty");
            }
            else if (_author.LastName.Length > 200)
            {
                result = false;
                exceptionList.Add($"Last Name Can't be more than 200 symbols. The name was {_author.LastName} - {_author.LastName.Length} symbols");
            }
            else
            {
                var rusPattern = @"^([а-яё]* ([А-ЯЁ][а-яё]*)('[А-ЯЁ][а-яё]*)?(-[А-ЯЁ][а-яё]*)?)$|^([а-яё]* ([А-ЯЁ][а-яё]*)(-[А-ЯЁ][а-яё]*('[А-ЯЁ][а-яё]*)?)?)$|^(([А-ЯЁ][а-яё]*)(-[А-ЯЁ][а-яё]*('[А-ЯЁ][а-яё]*)?)?)$|^(([А-ЯЁ][а-яё]*('[А-ЯЁ][а-яё]*)?)(-[А-ЯЁ][а-яё]*)?)$";
                var engPattern = @"^([a-z]* ([A-Z][a-z]*)('[A-Z][a-z]*)?(-[A-Z][a-z]*)?)$|^([a-z]* ([A-Z][a-z]*)(-[A-Z][a-z]*('[A-Z][a-z]*)?)?)$|^(([A-Z][a-z]*)(-[A-Z][a-z]*('[A-Z][a-z]*)?)?)$|^(([A-Z][a-z]*('[A-Z][a-z]*)?)(-[A-Z][a-z]*)?)$";
                if (!Regex.IsMatch(_author.LastName, rusPattern) && !Regex.IsMatch(_author.LastName, engPattern))
                {
                    result = false;
                    exceptionList.Add("The author last name must start with a uppercase symbol and it can contain a hyphen followed by a uppercase symbol " + Environment.NewLine
                        + "(Example: Last-Name, Lastname), and contain only latin or russian letters"
                        + $"The Last Name was {_author.LastName}");
                }
            }
            return result;
        }

        public bool AuthorLastNameValidation(string lastName)
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(lastName))
            {
                result = false;
                exceptionList.Add("The author last name cannot be empty");
            }
            else if (lastName.Length > 200)
            {
                result = false;
                exceptionList.Add($"Last Name Can't be more than 200 symbols. The name was {lastName} - {lastName.Length} symbols");
            }
            else
            {
                var rusPattern = @"^([а-яё]* ([А-ЯЁ][а-яё]*)('[А-ЯЁ][а-яё]*)?(-[А-ЯЁ][а-яё]*)?)$|^([а-яё]* ([А-ЯЁ][а-яё]*)(-[А-ЯЁ][а-яё]*('[А-ЯЁ][а-яё]*)?)?)$|^(([А-ЯЁ][а-яё]*)(-[А-ЯЁ][а-яё]*('[А-ЯЁ][а-яё]*)?)?)$|^(([А-ЯЁ][а-яё]*('[А-ЯЁ][а-яё]*)?)(-[А-ЯЁ][а-яё]*)?)$";
                var engPattern = @"^([a-z]* ([A-Z][a-z]*)('[A-Z][a-z]*)?(-[A-Z][a-z]*)?)$|^([a-z]* ([A-Z][a-z]*)(-[A-Z][a-z]*('[A-Z][a-z]*)?)?)$|^(([A-Z][a-z]*)(-[A-Z][a-z]*('[A-Z][a-z]*)?)?)$|^(([A-Z][a-z]*('[A-Z][a-z]*)?)(-[A-Z][a-z]*)?)$";
                if (!Regex.IsMatch(lastName, rusPattern) && !Regex.IsMatch(lastName, engPattern))
                {
                    result = false;
                    exceptionList.Add("The author last name must start with a uppercase symbol and it can contain a hyphen followed by a uppercase symbol " + Environment.NewLine
                        + "(Example: First-Name, Firstname), and contain only latin or russian letters"
                        + $"The Last Name was {lastName}");
                }
            }
            return result;
        }
    }
}