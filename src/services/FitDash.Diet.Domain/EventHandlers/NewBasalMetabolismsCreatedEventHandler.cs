using FitDash.Core.Messages.Events;
using FitDash.Diet.Domain.Entities;
using FitDash.Diet.Domain.Repositories;
using MediatR;
using Newtonsoft.Json;

namespace FitDash.Diet.Domain.EventHandlers
{
    public class NewBasalMetabolismsCreatedEventHandler : INotificationHandler<NewBasalMetabolismsCreatedEvent>
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public NewBasalMetabolismsCreatedEventHandler(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task Handle(NewBasalMetabolismsCreatedEvent notification, CancellationToken cancellationToken)
        {
            string jsonNewBasalMetabolismCreated = JsonConvert.SerializeObject(notification);
            var eventStore = new EventStore(nameof(NewBasalMetabolismsCreatedEvent), jsonNewBasalMetabolismCreated);

            await _eventStoreRepository.CreateAsync(eventStore);
            await _eventStoreRepository.UnitOfWork.Commit();
        }
    }
}
