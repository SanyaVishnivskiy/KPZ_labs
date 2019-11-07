using System;
using System.Collections.Generic;
using System.Text;


namespace BLL.Exceptions
{
    public class NotFoundArgumentException : Exception
    {
        public NotFoundArgumentException()
        {
        }

        public NotFoundArgumentException(string message)
            : base(message)
        {
        }

        public NotFoundArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
