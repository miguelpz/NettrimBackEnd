using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class ClienteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }
    }
}
