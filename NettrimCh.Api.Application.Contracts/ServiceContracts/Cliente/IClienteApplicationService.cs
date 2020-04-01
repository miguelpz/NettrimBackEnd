using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente
{
    public interface IClienteApplicationService
    {
        IEnumerable<ClienteDto> GetAll();
        ClienteDto GetById(int id);
        ClienteDto Add(ClienteDto cliente);
        void Update(int id, ClienteDto cliente);
        ClienteDto Delete(int id);
    }
}
