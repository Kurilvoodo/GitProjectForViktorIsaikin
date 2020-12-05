using System;

namespace Exceptions
{
    public class PatentValidationException : Exception
    {
        public PatentValidationException(string message)
            : base(message)
        {
        }

        public PatentValidationException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}