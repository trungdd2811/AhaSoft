using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.Infrastructure.Configurations
{
    public class SQLServerOptions
    {
        public string ConnectionString { get; set; }
        public int MaxRetryCount { get; set; }
        public int MaxRetryDelayInSecond { get; set; }
    }
}
