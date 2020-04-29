using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            ProyectoEmpleado = new HashSet<ProyectoEmpleado>();
            Tarea = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Baja { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<ProyectoEmpleado> ProyectoEmpleado { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
