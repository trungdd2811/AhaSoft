using System;
using System.Collections.Generic;
using System.Text;
using Services.Common.DomainObjects;
using Services.Common.Commands;
namespace Clients.Common.Dto
{
    public class ClientDto : ReadObject, ICommandDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
