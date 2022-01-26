﻿using Domain.Entities;
using Infra.Repositories.CosmosDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Infra.Repositories.CosmosDbMock
{
    public class TaxaJurosRepositoryMock : CosmosDbRepository<TaxaJuros>, ITaxaJurosRepository
    {
        public override string CollectionName { get; } = "";

        public TaxaJurosRepositoryMock(ICosmosDbClientFactory factory) : base(factory) {}

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
    }
}
