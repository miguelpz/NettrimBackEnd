using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class TareaDto
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string TipoTareaNombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Finalizada { get; set; }
        public string EmpleadoNombre { get; set; }
        public string NombreProyecto { get; set; }
        public int? EmpleadoId { get; set; }
        public int? ProyectoId { get; set; }
        public int TipoTareaId { get; set; }

    }
}
