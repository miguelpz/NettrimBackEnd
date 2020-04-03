using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace  NettrimCh.Api.Application.Mapping.Profile.TipoTarea
{
    public class TipoTareaProfile : AutoMapper.Profile
    {
        public TipoTareaProfile()
        {
            CreateMap<Entities.TipoTareaEntity, Dtos.TipoTareaDto>()
                .ReverseMap();
        }
    }
}
