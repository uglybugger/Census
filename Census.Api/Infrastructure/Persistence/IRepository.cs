using System;
using System.Threading.Tasks;

namespace Census.Api.Infrastructure.Persistence
{
    public interface IRepository<TAggregateRoot>
    {
        Task Add(TAggregateRoot aggregateRoot);
        Task<TAggregateRoot> Get(Guid id);
    }
}