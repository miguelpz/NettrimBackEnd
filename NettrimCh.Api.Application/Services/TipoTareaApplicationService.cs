using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Cliente;
using NettrimCh.Api.Application.Contracts.ServiceContracts.TipoTarea;
using NettrimCh.Api.Application.Mapping.Extension.TipoTarea;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.TipoTarea;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Services
{
    public class TipoTareaApplicationService: ITipoTareaApplicationService
    {
        private readonly ITipoTareaDomainService _tipoTareaDomainService;

        public TipoTareaApplicationService(ITipoTareaDomainService tipoTareaDomainService)
        {
            _tipoTareaDomainService = tipoTareaDomainService;
        }

        public IEnumerable<TipoTareaDto> GetAll()
        {
            return _tipoTareaDomainService.GetAll().toDto();

        }
        public TipoTareaDto GetById (int id)
        {
            return _tipoTareaDomainService.GetByID(id).toDto();
        }

        
        public TipoTareaDto Add (TipoTareaDto cliente)            
        {
           
            return _tipoTareaDomainService.Add(cliente.toEntity()).toDto();
        }
        
        public void Update(int id, TipoTareaDto cliente)
        {
            _tipoTareaDomainService.Update(id, cliente.toEntity());
        }

        public TipoTareaDto Delete(int id)
        {
            return _tipoTareaDomainService.Delete(id).toDto();
        }
    }
}
