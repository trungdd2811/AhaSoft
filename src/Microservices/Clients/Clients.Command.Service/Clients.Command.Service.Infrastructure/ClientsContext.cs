using Services.Common.DomainObjects.Interfaces;
using Clients.Command.Service.Domain.AggregatesModel.ClientAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Services.Common.Extensions;
using Services.Common.DomainObjects;
using System.Linq;
using System;
using Clients.Command.Service.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Design;

namespace Clients.Command.Service.Infrastructure
{
    public class ClientsContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "clients";
        public DbSet<Client> Clients { get; set; }

        private readonly IMediator _mediator;

        private ClientsContext(DbContextOptions<ClientsContext> options) : base(options) { }

        public ClientsContext(DbContextOptions<ClientsContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientEnityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            var domainEntities = this.ChangeTracker
               .Entries<Entity>()
               .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
               .Select(x=>x.Entity).ToArray();

            await MediatorExtension.DispatchDomainEventsAsync(_mediator, domainEntities);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
 }
