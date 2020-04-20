using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.ProyectoEmpleado
{
    public class ProyectoEmpleadoProfile : AutoMapper.Profile
    {
        public ProyectoEmpleadoProfile()
        {
            CreateMap<Models.ProyectoEmpleado, Entities.ProyectoEmpleadoEntity>()
                .ReverseMap();          
        }
    }
}
