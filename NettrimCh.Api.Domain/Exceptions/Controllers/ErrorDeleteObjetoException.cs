using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.Controllers
{
    public class ErrorDeleteObjetoException : Exception
    {
        public ErrorDeleteObjetoException() { }
        public ErrorDeleteObjetoException(string message) : base(message) { }
        public ErrorDeleteObjetoException(string message, Exception innerException) : base(message, innerException) { }
        protected ErrorDeleteObjetoException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
