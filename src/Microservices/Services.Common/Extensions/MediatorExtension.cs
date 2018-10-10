using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Services.Common.DomainObjects;
using System.Collections.Generic;
namespace Services.Common.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(IMediator mediator, IEnumerable<Entity> domainEntities)
        {
            var domainEvents = domainEntities
                .SelectMany(x => x.DomainEvents)
                .ToList();

            foreach(var entity in domainEntities)
               entity.ClearDomainEvents();

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
