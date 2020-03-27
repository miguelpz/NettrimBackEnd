using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.FactoryExceptions
{ 
    [Serializable]
    public class ImposibleCrearTareaException : Exception
    {
        public ImposibleCrearTareaException()
        {
        }

        public ImposibleCrearTareaException(string message) : base(message)
        {
        }

        public ImposibleCrearTareaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImposibleCrearTareaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}