using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace  NettrimCh.Api.Application.Mapping.Profile.Cliente
{
    public class RegistroHorasProfile : AutoMapper.Profile
    {
        public RegistroHorasProfile()
        {

            CreateMap<Entities.RegistroHorasEntity, Dtos.RegistroHorasDto>()
                .ReverseMap();
        }
    }
}
