using System;
using System.Collections.Generic;
using System.Text;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
using Clients.Command.Service.Domain.Events;

namespace Clients.Command.Service.Domain.AggregatesModel.Client
{
    public class Client : Entity, IAggregateRoot
    {
        #region constructors
        private Client() { }
        public Client(Guid id, string name, string phoneNumber,
            ICollection<Address> addresses)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Addresses = new List<Address>();
            if (addresses != null && addresses.Count > 0)
                Addresses.AddRange(addresses);
        }
        #endregion

        #region properties
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<Address> Addresses { get; private set; }
        #endregion

        #region methods
        public void SetName(string newName)
        {
            #region add domain event
            //Add to domain events collection
            //to be raised/dispatched when comitting changes into database
            ClientNameChangedDomainEvent evt = new ClientNameChangedDomainEvent(Id, Name, newName);
            AddDomainEvents(evt);
            #endregion

            Name = newName;
        }
        #endregion

    }
}
