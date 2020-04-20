using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace  NettrimCh.Api.Application.Mapping.Profile.ProyectoEmpleado
{
    public class ProyectoEmpleadoProfile : AutoMapper.Profile
    {
        public ProyectoEmpleadoProfile()
        {

            CreateMap<Entities.ProyectoEmpleadoEntity, Dtos.ProyectoEmpleadoDto>()
                .ReverseMap();
        }
    }
}
