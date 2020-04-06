using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class TareaAdjuntos
    {
        public int Id { get; set; }
        public int TareaId { get; set; }
        public string Path { get; set; }
        public virtual Tarea Tarea { get; set; }
    }
}
