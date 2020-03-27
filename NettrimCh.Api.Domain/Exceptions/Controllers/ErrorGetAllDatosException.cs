using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.Controllers
{
    public class ErrorGetAllDatosException : Exception
    {
        public ErrorGetAllDatosException() {}
        public ErrorGetAllDatosException(string message) : base(message) {}
        public ErrorGetAllDatosException(string message, Exception innerException) : base(message, innerException){}
        protected ErrorGetAllDatosException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}
