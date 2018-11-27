using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clients.Read.Service.Infrastructure.ClientQueries;
using Microsoft.Extensions.Configuration;
using Services.Common.DomainObjects.Enum;
using Microsoft.AspNetCore.Authorization;

namespace Clients.Read.Service.Controllers
{
    [Authorize(Policy = nameof(Policies.NormalUsers))]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientQueries _clientQueries;
        public ClientsController(IClientQueries clientQueries)
        {
            _clientQueries = clientQueries;

        }

        // GET: api/v1/Clients/id
        /// <summary>
        /// Return a specific Client with given id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/Clients/1
        ///
        /// </remarks>
        /// <returns>return a specific Client with given id</returns>
        /// <response code="200">return a specific Client with given id</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await ((ClientQueries)_clientQueries).GetClientAsync(id);
            return Ok(client);
        }
        // GET: api/v1/Clients
        /// <summary>
        /// Return a list of Clients
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/Clients
        ///
        /// </remarks>
        /// <returns>A list of created Client</returns>
        /// <response code="200">Returns the list created item</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientQueries.GetClientsAsync();
            return Ok(clients);
        }
    }
}
