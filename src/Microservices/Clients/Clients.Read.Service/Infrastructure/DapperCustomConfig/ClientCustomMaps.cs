using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.FluentMap.Mapping;
using Clients.Common.Dto;
using Services.Common.DomainObjects;

namespace Clients.Read.Service.Infrastructure.DapperCustomConfig
{
    public class AddressCustomMap : EntityMap<Address>
    {
        public AddressCustomMap()
        {
            Map(c => c.City).ToColumn("Address_City");
            Map(c => c.Country).ToColumn("Address_Country");
            Map(c => c.State).ToColumn("Address_State");
            Map(c => c.Street).ToColumn("Address_Street");
            Map(c => c.ZipCode).ToColumn("Address_ZipCode");
        }
    }
}
