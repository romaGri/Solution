using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Exceptions
{
    public class ApiTorrentsException : Exception
    {
        public ExceptionEvent ExceptionEvent { get; private set; }

        public ApiTorrentsException(ExceptionEvent exception) : this(exception, null)
        {
        }

        public ApiTorrentsException(ExceptionEvent exception, string message) : base(message)
        {
            ExceptionEvent = exception;
        }

    }
}
