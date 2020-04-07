using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Tarea;
using NettrimCh.Api.Application.Mapping.Extension.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Tarea;
using System.Collections.Generic;

namespace NettrimCh.Api.Application.Services
{
    public class TareaApplicationService: ITareaApplicationService
    {
        private readonly ITareaDomainService _tareaDomainService;

        public TareaApplicationService(ITareaDomainService tareaDomainService)
        {
            _tareaDomainService = tareaDomainService;
        }

        public IEnumerable<TareaDto> GetAll()
        {
            return _tareaDomainService.GetAll().toDto();

        }
        public TareaDto GetById (int id)
        {
            return _tareaDomainService.GetByID(id).toDto();
        }

        
        public TareaDto Add (TareaDto tarea)            
        {
           
            return _tareaDomainService.Add(tarea.toEntity()).toDto();
        }
        
        public void Update(int id, TareaDto tarea)
        {
            _tareaDomainService.Update(id, tarea.toEntity());
        }

        public TareaDto Delete(int id)
        {
            return _tareaDomainService.Delete(id).toDto();
        }
    }
}
