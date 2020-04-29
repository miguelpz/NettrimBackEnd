using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class EmpleadoSettingDto
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public string HoraEntradaDefault { get; set; }
        public string HoraSalidaDefault { get; set; }
        public string TiempoDescansoDefault { get; set; }
    }
}
