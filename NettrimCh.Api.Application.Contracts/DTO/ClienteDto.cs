using System;
using System.Collections.Generic;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Código { get; set; }
        public string Dirección { get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }
    }
}
