using System;

namespace Exceptions
{
    public class DALException : Exception
    {
        public DALException(string message)
            : base(message)
        {
        }

        public DALException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}