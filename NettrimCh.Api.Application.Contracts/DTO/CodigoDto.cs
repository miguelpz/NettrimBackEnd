using System;
using System.Collections.Generic;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class CodigoDto
    {
        public string Cidentif { get; set; }
        public string Ot { get; set; }
        public string Alias { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
        public int? CodCliente { get; set; }
        public string Jp { get; set; }
        public bool Interna { get; set; }
        public string Cliente { get; set; }
        public string Proyecto { get; set; }
        public bool Facturable { get; set; }
        public bool Informe { get; set; }
        public string Area { get; set; }
        public string Plataforma { get; set; }
        public bool ProyCerrado { get; set; }
        public string TipoProyecto { get; set; }
    }
}
