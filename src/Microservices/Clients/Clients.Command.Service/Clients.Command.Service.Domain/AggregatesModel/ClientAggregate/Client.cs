using System;
using System.Collections.Generic;
using System.Text;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
using Clients.Command.Service.Domain.Events;

namespace Clients.Command.Service.Domain.AggregatesModel.ClientAggregate
{
    public class Client : Entity, IAggregateRoot
    {
        #region constructors
        private Client() { }
        public Client(int id, string name, string phoneNumber,
            Address address, DateTime createdDate, DateTime updatedDate)
        {
            Id = id;
            _name = name;
            PhoneNumber = phoneNumber;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            if (address != null)
                Address = address;
        }
        public Client(string name, string phoneNumber,
           Address address, DateTime createdDate, DateTime updatedDate) : this(default(int), name, phoneNumber, address, createdDate, updatedDate)
        {

        }
        #endregion

        #region properties
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                #region add domain event
                //Add to domain events collection
                //to be raised/dispatched when comitting changes into database
                try
                {
                    ClientNameChangedDomainEvent evt = new ClientNameChangedDomainEvent(Id, _name, value);
                    AddDomainEvents(evt);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                #endregion

                _name = value;
            }
        }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Address Address { get; set; }
        #endregion

    }
}
