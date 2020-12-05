using System;

namespace Exceptions
{
    public class NewspaperValidationException : Exception
    {
        public NewspaperValidationException(string message)
            : base(message)
        {
        }

        public NewspaperValidationException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}