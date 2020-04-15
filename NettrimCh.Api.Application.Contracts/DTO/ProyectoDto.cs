using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class ProyectoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCliente { get; set; }
        public string Descripcion { get; set; }
        public bool Interno { get; set; }
        public bool Facturar { get; set; }
        public string Area { get; set; }
        public string Plataforma { get; set; }
        public bool Cerrado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int ClienteId { get; set; }



    }
}
