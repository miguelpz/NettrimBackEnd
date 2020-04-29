using NettrimCh.Api.DataAccess.Contracts.Repositories.RegistroHorasRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.RegistroHoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesImplementatios.RegistroHoras
{
    public class RegistroHorasDomainService: IRegistroHorasDomainService
    {

        private readonly IRegistroHorasRepository _registroHorasRepository;
        public RegistroHorasDomainService(IRegistroHorasRepository registroHorasRepository)
        {
            _registroHorasRepository = registroHorasRepository;
        }


        public IEnumerable<RegistroHorasEntity> GetMonthInputs (int tareaId, int month, int year)
        {

            //Obtener Valores por defecto del usuario o crearlos
            
            var previousRegisters = _registroHorasRepository.GetAll().Result.Where(o => o.TareaId == tareaId && o.DiaRegistro.Month == month && o.DiaRegistro.Year == year);



            if (previousRegisters.Count() == 0) { 

            var firsTDayMonth = new DateTime(year, month, 1);
            var lastDayMonth = firsTDayMonth.AddMonths(1).AddDays(-1);

            var registroHorasList = new List<RegistroHorasEntity>();

            for (int x = 1; x < lastDayMonth.Day; x++)
            {
                registroHorasList.Add(new RegistroHorasEntity()
                {
                    TareaId = tareaId,
                    DiaRegistro = firsTDayMonth.AddDays(x - 1),
                    HoraEntrada = new TimeSpan(11, 30, 00).ToString(),
                    HoraSalida = new TimeSpan(12, 30, 00).ToString(),
                    TiempoDescanso = new TimeSpan(00, 30, 00).ToString(),
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
    }
}
