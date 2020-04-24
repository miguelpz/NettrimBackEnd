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
                .ForMember(dest => dest.HoraEntradaDefault, opt => opt.MapFrom(src => src.HoraEntradaDefault.ToString()))
                .ForMember(dest => dest.HoraSalidaDefault, opt => opt.MapFrom(src => src.HoraSalidaDefault.ToString()))
                .ForMember(dest => dest.TiempoDescansoDefault, opt => opt.MapFrom(src => src.TiempoDescansoDefault.ToString()))
                .ReverseMap();          
        }
    }
}
