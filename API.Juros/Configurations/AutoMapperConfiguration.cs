using Domain.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Juros.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapperSetup();

            return services;
        }
    }
}
