using Microsoft.Extensions.DependencyInjection;
using System;

namespace Domain.Mapper
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            service.AddSingleton(MappingsConfig.RegisterMappings().CreateMapper());
        }
    }
}
