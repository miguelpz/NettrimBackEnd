using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.Cliente
{
    public interface IClienteDomainService
    {
        IEnumerable<ClienteEntity> GetAll();
        ClienteEntity GetByID(int id);
        ClienteEntity GetSingleOrDefault(string telefono);
        ClienteEntity Add(ClienteEntity clientEntity);
        void Update(int id, ClienteEntity clienteEntity);
        ClienteEntity Delete(int id);
    }
}
