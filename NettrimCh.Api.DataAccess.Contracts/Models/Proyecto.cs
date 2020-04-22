using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            ProyectoEmpleado = new HashSet<ProyectoEmpleado>();
            Tarea = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Interno { get; set; }
        public bool Facturar { get; set; }
        public string Area { get; set; }
        public string Plataforma { get; set; }
        public bool Cerrado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ProyectoEmpleado> ProyectoEmpleado { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
