using System;

namespace Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message)
            : base(message)
        {
        }

        public UserValidationException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}