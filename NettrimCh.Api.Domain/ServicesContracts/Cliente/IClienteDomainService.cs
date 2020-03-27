using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.Cliente
{
    public interface IClienteDomainService
    {
        IEnumerable<ClienteEntity> GetAll();
    }
}
