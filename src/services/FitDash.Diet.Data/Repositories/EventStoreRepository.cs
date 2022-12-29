using FitDash.Core.Data;
using FitDash.Diet.Data.Contexts;
using FitDash.Diet.Domain.Entities;
using FitDash.Diet.Domain.Repositories;

namespace FitDash.Diet.Data.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreSqlContext _context;

        public EventStoreRepository(EventStoreSqlContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(EventStore eventStore)
        {
           await _context.EventMetaData.AddAsync(eventStore);
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
