using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.TipoTarea
{
    public class TipoTareaProfile : AutoMapper.Profile
    {
        public TipoTareaProfile()
        {
            CreateMap<Models.TipoTarea, Entities.TipoTareaEntity>()
                .ReverseMap();          
        }
    }
}
