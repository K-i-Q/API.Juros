using Domain.Entities;
using Infra.Repositories.CosmosDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories.CosmosDbMock
{
    public class TaxaJurosRepositoryMockErro : CosmosDbRepository<TaxaJuros>, ITaxaJurosRepository
    {
        public override string CollectionName { get; } = "";

        public TaxaJurosRepositoryMockErro(ICosmosDbClientFactory factory) : base(factory) { }

        public async Task<TaxaJuros> Salvar(TaxaJuros efetuarCartaoFisico)
        {
            var entity = new TaxaJuros();
            return await Task.Run(() => entity);
        }

        public async Task<bool> Atualizar(TaxaJuros efetuarSaqueCartaoFisico)
        {
            return await Task.FromResult(true);
        }

        public async Task<TaxaJuros> Buscar(Guid id)
        {
            var entity = new TaxaJuros();
            return await Task.Run(() => entity);
        }

        public async Task<IList<TaxaJuros>> Buscar()
        {
            var entity = new List<TaxaJuros>();

            return await Task.Run(() => entity);
        }
    }
}
