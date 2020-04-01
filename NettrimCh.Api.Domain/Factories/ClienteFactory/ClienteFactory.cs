using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Exceptions.FactoryExceptions;
using NettrimCh.Api.Domain.Specifications.ClienteSpecification;

namespace NettrimCh.Api.Domain.Factories.ClienteFactory
{
    public class ClienteFactory : IClienteFactory
    {
        private readonly IClienteSpecification _specification;
       
        public ClienteFactory(IClienteSpecification specification)
        {
            _specification = specification;
        }

        public ClienteEntity Instanciar(ClienteEntity c)
        {
            if (c != null)
            {
                
                if (_specification.IsSatisfiedBy(c))
                {
                    return c;
                }
                throw new ImposibleCrearClienteException("No se ha podido crear el cliente: " + c.Nombre + ", porque hay datos incorrectos.");
            }
            throw new ImposibleCrearClienteException("No se ha podido crear el cliente porque es nulo.");            
        }
    }
}
