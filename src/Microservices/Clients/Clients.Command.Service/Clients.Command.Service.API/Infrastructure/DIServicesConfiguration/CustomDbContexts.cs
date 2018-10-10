using Clients.Command.Service.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Clients.Command.Service.API.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Clients.Command.Service.API.Infrastructure.DIServicesConfiguration
{
    static class CustomDbContexts
    {
        private static void ApplyDBOptions(IServiceProvider servicesProvider, DbContextOptionsBuilder options)
        {
            var sqlCustomOptions = servicesProvider.GetService<IOptions<ClientsSetting>>().Value.SQLServerOptions;
  
            options.UseSqlServer(sqlCustomOptions.ConnectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ClientsContext).GetTypeInfo().Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: sqlCustomOptions.MaxRetryCount, maxRetryDelay: TimeSpan.FromSeconds(sqlCustomOptions.MaxRetryDelayInSecond), errorNumbersToAdd: null);
                });
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddEntityFrameworkSqlServer()
                  .AddDbContext<ClientsContext>(ApplyDBOptions,
                      ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                  );

            //if we apply EventStore then we can config EventStore DB Context here

            return services;
        }
    }
}
