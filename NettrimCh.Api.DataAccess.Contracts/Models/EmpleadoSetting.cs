using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class EmpleadoSetting
    {
        public string Id { get; set; }
        public int EmpleadoId { get; set; }
        public TimeSpan HoraEntradaDefault { get; set; }
        public TimeSpan HoraSalidaDefault { get; set; }
        public TimeSpan TiempoDescansoDefault { get; set; }
    }
}
