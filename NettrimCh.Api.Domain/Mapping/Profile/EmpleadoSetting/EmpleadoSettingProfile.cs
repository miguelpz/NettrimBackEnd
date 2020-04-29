using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.EmpleadoSetting
{
    public class EmpleadoSettingProfile : AutoMapper.Profile
    {
        public EmpleadoSettingProfile()
        {
            CreateMap<Models.EmpleadoSetting, Entities.EmpleadoSettingEntity>()
                .ReverseMap();          
        }
    }
}
