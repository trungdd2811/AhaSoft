using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.DomainObjects.Interfaces
{
    public interface IDomainEvent
    {
        Guid Id { get; set; }
        string Version { get; set; }
    }
}
