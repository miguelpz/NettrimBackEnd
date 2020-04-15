using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.Empleado
{
    public class EmpleadoProfile : AutoMapper.Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Models.Empleado, Entities.EmpleadoEntity>()
                .ReverseMap();          
        }
    }
}
