using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class TareaDto
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int TipoTareaId { get; set; }
        public string Descripcion { get; set; }
        public float? Horas { get; set; }
        public string EmpleadoId { get; set; }
        public int ProyectoId { get; set; }

    }
}
