using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.RegistroHorasRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.RegistroHorasRepository
{
    public class RegistroHorasRepository: GenericRepository<RegistroHoras>, IRegistroHorasRepository
    {
        public RegistroHorasRepository(NettrimDbContext context)
        {
            _context = context;
            _table = _context.Set<RegistroHoras>();
        }
    }
}
