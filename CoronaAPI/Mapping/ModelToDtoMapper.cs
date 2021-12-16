using AutoMapper;
using CoronaAPI.Dto;
using CoronaAPI.Service.Models;

namespace CoronaAPI.Mapping
{
    public class ModelToDtoMapper : Profile
    {
        public ModelToDtoMapper()
        {
            CreateMap<CoronaReportModel, CoronaReportDto>();
        }
    }
}