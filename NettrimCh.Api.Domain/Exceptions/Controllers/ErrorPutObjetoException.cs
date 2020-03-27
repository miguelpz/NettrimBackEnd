using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.Controllers
{
    public class ErrorPutObjetoException : Exception
    {
        public ErrorPutObjetoException() { }
        public ErrorPutObjetoException(string message) : base(message) { }
        public ErrorPutObjetoException(string message, Exception innerException) : base(message, innerException) { }
        protected ErrorPutObjetoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
