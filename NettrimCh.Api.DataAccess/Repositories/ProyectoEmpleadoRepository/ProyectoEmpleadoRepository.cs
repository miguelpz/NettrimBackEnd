using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoEmpleadoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.ProyectoEmpleadoRepository
{
    public class ProyectoEmpleadoRepository: GenericRepository<ProyectoEmpleado>, IProyectoEmpleadoRepository
    {
        public ProyectoEmpleadoRepository(NettrimDbContext context)
        {
            _context = context;
            _table = _context.Set<ProyectoEmpleado>();
        }
    }
}
