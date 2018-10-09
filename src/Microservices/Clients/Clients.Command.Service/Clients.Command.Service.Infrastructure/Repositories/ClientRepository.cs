using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Clients.Command.Service.Domain.AggregatesModel.Client;
using Services.Common.DomainObjects.Interfaces;

namespace Clients.Command.Service.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Client Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Client Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
