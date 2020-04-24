using NettrimCh.Api.Application.Contracts.DTO;
using NettrimCh.Api.Application.Contracts.ServiceContracts.ProyectoEmpleado;
using NettrimCh.Api.Application.Mapping.Extension.Cliente;
using NettrimCh.Api.Application.Mapping.Extension.RegistroHoras;
using NettrimCh.Api.Domain.ServicesImplementatios.RegistroHoras;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Services
{
    public class RegistroHorasApplicationService: IRegistroHorasApplicationService
    {
        private readonly IRegistroHorasDomainService _registroHorasDomainService;

        public RegistroHorasApplicationService(IRegistroHorasDomainService registroHorasDomainService)
        {
            _registroHorasDomainService = registroHorasDomainService;

        }

        public IEnumerable<RegistroHorasDto> GetMonthInputs(int tareaId, int month, int year)
        {
            return _registroHorasDomainService.GetMonthInputs(tareaId, month, year).toDto();
        }

        public bool IsDafaultSetting(int tareaId)
        {
            return _registroHorasDomainService.IsDafaultSetting(tareaId);
        }

        public EmpleadoSettingDto SetDefaultSetting(int tareaId, EmpleadoSettingDto empleadoSetting)
        {
            return _registroHorasDomainService.SetDefaultSetting(tareaId, empleadoSetting.toEntity()).toDto();
        }

        public void UpdateDefaultSetting(EmpleadoSettingDto empleadoSetting)
        {
            _registroHorasDomainService.UpdateDefaultSetting(empleadoSetting.toEntity());
        }

        public void UpdateMonthInputs(IEnumerable<int> ids, IEnumerable<RegistroHorasDto> registroHoras)
        {
            _registroHorasDomainService.UpdateMonthInputs(ids, registroHoras.toEntity());

        }

    }
}
