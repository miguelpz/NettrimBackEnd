using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.Empleado
{
    public interface IEmpleadoApplicationService
    {
        IEnumerable<EmpleadoDto> GetAll();
        EmpleadoDto GetById(int id);
        EmpleadoDto Add(EmpleadoDto empleado);
        void Update(int id, EmpleadoDto empleado);
        EmpleadoDto Delete(int id);
    }
}
