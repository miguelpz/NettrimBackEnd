using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Domain.ServicesContracts.Proyecto;
using NettrimCh.Api.Application.Mapping.Extension.Proyecto;

using System;
using System.Collections.Generic;
using System.Text;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Proyecto;

namespace NettrimCh.Api.Application.Services
{
    public class ProyectoApplicationService: IProyectoApplicationService
    {
        private readonly IProyectoDomainService _proyectoDomainService;

        public ProyectoApplicationService(IProyectoDomainService proyectoDomainService)
        {
            _proyectoDomainService = proyectoDomainService;
        }

        public IEnumerable<ProyectoDto> GetAll()
        {
            return _proyectoDomainService.GetAll().toDto();

        }
        public ProyectoDto GetById(int id)
        {
            return _proyectoDomainService.GetByID(id).toDto();
        }


        public ProyectoDto Add(ProyectoDto proyecto)
        {

            return _proyectoDomainService.Add(proyecto.toEntity()).toDto();
        }

        public void Update(int id, ProyectoDto proyecto)
        {
            _proyectoDomainService.Update(id, proyecto.toEntity());
        }

        public ProyectoDto Delete(int id)
        {
            return _proyectoDomainService.Delete(id).toDto();
        }
    }
}
