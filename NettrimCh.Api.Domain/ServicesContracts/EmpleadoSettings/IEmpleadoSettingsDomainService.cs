using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.EmpleadoSettings
{
    public interface IEmpleadoSettingsDomainService
    {
        EmpleadoSettingEntity Add(EmpleadoSettingEntity empleado);
    }
}
