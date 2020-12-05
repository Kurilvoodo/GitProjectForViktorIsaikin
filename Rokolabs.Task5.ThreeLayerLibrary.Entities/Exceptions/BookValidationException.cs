using System;

namespace Exceptions
{
    public class BookValidationException : Exception
    {
        public BookValidationException(string message)
            : base(message)
        {
        }

        public BookValidationException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}