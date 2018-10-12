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
        public string OldName { get; private set; }
        public string NewName { get; private set; }

        public ClientNameChangedDomainEvent(int id, string oldName, string newName) : base(id)
        {
            OldName = oldName;
            NewName = newName;
        }
    }
}
