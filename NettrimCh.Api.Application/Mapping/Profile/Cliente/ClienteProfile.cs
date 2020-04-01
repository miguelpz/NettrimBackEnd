﻿using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace  NettrimCh.Api.Application.Mapping.Profile.Cliente
{
    public class ClienteProfile : AutoMapper.Profile
    {
        public ClienteProfile()
        {
            CreateMap<Entities.ClienteEntity, Dtos.ClienteDto>()
                .ForMember(
                    dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.Nombre)
                )
                .ForMember(
                    dest => dest.Direccion,
                    opt => opt.MapFrom(src => src.Direccion)
                )
                .ForMember(
                    dest => dest.Responsable,
                    opt => opt.MapFrom(src => src.Responsable)
                )
                .ForMember(
                    dest => dest.Telefono,
                    opt => opt.MapFrom(src => src.Telefono)
                );                           
        }
    }
}
