using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.Infrastructure.Configurations
{
    public class EventBusOptions
    {
        public string EventBusConnection { get; set; }
        public int EventBusRetryCount { get; set; }
    }
}
