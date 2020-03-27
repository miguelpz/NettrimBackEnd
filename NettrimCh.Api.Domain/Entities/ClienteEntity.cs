using System;
using System.Collections.Generic;

namespace NettrimCh.Api.Domain.Entities
{
    public class ClienteEntity
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Código { get; set; }
        public string Dirección { get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }
    }
}
