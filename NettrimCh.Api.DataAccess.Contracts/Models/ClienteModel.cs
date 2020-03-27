using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class ClienteModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Código { get; set; }
        public string Dirección { get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }
    }
}
