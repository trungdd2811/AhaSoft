using System;
using System.Collections.Generic;
using System.Text;
using Services.Common.DomainObjects.Interfaces;

namespace Services.Common.DomainObjects
{
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent(Guid id, string version = "1.0.0")
        {
            Id = id;
            Version = version;

        }
        public Guid Id { get; set; }
        public string Version { get; set; }
    }
}
