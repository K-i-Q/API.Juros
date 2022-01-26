using Domain.Entities;
using Infra.Exceptions;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Infra.Repositories.CosmosDB
{
    public class TaxaJurosRepository : CosmosDbRepository<TaxaJuros>, ITaxaJurosRepository
    {
        public override string CollectionName { get; } = "";
        private string Uri;
        private string PrimaryKey;
        public TaxaJurosRepository(ICosmosDbClientFactory factory, IConfiguration configuration) : base(factory)
        {
            var Collections = configuration.GetSection("CosmosDb").Get<CosmosDBOptions>().Collections;

            CollectionName = configuration.GetSection("CosmosDb").Get<CosmosDBOptions>().Collections.Where(x =>
                x.Name.IndexOf("TaxaJuros") >= 0
            ).FirstOrDefault().Name;

            Uri = configuration.GetSection("CosmosDb").Get<CosmosDBOptions>().Uri.ToString();
            PrimaryKey = configuration.GetSection("CosmosDb").Get<CosmosDBOptions>().PrimaryKey.ToString();
        }

        public async Task<TaxaJuros> Salvar(TaxaJuros example)
        {
            var entity = await AddAsync(example);
            return entity;
        }
        public async Task<bool> Atualizar(TaxaJuros example)
        {
            return await UpsertAsync(example);
        }
        public async Task<TaxaJuros> Buscar(Guid id)
        {
            try
            {
                return await GetByIdAsync(id.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
