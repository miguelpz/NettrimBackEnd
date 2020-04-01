using System;
using System.Collections.Generic;

namespace NettrimCh.Api.Domain.Entities
{
    public class ClienteEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }
    }
}
