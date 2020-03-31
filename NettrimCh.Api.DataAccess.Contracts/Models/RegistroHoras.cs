using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class RegistroHoras
    {
        public int TareaId { get; set; }
        public DateTime Fecha { get; set; }
        public float? Horas { get; set; }
        public string Comentario { get; set; }

        public virtual Tarea Tarea { get; set; }
    }
}
