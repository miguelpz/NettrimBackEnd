using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using System.Collections.Generic;

namespace NettrimCh.Api.Domain.Services.Cliente
{
    public class ClienteDomainService: IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;
       

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<ClienteEntity> GetAll()
        {
            var clientList = _clienteRepository.GetAll().Result;
            return clientList.toEntity();                        
        }
    }
}
