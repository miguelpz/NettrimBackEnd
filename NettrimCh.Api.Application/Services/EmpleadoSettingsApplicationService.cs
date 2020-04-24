using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.EmpleadoSettings;
using NettrimCh.Api.Application.Helpers;
using NettrimCh.Api.Application.Mapping.Extension.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.EmpleadoSettings;
using NettrimCh.Api.Domain.ServicesImplementatios.Empleado;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace NettrimCh.Api.Application.Services
{
    public class EmpleadoSettingsApplicationService: IEmpleadoSettingsApplicationService
    {
        private readonly IEmpleadoSettingsDomainService _empleadoSettingsDomainService;

        public EmpleadoSettingsApplicationService(IEmpleadoSettingsDomainService empleadoSettingsDomainService)
        {
            _empleadoSettingsDomainService = empleadoSettingsDomainService;
        }

        public EmpleadoSettingsDto Add (EmpleadoSettingsDto empleado)
        {
            _empleadoSettingsDomainService.Add(empleado.toEntity());
            return empleado;
        }



    }
}
