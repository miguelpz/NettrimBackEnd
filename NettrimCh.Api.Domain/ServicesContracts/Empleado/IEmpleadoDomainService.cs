using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.Empleado
{
    public interface IEmpleadoDomainService
    {
        EmpleadoEntity Add(EmpleadoEntity empleado);
    }
}
