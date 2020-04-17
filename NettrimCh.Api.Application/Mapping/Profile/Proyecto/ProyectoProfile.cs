using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Application.Mapping.Profile.Cliente
{
    public class ProyectoProfile : AutoMapper.Profile
    {
        public ProyectoProfile()
        {
            CreateMap<Entities.ProyectoEntity, Dtos.ProyectoDto>()
               .ReverseMap();
        }
    }
}
