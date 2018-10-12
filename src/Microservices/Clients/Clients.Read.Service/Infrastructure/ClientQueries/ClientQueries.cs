using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Clients.Common.Dto;
using Dapper;
using Services.Common.DomainObjects;

namespace Clients.Read.Service.Infrastructure.ClientQueries
{
    public class ClientQueries : IClientQueries
    {
        private string _connectionString = string.Empty;
        private string _selectQuery = "SELECT * FROM clients ";
        public ClientQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<ClientDto> GetClientAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await GetQueryResult(_selectQuery + $"where id={id}");
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<ClientDto>> GetClientsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await GetQueryResult(_selectQuery);
            }
        }
        private async Task<IEnumerable<ClientDto>> GetQueryResult(string sql)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<ClientDto, Address, ClientDto>(
                        _selectQuery,
                        MultipleMap,
                        splitOn: "Address_Street"
                    );
            }
        }
        private ClientDto MultipleMap(ClientDto clientDto, Address address)
        {
            clientDto.Address = address;
            return clientDto;
        }
    }
}
