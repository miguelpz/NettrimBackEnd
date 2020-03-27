using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Mapping.Extension.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Services
{
    public class ClienteApplicationService: IClienteApplicationService
    {
        private readonly IClienteDomainService _clienteDomainService;

        public ClienteApplicationService(IClienteDomainService clienteDomainService)
        {
            _clienteDomainService = clienteDomainService;
        }

        public IEnumerable<ClienteDto> GetAll()
        {
            return _clienteDomainService.GetAll().toEntity();

        }
    }
}
