using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Entities
{
    public class TareaAdjuntosEntity
    {
        public int Id { get; set; }
        public int TareaId { get; set; }
        public string Path { get; set; }     
    }
}
