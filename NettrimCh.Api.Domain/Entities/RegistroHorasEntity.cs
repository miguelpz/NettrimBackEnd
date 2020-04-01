using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Entities
{
    public class RegistroHorasEntity
    {
        public DateTime Fecha { get; set; }
        public float Horas { get; set; }
        public string Comentarios { get; set; }
        public int TareaId { get; set; }
    }
}
