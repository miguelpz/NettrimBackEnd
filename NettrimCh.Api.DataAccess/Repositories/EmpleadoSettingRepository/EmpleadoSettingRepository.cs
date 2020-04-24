using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoSettingRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.EmpleadoSettingRepository
{
    public class EmpleadoSettingRepository : GenericRepository<EmpleadoSetting>, IEmpleadoSettingRepository
    {
        public EmpleadoSettingRepository(NettrimDbContext context)
        {
            _context = context;
            _table = _context.Set<EmpleadoSetting>();
        }
    }
}
