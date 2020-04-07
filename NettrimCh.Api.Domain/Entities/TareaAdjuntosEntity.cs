using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Entities
{
    public class TareaAdjuntosEntity
    {
        public TareaAdjuntosEntity(int tareaId, string path )
        {
            TareaId = tareaId;
            Path = path;
        }
        public int Id { get; set; }
        public int TareaId { get; set; }
        public string Path { get; set; }     
    }
}
