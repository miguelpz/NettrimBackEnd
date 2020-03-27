using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.FactoryExceptions
{
    public class ImposibleCrearEmpleadoException : Exception
    {
        public ImposibleCrearEmpleadoException()
        {
        }

        public ImposibleCrearEmpleadoException(string message) : base(message)
        {
        }

        public ImposibleCrearEmpleadoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImposibleCrearEmpleadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
