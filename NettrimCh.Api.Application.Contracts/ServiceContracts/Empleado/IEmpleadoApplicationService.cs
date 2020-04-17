using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.Empleado
{
    public interface IEmpleadoApplicationService
    {
        EmpleadoDto Add(EmpleadoDto empleado);
    }
}
