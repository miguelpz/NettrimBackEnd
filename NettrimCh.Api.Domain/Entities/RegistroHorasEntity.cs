using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Entities
{
    public class RegistroHorasEntity
    {
        public int Id { get; set; }
        public int TareaId { get; set; }
        public DateTime DiaRegistro { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public string TiempoDescanso { get; set; }
        public string HorasTrabajadas { get; set; }
        public bool Confirmado { get; set; }
    }
}
