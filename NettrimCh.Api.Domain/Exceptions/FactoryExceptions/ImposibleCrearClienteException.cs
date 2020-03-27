using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.FactoryExceptions
{
    [Serializable]
    public class ImposibleCrearClienteException : Exception
    {
        public ImposibleCrearClienteException()
        {
        }

        public ImposibleCrearClienteException(string message) : base(message)
        {
        }

        public ImposibleCrearClienteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImposibleCrearClienteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}