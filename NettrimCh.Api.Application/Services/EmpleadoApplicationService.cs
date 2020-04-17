using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.Empleado;
using NettrimCh.Api.Application.Mapping.Extension.Empleado;
using NettrimCh.Api.CrossCutting.Encriptado;
using NettrimCh.Api.Domain.ServicesContracts.Empleado;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Services
{

    
    public  class EmpleadoApplicationService: IEmpleadoApplicationService
    {
        private readonly IEmpleadoDomainService _empleadoDomainService;
        private readonly ICipherService _cipherService;
        public EmpleadoApplicationService(
            IEmpleadoDomainService empleadoDomainService,
            ICipherService cipherService
            )
        {
            _empleadoDomainService = empleadoDomainService;
            _cipherService = cipherService;
        }

        public EmpleadoDto Add (EmpleadoDto empleado)
        {         
            empleado.Password = _cipherService.Encrypt(empleado.Password);
            return _empleadoDomainService.Add(empleado.toEntity()).toDto();


            
        }



    }
}
