using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Common.Infrastructure.Configurations;

namespace Clients.Command.Service.API.Infrastructure.Configuration
{
    public class ClientsSetting
    {
        public SQLServerOptions SQLServerOptions { get; set; }
        public EventBusOptions EventBusOptions { get; set; }
    }
}
