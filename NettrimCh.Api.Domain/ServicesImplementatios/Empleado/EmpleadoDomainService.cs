
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

        public IEnumerable<EmpleadoEntity> GetAll()
        {
            var clientList = _empleadoRepository.GetAll().Result;
            return clientList.toEntity();
        }

        public EmpleadoEntity GetByID(int id)
        {
            var client = _empleadoRepository.GetById(id).Result;
            return client.toEntity();
        }

        public EmpleadoEntity GetSingleOrDefault(string email)
        {
            var cliente = _empleadoRepository.GetSingleOrDefault(x => x.Email == email).Result;
            return cliente.toEntity();
        }

        public EmpleadoEntity Add (EmpleadoEntity empleado)
        {
            if (!CheckNettrimCode(empleado.Codigo))
                throw new Exception("Código Nettrim Incorrecto");

            if (IsEmailDuplicate(empleado))
            {
                throw new Exception("Email already exist");
            }

            SetDefaultValues(empleado);
            
            return _empleadoRepository.Add(empleado.toModel()).Result.toEntity();                     
        }
        
        public void Update(int id, EmpleadoEntity empleado)
        {
            if (IsEmailDuplicate(empleado))
            {
                throw new Exception("Email already exist");
            }

            if (empleado.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }

            var result = _empleadoRepository.Update(id, empleado.toModel()).Result;

            if (result == 0)
            {
                throw new Exception("El elemento a actualizar no existe");
            }
        }
        
        public EmpleadoEntity Delete(int id)
        {
            var clienteToDelete = _empleadoRepository.GetById(id).Result;

            if (clienteToDelete == null)
            {
                throw new Exception("Element to delete no exist");
            }

            var deletedEmpleado = _empleadoRepository.Delete(id).Result;
            return deletedEmpleado.toEntity();
        }
        
        private void SetDefaultValues(EmpleadoEntity empleado)
        {
            empleado.Rol = Roles.AdminRole;
            empleado.Baja = false;
        }
        
        private bool IsEmailDuplicate(EmpleadoEntity empleadoEntity)
        {
            return GetSingleOrDefault(empleadoEntity.Email) != null;
        }
       
        private bool CheckNettrimCode (string inputCode)
        {
            var actualNettrimCode = Configuration.GetValue<string>("InternalCodes:ActualNettrimCode");
            return actualNettrimCode.Equals(inputCode);
        }


    }
}
