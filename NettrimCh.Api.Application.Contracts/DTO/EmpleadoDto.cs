using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.DTO
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Codigo { get; set; }      
    }
}
