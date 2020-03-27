using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.Controllers
{
    public class ErrorGetObjetoException : Exception
    {
        public ErrorGetObjetoException() { }
        public ErrorGetObjetoException(string message) : base(message) { }
        public ErrorGetObjetoException(string message, Exception innerException) : base(message, innerException) { }
        protected ErrorGetObjetoException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
