using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Entities
{
    public class EmpleadoEntity
    {        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Baja { get; set; }
        public string Rol { get; set; }
        public string Codigo { get; set; }
    }
}
