using System;
using System.Collections.Generic;
using System.Text;


namespace BLL.Exceptions
{
    public class NotFoundEntitiesException : Exception
    {
        public NotFoundEntitiesException()
        {
        }

        public NotFoundEntitiesException(string message)
            : base(message)
        {
        }

        public NotFoundEntitiesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
