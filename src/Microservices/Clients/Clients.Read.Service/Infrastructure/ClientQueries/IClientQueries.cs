using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.Common.Dto;

namespace Clients.Read.Service.Infrastructure.ClientQueries
{
    public interface IClientQueries
    {
        Task<ClientDto> GetClientAsync(int id);
        Task<IEnumerable<ClientDto>> GetClientsAsync();
    }
}
