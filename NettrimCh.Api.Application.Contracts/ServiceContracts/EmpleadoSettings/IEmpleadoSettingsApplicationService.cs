using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.EmpleadoSettings
{
    public interface IEmpleadoSettingsApplicationService
    {
       EmpleadoSettingsDto Add(EmpleadoSettingsDto empleado);
    }
       
}
