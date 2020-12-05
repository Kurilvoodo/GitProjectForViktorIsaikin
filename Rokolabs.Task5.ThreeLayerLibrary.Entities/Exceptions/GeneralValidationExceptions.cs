using System;

namespace Exceptions
{
    public class GeneralValidationExceptions : Exception
    {
        public GeneralValidationExceptions(string message)
            : base(message)
        {
        }

        public GeneralValidationExceptions(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}