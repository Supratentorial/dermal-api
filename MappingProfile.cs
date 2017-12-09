﻿using AutoMapper;
using dermal.api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap()
                .ForPath(s => s.Telecom, opt => opt.MapFrom(src => src.Email))
                .ForPath(s => s.Telecom, opt => opt.MapFrom(src => src.MobilePhone));
        }
    }
}
