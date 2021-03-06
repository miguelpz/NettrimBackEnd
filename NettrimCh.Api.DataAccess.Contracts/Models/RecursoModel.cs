﻿using System;
using System.Collections.Generic;

namespace NettrimCh.Api.DataAccess.Contracts.Models
{
    public partial class RecursoModel
    {
        public string IdRecurso { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public bool Baja { get; set; }
        public string Nom { get; set; }
        public string Ape1 { get; set; }
        public string Ape2 { get; set; }
        public string Dni { get; set; }
    }
}
