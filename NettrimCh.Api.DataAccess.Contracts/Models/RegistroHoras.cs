﻿using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class RegistroHoras
    {
        public int Id { get; set; }
        public int TareaId { get; set; }
        public DateTime DiaRegistro { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public string TiempoDescanso { get; set; }
        public string HorasTrabajadas { get; set; }
        public bool Confirmado { get; set; }

        public virtual Tarea Tarea { get; set; }
    }
}
