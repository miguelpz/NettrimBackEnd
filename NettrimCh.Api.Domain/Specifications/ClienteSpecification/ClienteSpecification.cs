using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications;

namespace NettrimCh.Api.Domain.Specifications.ClienteSpecification
{
    public class ClienteSpecification : IClienteSpecification
    {
        private readonly INotNullSpecification _stringSpecification;
        

        public ClienteSpecification(INotNullSpecification stringSpecification)
        {
            _stringSpecification = stringSpecification;
           
        }

        public bool IsSatisfiedBy(ClienteEntity cliente)
        {
            return (_stringSpecification.IsSatisfiedBy(cliente.Cliente) && _stringSpecification.IsSatisfiedBy(cliente.Dirección)
                && _stringSpecification.IsSatisfiedBy(cliente.Responsable) && _stringSpecification.IsSatisfiedBy(cliente.Telefono));
                
        }
    }
}
