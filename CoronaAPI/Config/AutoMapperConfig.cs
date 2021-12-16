using AutoMapper;
using CoronaAPI.Mapping;
using CoronaAPI.Service.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace CoronaAPI.Config
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutomapper(this IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToModelMapper());
                cfg.AddProfile(new ModelToDtoMapper());
            });

            serviceCollection.AddSingleton(config.CreateMapper());
        }
    }
}