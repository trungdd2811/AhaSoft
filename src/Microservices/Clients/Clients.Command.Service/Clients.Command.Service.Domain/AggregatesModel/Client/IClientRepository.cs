using Services.Common.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Command.Service.Domain.AggregatesModel.Client
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetAsync(Guid id);
    }
}
