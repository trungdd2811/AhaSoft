using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Clients.Command.Service.Domain.AggregatesModel.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Services.Common.DomainObjects.Interfaces;

namespace Clients.Command.Service.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ClientRepository (ClientsContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public Client Add(Client entity)
        {
            return _context.Clients.Add(entity).Entity;
        }

        public void Delete(Client entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<Client> GetAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                await _context.Entry(client).Reference(c => c.Address).LoadAsync();
            }
            return client;
        }

        public void Update(Client entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Clients.AnyAsync(c => c.Id == id);
        }
    }
}
