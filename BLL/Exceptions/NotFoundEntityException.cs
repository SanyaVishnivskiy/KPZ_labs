using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException()
        {
        }

        public NotFoundEntityException(string message)
            : base(message)
        {
        }

        public NotFoundEntityException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
