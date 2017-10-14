using AutoMapper;
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
            CreateMap<Patient, PatientDTO>()
                .ForMember(dest => dest.GivenNames, options => options.MapFrom(src => src.Name.Given))
                .ForMember(dest => dest.FamilyName, options => options.MapFrom(src => src.Name.Family))
                .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Telecom.Where(t => t.System == "Email")))
                .ForMember(dest => dest.MobilePhone, options => options.MapFrom(src => src.Telecom.Where(t => t.System == "Mobile")))
                .ForMember(dest => dest.ResidentialAddress, options => options.MapFrom(src => src.Addresses.Where(a => a.Type == "Residential")))
                .ForMember(dest => dest.PostalAddress, options => options.MapFrom(src => src.Addresses.Where(a => a.Type == "Postal")));

            CreateMap<PatientDTO, HumanName>()
                .ForMember(dest => dest.Family, options => options.MapFrom(src => src.FamilyName))
                .ForMember(dest => dest.Given, options => options.MapFrom(src => src.GivenNames))
                .ForMember(dest => dest.Prefix, options => options.MapFrom(src => src.Title));

            CreateMap<PatientDTO, Patient>()
                .ForMember(dest => dest.Name, options => options.MapFrom(src => Mapper.Map<PatientDTO, HumanName>(src)));
        }
    }
}
