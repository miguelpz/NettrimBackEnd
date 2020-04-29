using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoSettingRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.EmpleadoSetting;
using NettrimCh.Api.Domain.ServicesContracts.EmpleadoSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesImplementatios.EmpleadoSettings
{
    public class EmpleadoSettingsDomainService: IEmpleadoSettingsDomainService
    {
        private readonly IEmpleadoSettingRepository _empleadoSettingsRepository;
        public EmpleadoSettingsDomainService(IEmpleadoSettingRepository empleadoSettingsRepository)
        {
            _empleadoSettingsRepository = empleadoSettingsRepository;
        }

        public EmpleadoSettingEntity Add(EmpleadoSettingEntity empleadoSettings)
        {
            CheckInputTimes(empleadoSettings);          
            if (_empleadoSettingsRepository.GetById(empleadoSettings.EmpleadoId).Result != null)
                throw new Exception("Este recurso ya tiene DefaultSettings");

            _empleadoSettingsRepository.Add(empleadoSettings.toModel());
            return empleadoSettings;
        }

        private void CheckInputTimes (EmpleadoSettingEntity empleadoSettings)
        {
            if (empleadoSettings.HoraEntradaDefault > empleadoSettings.HoraSalidaDefault)
                throw new Exception("La hora de salida debe ser superior a la de entrada");
        }

    }
}
