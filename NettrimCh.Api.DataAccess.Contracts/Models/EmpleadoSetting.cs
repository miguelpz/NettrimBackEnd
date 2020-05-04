﻿using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class EmpleadoSetting
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public string HoraEntradaDefault { get; set; }
        public string HoraSalidaDefault { get; set; }
        public string TiempoDescansoDefault { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}