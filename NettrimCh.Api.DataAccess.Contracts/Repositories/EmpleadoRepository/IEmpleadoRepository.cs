﻿using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoRepository
{
    public interface IEmpleadoRepository: IGenericRepository<Empleado>
    {
    }
    
}