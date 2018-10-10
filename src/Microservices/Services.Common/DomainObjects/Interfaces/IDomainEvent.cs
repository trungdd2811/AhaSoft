using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.DomainObjects.Interfaces
{
    public interface IDomainEvent
    {
        int Id { get; set; }
        string Version { get; set; }
    }
}
