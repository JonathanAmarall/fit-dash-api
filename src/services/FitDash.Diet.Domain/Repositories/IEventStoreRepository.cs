using FitDash.Core.Data;
using FitDash.Diet.Domain.Entities;

namespace FitDash.Diet.Domain.Repositories
{
    public interface IEventStoreRepository : IRepository<EventStore>
    {
        Task CreateAsync(EventStore eventStore);
    }
}
