using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.Controllers
{
    public class ErrorPostObjetoException : Exception
    {
        public ErrorPostObjetoException() { }
        public ErrorPostObjetoException(string message) : base(message) { }
        public ErrorPostObjetoException(string message, Exception innerException) : base(message, innerException) { }
        protected ErrorPostObjetoException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
