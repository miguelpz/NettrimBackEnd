using System;
using System.Collections.Generic;

namespace NettrimCh.Api.Domain.Entities
{
    public class TareaEntity
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public float? Horas { get; set; }
        public string EmpleadoId { get; set; }
        public int ProyectoId { get; set; }
       
    }
}
