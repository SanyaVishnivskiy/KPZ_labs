using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Exceptions
{
    public class NotFoundBookException : Exception
    {
        public NotFoundBookException()
        {
        }

        public NotFoundBookException(string message)
            : base(message)
        {
        }

        public NotFoundBookException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
