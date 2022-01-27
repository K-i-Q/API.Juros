using Domain.Entities;
using Microsoft.Azure.Documents;

namespace Infra.Repositories
{
    public interface IDocumentCollectionContext<in T> where T : Entity
    {
        string CollectionName { get; }

        PartitionKey ResolvePartitionKey(string entityId);
    }
}
