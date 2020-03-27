using System;
using System.Runtime.Serialization;

namespace NettrimCh.Api.Domain.Exceptions.FactoryExceptions
{
    [Serializable]
    public class ImposibleCrearProyectoException : Exception
    {
        public ImposibleCrearProyectoException()
        { }

        public ImposibleCrearProyectoException(string message) : base(message)
        { }

        public ImposibleCrearProyectoException(string message, Exception innerException) : base(message, innerException)
        { }

        protected ImposibleCrearProyectoException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
