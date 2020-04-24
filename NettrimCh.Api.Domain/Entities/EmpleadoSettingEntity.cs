using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Entities
{
    public class EmpleadoSettingEntity
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public TimeSpan HoraEntradaDefault { get; set; }
        public TimeSpan HoraSalidaDefault { get; set; }
        public TimeSpan TiempoDescansoDefault { get; set; }
    }
}
