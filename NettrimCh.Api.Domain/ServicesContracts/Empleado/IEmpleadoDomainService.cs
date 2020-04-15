using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.Empleado
{
    public interface IEmpleadoDomainService
    {
        EmpleadoEntity Add(EmpleadoEntity empleado);
        IEnumerable<EmpleadoEntity> GetAll();
        EmpleadoEntity GetByID(int id);
        EmpleadoEntity GetSingleOrDefault(string email);
        void Update(int id, EmpleadoEntity empleado);
        EmpleadoEntity Delete(int id);
    }    
}
