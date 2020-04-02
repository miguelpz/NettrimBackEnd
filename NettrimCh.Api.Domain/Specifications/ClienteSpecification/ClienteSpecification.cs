using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications.TelefonoSpecification;

namespace NettrimCh.Api.Domain.Specifications.ClienteSpecification
{
    public class ClienteSpecification : IClienteSpecification
    {
        private readonly IIsTelefonoSpecification _telefonoSpecification;
        

        public ClienteSpecification(IIsTelefonoSpecification telefonoSpecification)
        {
            _telefonoSpecification = telefonoSpecification;
           
        }

        public bool IsSatisfiedBy(ClienteEntity cliente)
        {
            return (_telefonoSpecification.IsSatisfiedBy(cliente.Telefono));
                
        }
    }
}
