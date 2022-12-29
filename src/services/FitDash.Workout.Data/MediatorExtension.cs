using FitDash.Core.DomainObjects;
using FitDash.Core.Mediator;
using Microsoft.EntityFrameworkCore;

namespace FitDash.Workout.Data
{
    public static class MediatorExtension
    {
        public static async Task PublicEvents(this IMediatorHandler mediator, DbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<EntityBase>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList().ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
