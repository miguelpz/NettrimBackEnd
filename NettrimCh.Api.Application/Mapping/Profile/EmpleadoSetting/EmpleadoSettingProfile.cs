using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace  NettrimCh.Api.Application.Mapping.Profile.EmpleadoSetting
{
    public class EmpleadoSettingProfile : AutoMapper.Profile
    {
        public EmpleadoSettingProfile()
        {
            CreateMap<Dtos.EmpleadoSettingDto, Entities.EmpleadoSettingEntity>()
               .ReverseMap();
        }
    }
}
