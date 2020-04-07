using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Tarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public ClienteEntity GetByID (int id)
        {
            var client = _clienteRepository.GetById(id).Result;
            return client.toEntity();
        }

        public ClienteEntity GetSingleOrDefault(string telefono)
        {
            var cliente = _clienteRepository.GetSingleOrDefault(x => x.Telefono == telefono).Result;
            return cliente.toEntity();
        }

        public ClienteEntity Add (ClienteEntity clientEntity)
        {
            var clientByTelefono = GetSingleOrDefault(clientEntity.Telefono);

            if (clientByTelefono != null)
            {
                throw new Exception("Element already exist");
            }
           
            var client = _clienteRepository.Add(clientEntity.toModel()).Result;

            return client.toEntity();
        }
        public void Update(int id, ClienteEntity clienteEntity)
        {
            if (clienteEntity.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }

            var result = _clienteRepository.Update(id, clienteEntity.toModel()).Result;

            if (result == 0)
            {
                throw new Exception("El elemento a actualizar no existe");
            }
        }

        public ClienteEntity Delete (int id)
        {
            var clienteToDelete = _clienteRepository.GetById(id).Result;

            if (clienteToDelete == null)
            {
                throw new Exception("Element to delete no exist");
            }
            
            var deletedCliente= _clienteRepository.Delete(id).Result;
            return deletedCliente.toEntity();
        }
    }
    
}
