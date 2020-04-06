using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class Tarea
    {
        public Tarea()
        {
            TareaAdjuntos = new HashSet<TareaAdjuntos>();
        }

        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int TipoTareaId { get; set; }
        public string Descripcion { get; set; }
        public bool? Finalizada { get; set; }
        public int? EmpleadoId { get; set; }
        public int? ProyectoId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual TipoTarea TipoTarea { get; set; }
        public virtual ICollection<TareaAdjuntos> TareaAdjuntos { get; set; }
    }
}
