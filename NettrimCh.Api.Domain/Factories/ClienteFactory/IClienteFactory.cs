using NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Domain.Factories.ClienteFactory
{
    public interface IClienteFactory
    {
        ClienteEntity Instanciar(ClienteEntity c);
    }
}
