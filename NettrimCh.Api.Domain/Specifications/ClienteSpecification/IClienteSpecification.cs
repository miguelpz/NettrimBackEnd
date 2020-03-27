using NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Domain.Specifications.ClienteSpecification
{
    public interface IClienteSpecification
    {
        bool IsSatisfiedBy(ClienteEntity cliente);
    }
}
