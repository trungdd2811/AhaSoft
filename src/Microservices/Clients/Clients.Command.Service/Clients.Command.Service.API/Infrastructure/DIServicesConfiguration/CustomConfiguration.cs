using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clients.Command.Service.API.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients.Command.Service.API.Infrastructure.DIServicesConfiguration
{
    static class CustomConfiguration
    {
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<ClientsSetting>(configuration);         
            return services;
        }
    }
}
