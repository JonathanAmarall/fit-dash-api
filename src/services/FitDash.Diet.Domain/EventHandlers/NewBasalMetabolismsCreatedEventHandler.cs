using FitDash.Core.Messages.Events;
using MediatR;

namespace FitDash.Diet.Domain.EventHandlers
{
    public class NewBasalMetabolismsCreatedEventHandler : INotificationHandler<NewBasalMetabolismsCreatedEvent>
    {
        public async Task Handle(NewBasalMetabolismsCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
