using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public interface ITaxaJurosRepository : IRepository<TaxaJuros>
    {
        Task<TaxaJuros> Salvar(TaxaJuros example);
        Task<bool> Atualizar(TaxaJuros example);
        Task<TaxaJuros> Buscar(Guid id);
        Task<IList<TaxaJuros>> Buscar();
    }
}
