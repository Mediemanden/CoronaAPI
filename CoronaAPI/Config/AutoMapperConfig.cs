using AutoMapper;
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
            });

            serviceCollection.AddSingleton(config.CreateMapper());
        }
    }
}