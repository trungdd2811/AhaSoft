using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Clients.Command.Service.Domain.AggregatesModel.ClientAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Common.DomainObjects;

namespace Clients.Command.Service.Infrastructure.EntityConfigurations
{
    class ClientEnityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //builder.ToTable("clients");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseSqlServerIdentityColumn();
          
            builder.OwnsOne(b => b.Address);

            builder.Ignore(b => b.DomainEvents);

            //var navigation = builder.Metadata.FindNavigation(nameof(Client.Address));

            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
