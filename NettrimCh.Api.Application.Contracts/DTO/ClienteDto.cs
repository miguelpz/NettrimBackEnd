using System;
using System.Collections.Generic;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }
    }
}
