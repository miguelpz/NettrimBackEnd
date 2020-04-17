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

        public IEnumerable<EmpleadoDto> GetAll()
        {
            return _empleadoDomainService.GetAll().toDto();

        }
        public EmpleadoDto GetById(int id)
        {
            return _empleadoDomainService.GetByID(id).toDto();
        }

        public EmpleadoDto Add (EmpleadoDto empleado)
        {         
            empleado.Password = _cipherService.Encrypt(empleado.Password);
            return _empleadoDomainService.Add(empleado.toEntity()).toDto();           
        }

        public void Update(int id, EmpleadoDto empleado)
        {
            _empleadoDomainService.Update(id, empleado.toEntity());
        }

        public EmpleadoDto Delete(int id)
        {
            return _empleadoDomainService.Delete(id).toDto();
        }



    }
}
