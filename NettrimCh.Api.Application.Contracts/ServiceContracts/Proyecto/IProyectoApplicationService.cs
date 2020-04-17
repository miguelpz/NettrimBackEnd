using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.Proyecto
{
    public interface IProyectoApplicationService
    {
        IEnumerable<ProyectoDto> GetAll();
    }
}
