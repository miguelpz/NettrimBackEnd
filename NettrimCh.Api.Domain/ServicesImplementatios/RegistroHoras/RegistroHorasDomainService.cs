using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoSettingRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.RegistroHorasRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.EmpleadoSetting;
using NettrimCh.Api.Domain.Mapping.Extension.RegistroHoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NettrimCh.Api.Domain.ServicesImplementatios.RegistroHoras
{
    public class RegistroHorasDomainService: IRegistroHorasDomainService
    {

        private readonly IRegistroHorasRepository _registroHorasRepository;
        private readonly IEmpleadoSettingRepository _empleadoSettingRepository;
        private readonly ITareaRepository _tareaRepository;

        public RegistroHorasDomainService(
            IRegistroHorasRepository registroHorasRepository,
            IEmpleadoSettingRepository empleadoSettingRepository,
            ITareaRepository tareaRepository
        )
        {
            _registroHorasRepository = registroHorasRepository;
            _empleadoSettingRepository = empleadoSettingRepository;
            _tareaRepository = tareaRepository;
        }


        public IEnumerable<RegistroHorasEntity> GetMonthInputs (int tareaId, int month, int year)
        {                                               
            var previousRegisters = _registroHorasRepository.GetAll().Result.Where(o => o.TareaId == tareaId && o.DiaRegistro.Month == month && o.DiaRegistro.Year == year);

            if (previousRegisters.Count() == 0) {

                var defaultSetting = GetDefaultSettig(tareaId);
                if (defaultSetting == null)
                    throw new Exception("Debería haber default setting para este empleado");

                var firsTDayMonth = new DateTime(year, month, 1);
                var lastDayMonth = firsTDayMonth.AddMonths(1).AddDays(-1);

                var registroHorasList = new List<RegistroHorasEntity>();

                for (int x = 1; x < lastDayMonth.Day; x++)
                {
                    registroHorasList.Add(new RegistroHorasEntity()
                    {
                        TareaId = tareaId,
                        DiaRegistro = firsTDayMonth.AddDays(x - 1),
                        HoraEntrada = defaultSetting.HoraEntradaDefault,
                        HoraSalida = defaultSetting.HoraSalidaDefault,
                        TiempoDescanso = defaultSetting.TiempoDescansoDefault,
                        Confirmado = false,
                        HorasTrabajadas = (new TimeSpan(12, 30, 00) - new TimeSpan(11, 30, 00) - new TimeSpan(00, 30, 00)).ToString()
                    });                 
                }

            return registroHorasList;

        }
           
                return previousRegisters.toEntity();
            
    }

        public void UpdateMonthInputs(IEnumerable<int> ids, IEnumerable<RegistroHorasEntity> registroHoras) 
        {
            var previousRegisters = _registroHorasRepository.GetAll().Result.Where(o => o.DiaRegistro == registroHoras.FirstOrDefault().DiaRegistro).Count(); 
            
            if (previousRegisters == 0)
            {
                _registroHorasRepository.Add(registroHoras.toModel());
            }
            else
            {
                _registroHorasRepository.Update(ids, registroHoras.toModel());
            }
            
        }

        public bool IsDafaultSetting ( int tareaId)
        {         
            var result =  _empleadoSettingRepository.GetSingleOrDefault(o => o.EmpleadoId ==  GetEmpleado(tareaId).Result);          
            return result.Result != null;      
        }

        public EmpleadoSettingEntity SetDefaultSetting (int tareaId, EmpleadoSettingEntity empleadoSetting)
        {
            if (IsDafaultSetting(tareaId))
                throw new Exception("Este usuario ya tiene Setting");
            
            return _empleadoSettingRepository.Add(new EmpleadoSettingEntity()
                                                        {
                                                            EmpleadoId = GetEmpleado(tareaId).Result,
                                                            HoraEntradaDefault = empleadoSetting.HoraEntradaDefault,
                                                            HoraSalidaDefault = empleadoSetting.HoraSalidaDefault,
                                                            TiempoDescansoDefault = empleadoSetting.TiempoDescansoDefault
                                                        }.toModel()
                                                ).Result.toEntity();
        }

        private EmpleadoSettingEntity GetDefaultSettig (int tareaId)
        {          
            return _empleadoSettingRepository.GetSingleOrDefault(o => o.EmpleadoId == GetEmpleado(tareaId).Result).Result.toEntity();
        }

        public void UpdateDefaultSetting (EmpleadoSettingEntity empleadoSetting)
        {
            var result = _empleadoSettingRepository.Update(empleadoSetting.Id, empleadoSetting.toModel()).Result;
        }
        private async Task<int> GetEmpleado (int tareaId)           
        {
            var result = await _tareaRepository.GetById(tareaId);
            return result != null ? result.EmpleadoId.Value : 0;
        }
    }
}
