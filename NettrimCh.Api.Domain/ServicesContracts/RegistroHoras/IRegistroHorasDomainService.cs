using NettrimCh.Api.DataAccess.Contracts.Repositories.RegistroHorasRepository;
using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesImplementatios.RegistroHoras
{
    public interface IRegistroHorasDomainService
    {
        IEnumerable<RegistroHorasEntity> GetMonthInputs(int tareaId, int month, int year);
        void UpdateMonthInputs(IEnumerable<int> ids, IEnumerable<RegistroHorasEntity> registroHoras);
        bool IsDafaultSetting(int tareaId);
        EmpleadoSettingEntity SetDefaultSetting(int tareaId, EmpleadoSettingEntity empleadoSettin);
        void UpdateDefaultSetting(EmpleadoSettingEntity empleadoSetting);
    }
}
