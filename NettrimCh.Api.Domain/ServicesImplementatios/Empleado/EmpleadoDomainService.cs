
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using NettrimCh.Api.CrossCutting.Encriptado;
using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoRepository;
using NettrimCh.Api.Domain.Constants;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.Empleado;
using NettrimCh.Api.Domain.ServicesContracts.Empleado;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesImplementatios.Empleado
{
    public class EmpleadoDomainService: IEmpleadoDomainService
    {
        public IConfiguration Configuration { get; }
        private readonly IEmpleadoRepository _empleadoRepository;
        public EmpleadoDomainService(IConfiguration configuration,
                                     IEmpleadoRepository empleadoRepository)
                                    
        {
            Configuration = configuration;
            _empleadoRepository = empleadoRepository;
        }

        private bool CheckNettrimCode (string inputCode)
        {
            var actualNettrimCode = Configuration.GetValue<string>("InternalCodes:ActualNettrimCode");
            return actualNettrimCode.Equals(inputCode);
        }

        public EmpleadoEntity Add (EmpleadoEntity empleado)
        {
            if (!CheckNettrimCode(empleado.Codigo))
                throw new Exception("Código Nettrim Incorrecto");
            
            SetDefaultValues(empleado);
            
            return _empleadoRepository.Add(empleado.toModel()).Result.toEntity();                     
        }

        private void SetDefaultValues (EmpleadoEntity empleado)
        {
            empleado.Rol = Roles.AdminRole;
            empleado.Baja = false;
        }


    }
}
