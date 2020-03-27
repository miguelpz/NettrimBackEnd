using System;
using System.Collections.Generic;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class TareaDto
    {
        public int IdIndice { get; set; }
        public string IdRecurso { get; set; }
        public DateTime? Fecha { get; set; }
        public string Ot { get; set; }
        public string IdDocumento { get; set; }
        public string DescTarea { get; set; }
        public string Descripcion { get; set; }
        public float? Horas { get; set; }
        public string Bloqueo { get; set; }
        public string Alias { get; set; }
        public string Cidentif { get; set; }
        public bool Finalizada { get; set; }
        public int? Realizacion { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool Facturable { get; set; }
    }
}
