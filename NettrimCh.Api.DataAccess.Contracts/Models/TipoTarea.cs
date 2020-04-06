using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class TipoTarea
    {
        public TipoTarea()
        {
            Tarea = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
