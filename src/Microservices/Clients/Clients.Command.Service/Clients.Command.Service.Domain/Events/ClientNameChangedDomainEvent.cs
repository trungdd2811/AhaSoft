using MediatR;
using Services.Common.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clients.Command.Service.Domain.Events
{
    /// <summary>
    /// Event used when name of client is changed (other services can be notified to update changed name
    /// </summary>
    public class ClientNameChangedDomainEvent : DomainEvent, INotification
    {
        public string OldName { get; }
        public string NewName { get; }

        public ClientNameChangedDomainEvent(Guid id, string oldName, string newName) : base(id)
        {
            OldName = oldName;
            NewName = newName;
        }
    }
}
