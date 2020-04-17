
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
            var empleadoList = _empleadoRepository.GetAll().Result;
            return empleadoList.toEntity();
        }

        public EmpleadoEntity GetByID(int id)
        {
            var empleado = _empleadoRepository.GetById(id).Result;
            return empleado.toEntity();
        }

        public EmpleadoEntity GetSingleOrDefault(string email)
        {
            var cliente = _empleadoRepository.GetSingleOrDefault(x => x.Email == email).Result;
            return cliente.toEntity();
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


        public void Update(int id, EmpleadoEntity empleadoEntity)
        {
            if (IsEmailDuplicate(empleadoEntity))
            {
                throw new Exception("Email already exist");
            }

            if (empleadoEntity.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }

            var result = _empleadoRepository.Update(id, empleadoEntity.toModel()).Result;

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

            var deletedCliente = _empleadoRepository.Delete(id).Result;
            return deletedCliente.toEntity();
        }

        private bool IsEmailDuplicate(EmpleadoEntity empleado)
        {
            return GetSingleOrDefault(empleado.Email) != null;
        }
        private void SetDefaultValues (EmpleadoEntity empleado)
        {
            empleado.Rol = Roles.AdminRole;
            empleado.Baja = false;
        }


    }
}
