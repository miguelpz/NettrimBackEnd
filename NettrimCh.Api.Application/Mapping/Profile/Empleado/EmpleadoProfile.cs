using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace  NettrimCh.Api.Application.Mapping.Profile.Empleado
{
    public class EmpleadoProfile : AutoMapper.Profile
    {
        public EmpleadoProfile()
        {


            CreateMap<Dtos.EmpleadoDto, Entities.EmpleadoEntity>()
               .ReverseMap();


           
        }
    }
}
