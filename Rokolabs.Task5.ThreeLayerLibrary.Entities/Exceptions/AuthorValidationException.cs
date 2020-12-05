using System;

namespace Exceptions
{
    public class AuthorValidationException : Exception
    {
        public AuthorValidationException(string message)
            : base(message)
        {
        }

        public AuthorValidationException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}