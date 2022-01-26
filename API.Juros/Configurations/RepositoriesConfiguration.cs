using Infra.Repositories;
using Infra.Repositories.CosmosDB;
using Infra.Repositories.CosmosDbMock;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Juros.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositoriesConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<ITaxaJurosRepository, TaxaJurosRepository>();

            return services;
        }
    }
}