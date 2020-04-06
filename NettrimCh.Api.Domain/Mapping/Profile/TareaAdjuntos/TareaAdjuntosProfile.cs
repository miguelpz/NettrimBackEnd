using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.TareaAdjuntos
{
    public class TareaAdjuntosProfile : AutoMapper.Profile
    {
        public TareaAdjuntosProfile()
        {
            CreateMap<Models.TareaAdjuntos, Entities.TareaAdjuntosEntity>()
                .ReverseMap();          
        }
    }
}
