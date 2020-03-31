using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                var clientList = _clienteRepository.GetAll().Result;
                return clientList.toEntity();
            }
            catch
            {
                return Enumerable.Empty<ClienteEntity>();
            }
        }

        public bool Update(int id, ClienteEntity clienteEntity)
        {
            if (clienteEntity.Id != id) return false;
            
            try
            {
                return _clienteRepository.Update(id, clienteEntity.toModel()).Result;
            } 
            catch 
            {
                return false;
            }
        }
    }
    
}
