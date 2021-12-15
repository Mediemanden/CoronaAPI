using System;
using AutoMapper;
using CoronaAPI.Repository.Entities;
using CoronaAPI.Service.Models;

namespace CoronaAPI.Service.Mapping
{
    public class EntityToModelMapper : Profile
    {
        public EntityToModelMapper()
        {
            CreateMap<CoronaReportEntity, CoronaReportModel>()
                .ForMember(dest => dest.Date,
                src => src.MapFrom(x => DateTime.Parse(x.DateRep)))
                .ForMember(dest => dest.Country,
                    src => src.MapFrom(x => x.CountriesAndTerritories))
                .ForMember(dest => dest.CountryCode,
                    src => src.MapFrom(x => x.CountryTerritoryCode));
        }
    }
}